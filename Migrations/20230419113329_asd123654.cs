using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sklad.Migrations
{
    public partial class asd123654 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteData",
                table: "Recipients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteData",
                table: "Recipients");
        }
    }
}
