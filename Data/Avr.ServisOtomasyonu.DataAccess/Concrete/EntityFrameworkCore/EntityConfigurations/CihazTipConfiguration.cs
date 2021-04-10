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
    public class CihazTipConfiguration : IEntityTypeConfiguration<CihazTip>
    {
        public void Configure(EntityTypeBuilder<CihazTip> cihazTipConfiguration)
        {
            cihazTipConfiguration.ToTable("CihazTipleri", ServisOtomasyonuContext.DEFAULT_SCHEMA);
            cihazTipConfiguration.HasKey(s => s.Id);
        }
    }
}
