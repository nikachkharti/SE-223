using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "DateOfDeath", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1792, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1902, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ილია", "ჭავჭავაძე" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "DateOfDeath", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1812, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1917, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ვაჟა", "ფშაველა" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "DateOfDeath", "FirstName", "LastName" },
                values: new object[] { 3, null, null, "შოთა", "რუსთაველი" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
