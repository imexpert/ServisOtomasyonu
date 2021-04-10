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
    public class MusteriAdresConfiguration : IEntityTypeConfiguration<MusteriAdres>
    {
        public void Configure(EntityTypeBuilder<MusteriAdres> musteriAdresConfiguration)
        {
            musteriAdresConfiguration.ToTable("MusteriAdresleri", ServisOtomasyonuContext.DEFAULT_SCHEMA);
            musteriAdresConfiguration.HasKey(s => s.Id);

            musteriAdresConfiguration
                .HasOne(s => s.Musteri)
                .WithMany()
                .IsRequired()
                .HasForeignKey("MusteriId")
                .OnDelete(DeleteBehavior.Restrict);

            musteriAdresConfiguration
                .HasOne(s => s.Sehir)
                .WithMany()
                .IsRequired()
                .HasForeignKey("SehirId")
                .OnDelete(DeleteBehavior.Restrict);

            musteriAdresConfiguration
                .HasOne(s => s.Ilce)
                .WithMany()
                .IsRequired()
                .HasForeignKey("IlceId")
                .OnDelete(DeleteBehavior.Restrict);

            musteriAdresConfiguration
                .HasOne(s => s.Semt)
                .WithMany()
                .IsRequired()
                .HasForeignKey("SemtId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
