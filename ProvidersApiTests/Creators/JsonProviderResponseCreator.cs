using ProviderApi.Json;
using System;
using System.Collections.Generic;

namespace ProvidersApiTests.Creators
{
    public static class JsonProviderResponseCreator
    {
        public static JsonProviderResponse Minimum() => With();

        public static JsonProviderResponse With(
            string providerId = "1-001",
            string region = "",
            string inspectionDirectorate = "",
            IReadOnlyCollection<string> locationIds = null,
            string organisationType = "",
            string ownershipType = "",
            string type = "",
            string name = "",
            string brandId = "",
            string brandName = "",
            string registrationStatus = "",
            DateTime? registrationDate = null,
            string companiesHouseNumber = "",
            string charityNumber = "",
            string website = "",
            string postalAddressLine1 = "",
            string postalAddressLine2 = "",
            string postalAddressTownCity = "",
            string postalAddressCounty = "",
            string postalCode = "",
            string uprn = "",
            decimal onspdLatitude = 0.0m,
            decimal onspdLongitude = 0.0m,
            string mainPhoneNumber = "",
            string constituency = "",
            string localAuthority = "",
            JsonLastInspection lastInspection = null) =>
            new JsonProviderResponse(
            providerId,
            region,
            inspectionDirectorate,
            locationIds,
            organisationType,
            ownershipType,
            type,
            name,
            brandId,
            brandName,
            registrationStatus,
            registrationDate.HasValue ? registrationDate.Value : new DateTime(),
            companiesHouseNumber,
            charityNumber,
            website,
            postalAddressLine1,
            postalAddressLine2,
            postalAddressTownCity,
            postalAddressCounty,
            postalCode,
            uprn,
            onspdLatitude,
            onspdLongitude,
            mainPhoneNumber,
            constituency,
            localAuthority,
            lastInspection);
    }
}
