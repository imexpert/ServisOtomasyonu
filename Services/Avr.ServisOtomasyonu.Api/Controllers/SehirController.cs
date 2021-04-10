using Avr.Core.Results;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Sehir;
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
    public class SehirController : ControllerBase
    {
        ISehirService _service;

        public SehirController(ISehirService service)
        {
            _service = service;
        }

        [Route("getirsehir")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SehirModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<AjaxResult<IEnumerable<SehirModel>>>> GetirSehirAsync()
        {
            var Sehirler = await _service.GetirSehirAsync();
            return Ok(Sehirler);
        }
    }
}
