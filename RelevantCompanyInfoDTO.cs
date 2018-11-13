using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesHouse.DTOs
{
    public class RelevantCompanyInfoDTO
    {
        public string CompanyName { get; set; }
        public List<PreviousCompanyNameDto> PreviousNames {get;set;}
        public AddressDto RegisteredAddress { get; set; }
        public CompanyTypeEnum CompanyType { get; set; }
        public CompanyStatusEnum CompanyStatus { get; set; }
        public bool HasInsolvencyHistory { get; set; }
        public bool HasBeenLiquidatedInPast { get; set; }
        public List<CompanyOfficerDTO> DirectorList { get; set; }
    }
}
