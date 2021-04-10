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
    public class SemtConfiguration : IEntityTypeConfiguration<Semt>
    {
        public void Configure(EntityTypeBuilder<Semt> semtConfiguration)
        {
            semtConfiguration.ToTable("Semtler", ServisOtomasyonuContext.DEFAULT_SCHEMA);
            semtConfiguration.HasKey(s => s.Id);

            semtConfiguration
                .HasOne(s => s.Ilce)
                .WithMany()
                .IsRequired()
                .HasForeignKey("IlceId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
