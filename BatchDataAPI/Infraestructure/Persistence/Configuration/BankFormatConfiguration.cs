using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infraestructure.Persistence.Configuration
{
    public class BankFormatConfiguration : IEntityTypeConfiguration<BankFormat>
    {
        public void Configure(EntityTypeBuilder<BankFormat> entity)
        {
            entity.HasKey(b => b.BankFormatId);
            entity.Property(b => b.Name);
            entity.Property(b => b.Slogan);
            entity.Property(b => b.Logo);
        }
    }
}
