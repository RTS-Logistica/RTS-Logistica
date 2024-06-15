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
    public class UserDataConfiguration : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> entity)
        {
            entity.HasKey(u => u.CardNumber);
            entity.Property(u => u.CardNumber);
            entity.Property(u => u.Name);
            entity.Property(u => u.Surname);
            entity.HasOne(u => u.AddressNav)
                  .WithOne()
                  .HasForeignKey<UserData>(u => u.AddressId);
        }
    }
}
