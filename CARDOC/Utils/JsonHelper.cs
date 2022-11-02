using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARDOC.Utils
{
    public static class JsonHelper
    {
        public class OrderedContractResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
            {
                return base.CreateProperties(type, memberSerialization)
                    .OrderBy(p => p.Order ?? int.MaxValue)  // Honour any explit ordering first
                    .ThenBy(p => p.PropertyName)
                    .ToList();
            }
        }

        public static string SerialiseAlphabeticaly(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new OrderedContractResolver() });
        }
    }
}
