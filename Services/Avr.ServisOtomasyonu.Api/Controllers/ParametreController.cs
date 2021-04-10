using Avr.Core.Results;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Parametre;
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
    public class ParametreController : ControllerBase
    {
        IParametreService _service;

        public ParametreController(IParametreService service)
        {
            _service = service;
        }

        [Route("getirparametre")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ParametreModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<AjaxResult<IEnumerable<ParametreModel>>>> GetirParametreAsync(int anaGrupKod, string grupKod)
        {
            var parametreler = await _service.GetirParametreAsync(anaGrupKod, grupKod);
            return Ok(parametreler);
        }
    }
}
