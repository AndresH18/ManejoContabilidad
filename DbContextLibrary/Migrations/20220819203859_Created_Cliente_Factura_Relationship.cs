using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContextLibrary.Migrations
{
    public partial class Created_Cliente_Factura_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClienteId",
                table: "Facturas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_ClienteId",
                table: "Facturas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_ClienteId",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_ClienteId",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Facturas");
        }
    }
}
