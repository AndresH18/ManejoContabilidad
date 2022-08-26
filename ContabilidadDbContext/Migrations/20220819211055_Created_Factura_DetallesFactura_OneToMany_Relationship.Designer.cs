﻿// <auto-generated />
using System;
using DbContextLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbContextLibrary.Migrations
{
    [DbContext(typeof(ContabilidadDbContext))]
    [Migration("20220819211055_Created_Factura_DetallesFactura_OneToMany_Relationship")]
    partial class Created_Factura_DetallesFactura_OneToMany_Relationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ModelEntities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ModelEntities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MunicipioId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegimenContable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsabilidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoContribuyente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Imporcom",
                            NumeroDocumento = "123-456-7890",
                            TipoDocumento = "Nit"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Andres' Programmers SAS",
                            NumeroDocumento = "111-222-33-44",
                            TipoDocumento = "Nit"
                        });
                });

            modelBuilder.Entity("ModelEntities.DetallesFactura", b =>
                {
                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoFacturaId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.HasKey("FacturaId", "ProductoFacturaId");

                    b.HasIndex("ProductoFacturaId")
                        .IsUnique();

                    b.ToTable("DetallesFactura");
                });

            modelBuilder.Entity("ModelEntities.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("ModelEntities.InfoFactura", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRecepcion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedioPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroFactura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plazo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefijo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoEntrega")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoNegociacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoOperacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InfoFactura");
                });

            modelBuilder.Entity("ModelEntities.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("ModelEntities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("MarcaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ModelEntities.ProductoFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductoFactura");
                });

            modelBuilder.Entity("ModelEntities.DetallesFactura", b =>
                {
                    b.HasOne("ModelEntities.Factura", "Factura")
                        .WithMany("DetallesFacturas")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelEntities.ProductoFactura", "ProductoFactura")
                        .WithOne("DetallesFactura")
                        .HasForeignKey("ModelEntities.DetallesFactura", "ProductoFacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");

                    b.Navigation("ProductoFactura");
                });

            modelBuilder.Entity("ModelEntities.Factura", b =>
                {
                    b.HasOne("ModelEntities.Cliente", "Cliente")
                        .WithMany("Facturas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ModelEntities.InfoFactura", b =>
                {
                    b.HasOne("ModelEntities.Factura", "Factura")
                        .WithOne("InfoFactura")
                        .HasForeignKey("ModelEntities.InfoFactura", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");
                });

            modelBuilder.Entity("ModelEntities.Producto", b =>
                {
                    b.HasOne("ModelEntities.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("ModelEntities.Marca", "Marca")
                        .WithMany("Productos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("ModelEntities.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("ModelEntities.Cliente", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("ModelEntities.Factura", b =>
                {
                    b.Navigation("DetallesFacturas");

                    b.Navigation("InfoFactura")
                        .IsRequired();
                });

            modelBuilder.Entity("ModelEntities.Marca", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("ModelEntities.ProductoFactura", b =>
                {
                    b.Navigation("DetallesFactura")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
