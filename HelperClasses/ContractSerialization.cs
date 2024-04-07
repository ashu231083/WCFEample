using Newtonsoft.Json;
using System.Text;

namespace HelperClasses
{
    public class ContractSerialization
    {
        public static string SerializeObjectStr(object value)
        {
            if (value != null)
            {
                return JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            return null;
        }

        public static byte[] SerializeObject(object value)
        {
            if (value != null)
            {
                return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }));
            }
            return null;
        }

        public static T DeserializeObject<T>(byte[] value)
        {
            if (value != null && value.Length != 0)
            {
                return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(value));
            }
            return default(T);
        }
    }
}
