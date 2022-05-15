using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ECommerceMVC.Extensions
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session,string key,object value) 
        { 
            session.SetString(key,JsonConvert.SerializeObject(value)); 
        }
        public static T GetJson<T>(this ISession session, string key)
        {
            string result = session.GetString(key);
            T response = JsonConvert.DeserializeObject<T>(result);
            return response;
        }
    }
}
