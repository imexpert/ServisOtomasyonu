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
    public class MusteriConfiguration : IEntityTypeConfiguration<Musteri>
    {
        public void Configure(EntityTypeBuilder<Musteri> musteriConfiguration)
        {
            musteriConfiguration.ToTable("Musteriler", ServisOtomasyonuContext.DEFAULT_SCHEMA);
            musteriConfiguration.HasKey(s => s.Id);

            musteriConfiguration
                .HasOne(s => s.Firma)
                .WithMany()
                .IsRequired()
                .HasForeignKey("FirmaId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
