using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestApi.Migrations
{
    /// <inheritdoc />
    public partial class InsertComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Author", "CreatedAt", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Ricardo C.", new DateTime(2023, 7, 17, 20, 5, 33, 766, DateTimeKind.Local).AddTicks(3400), "Descripción UwU", "Holi" },
                    { 2, "Ricardo C.", new DateTime(2023, 7, 17, 20, 5, 33, 766, DateTimeKind.Local).AddTicks(3418), "Bar", "Foo" },
                    { 3, "Ricardo C.", new DateTime(2023, 7, 17, 20, 5, 33, 766, DateTimeKind.Local).AddTicks(3419), "l wea fme wn", "Causa pe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
