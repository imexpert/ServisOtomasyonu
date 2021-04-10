using Avr.Core.Results;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Musteri;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MusteriController : ControllerBase
    {
        IMusteriService _service;

        public MusteriController(IMusteriService service)
        {
            _service = service;
        }

        [Route("musterikaydet")]
        [HttpPost]
        [ProducesResponseType(typeof(MusteriModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<AjaxResult<MusteriModel>>> MusteriKaydetAsync([FromForm] MusteriModel model)
        {
            var result = await _service.MusteriKaydetAsync(model);
            return Ok(result);
        }
    }
}
