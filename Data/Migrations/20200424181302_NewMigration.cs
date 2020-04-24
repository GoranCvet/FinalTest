using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TaxPayers_TaxPayerId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "TaxPayerId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TaxPayers_TaxPayerId",
                table: "Products",
                column: "TaxPayerId",
                principalTable: "TaxPayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TaxPayers_TaxPayerId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "TaxPayerId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TaxPayers_TaxPayerId",
                table: "Products",
                column: "TaxPayerId",
                principalTable: "TaxPayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
