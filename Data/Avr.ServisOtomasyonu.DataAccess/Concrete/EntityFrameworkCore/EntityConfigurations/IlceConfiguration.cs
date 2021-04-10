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
    public class IlceConfiguration : IEntityTypeConfiguration<Ilce>
    {
        public void Configure(EntityTypeBuilder<Ilce> ilceConfiguration)
        {
            ilceConfiguration.ToTable("Ilceler", ServisOtomasyonuContext.DEFAULT_SCHEMA);
            ilceConfiguration.HasKey(s => s.Id);

            ilceConfiguration
                .HasOne(s => s.Sehir)
                .WithMany()
                .IsRequired()
                .HasForeignKey("SehirId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
