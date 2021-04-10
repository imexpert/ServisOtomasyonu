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
    public class CihazModelConfiguration : IEntityTypeConfiguration<CihazModel>
    {
        public void Configure(EntityTypeBuilder<CihazModel> cihazModelConfiguration)
        {
            cihazModelConfiguration.ToTable("CihazModelleri", ServisOtomasyonuContext.DEFAULT_SCHEMA);
            cihazModelConfiguration.HasKey(s => s.Id);

            cihazModelConfiguration
                .HasOne(s => s.CihazMarka)
                .WithMany()
                .IsRequired()
                .HasForeignKey("CihazMarkaId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
