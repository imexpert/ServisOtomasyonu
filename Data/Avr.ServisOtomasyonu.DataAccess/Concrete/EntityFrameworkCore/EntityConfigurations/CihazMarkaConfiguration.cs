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
    public class CihazMarkaConfiguration : IEntityTypeConfiguration<CihazMarka>
    {
        public void Configure(EntityTypeBuilder<CihazMarka> cihazMarkaConfiguration)
        {
            cihazMarkaConfiguration.ToTable("CihazMarkalari", ServisOtomasyonuContext.DEFAULT_SCHEMA);
            cihazMarkaConfiguration.HasKey(s => s.Id);

            cihazMarkaConfiguration
                .HasOne(s => s.CihazTip)
                .WithMany()
                .IsRequired()
                .HasForeignKey("CihazTipId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
