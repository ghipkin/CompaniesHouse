using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CompaniesHouse.DTOs
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum CompanyStatusEnum
    {
        active,
        dissolved,
        liquidation,
        receivership,
        administration,
        [System.Runtime.Serialization.EnumMember(Value = "voluntary-arrangement")]
        voluntaryArrangement,
        [System.Runtime.Serialization.EnumMember(Value = "converted-closed")]
        convertedClosed,
        [System.Runtime.Serialization.EnumMember(Value = "insolvency-proceedings")]
        insolvencyProceedings,
        open,
        closed,
        [System.Runtime.Serialization.EnumMember(Value = "closed-on")]
        closedOn,

    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum CompanyStatusDetailEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = "transferred-from-uk")]
        transferredFromUk,
        [System.Runtime.Serialization.EnumMember(Value = "active-proposal-to-strike-off")]
        activeProposalToStrikeOff,
        [System.Runtime.Serialization.EnumMember(Value = "petition-to-restore-dissolved")]
        petitionToRestoreDissolved,
        [System.Runtime.Serialization.EnumMember(Value = "transformed-to-se")]
        transformedToSe,
        [System.Runtime.Serialization.EnumMember(Value = "converted-to-plc")]
        convertedToPlc
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum CompanyTypeEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = "private-unlimited")]
        privateUnlimited,
        ltd,
        plc,
        [System.Runtime.Serialization.EnumMember(Value = "old-public-company")]
        oldPublicCompany,

        [System.Runtime.Serialization.EnumMember(Value = "private-limited-guarant-nsc-limited-exemption")]
        privateLimitedGuarantNscLimitedExemption,
        [System.Runtime.Serialization.EnumMember(Value = "limited-partnership")]
        limitedPartnership,

        [System.Runtime.Serialization.EnumMember(Value = "private-limited-guarant-nsc")]
        privateLimitedGuarantNsc,
        [System.Runtime.Serialization.EnumMember(Value = "converted-or-closed")]
        ConvertedOrClosed,

        [System.Runtime.Serialization.EnumMember(Value = "private-unlimited-nsc")]
        PrivateUnlimitedNsc,

        [System.Runtime.Serialization.EnumMember(Value = "private-limited-shares-section-30-exemption")]
        privateLimitedSharesSection30Exemption,

        [System.Runtime.Serialization.EnumMember(Value = "protected-cell-company")]
        protectedCellCompany,
        [System.Runtime.Serialization.EnumMember(Value = "assurance-company")]
        assuranceCompany,
        [System.Runtime.Serialization.EnumMember(Value = "oversea-company")]
        overseaCompany,
        eeig,
        [System.Runtime.Serialization.EnumMember(Value = "icvc-securities")]
        icvcSecurities,
        [System.Runtime.Serialization.EnumMember(Value = "icvc-warrant")]
        icvcWarrant,
        [System.Runtime.Serialization.EnumMember(Value = "icvc-umbrella")]
        icvcUmbrella,

        [System.Runtime.Serialization.EnumMember(Value = "industrial-and-provident-society")]
        industrialAndProvidentSociety,
        [System.Runtime.Serialization.EnumMember(Value = "northern-ireland")]
        northernIreland,

        [System.Runtime.Serialization.EnumMember(Value = "northern-ireland-other")]
        northernIrelandOther,
        llp,
        [System.Runtime.Serialization.EnumMember(Value = "royal-charter")]
        royalCharter,

        [System.Runtime.Serialization.EnumMember(Value = "investment-company-with-variable-capital")]
        investmentCompanyWithVariableCapital,
        [System.Runtime.Serialization.EnumMember(Value = "unregistered-company")]
        unregisteredCompany,
        other,

        [System.Runtime.Serialization.EnumMember(Value = "european-public-limited-liability-company-se")]
        europeanPublicLimitedLiabilityCompanySe,
        [System.Runtime.Serialization.EnumMember(Value = "scottish-partnership")]
        scottishPartnership,

        [System.Runtime.Serialization.EnumMember(Value = "charitable-incorporated-organisation")]
        charitableIncorporatedOrganisation,

        [System.Runtime.Serialization.EnumMember(Value = "scottish-charitable-incorporated-organisation")]
        scottishCharitableIncorporatedOrganisation,
        [System.Runtime.Serialization.EnumMember(Value = "uk-establishment")]
        ukEstablishment,
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum SearchDescriptionEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = "incorporated-on")]
        incorporatedOn,
        [System.Runtime.Serialization.EnumMember(Value = "registered-on")]
        registeredOn,
        [System.Runtime.Serialization.EnumMember(Value = "formed-on")]
        formedOn,
        [System.Runtime.Serialization.EnumMember(Value = "dissolved-on")]
        dissolvedOn,
        [System.Runtime.Serialization.EnumMember(Value = "converted-closed-on")]
        convertedClosedOn,
        [System.Runtime.Serialization.EnumMember(Value = "closed-on")]
        closedOn,
        closed,
        [System.Runtime.Serialization.EnumMember(Value = "first-uk-establishment-opened-on")]
        firstUKEstablishmentOpenedOn,
        [System.Runtime.Serialization.EnumMember(Value = "openedOn")]
        openedOn,
        [System.Runtime.Serialization.EnumMember(Value = "voluntary-arrangement")]
        voluntaryArrangement,
        [System.Runtime.Serialization.EnumMember(Value = "insolvency-proceedings")]
        insolvencyProceedings,
        administration,
        [System.Runtime.Serialization.EnumMember(Value = "registered-externally")]
        registeredExternally
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum AccountTypeEnum
    {
        full,
        small,
        medium,
        group,
        dormant,
        interim,
        initial,
        [System.Runtime.Serialization.EnumMember(Value = "total-exemption-full")]
        totalExemptionFull,
        [System.Runtime.Serialization.EnumMember(Value = "total-exemption-small")]
        totalExemptionSmall,
        [System.Runtime.Serialization.EnumMember(Value = "partial-exemption")]
        partialExemption,
        [System.Runtime.Serialization.EnumMember(Value = "audit-exemption-subsidiary")]
        auditExemptionSubsidiary,
        filingExemptionSubsidiary,
        [System.Runtime.Serialization.EnumMember(Value = "micro-entity")]
        microEntity
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ForeignAccountTypeEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = "accounting-requirements-of-originating-country-apply")]
        accountingRequirementsOfOriginatingCountryApply,
        [System.Runtime.Serialization.EnumMember(Value = "accounting-requirements-of-originating-country-do-not-apply")]
        accountingRequirementsOfOriginatingCountryDoNotApply
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum TermsOfAccountPublicationEnum
    { 
        [System.Runtime.Serialization.EnumMember(Value = "accounting-publication-date-supplied-by-company")]
        AccountingPublicationDateSuppliedByCompany,
        [System.Runtime.Serialization.EnumMember(Value = "accounting-publication-date-does-not-need-to-be-supplied-by-company")]
        AccountingPublicationDateDoesNotNeedToBeSuppliedByCompany,
        [System.Runtime.Serialization.EnumMember(Value = "accounting-reference-date-allocated-by-companies-house")]
        AccountingReferenceDateAllocatedByCompaniesHouse
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum JurisdictionEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = "england-wales")]
        englandWales,
        wales,
        scotland,
        [System.Runtime.Serialization.EnumMember(Value = "northern-ireland")]
        northernIreland,
        [System.Runtime.Serialization.EnumMember(Value = "european-union")]
        europeanUnion,
        [System.Runtime.Serialization.EnumMember(Value = "united-kingdom")]
        unitedKingdom,
        england,
        noneu,
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum PartialDataAvailableEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = "full-data-available-from-financial-conduct-authority")]
        fullDataAvailableFromFinancialConductAuthority,
        [System.Runtime.Serialization.EnumMember(Value = "full-data-available-from-department-of-the-economy")]
        fullDataAvailableFromDepartmentOfTheEconomy,
        [System.Runtime.Serialization.EnumMember(Value = "full-data-available-from-the-company")]
        fullDataAvailableFromTheCompany
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum CountryEnum
    {
        Wales,
        England,
        Scotland,
        [System.Runtime.Serialization.EnumMember(Value = "Great Britain")]
        GreatBritain,
        [System.Runtime.Serialization.EnumMember(Value = "Not specified")]
        NotSpecified,
        [System.Runtime.Serialization.EnumMember(Value = "United Kingdom")]
        UnitedKingdom,
        [System.Runtime.Serialization.EnumMember(Value = "Northern Ireland")]
        NorthernIreland,
        Netherlands
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum CompanySubtypeEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = "community-interest-company")]
        communityInterestCompany,
        [System.Runtime.Serialization.EnumMember(Value = "private-fund-limited-partnership")]
        privateFundLimitedPartnership
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum OfficerRoleEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = "cic-manager")]
        cicManager,
        [System.Runtime.Serialization.EnumMember(Value = "corporate-director")]
        corporateDirector,
        [System.Runtime.Serialization.EnumMember(Value = "corporate-llp-designated-member")]
        corporateLlpDesignatedMember,
        [System.Runtime.Serialization.EnumMember(Value = "corporate-llp-member")]
        corporateLlpMember,
        [System.Runtime.Serialization.EnumMember(Value = "corporate-manager-of-an-eeig")]
        corporateManagerOfAnEeig,
        [System.Runtime.Serialization.EnumMember(Value = "corporate-member-of-a-management-organ")]
        corporateMemberOfAManagementOrgan,
        [System.Runtime.Serialization.EnumMember(Value = "corporate-member-of-a-supervisory-organ")]
        corporateMemberOfASupervisoryOrgan,
        [System.Runtime.Serialization.EnumMember(Value = "corporate-member-of-an-administrative-organ")]
        corporateMemberOfAnAdministrativeOrgan,
        [System.Runtime.Serialization.EnumMember(Value = "corporate-nominee-director")]
        corporateNomineeDirector,
        [System.Runtime.Serialization.EnumMember(Value = "corporate-nominee-secretary")]
        corporateNomineeSecretary,
        [System.Runtime.Serialization.EnumMember(Value = "corporate-secretary")]
        corporateSecretary,
        director,
        [System.Runtime.Serialization.EnumMember(Value = "general-partner-in-a-limited-partnership")]
        generalPartnerInALimitedPartnership,
        [System.Runtime.Serialization.EnumMember(Value = "judicial-factor")]
        judicialFactor,
        [System.Runtime.Serialization.EnumMember(Value = "limited-partner-in-a-limited-partnership")]
        limitedPartnerInALimitedPartnership,
        [System.Runtime.Serialization.EnumMember(Value = "llp-designated-member")]
        llpDesignatedMember,
        [System.Runtime.Serialization.EnumMember(Value = "llp-member")]
        llpMember,
        [System.Runtime.Serialization.EnumMember(Value = "manager-of-an-eeig")]
        managerOfAnEeig,
        [System.Runtime.Serialization.EnumMember(Value = "member-of-a-management-organ")]
        MemberOfAManagementOrgan,
        [System.Runtime.Serialization.EnumMember(Value = "member-of-a-supervisory-organ")]
        MemberOfASupervisoryOrgan,
        [System.Runtime.Serialization.EnumMember(Value = "member-of-an-administrative-organ")]
        MemberOfAnAdministrativeOrgan,
        [System.Runtime.Serialization.EnumMember(Value = "nominee-director")]
        nomineeDirector,
        [System.Runtime.Serialization.EnumMember(Value = "nominee-secretary")]
        nomineeSecretary,
        [System.Runtime.Serialization.EnumMember(Value = "person-authorised-to-accept")]
        personAuthorisedToAccept,
        [System.Runtime.Serialization.EnumMember(Value = "person-authorised-to-represent")]
        personAuthorisedToRepresent,
        [System.Runtime.Serialization.EnumMember(Value = "person-authorised-to-represent-and-accept")]
        personAuthorisedToRepresentAndAccept,
        [System.Runtime.Serialization.EnumMember(Value = "receiver-and-manager")]
        receiverAndManager,
        secretary
    }
}