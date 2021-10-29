using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.EntityConfig.Pressure
{
    public class PressureEntityConfiguration : IEntityTypeConfiguration<Entities.Pressure>
    {
        public void Configure(EntityTypeBuilder<Entities.Pressure> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DiastolicPressure).IsRequired(true);
            builder.Property(p => p.SystolicPressure).IsRequired(true);
            builder.Property(p => p.Pulse).IsRequired(true);
            builder.Property(p => p.MeasurementDateTime).IsRequired(true);
        }
    }
}
