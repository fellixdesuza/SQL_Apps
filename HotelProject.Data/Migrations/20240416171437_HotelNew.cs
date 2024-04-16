using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class HotelNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhisicalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    DailyPrice = table.Column<double>(type: "float", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Country", "HotelName", "PhisicalAddress", "Rating" },
                values: new object[,]
                {
                    { 1, "Budapest", "Hungary", "Transilvania", "Forest Transilvania", 7.0 },
                    { 2, "Kaspi", "Sakartvelo", "Tvaladuri", "Village Tvaladi", 10.0 },
                    { 3, "New-York", "USA", "Continental", "Manhattan", 15.0 }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "FirstName", "HotelId", "LastName" },
                values: new object[,]
                {
                    { 1, "ჯუმბერ", 1, "ტყაბლაძე" },
                    { 2, "დონალდ", 2, "ტრამპი" },
                    { 3, "სადამ", 3, "ჰუსეინი" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "DailyPrice", "HotelId", "IsFree", "RoomName" },
                values: new object[,]
                {
                    { 1, 100.0, 1, true, "101" },
                    { 2, 90.0, 1, true, "102" },
                    { 3, 150.0, 1, false, "103" },
                    { 4, 50.0, 2, true, "A1" },
                    { 5, 60.0, 2, false, "A2" },
                    { 6, 70.0, 2, true, "B1" },
                    { 7, 1000.0, 3, false, "101" },
                    { 8, 1000.0, 3, true, "201" },
                    { 9, 1000.0, 3, true, "301" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_HotelId",
                table: "Managers",
                column: "HotelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
