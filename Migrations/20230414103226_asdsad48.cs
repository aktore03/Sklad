using Microsoft.EntityFrameworkCore.Migrations;

namespace Sklad.Migrations
{
    public partial class asdsad48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "Recipients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_StorageId",
                table: "Recipients",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Storage_StorageId",
                table: "Recipients",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Storage_StorageId",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_StorageId",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Recipients");
        }
    }
}
