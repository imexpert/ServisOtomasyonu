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
    public class FirmaConfiguration : IEntityTypeConfiguration<Firma>
    {
        public void Configure(EntityTypeBuilder<Firma> firmaConfiguration)
        {
            firmaConfiguration.ToTable("Firmalar", ServisOtomasyonuContext.DEFAULT_SCHEMA);
            firmaConfiguration.HasKey(s => s.Id);
        }
    }
}
