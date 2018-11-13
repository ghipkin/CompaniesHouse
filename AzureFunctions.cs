using System;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using CompaniesHouseAzureFunctions.DTOs;

namespace CompaniesHouseAzureFunctions
{
    public class AzureFunctions
    {
        const string API_KEY = "BGT_IcJnch9ltuG9vPJIP5vwaC83NmFuiYeYBTwy";
        const string URL = "https://api.companieshouse.gov.uk/";
        const string SEARCH = "search";
        const string SEARCH_COMPANIES = "search/companies";

        public object GetCompanyDetailsFromName(string searchTerm)
        {

            WebRequest webReq = GetWebRequest(SEARCH + "?q=" + searchTerm + "&items_per_page=20&start_index=0");

            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();

            Stream answer = response.GetResponseStream();
            using (var sr = new StreamReader(answer))
            using (var jsonTextReader = new JsonTextReader(sr))
            {

                var serializer = new JsonSerializer();
                //dynamic obj= (CompaniesDto)serializer.Deserialize(jsonTextReader);
                string json = sr.ReadToEnd();
                   // "{'page_number': 1,'start_index': 0,'kind': 'search#all','items_per_page': 20,'total_results': 53, items: []}";
                  //  "{'page_number': 1,'start_index': 0,'kind': 'search#all','items_per_page': 20,'total_results': 53,'items': [{'address_snippet': 'Aspect House, Spencer Road, Lancing, West Sussex, BN99 6DA','description_identifier': ['incorporated-on'],'title': 'EQUINITI LIMITED','company_number': '06226088','description': '06226088 - Incorporated on 25 April 2007','kind': 'searchresults#company','company_status': 'active','date_of_creation': '2007-04-25','links': {'self': '/company/06226088'},'company_type': 'ltd','matches': {'snippet': [],'title': [1,8]},'address': {'region': 'West Sussex','address_line_1': 'Spencer Road','locality': 'Lancing','postal_code': 'BN99 6DA','premises': 'Aspect House'},'snippet': ''}]}";
                CompanySearchDto obj =  JsonConvert.DeserializeObject<CompanySearchDto>(json);

                if (obj.items == null || obj.items.Count == 0)
                {
                    return null;
                }
                else
                {
                    return GetCompanyDetails(obj.items[0].links.self);
                }
            }
        }

        public CompanyProfileDTO GetCompanyDetails(string link)
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


        public WebRequest GetWebRequest(string URLSuffix)
        {
            string credentials = String.Format("{0}:{1}", API_KEY, "");
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(credentials);
            string base64 = Convert.ToBase64String(bytes);
            string authorization = String.Concat("Basic ", base64);

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