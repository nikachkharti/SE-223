using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class AuthorImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16ce02a0-0f14-4df4-b315-280af0bc1e8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88b1a76e-b2ff-416d-ba69-56326ef01598");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65d6da7a-a7f3-4540-9380-b049b5cdef31", "b85896a5-bcee-4bb6-940d-5b1dd5eb271a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "adcd04c9-4153-4b94-b399-2dbf0c5f4ca9", "05a930c2-4dd6-43d2-a03e-29d25055fb63", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65d6da7a-a7f3-4540-9380-b049b5cdef31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adcd04c9-4153-4b94-b399-2dbf0c5f4ca9");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Authors");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16ce02a0-0f14-4df4-b315-280af0bc1e8d", "62946af1-4abe-4f2b-a9a4-6601c3dd03d8", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88b1a76e-b2ff-416d-ba69-56326ef01598", "a6374c23-c6ec-43cb-ade0-01255a5b48cc", "Admin", "ADMIN" });
        }
    }
}
