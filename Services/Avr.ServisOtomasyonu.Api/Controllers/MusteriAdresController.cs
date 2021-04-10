using Avr.Core.Results;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Musteri;
using Avr.ServisOtomasyonu.DataTransferObject.MusteriAdres;
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
    public class MusteriAdresController : ControllerBase
    {
        IMusteriAdresService _service;

        public MusteriAdresController(IMusteriAdresService service)
        {
            _service = service;
        }

        [Route("musteriadreskaydet")]
        [HttpPost]
        [ProducesResponseType(typeof(MusteriAdresModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<AjaxResult<MusteriModel>>> MusteriAdresKaydetAsync([FromForm] MusteriAdresModel model)
        {
            var result = await _service.MusteriAdresKaydetAsync(model);
            return Ok(result);
        }
    }
}
