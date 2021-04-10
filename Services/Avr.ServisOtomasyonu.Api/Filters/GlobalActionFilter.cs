using Avr.Core.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Api.Filters
{
    public class GlobalActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Thread.CurrentPrincipal = context.HttpContext.User;
            UserInformation.UserIp = GetIp(context.HttpContext);
            base.OnActionExecuting(context);
        }

        public string GetIp(HttpContext context)
        {
            string IP = "";
            try
            {
                IP = GetHeaderValueAs<string>(context,"X-Forwarded-For");
            }
            catch (Exception ex)
            {
            }
            return IP;
        }


        public T GetHeaderValueAs<T>(HttpContext context, string headerName)
        {
            StringValues values = new StringValues();

            if (context?.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
            {
                string rawValues = values.ToString();   // writes out as Csv when there are multiple.

                if (!String.IsNullOrWhiteSpace(rawValues))
                    return (T)Convert.ChangeType(values.ToString(), typeof(T));
            }
            return default(T);
        }
    }
}
