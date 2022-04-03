using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProviderApi.Json
{
    public class JsonProviderResponse
    {
        public JsonProviderResponse(
            string providerId,
            string region,
            string inspectionDirectorate,
            IReadOnlyCollection<string> locationIds,
            string organisationType,
            string ownershipType,
            string type,
            string name,
            string brandId,
            string brandName,
            string registrationStatus,
            DateTime registrationDate,
            string companiesHouseNumber,
            string charityNumber,
            string website,
            string postalAddressLine1,
            string postalAddressLine2,
            string postalAddressTownCity,
            string postalAddressCounty,
            string postalCode,
            string uprn,
            decimal onspdLatitude,
            decimal onspdLongitude,
            string mainPhoneNumber,
            string constituency,
            string localAuthority,
            JsonLastInspection lastInspection
            )
        {
            ProviderId = providerId;
            Region = region;
            InspectionDirectorate = inspectionDirectorate;
            LocationIds = locationIds;
            OrganisationType = organisationType;
            OwnershipType = ownershipType;
            Type = type;
            Name = name;
            BrandId = brandId;
            BrandName = brandName;
            RegistrationStatus = registrationStatus;
            RegistrationDate = registrationDate;
            CompaniesHouseNumber = companiesHouseNumber;
            CharityNumber = charityNumber;
            Website = website;
            PostalAddressLine1 = postalAddressLine1;
            PostalAddressLine2 = postalAddressLine2;
            PostalAddressTownCity = postalAddressTownCity;
            PostalAddressCounty = postalAddressCounty;
            PostalCode = postalCode;
            Uprn = uprn;
            OnspdLatitude = onspdLatitude;
            OnspdLongitude = onspdLongitude;
            MainPhoneNumber = mainPhoneNumber;
            Constituency = constituency;
            LocalAuthority = localAuthority;
            LastInspection = lastInspection;
        }

        [JsonProperty(Required = Required.Always)]
        public string ProviderId { get; }

        [JsonProperty]
        public string Region { get; }

        [JsonProperty]
        public string InspectionDirectorate { get; }

        [JsonProperty]
        public IReadOnlyCollection<string> LocationIds { get; }

        [JsonProperty]
        public string OrganisationType { get; }

        [JsonProperty]
        public string OwnershipType { get; }

        [JsonProperty]
        public string Type { get; }

        [JsonProperty]
        public string Name { get; }

        [JsonProperty]
        public string BrandId { get; }

        [JsonProperty]
        public string BrandName { get; }

        [JsonProperty]
        public string RegistrationStatus { get; }

        [JsonProperty]
        public DateTime RegistrationDate { get; }

        [JsonProperty]
        public string CompaniesHouseNumber { get; }

        [JsonProperty]
        public string CharityNumber { get; }

        [JsonProperty]
        public string Website { get; }

        [JsonProperty]
        public string PostalAddressLine1 { get; }

        [JsonProperty]
        public string PostalAddressLine2 { get; }

        [JsonProperty]
        public string PostalAddressTownCity { get; }

        [JsonProperty]
        public string PostalAddressCounty { get; }

        [JsonProperty]
        public string PostalCode { get; }

        [JsonProperty]
        public string Uprn { get; }

        [JsonProperty]
        public decimal OnspdLatitude { get; }

        [JsonProperty]
        public decimal OnspdLongitude { get; }

        [JsonProperty]
        public string MainPhoneNumber { get; }

        [JsonProperty]
        public string Constituency { get; }

        [JsonProperty]
        public string LocalAuthority { get; }

        [JsonProperty]
        public JsonLastInspection LastInspection { get; }
    }
}
