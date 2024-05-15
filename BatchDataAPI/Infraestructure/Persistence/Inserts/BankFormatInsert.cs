using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infraestructure.Persistence.Inserts
{
    public class BankFormatInsert : IEntityTypeConfiguration<BankFormat>
    {
        public void Configure(EntityTypeBuilder<BankFormat> builder)
        {
            builder.HasData(
                    new BankFormat { 
                        BankFormatId = 1, 
                        Name = "BBVA Frances", 
                        Slogan = "Creando Oportunidades", 
                        Logo = "https://i.pinimg.com/originals/5a/55/9d/5a559d02bc8996d233ba05d8fb2d56e3.png" 
                    },
                    new BankFormat
                    {
                        BankFormatId = 2,
                        Name = "Grupo Galicia",
                        Slogan = "Te merecés lo mejor, hacete Galicia",
                        Logo = "https://iconape.com/wp-content/files/ko/182549/png/182549.png"
                    },
                    new BankFormat
                    {
                        BankFormatId = 3,
                        Name = "Banco Macro",
                        Slogan = "Pensá en grande. Pensá en Macro",
                        Logo = "https://companieslogo.com/img/orig/BMA-99c2b89d.png?t=1684228585"
                    },
                    new BankFormat
                    {
                        BankFormatId = 4,
                        Name = "ICBC",
                        Slogan = "ICBC, si ;)",
                        Logo = "https://1000marcas.net/wp-content/uploads/2020/07/Logo-ICBC.png"
                    }
            );
        }
    }
}
