using Avr.ServisOtomasyonu.DataTransferObject.Kullanici;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Web.Extensions
{
    public static class SessionUser
    {
        private static IHttpContextAccessor _session;

        public static void SetContext(IHttpContextAccessor session)
        {
            _session = session;
        }

        public static void SetLoginInfo(KullaniciModel login)
        {
            string objectString = JsonConvert.SerializeObject(login);
            _session.HttpContext.Session.SetString("Kullanici", objectString);
        }

        public static KullaniciModel LoginKullanici
        {
            get
            {
                return _session.HttpContext.Session.LoginUser();
            }
        }

        public static void CikisYap()
        {
            _session.HttpContext.Session.Clear();
        }

        public static bool IsAuthenticated
        {
            get
            {
                return LoginKullanici != null && LoginKullanici.Id > 0;
            }
        }

        public static KullaniciModel LoginUser(this ISession session)
        {
            string objectString = session.GetString("Kullanici");
            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            KullaniciModel value = JsonConvert.DeserializeObject<KullaniciModel>(objectString, settings);
            return value;
        }
    }
}
