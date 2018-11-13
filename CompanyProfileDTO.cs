using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CompaniesHouse.DTOs
{
    public class CompanyProfileDTO
    {
        public AccountsDto accounts { get; set; }
        public AnnualReturnDto annual_return { get; set; }
        public BranchCompanyDetailsDto branch_company_details { get; set; }
        public bool can_file { get; set; }
        public string company_name { get; set; }
        public string company_number { get; set; }
        public CompanyStatusEnum company_status { get; set; }
        public CompanyStatusDetailEnum company_status_detail { get; set; }
        public AnnualReturnDto confirmation_statement { get; set; }
        public DateTime date_of_cessation { get; set; }
        public DateTime date_of_creation { get; set; }
        public string etag { get; set; }
        public string external_registration_number { get; set; }
        public ForeignCompanyDetailsDto foreign_company_details { get; set; }
        public bool has_been_liquidated { get; set; }
        public bool has_charges { get; set; }
        public bool has_insolvency_history { get; set; }
        public bool is_community_interest_company { get; set; }
        public JurisdictionEnum jurisdiction { get; set; }
        public DateTime last_full_members_list_date { get; set; }
        public LinkDto links { get; set; }
        public PartialDataAvailableEnum partial_data_available { get; set; }
        public List<PreviousCompanyNameDto> previous_company_names { get; set; }
        public AddressDto registered_office_address { get; set; }
        public bool registered_office_is_in_dispute { get; set; }
        public List<string> sic_codes { get; set; }
        public CompanySubtypeEnum subtype { get; set; }
        public CompanyTypeEnum type { get; set; }
        public bool undeliverable_registered_office_address { get; set; }
    }

    public class AccountsDto
    {
        public AccountingDateDto accounting_reference_date { get; set; }
        public LastAccountsDto last_accounts { get; set; }
        public NextAccountsDto next_accounts { get; set; }
        public DateTime next_due { get; set; }
        public DateTime next_made_up_to { get; set; }
        public bool overdue { get; set; }
    }

    public class AccountingDateDto
    {
        public int day { get; set; }
        public int month { get; set; }
    }

    public class LastAccountsDto
    {
        public DateTime made_up_to { get; set; }
        public DateTime period_end_on { get; set; }
        public DateTime period_start_on { get; set; }
        public AccountTypeEnum type { get; set; }

    }

    public class NextAccountsDto
    {
        public DateTime due_on { get; set; }
        public bool overdue { get; set; }
        public DateTime period_end_on { get; set; }
        public DateTime period_start_on { get; set; }
    }

    public class AnnualReturnDto
    {
        public DateTime last_made_up_to { get; set; }
        public DateTime next_due { get; set; }
        public DateTime next_made_up_to { get; set; }
        public bool overdue { get; set; }
    }

    public class BranchCompanyDetailsDto
    {
        public string business_activity { get; set; }
        public string parent_company_name { get; set; }
        public string parent_company_number{ get; set; }
    }

    public class ForeignCompanyDetailsDto
    {
        public AccountingRequirementDto accounting_requirements { get; set; }
        public ForeignAccountsDto Accounts { get; set; }
        public string business_activity { get; set; }
        public string company_type { get; set; }
        public string governed_by { get; set; }
        public bool is_a_credit_finance_institution { get; set; }
        public OriginatingRegistryDto originating_registry { get; set; }
        public string registration_number { get; set; }
    }
    
    public class AccountingRequirementDto
    {
        public ForeignAccountTypeEnum foreign_account_type { get; set; }
        public TermsOfAccountPublicationEnum terms_of_account_publication { get; set; }
    }

    public class ForeignAccountsDto
    {
        public AccountingDateDto account_period_from { get; set; }
        public AccountingDateDto account_period_to { get; set; }
        public MonthsDto must_file_within { get; set; }
    }

    public class MonthsDto
    {
        public string months { get; set; }
    }

    public class OriginatingRegistryDto
    {

        public string country { get; set; }
        public string name { get; set; }
    }

    public class PreviousCompanyNameDto
    {
        public DateTime ceased_on { get; set; }
        public DateTime effective_from { get; set; }
        public string name { get; set; }
    }


}