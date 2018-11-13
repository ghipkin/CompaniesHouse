using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using CompaniesHouse.DTOs;

namespace CompaniesHouse
{
    public static class CompaniesHouseQuery
    {
        const string API_KEY = "BGT_IcJnch9ltuG9vPJIP5vwaC83NmFuiYeYBTwy";
        const string URL = "https://api.companieshouse.gov.uk/";
        const string SEARCH = "search";
        const string SEARCH_COMPANIES = "search/companies";

        [FunctionName("GetCompanyDetails")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            if (name == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                name = data?.name;
            }

            if (name == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body");
            }
            else
            {
                WebRequest webReq = GetWebRequest(SEARCH + "?q=" + name + "&items_per_page=20&start_index=0");

                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                Stream answer = response.GetResponseStream();

                CompanySearchDto searchResult = null;
                using (var sr = new StreamReader(answer))
                using (var jsonTextReader = new JsonTextReader(sr))
                {

                    var serializer = new JsonSerializer();
                    string json = sr.ReadToEnd();
                    //string json = "{'page_number': 1,'start_index': 0,'kind': 'search#all','items_per_page': 20,'total_results': 53, items: []}";
                    //string json = "{'page_number': 1,'start_index': 0,'kind': 'search#all','items_per_page': 20,'total_results': 53,'items': [{'address_snippet': 'Aspect House, Spencer Road, Lancing, West Sussex, BN99 6DA','description_identifier': ['incorporated-on'],'title': 'EQUINITI LIMITED','company_number': '06226088','description': '06226088 - Incorporated on 25 April 2007','kind': 'searchresults#company','company_status': 'active','date_of_creation': '2007-04-25','links': {'self': '/company/06226088'},'company_type': 'ltd','matches': {'snippet': [],'title': [1,8]},'address': {'region': 'West Sussex','address_line_1': 'Spencer Road','locality': 'Lancing', 'country': 'Great Britain','postal_code': 'BN99 6DA','premises': 'Aspect House'},'snippet': ''}]}";
                    var settings = new JsonSerializerSettings { Error = (se, ev) => { ev.ErrorContext.Handled = true; } };

                    searchResult = JsonConvert.DeserializeObject<CompanySearchDto>(json, settings);
                }
                if (searchResult.items == null || searchResult.items.Count == 0)
                {
                    return req.CreateResponse(HttpStatusCode.InternalServerError, "No data returned from Companies House.");
                }
                else
                {
                    //get the link of the first item
                    string companylink = searchResult.items.First().links.self;
                    CompanyProfileDTO company = GetSpecificCompanyDetails(companylink);
                    //Check that the company is not null
                    if (company == null)
                    {
                        return req.CreateResponse(HttpStatusCode.InternalServerError, "Company details could not be retrieved.");
                    }

                    List<CompanyOfficerDTO> directorList = null;
                    string officersLink = company.links.officers;
                    if(officersLink != null && officersLink.Length > 0 )
                    { 
                        directorList = GetDirectorDetails(officersLink);
                    }
                    //do no check if ththe list of directors is null or empty. If there are no directors we shall return nothing

                    var relevantInfo = new RelevantCompanyInfoDTO();
                    relevantInfo.CompanyName = company.company_name;
                    relevantInfo.PreviousNames = company.previous_company_names;
                    relevantInfo.CompanyStatus = company.company_status;
                    relevantInfo.CompanyType = company.type;
                    relevantInfo.HasBeenLiquidatedInPast = company.has_been_liquidated;
                    relevantInfo.HasInsolvencyHistory = company.has_insolvency_history;
                    relevantInfo.RegisteredAddress = company.registered_office_address;
                    relevantInfo.DirectorList = directorList;
                    return req.CreateResponse(HttpStatusCode.OK, relevantInfo);
                }
            }

            //return name == null
            //    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
            //    : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
        }

        public static CompanyProfileDTO GetSpecificCompanyDetails(string link)
        {
            WebRequest webReq = GetWebRequest(link);

            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();

            Stream answer = response.GetResponseStream();
            using (var sr = new StreamReader(answer))
            using (var jsonTextReader = new JsonTextReader(sr))
            {

                var serializer = new JsonSerializer();
                string json = sr.ReadToEnd();

                CompanyProfileDTO obj = JsonConvert.DeserializeObject<CompanyProfileDTO>(json);

                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
        }

        public static List<CompanyOfficerDTO> GetDirectorDetails(string link)
        {
            WebRequest webReq = GetWebRequest(link);

            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();

            Stream answer = response.GetResponseStream();

            CompanyOfficersDTO officersRetrieved = null;
            var ListOfDirectors = new List<CompanyOfficerDTO>();
            using (var sr = new StreamReader(answer))
            using (var jsonTextReader = new JsonTextReader(sr))
            {

                var serializer = new JsonSerializer();
                string json = sr.ReadToEnd();

                officersRetrieved = JsonConvert.DeserializeObject<CompanyOfficersDTO>(json);
            }

            List<CompanyOfficerDTO> listOfDirectors = null;
            if (officersRetrieved == null || officersRetrieved.Items.Count == 0)
            {
                return null;
            }
            else
            {
                listOfDirectors = new List<CompanyOfficerDTO>();
                foreach (CompanyOfficerDTO officer in officersRetrieved.Items)
                {
                    if(officer.officer_role == OfficerRoleEnum.corporateDirector
                        || officer.officer_role == OfficerRoleEnum.corporateNomineeDirector
                        || officer.officer_role == OfficerRoleEnum.director
                        || officer.officer_role == OfficerRoleEnum.nomineeDirector
                        || officer.officer_role == OfficerRoleEnum.generalPartnerInALimitedPartnership
                        || officer.officer_role == OfficerRoleEnum.limitedPartnerInALimitedPartnership)
                    {
                        listOfDirectors.Add(officer);
                    }
                }
            }
            return listOfDirectors;
        }

        /// <summary>
        /// Assembles a web request
        /// </summary>
        /// <param name="URLSuffix"></param>
        /// <returns></returns>
        private static WebRequest GetWebRequest(string URLSuffix)
        {
            string credentials = string.Format("{0}:{1}", API_KEY, "");
            byte[] bytes = Encoding.ASCII.GetBytes(credentials);
            string base64 = Convert.ToBase64String(bytes);
            string authorization = string.Concat("Basic ", base64);

            //Check there are no more or less "/" characters then needed
            string apiUrl;
            string urlToCall;
            if (URL.EndsWith("/"))
            {
                apiUrl = URL.Substring(0, URL.Length - 1);
            }
            else
            {
                apiUrl = URL;
            }

            if (URLSuffix.StartsWith("/"))
            {
                urlToCall = apiUrl + URLSuffix;
            }
            else
            {
                urlToCall = apiUrl + "/" + URLSuffix;
            }

            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(urlToCall);
            webReq.UseDefaultCredentials = true;
            webReq.Headers.Add("Authorization", authorization);
            webReq.Method = "GET";

            return webReq;
        }
    }


}
