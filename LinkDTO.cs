using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompaniesHouse.DTOs
{
    public class LinkDto
    {
        public string charges { get; set; }
        public string filing_history { get; set; }
        public string insolvency { get; set; }
        public string officers { get; set; }
        public string persons_with_significant_control { get; set; }
        public string persons_with_significant_control_statements { get; set; }
        public string registers { get; set; }
        public string self { get; set; }
    }
}