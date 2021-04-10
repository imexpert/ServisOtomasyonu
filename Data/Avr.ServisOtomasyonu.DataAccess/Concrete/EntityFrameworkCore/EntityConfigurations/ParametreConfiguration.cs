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
    public class ParametreConfiguration : IEntityTypeConfiguration<Parametre>
    {
        public void Configure(EntityTypeBuilder<Parametre> parametreConfiguration)
        {
            parametreConfiguration.ToTable("Parametreler", ServisOtomasyonuContext.DEFAULT_SCHEMA);
            parametreConfiguration.HasKey(s => s.Id);

            parametreConfiguration
                .HasOne(s => s.Firma)
                .WithMany()
                .IsRequired()
                .HasForeignKey("FirmaId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
