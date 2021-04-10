using Avr.Core.Results;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Ilce;
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
    public class IlceController : ControllerBase
    {
        IIlceService _service;

        public IlceController(IIlceService service)
        {
            _service = service;
        }

        [Route("getirilce")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IlceModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<AjaxResult<IEnumerable<IlceModel>>>> GetirIlceAsync(int sehirId)
        {
            var Ilceler = await _service.GetirIlceAsync(sehirId);
            return Ok(Ilceler);
        }
    }
}
