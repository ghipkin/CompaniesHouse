using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompaniesHouse.DTOs
{
    public class AddressDto
    {
        public string premises { get; set; }
        public string address_line1 { get; set; }
        public string address_line2 { get; set; }
        public string care_of { get; set; }
        public string country { get; set; }
        public string locality { get; set; }
        public string po_box { get; set; }
        public string postal_code { get; set; }
        public string region { get; set; }
    }
}