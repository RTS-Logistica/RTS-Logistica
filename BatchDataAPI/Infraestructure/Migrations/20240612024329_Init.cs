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
                name: "UserAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.AddressId);
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
                columns: new[] { "AddressId", "Address", "City", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Hiprito Yrigiyen 9792", "Mina Clavero", "Tucumán", 3621 },
                    { 2, "Av. San Martin 3492", "Resistencia", "Santa Fe", 1454 },
                    { 3, "Av. Cabildo 1982", "Mina Clavero", "Santa Fe", 1913 },
                    { 4, "Av. Los Quilmes 4148", "Yerba Buena", "Buenos Aires", 5249 },
                    { 5, "Las Heras 9764", "Mina Clavero", "Chaco", 5678 },
                    { 6, "Av. Cabildo 4712", "San Lorenzo", "Chaco", 5826 },
                    { 7, "Av. Mitre 1164", "Ushuaia", "Santa Fe", 7972 },
                    { 8, "Luis Braile 4615", "Palermo", "Santa Fe", 1316 },
                    { 9, "Av. Los Quilmes 1828", "Las Leñas", "Córdoba", 2333 },
                    { 10, "Av. Cabildo 5998", "San Lorenzo", "Córdoba", 9042 },
                    { 11, "Francisco Pienovi 8371", "San Lorenzo", "Entre Ríos", 2543 },
                    { 12, "Conesa 6276", "Ushuaia", "Mendoza", 7630 },
                    { 13, "Conesa 4954", "Florencio Varela", "Santa Fe", 3464 },
                    { 14, "Av. Independencia 4432", "Mina Clavero", "Salta", 4232 },
                    { 15, "Cochabamba 6108", "Mina Clavero", "Chaco", 3408 },
                    { 16, "Conesa 3946", "San Lorenzo", "Misiones", 3587 },
                    { 17, "Av. Los Quilmes 5159", "San Lorenzo", "Salta", 2254 },
                    { 18, "Francisco Pienovi 6202", "Florencio Varela", "Santa Fe", 2317 },
                    { 19, "Av. Cabildo 7092", "Palermo", "Córdoba", 7558 },
                    { 20, "Las Heras 2895", "Yerba Buena", "Misiones", 1657 },
                    { 21, "Las Heras 3569", "Bariloche", "Buenos Aires", 7118 },
                    { 22, "Av. Cabildo 4125", "Yerba Buena", "Santa Fe", 8761 },
                    { 23, "Av. Los Quilmes 8701", "Ushuaia", "Misiones", 4728 },
                    { 24, "Cochabamba 7544", "Florencio Varela", "Buenos Aires", 4940 },
                    { 25, "Francisco Pienovi 9300", "Ushuaia", "Entre Ríos", 4175 },
                    { 26, "Av. Manuel Belgrano 1460", "Palermo", "Santa Fe", 7571 },
                    { 27, "Av. Mitre 2857", "Mina Clavero", "Chaco", 2401 },
                    { 28, "Av. Cabildo 2589", "Mina Clavero", "Misiones", 1476 },
                    { 29, "Hiprito Yrigiyen 6873", "Ushuaia", "Salta", 6114 },
                    { 30, "Av. Los Quilmes 5050", "Bariloche", "Córdoba", 7475 },
                    { 31, "Av. Mitre 9882", "Las Leñas", "Santa Fe", 3036 },
                    { 32, "Juan Domingo Peron 7833", "Palermo", "Tucumán", 9105 },
                    { 33, "Francisco Pienovi 8174", "Yerba Buena", "Santa Fe", 3798 },
                    { 34, "Av. Los Quilmes 9566", "Yerba Buena", "Tucumán", 1199 },
                    { 35, "Cochabamba 1767", "Resistencia", "Chaco", 8974 },
                    { 36, "Cochabamba 3008", "Resistencia", "Corrientes", 1971 },
                    { 37, "Av. Independencia 2372", "Las Leñas", "Salta", 7406 },
                    { 38, "Castro Barro 5104", "Ushuaia", "Chaco", 7518 },
                    { 39, "Av. Los Quilmes 2790", "Mina Clavero", "Entre Ríos", 6025 },
                    { 40, "Castro Barro 6371", "Ushuaia", "Misiones", 5952 },
                    { 41, "Conesa 1326", "San Lorenzo", "Tucumán", 9447 },
                    { 42, "Av. Manuel Belgrano 2244", "Resistencia", "Salta", 2581 },
                    { 43, "Las Heras 8730", "La Boca", "Misiones", 5795 },
                    { 44, "Hiprito Yrigiyen 4235", "La Boca", "Tucumán", 6034 },
                    { 45, "Cochabamba 3710", "Bariloche", "Misiones", 6918 },
                    { 46, "Av. Los Quilmes 2769", "Bariloche", "Entre Ríos", 9920 },
                    { 47, "Castro Barro 2704", "Florencio Varela", "Tucumán", 5036 },
                    { 48, "Conesa 1694", "Bariloche", "Misiones", 2280 },
                    { 49, "Francisco Pienovi 4348", "Bariloche", "Misiones", 9266 },
                    { 50, "Francisco Pienovi 8577", "La Boca", "Misiones", 5666 },
                    { 51, "Av. Mitre 1798", "San Lorenzo", "Salta", 6308 },
                    { 52, "Cochabamba 3792", "La Boca", "Salta", 4065 },
                    { 53, "Av. San Martin 8493", "Mina Clavero", "Tucumán", 4943 },
                    { 54, "Av. San Martin 7056", "Palermo", "Misiones", 7039 },
                    { 55, "Luis Braile 4615", "Las Leñas", "Santa Fe", 4915 },
                    { 56, "Av. Los Quilmes 3540", "Resistencia", "Misiones", 5184 },
                    { 57, "Av. Mitre 8212", "Mina Clavero", "Buenos Aires", 7510 },
                    { 58, "Hiprito Yrigiyen 7202", "Florencio Varela", "Misiones", 2097 },
                    { 59, "Francisco Pienovi 2473", "Resistencia", "Mendoza", 3747 },
                    { 60, "Juan Domingo Peron 1386", "Bariloche", "Tucumán", 1167 },
                    { 61, "Las Heras 1749", "Las Leñas", "Corrientes", 6440 },
                    { 62, "Hiprito Yrigiyen 5528", "Resistencia", "Buenos Aires", 4248 },
                    { 63, "Av. Los Quilmes 9857", "Florencio Varela", "Mendoza", 2666 },
                    { 64, "Av. Cabildo 2743", "Palermo", "Salta", 4720 },
                    { 65, "Francisco Pienovi 7734", "La Boca", "Tucumán", 6292 },
                    { 66, "Av. Los Quilmes 2561", "San Lorenzo", "Misiones", 5242 },
                    { 67, "Francisco Pienovi 4562", "Resistencia", "Córdoba", 2041 },
                    { 68, "Av. Independencia 3413", "La Boca", "Córdoba", 1169 },
                    { 69, "Luis Braile 5141", "Florencio Varela", "Corrientes", 1251 },
                    { 70, "Castro Barro 6101", "Resistencia", "Mendoza", 2446 },
                    { 71, "Av. Manuel Belgrano 6253", "Palermo", "Buenos Aires", 7234 },
                    { 72, "Av. Mitre 5819", "Florencio Varela", "Tucumán", 4779 },
                    { 73, "Av. Manuel Belgrano 4675", "La Boca", "Santa Fe", 7717 },
                    { 74, "Av. Manuel Belgrano 5829", "Bariloche", "Mendoza", 2540 },
                    { 75, "Castro Barro 7500", "Bariloche", "Mendoza", 6242 },
                    { 76, "Luis Braile 1375", "Palermo", "Santa Fe", 1878 },
                    { 77, "Av. Independencia 8670", "Florencio Varela", "Santa Fe", 9408 },
                    { 78, "Av. San Martin 7941", "Resistencia", "Misiones", 5977 },
                    { 79, "Av. Cabildo 7941", "Las Leñas", "Buenos Aires", 2090 },
                    { 80, "Castro Barro 1752", "Palermo", "Tucumán", 1871 }
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
                    { 164477165611L, 48, 3, "Pedro", "Perez" },
                    { 181540426063L, 31, 2, "Lucas", "Sanchez" },
                    { 236638206986L, 79, 4, "Valentina", "Fernandez" },
                    { 254601348489L, 16, 1, "Juan", "Martinez" },
                    { 258332630605L, 21, 2, "Valentina", "Lopez" },
                    { 265421080063L, 38, 2, "Valentina", "Garcia" },
                    { 267764218034L, 5, 1, "Lucas", "Garcia" },
                    { 269091695974L, 39, 2, "Diego", "Gonzalez" },
                    { 290866974482L, 36, 2, "Sofia", "Rodriguez" },
                    { 300698625624L, 9, 1, "Carlos", "Gonzalez" },
                    { 304723332949L, 43, 3, "Pedro", "Torres" },
                    { 313787886966L, 4, 1, "Pedro", "Rodriguez" },
                    { 331863666435L, 61, 4, "Ana", "Fernandez" },
                    { 336432169213L, 63, 4, "Ana", "Garcia" },
                    { 353399676642L, 40, 2, "Lucas", "Rodriguez" },
                    { 358110496342L, 25, 2, "Ana", "Sanchez" },
                    { 359901760741L, 65, 4, "Laura", "Lopez" },
                    { 381713195306L, 18, 1, "Juan", "Ramirez" },
                    { 403833585950L, 32, 2, "Pedro", "Torres" },
                    { 452661454269L, 56, 3, "Juan", "Sanchez" },
                    { 462527309262L, 53, 3, "Ana", "Lopez" },
                    { 478492516795L, 69, 4, "Valentina", "Ramirez" },
                    { 486016214979L, 44, 3, "Carlos", "Fernandez" },
                    { 496099949384L, 51, 3, "Carlos", "Garcia" },
                    { 501539115986L, 57, 3, "Laura", "Fernandez" },
                    { 503632234846L, 55, 3, "Juan", "Fernandez" },
                    { 531709084590L, 24, 2, "Laura", "Lopez" },
                    { 532321850775L, 68, 4, "Valentina", "Garcia" },
                    { 549843294378L, 8, 1, "Valentina", "Fernandez" },
                    { 553270770066L, 1, 1, "Maria", "Rodriguez" },
                    { 556146222593L, 23, 2, "Maria", "Ramirez" },
                    { 569884446492L, 41, 3, "Lucas", "Rodriguez" },
                    { 574612039444L, 15, 1, "Pedro", "Sanchez" },
                    { 579819709632L, 20, 1, "Sofia", "Torres" },
                    { 587538929495L, 22, 2, "Ana", "Gonzalez" },
                    { 593547787312L, 29, 2, "Laura", "Perez" },
                    { 600237656111L, 27, 2, "Valentina", "Fernandez" },
                    { 602497354574L, 78, 4, "Carlos", "Torres" },
                    { 613310963768L, 52, 3, "Lucas", "Sanchez" },
                    { 625093933805L, 37, 2, "Lucas", "Sanchez" },
                    { 631755283106L, 60, 3, "Maria", "Garcia" },
                    { 636405956430L, 75, 4, "Diego", "Rodriguez" },
                    { 651370857834L, 70, 4, "Valentina", "Perez" },
                    { 654065725592L, 77, 4, "Carlos", "Fernandez" },
                    { 673729540409L, 45, 3, "Pedro", "Lopez" },
                    { 704341435406L, 35, 2, "Laura", "Fernandez" },
                    { 709582611379L, 17, 1, "Lucas", "Fernandez" },
                    { 720382564329L, 46, 3, "Ana", "Martinez" },
                    { 726381681325L, 19, 1, "Pedro", "Torres" },
                    { 741830617271L, 67, 4, "Ana", "Rodriguez" },
                    { 744355618646L, 14, 1, "Diego", "Perez" },
                    { 747266045588L, 13, 1, "Juan", "Perez" },
                    { 761643838488L, 71, 4, "Diego", "Sanchez" },
                    { 770019674918L, 12, 1, "Maria", "Torres" },
                    { 783364247669L, 80, 4, "Diego", "Garcia" },
                    { 784701951832L, 58, 3, "Ana", "Torres" },
                    { 787764019214L, 47, 3, "Lucas", "Martinez" },
                    { 795174916041L, 42, 3, "Juan", "Fernandez" },
                    { 800108336745L, 73, 4, "Carlos", "Ramirez" },
                    { 815262160695L, 34, 2, "Laura", "Rodriguez" },
                    { 830389386546L, 62, 4, "Pedro", "Ramirez" },
                    { 834090807724L, 11, 1, "Valentina", "Ramirez" },
                    { 857593446327L, 2, 1, "Laura", "Martinez" },
                    { 858845656005L, 64, 4, "Ana", "Martinez" },
                    { 865986979590L, 59, 3, "Laura", "Perez" },
                    { 899043343285L, 3, 1, "Juan", "Perez" },
                    { 906124234496L, 7, 1, "Juan", "Fernandez" },
                    { 910689936764L, 28, 2, "Ana", "Sanchez" },
                    { 912623582129L, 72, 4, "Juan", "Perez" },
                    { 918132239958L, 6, 1, "Juan", "Garcia" },
                    { 926291640170L, 76, 4, "Juan", "Gonzalez" },
                    { 928251365712L, 26, 2, "Lucas", "Fernandez" },
                    { 946968025249L, 66, 4, "Lucas", "Ramirez" },
                    { 947504727869L, 50, 3, "Juan", "Fernandez" },
                    { 953523375376L, 49, 3, "Lucas", "Rodriguez" },
                    { 956856793169L, 10, 1, "Maria", "Rodriguez" },
                    { 958706200512L, 30, 2, "Laura", "Torres" },
                    { 974325970789L, 33, 2, "Carlos", "Garcia" },
                    { 977944695362L, 74, 4, "Ana", "Torres" },
                    { 995847179644L, 54, 3, "Valentina", "Martinez" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatchCard_BankFormatId",
                table: "BatchCard",
                column: "BankFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserData_AddressId",
                table: "UserData",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserData_BatchCardId",
                table: "UserData",
                column: "BatchCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserData");

            migrationBuilder.DropTable(
                name: "BatchCard");

            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.DropTable(
                name: "BankFormat");
        }
    }
}
