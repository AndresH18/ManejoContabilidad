using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContextLibrary.Migrations
{
    public partial class AddedRelationship_ProductoFactura_With_Marca_Categoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "ProductoFactura");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "ProductoFactura");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "ProductoFactura",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "ProductoFactura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductoFactura_CategoriaId",
                table: "ProductoFactura",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoFactura_MarcaId",
                table: "ProductoFactura",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoFactura_Categorias_CategoriaId",
                table: "ProductoFactura",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoFactura_Marcas_MarcaId",
                table: "ProductoFactura",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoFactura_Categorias_CategoriaId",
                table: "ProductoFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoFactura_Marcas_MarcaId",
                table: "ProductoFactura");

            migrationBuilder.DropIndex(
                name: "IX_ProductoFactura_CategoriaId",
                table: "ProductoFactura");

            migrationBuilder.DropIndex(
                name: "IX_ProductoFactura_MarcaId",
                table: "ProductoFactura");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "ProductoFactura");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "ProductoFactura");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "ProductoFactura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "ProductoFactura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
