using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avr.Core.Results;
using Avr.Core.Security.Hashing;
using Avr.Core.Security.Jwt;
using Avr.Core.Utilities.Extensions;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataAccess.Abstract;
using Avr.ServisOtomasyonu.DataAccess.Concrete.EntityFrameworkCore;
using Avr.ServisOtomasyonu.DataTransferObject.Kullanici;
using Avr.ServisOtomasyonu.DataTransferObject.Login;
using Avr.ServisOtomasyonu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Avr.ServisOtomasyonu.Business.Concrete.Managers
{
    public class KullaniciManager : IKullaniciService
    {
        IKullaniciDal _kullaniciDal;
        private ITokenHelper _tokenHelper;
        ServisOtomasyonuContext _context;
        public KullaniciManager(IKullaniciDal kullaniciDal, ITokenHelper tokenHelper,ServisOtomasyonuContext context)
        {
            _kullaniciDal = kullaniciDal;
            _tokenHelper = tokenHelper;
            _context = context;
        }

        public async Task<AjaxResult<KullaniciModel>> GirisAsync(LoginModel girisModel)
        {
            AjaxResult<KullaniciModel> result = new AjaxResult<KullaniciModel>();
            KullaniciModel model = new KullaniciModel();

            var firma = await _context.Firmalar.FirstOrDefaultAsync(s => s.FirmaKodu == girisModel.FirmaKodu.Trim().ToUpper());

            if (firma == null || firma.Id <= 0)
            {
                result.isSuccess = false;
                result.message = "Firma kodu bulunamadı.";
                return result;
            }


            Kullanici kullanici = await _context.Kullanicilar
                .AsQueryable()
                .Include(s => s.Firma)
                .FirstOrDefaultAsync(s => s.KullaniciAd == girisModel.KullaniciAdi && s.Sifre == girisModel.Sifre.ToMD5());

            if (kullanici != null)
            {
                AccessToken token = CreateAccessToken(kullanici);
                model.Token = token.Token;
                kullanici.MapTo(model);
                result.data = model;
            }
            else
            {
                result.isSuccess = false;
                result.message = "Hatalı kullanıcı adı veya şifre";
            }

            return result;
        }
        private AccessToken CreateAccessToken(Kullanici kullanici)
        {
            var accessToken = _tokenHelper.CreateToken(kullanici);
            return accessToken;
        }
    }
}
