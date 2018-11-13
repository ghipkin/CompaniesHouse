using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesHouse.DTOs
{
    public class CompanyOfficersDTO
    {
        public int active_count { get; set; }
        public string etag { get; set; }
        public List<CompanyOfficerDTO> Items { get; set; }
        public int? items_per_page { get; set; }
        public string kind { get; set; }
        public LinkDto links { get; set; }
        public int resigned_count { get; set; }
        public int start_index { get; set; }
        public int total_results { get; set; }
    }

    public class CompanyOfficerDTO 
    {
        public AddressDto Address { get; set; }
        public DateTime AppointedOn { get; set; }
        public string country_of_residence{ get; set; }
        public DateDto date_of_birth { get; set; }
        public List<NameDTO> former_names{ get; set; }
        public IdentificationDTO Identification{ get; set; }
        public OfficerDTO links{ get; set; }
        public string name { get; set; }
        public string nationality { get; set; }
        public string occupation { get; set; }
        public OfficerRoleEnum officer_role { get; set; }
        public DateTime resigned_on { get; set; }
    }

    public class DateDto
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year{ get; set; }
    }

    public class NameDTO
    {

        public string forenames { get; set; }
        public string surname { get; set; }
    }

    public class IdentificationDTO
    {
        public string identifiaction_type { get; set; }
        public string legal_authority { get; set; }
        public string legal_form { get; set; }
        public string place_registered { get; set; }
        public string registration_number { get; set; }
    }

    public class OfficerDTO
    {

        public string Appointments{ get; set; }
    }
}
