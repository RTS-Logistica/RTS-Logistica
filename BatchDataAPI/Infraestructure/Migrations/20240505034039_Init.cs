using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankFormat",
                columns: table => new
                {
                    BankFormatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slogan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankFormat", x => x.BankFormatId);
                });

            migrationBuilder.CreateTable(
                name: "BatchCard",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankFormatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchCard", x => x.BatchId);
                    table.ForeignKey(
                        name: "FK_BatchCard_BankFormat_BankFormatId",
                        column: x => x.BankFormatId,
                        principalTable: "BankFormat",
                        principalColumn: "BankFormatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    UserDataNavCardNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    CardNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    BatchCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.CardNumber);
                    table.ForeignKey(
                        name: "FK_UserData_BatchCard_BatchCardId",
                        column: x => x.BatchCardId,
                        principalTable: "BatchCard",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserData_UserAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "UserAddress",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BankFormat",
                columns: new[] { "BankFormatId", "Logo", "Name", "Slogan" },
                values: new object[,]
                {
                    { 1, "https://i.pinimg.com/originals/5a/55/9d/5a559d02bc8996d233ba05d8fb2d56e3.png", "BBVA Frances", "Creando Oportunidades" },
                    { 2, "https://iconape.com/wp-content/files/ko/182549/png/182549.png", "Grupo Galicia", "Te merecés lo mejor, hacete Galicia" },
                    { 3, "https://companieslogo.com/img/orig/BMA-99c2b89d.png?t=1684228585", "Banco Macro", "Pensá en grande. Pensá en Macro" },
                    { 4, "https://1000marcas.net/wp-content/uploads/2020/07/Logo-ICBC.png", "ICBC", "ICBC, si ;)" }
                });

            migrationBuilder.InsertData(
                table: "UserAddress",
                columns: new[] { "AddressId", "Address", "City", "State", "UserDataNavCardNumber", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Av. Mitre 3353", "Florencio Varela", "Mendoza", null, 2078 },
                    { 2, "Juan Domingo Peron 4296", "Resistencia", "Santa Fe", null, 2692 },
                    { 3, "Av. Cabildo 5825", "Mina Clavero", "Tucumán", null, 2813 },
                    { 4, "Av. Manuel Belgrano 2808", "Mina Clavero", "Salta", null, 6851 },
                    { 5, "Las Heras 6734", "Mina Clavero", "Santa Fe", null, 6886 },
                    { 6, "Castro Barro 8461", "Las Leñas", "Buenos Aires", null, 4578 },
                    { 7, "Castro Barro 7940", "Mina Clavero", "Tucumán", null, 9054 },
                    { 8, "Av. Independencia 4664", "Palermo", "Chaco", null, 8359 },
                    { 9, "Av. Manuel Belgrano 2519", "Florencio Varela", "Córdoba", null, 9211 },
                    { 10, "Hiprito Yrigiyen 2855", "Mina Clavero", "Santa Fe", null, 9295 },
                    { 11, "Castro Barro 3421", "Florencio Varela", "Entre Ríos", null, 2921 },
                    { 12, "Av. Manuel Belgrano 1773", "Resistencia", "Tucumán", null, 5954 },
                    { 13, "Hiprito Yrigiyen 6764", "Mina Clavero", "Santa Fe", null, 8350 },
                    { 14, "Francisco Pienovi 1866", "La Boca", "Mendoza", null, 3812 },
                    { 15, "Av. Mitre 7100", "Mina Clavero", "Mendoza", null, 3309 },
                    { 16, "Francisco Pienovi 4327", "La Boca", "Buenos Aires", null, 2492 },
                    { 17, "Av. Independencia 5615", "La Boca", "Buenos Aires", null, 3478 },
                    { 18, "Hiprito Yrigiyen 6879", "San Lorenzo", "Buenos Aires", null, 3936 },
                    { 19, "Cochabamba 1647", "Yerba Buena", "Córdoba", null, 6852 },
                    { 20, "Francisco Pienovi 5272", "Palermo", "Corrientes", null, 7190 },
                    { 21, "Hiprito Yrigiyen 5561", "Florencio Varela", "Córdoba", null, 6399 },
                    { 22, "Juan Domingo Peron 4486", "Bariloche", "Corrientes", null, 4083 },
                    { 23, "Castro Barro 1963", "Mina Clavero", "Mendoza", null, 8956 },
                    { 24, "Francisco Pienovi 9453", "Resistencia", "Buenos Aires", null, 1398 },
                    { 25, "Av. San Martin 6484", "La Boca", "Misiones", null, 9274 },
                    { 26, "Hiprito Yrigiyen 9569", "Las Leñas", "Misiones", null, 2163 },
                    { 27, "Av. Los Quilmes 4193", "Resistencia", "Tucumán", null, 4045 },
                    { 28, "Av. Independencia 2401", "Palermo", "Tucumán", null, 2219 },
                    { 29, "Cochabamba 7015", "San Lorenzo", "Córdoba", null, 5951 },
                    { 30, "Av. San Martin 7762", "Resistencia", "Salta", null, 7467 },
                    { 31, "Cochabamba 9773", "Las Leñas", "Tucumán", null, 7679 },
                    { 32, "Cochabamba 4169", "Mina Clavero", "Santa Fe", null, 4945 },
                    { 33, "Av. Los Quilmes 2966", "Bariloche", "Corrientes", null, 1894 },
                    { 34, "Castro Barro 5294", "Resistencia", "Tucumán", null, 2353 },
                    { 35, "Av. Cabildo 7090", "Ushuaia", "Corrientes", null, 7312 },
                    { 36, "Av. Cabildo 6041", "Mina Clavero", "Entre Ríos", null, 7618 },
                    { 37, "Las Heras 8140", "Mina Clavero", "Misiones", null, 9705 },
                    { 38, "Conesa 2102", "Florencio Varela", "Santa Fe", null, 6373 },
                    { 39, "Av. Manuel Belgrano 2297", "Palermo", "Corrientes", null, 1819 },
                    { 40, "Av. Los Quilmes 5876", "Bariloche", "Misiones", null, 9632 },
                    { 41, "Hiprito Yrigiyen 4108", "La Boca", "Entre Ríos", null, 3220 },
                    { 42, "Av. Cabildo 4432", "Palermo", "Entre Ríos", null, 8386 },
                    { 43, "Castro Barro 3710", "Ushuaia", "Corrientes", null, 9785 },
                    { 44, "Castro Barro 9962", "Palermo", "Corrientes", null, 7983 },
                    { 45, "Av. Independencia 1358", "Palermo", "Córdoba", null, 5525 },
                    { 46, "Cochabamba 8342", "Palermo", "Corrientes", null, 5719 },
                    { 47, "Cochabamba 5857", "Ushuaia", "Tucumán", null, 2588 },
                    { 48, "Conesa 4535", "Las Leñas", "Entre Ríos", null, 9531 },
                    { 49, "Cochabamba 3991", "Ushuaia", "Mendoza", null, 2801 },
                    { 50, "Las Heras 6515", "La Boca", "Santa Fe", null, 7202 },
                    { 51, "Francisco Pienovi 3236", "Las Leñas", "Corrientes", null, 2023 },
                    { 52, "Av. San Martin 5251", "Mina Clavero", "Córdoba", null, 8068 },
                    { 53, "Av. Independencia 4567", "San Lorenzo", "Corrientes", null, 7665 },
                    { 54, "Francisco Pienovi 7358", "Ushuaia", "Chaco", null, 1533 },
                    { 55, "Av. San Martin 5949", "Ushuaia", "Corrientes", null, 5373 },
                    { 56, "Av. Independencia 8879", "Mina Clavero", "Chaco", null, 8297 },
                    { 57, "Av. Cabildo 7454", "Ushuaia", "Misiones", null, 1695 },
                    { 58, "Castro Barro 9310", "Ushuaia", "Misiones", null, 9848 },
                    { 59, "Las Heras 3866", "La Boca", "Salta", null, 8611 },
                    { 60, "Castro Barro 1568", "Mina Clavero", "Salta", null, 3870 },
                    { 61, "Juan Domingo Peron 4946", "Yerba Buena", "Córdoba", null, 3673 },
                    { 62, "Conesa 2756", "Ushuaia", "Tucumán", null, 9865 },
                    { 63, "Av. Mitre 5637", "Florencio Varela", "Corrientes", null, 2976 },
                    { 64, "Castro Barro 7499", "Ushuaia", "Misiones", null, 5798 },
                    { 65, "Cochabamba 5145", "Resistencia", "Buenos Aires", null, 1945 },
                    { 66, "Av. San Martin 6688", "Mina Clavero", "Buenos Aires", null, 9428 },
                    { 67, "Juan Domingo Peron 5997", "Mina Clavero", "Chaco", null, 3252 },
                    { 68, "Av. San Martin 3777", "San Lorenzo", "Salta", null, 8691 },
                    { 69, "Av. Cabildo 4080", "La Boca", "Buenos Aires", null, 7690 },
                    { 70, "Luis Braile 4864", "Bariloche", "Córdoba", null, 2032 },
                    { 71, "Cochabamba 2043", "Las Leñas", "Entre Ríos", null, 9671 },
                    { 72, "Luis Braile 4728", "Resistencia", "Chaco", null, 6281 },
                    { 73, "Francisco Pienovi 8293", "Resistencia", "Mendoza", null, 2628 },
                    { 74, "Av. Mitre 2762", "Yerba Buena", "Santa Fe", null, 3028 },
                    { 75, "Av. San Martin 1224", "Yerba Buena", "Santa Fe", null, 9405 },
                    { 76, "Cochabamba 9369", "La Boca", "Entre Ríos", null, 4035 },
                    { 77, "Luis Braile 2516", "Las Leñas", "Corrientes", null, 2227 },
                    { 78, "Av. Cabildo 2229", "Florencio Varela", "Chaco", null, 8997 },
                    { 79, "Las Heras 9528", "San Lorenzo", "Mendoza", null, 8891 },
                    { 80, "Av. Mitre 3365", "La Boca", "Santa Fe", null, 6500 }
                });

            migrationBuilder.InsertData(
                table: "BatchCard",
                columns: new[] { "BatchId", "BankFormatId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "UserData",
                columns: new[] { "CardNumber", "AddressId", "BatchCardId", "Name", "Surname" },
                values: new object[,]
                {
                    { 104984426202L, 32, 2, "Ana", "Martinez" },
                    { 120150195521L, 50, 3, "Diego", "Gonzalez" },
                    { 126808894654L, 65, 4, "Lucas", "Perez" },
                    { 127255809457L, 43, 3, "Pedro", "Lopez" },
                    { 127551128546L, 62, 4, "Laura", "Torres" },
                    { 188503348571L, 60, 3, "Ana", "Martinez" },
                    { 191910677970L, 68, 4, "Laura", "Sanchez" },
                    { 193883332984L, 13, 1, "Pedro", "Torres" },
                    { 199124245002L, 26, 2, "Maria", "Gonzalez" },
                    { 224025074390L, 80, 4, "Sofia", "Perez" },
                    { 245230110400L, 73, 4, "Valentina", "Rodriguez" },
                    { 268092387411L, 47, 3, "Maria", "Lopez" },
                    { 279591263186L, 23, 2, "Juan", "Garcia" },
                    { 282522194456L, 25, 2, "Lucas", "Rodriguez" },
                    { 286749475866L, 29, 2, "Pedro", "Ramirez" },
                    { 301542354826L, 28, 2, "Juan", "Garcia" },
                    { 313635702648L, 20, 1, "Pedro", "Fernandez" },
                    { 348784017020L, 39, 2, "Maria", "Fernandez" },
                    { 349885525325L, 22, 2, "Juan", "Martinez" },
                    { 361971591231L, 67, 4, "Carlos", "Perez" },
                    { 363298115423L, 77, 4, "Juan", "Lopez" },
                    { 369450969051L, 70, 4, "Pedro", "Fernandez" },
                    { 389605205122L, 59, 3, "Juan", "Garcia" },
                    { 409859330226L, 12, 1, "Carlos", "Garcia" },
                    { 421050220299L, 66, 4, "Carlos", "Torres" },
                    { 442479958502L, 14, 1, "Ana", "Sanchez" },
                    { 443718292223L, 6, 1, "Sofia", "Torres" },
                    { 462737530792L, 55, 3, "Diego", "Gonzalez" },
                    { 468914735552L, 54, 3, "Ana", "Martinez" },
                    { 493871641950L, 19, 1, "Diego", "Garcia" },
                    { 502092218442L, 48, 3, "Ana", "Garcia" },
                    { 517205147808L, 2, 1, "Laura", "Sanchez" },
                    { 530030203331L, 75, 4, "Valentina", "Gonzalez" },
                    { 531576477471L, 5, 1, "Valentina", "Martinez" },
                    { 536718815238L, 35, 2, "Laura", "Garcia" },
                    { 550500446342L, 7, 1, "Ana", "Martinez" },
                    { 564322736034L, 17, 1, "Diego", "Lopez" },
                    { 576620660545L, 78, 4, "Laura", "Martinez" },
                    { 589746474757L, 63, 4, "Valentina", "Fernandez" },
                    { 611567584252L, 42, 3, "Valentina", "Fernandez" },
                    { 616570514581L, 10, 1, "Pedro", "Fernandez" },
                    { 636654232459L, 21, 2, "Maria", "Fernandez" },
                    { 651441385659L, 51, 3, "Valentina", "Sanchez" },
                    { 652638819004L, 15, 1, "Valentina", "Gonzalez" },
                    { 657923585670L, 61, 4, "Pedro", "Fernandez" },
                    { 666309240975L, 76, 4, "Laura", "Perez" },
                    { 668859626535L, 49, 3, "Maria", "Gonzalez" },
                    { 675001445824L, 9, 1, "Maria", "Sanchez" },
                    { 679722828409L, 52, 3, "Carlos", "Perez" },
                    { 683205162115L, 27, 2, "Juan", "Martinez" },
                    { 688675823237L, 30, 2, "Ana", "Gonzalez" },
                    { 705636930462L, 31, 2, "Maria", "Garcia" },
                    { 711774331733L, 72, 4, "Pedro", "Lopez" },
                    { 717983071532L, 79, 4, "Ana", "Rodriguez" },
                    { 731014440275L, 16, 1, "Carlos", "Gonzalez" },
                    { 771854759318L, 37, 2, "Carlos", "Rodriguez" },
                    { 778621705212L, 45, 3, "Maria", "Martinez" },
                    { 786349225145L, 64, 4, "Juan", "Torres" },
                    { 788968014035L, 56, 3, "Valentina", "Lopez" },
                    { 797921530473L, 57, 3, "Ana", "Martinez" },
                    { 809064001913L, 33, 2, "Lucas", "Rodriguez" },
                    { 818388420172L, 69, 4, "Carlos", "Gonzalez" },
                    { 819811724854L, 18, 1, "Lucas", "Lopez" },
                    { 832437564222L, 58, 3, "Pedro", "Gonzalez" },
                    { 839389623709L, 34, 2, "Juan", "Fernandez" },
                    { 858235777653L, 3, 1, "Pedro", "Fernandez" },
                    { 875049562843L, 46, 3, "Juan", "Perez" },
                    { 876869204860L, 36, 2, "Valentina", "Torres" },
                    { 877390474439L, 44, 3, "Maria", "Ramirez" },
                    { 877566093970L, 8, 1, "Lucas", "Fernandez" },
                    { 887120098749L, 53, 3, "Diego", "Ramirez" },
                    { 905339950220L, 41, 3, "Sofia", "Rodriguez" },
                    { 912319400672L, 38, 2, "Pedro", "Garcia" },
                    { 924106156753L, 71, 4, "Sofia", "Lopez" },
                    { 928086033866L, 40, 2, "Carlos", "Torres" },
                    { 931569297702L, 24, 2, "Sofia", "Garcia" },
                    { 934895327027L, 1, 1, "Carlos", "Martinez" },
                    { 943177695623L, 11, 1, "Ana", "Torres" },
                    { 949148462237L, 4, 1, "Lucas", "Garcia" },
                    { 997180090013L, 74, 4, "Maria", "Garcia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatchCard_BankFormatId",
                table: "BatchCard",
                column: "BankFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserDataNavCardNumber",
                table: "UserAddress",
                column: "UserDataNavCardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_UserData_AddressId",
                table: "UserData",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserData_BatchCardId",
                table: "UserData",
                column: "BatchCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_UserData_UserDataNavCardNumber",
                table: "UserAddress",
                column: "UserDataNavCardNumber",
                principalTable: "UserData",
                principalColumn: "CardNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchCard_BankFormat_BankFormatId",
                table: "BatchCard");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_UserData_UserDataNavCardNumber",
                table: "UserAddress");

            migrationBuilder.DropTable(
                name: "BankFormat");

            migrationBuilder.DropTable(
                name: "UserData");

            migrationBuilder.DropTable(
                name: "BatchCard");

            migrationBuilder.DropTable(
                name: "UserAddress");
        }
    }
}
