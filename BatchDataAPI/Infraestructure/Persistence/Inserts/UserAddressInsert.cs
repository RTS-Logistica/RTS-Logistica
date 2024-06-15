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
    public class UserAddressInsert : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.HasData(GenerateUserAddresses(80));
        }

        public List<UserAddress> GenerateUserAddresses(int count)
        {
            List<UserAddress> addresses = new List<UserAddress>();

            for (int i = 1; i <= count; i++)
            {
                addresses.Add(new UserAddress
                {
                    AddressId = i,
                    Address = GenerateRandomAddress(),
                    City = GenerateRandomCity(),
                    State = GenerateRandomState(),
                    ZipCode = GenerateRandomZipCode()
                });
            }

            return addresses;
        }

        public string GenerateRandomAddress()
        {
            Random rand = new Random();
            string[] streets = { "Av. Los Quilmes", "Av. Cabildo", "Las Heras", "Luis Braile", "Castro Barro",
                                "Av. Independencia", "Conesa", "Hiprito Yrigiyen", "Juan Domingo Peron", "Cochabamba", "Av. Manuel Belgrano",
                                "Av. San Martin", "Francisco Pienovi", "Av. Mitre"};
            return streets[rand.Next(streets.Length)] + " " + rand.Next(1000, 10000);
        }

        public string GenerateRandomCity()
        {
            Random rand = new Random();
            string[] cities = { "Palermo", "Florencio Varela", "Mina Clavero", "Yerba Buena", "La Boca", "Resistencia", "Bariloche", "Ushuaia", "Las Leñas", "San Lorenzo" };
            return cities[rand.Next(cities.Length)];
        }

        public string GenerateRandomState()
        {
            Random rand = new Random();
            string[] states = { "Buenos Aires", "Córdoba", "Santa Fe", "Mendoza", "Tucumán", "Entre Ríos", "Salta", "Misiones", "Chaco", "Corrientes" };
            return states[rand.Next(states.Length)];
        }

        public int GenerateRandomZipCode()
        {
            Random rand = new Random();
            return rand.Next(1000, 10000);
        }
    }
    /*
    public class UserAddressInsert : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.HasData(
                    new UserAddress
                    {
                        AddressId = 1,
                        Address = "Estados Unidos de Brasil 3527",
                        City = "Florencio Varela,",
                        State = "Buenos Aires",
                        ZipCode = 1888
                    },
            );
        }
    }
    */
}
