using Autofac;
using Autofac.Extras.DynamicProxy;
using Avr.Core.Security.Jwt;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.Business.Concrete.Managers;
using Avr.ServisOtomasyonu.DataAccess.Abstract;
using Avr.ServisOtomasyonu.DataAccess.Concrete.EntityFrameworkCore;
using Castle.DynamicProxy;

namespace Avr.ServisOtomasyonu.Api.Infrastructure.Modules
{
    public class ApplicationModule : Autofac.Module
    {
        public ApplicationModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            #region Token
            builder.RegisterType<JwtHelper>()
                            .As<ITokenHelper>()
                            .InstancePerLifetimeScope();
            #endregion

            #region Kullanıcı
            builder.RegisterType<KullaniciManager>()
                            .As<IKullaniciService>()
                            .InstancePerLifetimeScope();

            builder.RegisterType<KullaniciDal>()
                .As<IKullaniciDal>()
                .InstancePerLifetimeScope();
            #endregion

            #region Parametre
            builder.RegisterType<ParametreManager>()
                            .As<IParametreService>()
                            .InstancePerLifetimeScope();

            builder.RegisterType<ParametreDal>()
                .As<IParametreDal>()
                .InstancePerLifetimeScope();
            #endregion

            #region Şehir
            builder.RegisterType<SehirManager>()
                            .As<ISehirService>()
                            .InstancePerLifetimeScope();

            builder.RegisterType<SehirDal>()
                .As<ISehirDal>()
                .InstancePerLifetimeScope();
            #endregion

            #region İlçe
            builder.RegisterType<IlceManager>()
                            .As<IIlceService>()
                            .InstancePerLifetimeScope();

            builder.RegisterType<IlceDal>()
                .As<IIlceDal>()
                .InstancePerLifetimeScope();
            #endregion

            #region Semt
            builder.RegisterType<SemtManager>()
                            .As<ISemtService>()
                            .InstancePerLifetimeScope();

            builder.RegisterType<SemtDal>()
                .As<ISemtDal>()
                .InstancePerLifetimeScope();
            #endregion

            #region Müşteri
            builder.RegisterType<MusteriManager>()
                            .As<IMusteriService>()
                            .InstancePerLifetimeScope();

            builder.RegisterType<MusteriDal>()
                .As<IMusteriDal>()
                .InstancePerLifetimeScope();
            #endregion

            #region Arama
            builder.RegisterType<AramaManager>()
                            .As<IAramaService>()
                            .InstancePerLifetimeScope();
            #endregion

            #region Müşteri Adres
            builder.RegisterType<MusteriAdresManager>()
                            .As<IMusteriAdresService>()
                            .InstancePerLifetimeScope();

            builder.RegisterType<MusteriAdresDal>()
                .As<IMusteriAdresDal>()
                .InstancePerLifetimeScope();
            #endregion

            #region Interceptors
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            #endregion
        }
    }
}
