using Avr.Core.Results;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Arama;
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
    public class AramaController : ControllerBase
    {
        IAramaService _service;

        public AramaController(IAramaService service)
        {
            _service = service;
        }

        [Route("ara")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<AramaModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<AjaxResult<IEnumerable<AramaModel>>>> AraAsync(AramaFilterModel filter)
        {
            var sonuclar = await _service.AraAsync(filter);
            return Ok(sonuclar);
        }
    }
}
