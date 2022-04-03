using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProviderApi.Json
{
    public class JsonLastInspection
    {
        public JsonLastInspection(DateTime date)
        {
            Date = date;
        }

        [JsonProperty]
        public DateTime Date { get; }
    }
}
