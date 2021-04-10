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
    public class ServisConfiguration : IEntityTypeConfiguration<Servis>
    {
        public void Configure(EntityTypeBuilder<Servis> servisConfiguration)
        {
            servisConfiguration.ToTable("Servisler", ServisOtomasyonuContext.DEFAULT_SCHEMA);
            servisConfiguration.HasKey(s => s.Id);

            servisConfiguration
                .HasOne(s => s.Cihaz)
                .WithMany()
                .IsRequired()
                .HasForeignKey("CihazId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
