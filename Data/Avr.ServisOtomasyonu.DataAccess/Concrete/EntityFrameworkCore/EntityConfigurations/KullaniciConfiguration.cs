using Avr.ServisOtomasyonu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.DataAccess.Concrete.EntityFrameworkCore.EntityConfigurations
{
    public class KullaniciConfiguration : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> kullaniciConfiguration)
        {
            kullaniciConfiguration.ToTable("Kullanicilar", ServisOtomasyonuContext.DEFAULT_SCHEMA);
            kullaniciConfiguration.HasKey(s => s.Id);

            kullaniciConfiguration
                .HasOne(s => s.Firma)
                .WithMany()
                .IsRequired()
                .HasForeignKey("FirmaId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
