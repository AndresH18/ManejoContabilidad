using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContextLibrary.Migrations
{
    public partial class CreatedSomeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipioId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoContribuyente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegimenContable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsabilidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoFactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumeroFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoOperacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoNegociacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Prefijo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedioPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plazo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoFactura_Facturas_Id",
                        column: x => x.Id,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Correo", "Direccion", "MunicipioId", "Nombre", "NumeroDocumento", "RegimenContable", "Responsabilidad", "Telefono", "TipoContribuyente", "TipoDocumento" },
                values: new object[] { 1, null, null, null, "Imporcom", "123-456-7890", null, null, null, null, "Nit" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Correo", "Direccion", "MunicipioId", "Nombre", "NumeroDocumento", "RegimenContable", "Responsabilidad", "Telefono", "TipoContribuyente", "TipoDocumento" },
                values: new object[] { 2, null, null, null, "Andres' Programmers SAS", "111-222-33-44", null, null, null, null, "Nit" });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                column: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "InfoFactura");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
