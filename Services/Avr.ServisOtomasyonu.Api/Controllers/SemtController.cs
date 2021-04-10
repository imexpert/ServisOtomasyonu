using Avr.Core.Results;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Semt;
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
    public class SemtController : ControllerBase
    {
        ISemtService _service;

        public SemtController(ISemtService service)
        {
            _service = service;
        }

        [Route("getirSemt")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SemtModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<AjaxResult<IEnumerable<SemtModel>>>> GetirSemtAsync(int ilceId)
        {
            var Semtler = await _service.GetirSemtAsync(ilceId);
            return Ok(Semtler);
        }
    }
}
