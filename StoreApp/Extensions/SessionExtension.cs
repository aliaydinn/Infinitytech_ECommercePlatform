using Newtonsoft.Json;
using System.Text.Json;

namespace StoreApp.Extensions
{
    public static class SessionExtension       
    {
        //public static void SetJson( this ISession session,string key,object value)
        //{
        //    session.SetString(key,JsonSerializer.Serialize(value));
        //}

        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }


    }
}
