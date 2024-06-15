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
    public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> entity)
        {
            entity.HasKey(u => u.AddressId);
            entity.Property(u => u.Address);
            entity.Property(u => u.City);
            entity.Property(u => u.State);
            entity.Property(u => u.ZipCode);
        }
    }
}
