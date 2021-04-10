using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Avr.Core.Utilities.Extensions
{
    public static class UserInformation
    {
        public static long KullaniciId 
        {
            get
            {
                if (Thread.CurrentPrincipal == null)
                {
                    throw new Exception("Token alınamadı.");
                }

                ClaimsPrincipal cp = (ClaimsPrincipal)Thread.CurrentPrincipal;
                return Convert.ToInt64(cp.FindFirst("KullaniciId").Value);
            }
            private set { } 
        }

        public static long FirmaId
        {
            get
            {
                if (Thread.CurrentPrincipal == null)
                {
                    throw new Exception("Token alınamadı.");
                }

                ClaimsPrincipal cp = (ClaimsPrincipal)Thread.CurrentPrincipal;
                return Convert.ToInt64(cp.FindFirst("FirmaId").Value);
            }
            private set { }
        }

        [ThreadStatic]
        public static string UserIp;
    }
}
