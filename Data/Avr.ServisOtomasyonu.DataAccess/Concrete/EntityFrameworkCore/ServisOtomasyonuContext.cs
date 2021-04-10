using Avr.Core.Auditing;
using Avr.Core.Utilities.Extensions;
using Avr.ServisOtomasyonu.DataAccess.Concrete.EntityFrameworkCore.EntityConfigurations;
using Avr.ServisOtomasyonu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.DataAccess.Concrete.EntityFrameworkCore
{
    public class ServisOtomasyonuContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public ServisOtomasyonuContext()
        {

        }
        public ServisOtomasyonuContext(DbContextOptions<ServisOtomasyonuContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configurations
            modelBuilder.ApplyConfiguration(new KullaniciConfiguration());
            modelBuilder.ApplyConfiguration(new FirmaConfiguration());
            modelBuilder.ApplyConfiguration(new CihazConfiguration());
            modelBuilder.ApplyConfiguration(new CihazMarkaConfiguration());
            modelBuilder.ApplyConfiguration(new CihazModelConfiguration());
            modelBuilder.ApplyConfiguration(new CihazTipConfiguration());
            modelBuilder.ApplyConfiguration(new IlceConfiguration());
            modelBuilder.ApplyConfiguration(new MusteriAdresConfiguration());
            modelBuilder.ApplyConfiguration(new MusteriConfiguration());
            modelBuilder.ApplyConfiguration(new SehirConfiguration());
            modelBuilder.ApplyConfiguration(new SemtConfiguration());
            modelBuilder.ApplyConfiguration(new ServisConfiguration());
            modelBuilder.ApplyConfiguration(new ParametreConfiguration());
            #endregion
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Entity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((Entity)entityEntry.Entity).KayitTarihi = DateTime.Now;
                ((Entity)entityEntry.Entity).KayitKullaniciId = UserInformation.KullaniciId;
                ((Entity)entityEntry.Entity).Ip = UserInformation.UserIp;
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #region DbSet
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Cihaz> Cihazlar { get; set; }
        public DbSet<CihazMarka> CihazMarkalar { get; set; }
        public DbSet<CihazModel> CihazModeller { get; set; }
        public DbSet<CihazTip> CihazTipler { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<MusteriAdres> MusteriAdresler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Semt> Semtler { get; set; }
        public DbSet<Servis> Servisler { get; set; }
        public DbSet<Parametre> Parametreler { get; set; }
        #endregion
    }
}
