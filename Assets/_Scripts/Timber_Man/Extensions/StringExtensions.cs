using Newtonsoft.Json;

namespace _Scripts.Timber_Man.Extensions
{
    public static class StringExtensions
    {
        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}