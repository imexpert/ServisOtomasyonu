using Avr.Core.Results;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Kullanici;
using Avr.ServisOtomasyonu.DataTransferObject.Login;
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
    public class LoginController : ControllerBase
    {
        IKullaniciService _kullaniciService;

        public LoginController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [Route("giris")]
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(KullaniciModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AjaxResult<KullaniciModel>>> GirisAsync([FromForm]LoginModel model)
        {
            var kullanici = await _kullaniciService.GirisAsync(model);
            return Ok(kullanici);
        }
    }
}
