using Microsoft.AspNetCore.Http;

namespace ECommerceMVC.Extensions
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session,string key,object value) 
        { 
            session.SetJson(key,value); 
        }
    }
}
