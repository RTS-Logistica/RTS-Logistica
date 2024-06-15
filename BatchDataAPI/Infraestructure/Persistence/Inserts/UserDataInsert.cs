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
    public class UserDataInsert : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            builder.HasData(GenerateUserData(80));
        }

        public List<UserData> GenerateUserData(int count)
        {
            List<UserData> userDataList = new List<UserData>();
            int currentBatchId = 1;

            for (int i = 1; i <= count; i++)
            {
                userDataList.Add(new UserData
                {
                    CardNumber = GenerateRandomCardNumber(),
                    Name = GenerateRandomName(),
                    Surname = GenerateRandomSurname(),
                    AddressId = i,
                    BatchCardId = currentBatchId
                });

                // Cambiar el BatchId cada 20 Inserts
                if (i % 20 == 0)
                    currentBatchId++;
            }

            return userDataList;
        }
        public string GenerateRandomName()
        {
            Random rand = new Random();
            string[] names = { "Juan", "Maria", "Carlos", "Laura", "Pedro", "Ana", "Diego", "Sofia", "Lucas", "Valentina" };
            return names[rand.Next(names.Length)];
        }
        public string GenerateRandomSurname()
        {
            Random rand = new Random();
            string[] surnames = { "Garcia", "Rodriguez", "Lopez", "Martinez", "Fernandez", "Gonzalez", "Perez", "Sanchez", "Ramirez", "Torres" };
            return surnames[rand.Next(surnames.Length)];
        }

        public long GenerateRandomCardNumber()
        {
            Random rand = new Random();
            return (long)(rand.NextDouble() * (999999999999 - 100000000000) + 100000000000);
        }
    }

    /*
    public class UserDataInsert : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            builder.HasData(
                    new UserData
                    {
                        CardNumber = 123456789101,
                        Name = "Emiliano",
                        Surname = "Camer",
                        AddressId = 1,
                        BatchCardId = 1
                    }
            );
        }
    }
    */
}
