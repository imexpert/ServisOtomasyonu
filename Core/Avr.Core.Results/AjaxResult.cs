using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avr.Core.Results
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class AjaxResult<T>
    {
        public AjaxResult()
        {
            isSuccess = true;
        }
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public object developerMessage { get; set; }
        public int statusCode { get; set; }
        public T data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);

        }
    }
}
