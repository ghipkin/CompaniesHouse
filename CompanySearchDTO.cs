using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace CompaniesHouse.DTOs
{
    public class CompanySearchDto
    {
        public string etag { get; set; }

        public int? start_index { get; set; }

        public int? total_results { get; set; }

        public List<CompanyDto> items { get; set; }

        public string kind { get; set; }

        public int page_number { get; set; }

        public int? items_per_page { get; set; }

    }

    public class CompanyDto
    {
        public AddressDto address { get; set; }
        public string address_snippet { get; set; }
        public string company_number { get; set; }
        public CompanyStatusEnum company_status { get; set; }
        public CompanyTypeEnum company_type { get; set; }
        public DateTime? date_of_cessation { get; set; }
        public DateTime? date_of_creation { get; set; }
        public string description { get; set; }
        public List<string> description_identifier { get; set; }
        public string external_registration_number { get; set; }
        public string kind { get; set; }
        public LinkDto links { get; set; }
        public Match matches { get; set; }
        public string snippet { get; set; }
        public string title { get; set; }
    }

    public class Match
    {
        public int[] address_snippet { get; set; }
        public int[] snippet { get; set; }
        public int[] title { get; set; }
    }
}