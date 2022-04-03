# ProvidersApi

## Overview

Create an API that caches results to a SqlServer database for the below endpoints whose specs can be found [here](https://anypoint.mulesoft.com/exchange/portals/care-quality-commission-5/4d36bd23-127d-4acf-8903-ba292ea615d4/cqc-syndication-1/minor/1.0/console/method/%231223/):
- `https://api.cqc.org.uk/v1/providers` 
- `https://api.cqc.org.uk/public/v1/providers/{providerId}`
  - query parameters of for this data: `inspectionDirectorate` & `region`

Results that are more than a month old should be removed form the cache
- assumed definition of "month" to be: the same day of the next month i.e. a month after `05/02/2022` is `05/03/2022`

<details>
  <summary>The structure of a Provider entity: any extra can be thrown away</summary>
  
```json
{
  "providerId": "1-345678912",
  "locationIds": [
    "1-987654321",
    "1-876543212" ],
  "organisationType": "Provider",
  "ownershipType": "NHS Body",
  "type": "NHS Healthcare Organisation",
  "name": "Sample Teaching Hospitals NHS Foundation Trust",
  "brandId": "ABC123",
  "brandName": "Sample Hill",
  "registrationStatus": "Registered",
  "registrationDate": "2012-04-01",
  "companiesHouseNumber": "12345678",
  "charityNumber": "123456",
  "website": "www.samplehospitals.nhs.uk",
  "postalAddressLine1": "Trust Headquarters, Example Hospital",
  “postalAddressLine2": "Example Road",
  “postalAddressTownCity": "Blackpool",
  "postalAddressCounty": "Lancashire",
  "region": "North West",
  "postalCode": "FY3 8RN",
  "uprn": "123456789012",
  "onspdLatitude": 53.123456,
  "onspdLongitude": -2.123456,
  "mainPhoneNumber": "01253301234",
  "inspectionDirectorate": "Hospitals",
  "constituency": "Blackpool North and Cleveleys",
  "localAuthority": "Blackpool",
  "lastInspection": {
    "date": "2021-11-01"
    }
}
```
</details>

### Thoughts

Considered how to handle the simple case of how to handle the `/v1/providers/{providerId}`. Believed I had examined the providers endpoint and it was a simple exension.
- use `Entitiy Framework Core` and a database-first approach to auto-magically spin up the c# classes
- can DI a DbContext and then just need to creat an interface that can manage the DB interactions
- then create a service to handle a daily cleanup of the records
- or, I can not invent thewheel and use `Microsoft.Extensions.Caching.Distributed`to manage the caching ^_^
  - lovely solution, using this library and storing: key: providerId, valueCached: response from the external provider as a string
  - as the Json wanted is a subset this works beautifully.  

Upon extending an adding the `/v1/providers` in which returns only providerIds but (as checked) full provider objects were to be returned from both endpoints, not a collection of Ids. But twas on this second parse that I spotted it used pagination *facepalm* Of course it does. Actually, barring first call performance if we use a different key & value in the database cache like:
- key: queryString i.e. `page=1&perPage=100&region=North`
- value: response to supply from this providersApi

We have to map from the providerId to a fully fleshed provider entity. So why not do that all in memory, and store in the cache the collection (including paging information) fully fleshed. It has the added bonus that this will be idempotent for all query calls for the full response to be given was stored. You can ask the cache *first* if it has a record cached as opposed to having to always call the external api to get all the providerIds and then cnostructing a response.

Performance would be the arguement between the two designs. Knowing more about the typical users/types of calls to be made would help. Because this was supposed to be a two hour task but I ended up having fun on my Sunday afternoon I chose to finish off the production code for personal satisfaction.

How about overflow though, from a "back of the envelope" estimate of if one was maxing out all the fields stored, and the value column (`VARBINARY(MAX)`) wont overflow, but, if we do get large, performance would take a hit.

## Connection String

The ConnectionString in the `appsettings.json` flie will need to be set. Below is an example:

```
"providerCache": "Data Source=YourServerName;Initial Catalog=YourDataBaseName;User id=YourDBUserName;Password=YourDBSecret;"
```
