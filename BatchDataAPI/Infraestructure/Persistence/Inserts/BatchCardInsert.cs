using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Inserts
{
    public class BatchCardInsert : IEntityTypeConfiguration<BatchCard>
    {
        public void Configure(EntityTypeBuilder<BatchCard> builder)
        {
            builder.HasData(
                    new BatchCard
                    {
                        BatchId = 1,
                        BankFormatId = 1,
                    },
                    new BatchCard
                    {
                        BatchId = 2,
                        BankFormatId = 2,
                    },
                    new BatchCard
                    {
                        BatchId = 3,
                        BankFormatId = 3,
                    },
                    new BatchCard
                    {
                        BatchId = 4,
                        BankFormatId = 4,
                    }
            );
        }
    }
}
