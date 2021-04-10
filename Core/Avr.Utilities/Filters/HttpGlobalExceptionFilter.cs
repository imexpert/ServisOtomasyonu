using Avr.Core.Results;
using Avr.Core.Utilities.ActionResults;
using Avr.ServisOtomasyonu.DataTransferObject.Error;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Avr.Core.Utilities.Filters
{
    public class HttpGlobalExceptionFilter<T> : IExceptionFilter where T : Exception
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<HttpGlobalExceptionFilter<T>> _logger;

        public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter<T>> logger)
        {
            _env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            context.ExceptionHandled = true;

            AjaxResult<ErrorModel> result = new AjaxResult<ErrorModel>();
            result.isSuccess = false;

            if (_env.IsDevelopment())
            {
                result.message = context.Exception.GetBaseException().Message;
            }
            else
            {
                result.message = "İşlem sırasında hata oluştu. Lütfen tekrar deneyiniz.";
            }

            result.developerMessage = context.Exception.GetBaseException().Message;

            context.HttpContext.Response.WriteAsync(result.ToString());
        }
    }
}
