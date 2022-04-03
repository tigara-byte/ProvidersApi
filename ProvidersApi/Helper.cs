using System;

namespace ProviderApi
{
    public static class Helper
    {
        public static string CreateProvidersQuery(
            int page, int perPage, string region = "", string inspectionDirectorate = "")
        {
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            queryString.Add(nameof(page), page.ToString());
            queryString.Add(nameof(perPage), perPage.ToString());

            if (!string.IsNullOrEmpty(region))
            {
                queryString.Add(nameof(region), region);
            }

            if (!string.IsNullOrEmpty(inspectionDirectorate))
            {
                queryString.Add(nameof(inspectionDirectorate), inspectionDirectorate);
            }

            return queryString.ToString();
        }

        public static TimeSpan CalculateAMonthFromNow()
        {
            var currentDate = DateTime.Now;
            return currentDate.AddMonths(1) - currentDate;
        }
    }
}
