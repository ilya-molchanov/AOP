using Newtonsoft.Json;

namespace LoggerRewriting
{
    public static class JsonSerializer
    {
        public static string Serialize(object value)
        {
            try
            {
                return JsonConvert.SerializeObject(value, Formatting.Indented);
            }
            catch (JsonSerializationException)
            {
                return $"Not serializable";
            }
        }
    }
}
