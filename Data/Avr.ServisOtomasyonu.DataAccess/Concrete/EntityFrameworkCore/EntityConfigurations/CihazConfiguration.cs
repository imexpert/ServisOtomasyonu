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
    public class CihazConfiguration : IEntityTypeConfiguration<Cihaz>
    {
        public void Configure(EntityTypeBuilder<Cihaz> cihazConfiguration)
        {
            cihazConfiguration.ToTable("Cihazlar", ServisOtomasyonuContext.DEFAULT_SCHEMA);
            cihazConfiguration.HasKey(s => s.Id);

            cihazConfiguration
                .HasOne(s => s.MusteriAdres)
                .WithMany()
                .IsRequired()
                .HasForeignKey("MusteriAdresId")
                .OnDelete(DeleteBehavior.Restrict);

            cihazConfiguration
                .HasOne(s => s.CihazMarka)
                .WithMany()
                .IsRequired()
                .HasForeignKey("CihazMarkaId")
                .OnDelete(DeleteBehavior.Restrict);

            cihazConfiguration
                .HasOne(s => s.CihazTip)
                .WithMany()
                .IsRequired()
                .HasForeignKey("CihazTipId")
                .OnDelete(DeleteBehavior.Restrict);

            cihazConfiguration
                .HasOne(s => s.CihazModel)
                .WithMany()
                .IsRequired()
                .HasForeignKey("CihazModelId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
