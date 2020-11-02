using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalDesarrollo.Migrations
{
    public partial class migracion_makepeace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_ClientesModel",
                columns: table => new
                {
                    CodigoCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "Varchar(100)", nullable: false),
                    ApellidoCliente = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Nit = table.Column<string>(type: "Varchar(25)", nullable: false),
                    Direccion = table.Column<string>(type: "Varchar(50)", nullable: false),
                    CategoriaCliente = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ClientesModel", x => x.CodigoCliente);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DVentaModel",
                columns: table => new
                {
                    CodigoDVenta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoEVenta = table.Column<int>(type: "Int", nullable: false),
                    CodigoProducto = table.Column<int>(type: "Int", nullable: false),
                    Cantidad = table.Column<int>(type: "Int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "Decimal", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "Decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DVentaModel", x => x.CodigoDVenta);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EVentaModel",
                columns: table => new
                {
                    CodigoEVenta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    CodigoCliente = table.Column<int>(type: "Int", nullable: false),
                    TipoDocumento = table.Column<int>(type: "Int", nullable: false),
                    Estado = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EVentaModel", x => x.CodigoEVenta);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProductosModel",
                columns: table => new
                {
                    CodigoProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "Varchar(100)", nullable: false),
                    CodigoProveedor = table.Column<int>(type: "Int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    UbicacionFisica = table.Column<string>(type: "Varchar(25)", nullable: false),
                    ExistenciaMinima = table.Column<int>(type: "Int", nullable: false),
                    TipoProducto = table.Column<int>(type: "Int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "Decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProductosModel", x => x.CodigoProducto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_ClientesModel");

            migrationBuilder.DropTable(
                name: "tbl_DVentaModel");

            migrationBuilder.DropTable(
                name: "tbl_EVentaModel");

            migrationBuilder.DropTable(
                name: "tbl_ProductosModel");
        }
    }
}
