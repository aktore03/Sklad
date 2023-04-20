using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sklad.Migrations
{
    public partial class asdas44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteData",
                table: "Storage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Storage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteData",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Storage");
        }
    }
}
