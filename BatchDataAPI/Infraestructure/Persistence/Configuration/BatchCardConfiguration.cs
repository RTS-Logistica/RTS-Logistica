using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Configuration
{
    public class BatchCardConfiguration : IEntityTypeConfiguration<BatchCard>
    {
        public void Configure(EntityTypeBuilder<BatchCard> entity)
        {
            entity.HasKey(b => b.BatchId);
            entity.HasOne(b => b.BankFormatNav)
                  .WithMany()
                  .HasForeignKey(b => b.BankFormatId);
            entity.HasMany(b => b.UserDataCollection)
                  .WithOne()
                  .HasForeignKey(b => b.BatchCardId);
        }
    }
}
