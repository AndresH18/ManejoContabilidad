using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContextLibrary.Migrations
{
    public partial class Deleted_ProductoFactura_ModifiedRelationshipsTo_Producto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesFactura_ProductoFactura_ProductoFacturaId",
                table: "DetallesFactura");

            migrationBuilder.DropTable(
                name: "ProductoFactura");

            migrationBuilder.DropIndex(
                name: "IX_DetallesFactura_ProductoFacturaId",
                table: "DetallesFactura");

            migrationBuilder.RenameColumn(
                name: "ProductoFacturaId",
                table: "DetallesFactura",
                newName: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFactura_ProductoId",
                table: "DetallesFactura",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesFactura_Productos_ProductoId",
                table: "DetallesFactura",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesFactura_Productos_ProductoId",
                table: "DetallesFactura");

            migrationBuilder.DropIndex(
                name: "IX_DetallesFactura_ProductoId",
                table: "DetallesFactura");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "DetallesFactura",
                newName: "ProductoFacturaId");

            migrationBuilder.CreateTable(
                name: "ProductoFactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoFactura_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoFactura_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFactura_ProductoFacturaId",
                table: "DetallesFactura",
                column: "ProductoFacturaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductoFactura_CategoriaId",
                table: "ProductoFactura",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoFactura_MarcaId",
                table: "ProductoFactura",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesFactura_ProductoFactura_ProductoFacturaId",
                table: "DetallesFactura",
                column: "ProductoFacturaId",
                principalTable: "ProductoFactura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
