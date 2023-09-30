using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoGestionVenta.Migrations
{
    public partial class password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    categoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__6378C0C09DE82B73", x => x.categoriaId);
                });

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    personaid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_persona = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    tipo_documento = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    num_documento = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    direccion = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.personaid);
                });

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    proveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rnc = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    correo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    representante = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    contacto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.proveedorId);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    rolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.rolId);
                });

            migrationBuilder.CreateTable(
                name: "articulo",
                columns: table => new
                {
                    articuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoriaId = table.Column<int>(type: "int", nullable: false),
                    proveedorId = table.Column<int>(type: "int", nullable: false),
                    codigo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    precio_venta = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articulo", x => x.articuloId);
                    table.ForeignKey(
                        name: "FK__articulo__catego__47DBAE45",
                        column: x => x.categoriaId,
                        principalTable: "categoria",
                        principalColumn: "categoriaId");
                    table.ForeignKey(
                        name: "FK__articulo__provee__48CFD27E",
                        column: x => x.proveedorId,
                        principalTable: "proveedor",
                        principalColumn: "proveedorId");
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolId = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    tipo_documento = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    num_documento = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    direccion = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.usuarioId);
                    table.ForeignKey(
                        name: "FK__usuario__rolId__3D5E1FD2",
                        column: x => x.rolId,
                        principalTable: "rol",
                        principalColumn: "rolId");
                });

            migrationBuilder.CreateTable(
                name: "ingreso",
                columns: table => new
                {
                    ingresoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proveedorId = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    tipo_comprobante = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    serie_comprobante = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    num_comprobante = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    impuesto = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingreso", x => x.ingresoId);
                    table.ForeignKey(
                        name: "FK__ingreso__proveed__4BAC3F29",
                        column: x => x.proveedorId,
                        principalTable: "persona",
                        principalColumn: "personaid");
                    table.ForeignKey(
                        name: "FK__ingreso__usuario__4CA06362",
                        column: x => x.usuarioId,
                        principalTable: "usuario",
                        principalColumn: "usuarioId");
                });

            migrationBuilder.CreateTable(
                name: "venta",
                columns: table => new
                {
                    ventaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    tipo_comprobante = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    serie_comprobante = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    num_comprobante = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    fecha_hora = table.Column<DateTime>(type: "datetime", nullable: false),
                    impuesto = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__venta__40B8EB54E40D8982", x => x.ventaId);
                    table.ForeignKey(
                        name: "FK__venta__clienteId__534D60F1",
                        column: x => x.clienteId,
                        principalTable: "persona",
                        principalColumn: "personaid");
                    table.ForeignKey(
                        name: "FK__venta__usuarioId__5441852A",
                        column: x => x.usuarioId,
                        principalTable: "usuario",
                        principalColumn: "usuarioId");
                });

            migrationBuilder.CreateTable(
                name: "detalle_ingreso",
                columns: table => new
                {
                    detalle_ingresoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ingresoId = table.Column<int>(type: "int", nullable: false),
                    articuloId = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_ingreso", x => x.detalle_ingresoId);
                    table.ForeignKey(
                        name: "FK__detalle_i__artic__5070F446",
                        column: x => x.articuloId,
                        principalTable: "articulo",
                        principalColumn: "articuloId");
                    table.ForeignKey(
                        name: "FK__detalle_i__ingre__4F7CD00D",
                        column: x => x.ingresoId,
                        principalTable: "ingreso",
                        principalColumn: "ingresoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalle_venta",
                columns: table => new
                {
                    detalle_ventaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ventaId = table.Column<int>(type: "int", nullable: false),
                    articuloId = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    descuento = table.Column<decimal>(type: "decimal(11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__detalle___000CCCF790943053", x => x.detalle_ventaId);
                    table.ForeignKey(
                        name: "FK__detalle_v__artic__5812160E",
                        column: x => x.articuloId,
                        principalTable: "articulo",
                        principalColumn: "articuloId");
                    table.ForeignKey(
                        name: "FK__detalle_v__venta__571DF1D5",
                        column: x => x.ventaId,
                        principalTable: "venta",
                        principalColumn: "ventaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articulo_categoriaId",
                table: "articulo",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_articulo_proveedorId",
                table: "articulo",
                column: "proveedorId");

            migrationBuilder.CreateIndex(
                name: "UQ__articulo__72AFBCC6CD801CEF",
                table: "articulo",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__categori__72AFBCC6DE9F50FB",
                table: "categoria",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_detalle_ingreso_articuloId",
                table: "detalle_ingreso",
                column: "articuloId");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_ingreso_ingresoId",
                table: "detalle_ingreso",
                column: "ingresoId");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_venta_articuloId",
                table: "detalle_venta",
                column: "articuloId");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_venta_ventaId",
                table: "detalle_venta",
                column: "ventaId");

            migrationBuilder.CreateIndex(
                name: "IX_ingreso_proveedorId",
                table: "ingreso",
                column: "proveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ingreso_usuarioId",
                table: "ingreso",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rolId",
                table: "usuario",
                column: "rolId");

            migrationBuilder.CreateIndex(
                name: "IX_venta_clienteId",
                table: "venta",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_venta_usuarioId",
                table: "venta",
                column: "usuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_ingreso");

            migrationBuilder.DropTable(
                name: "detalle_venta");

            migrationBuilder.DropTable(
                name: "ingreso");

            migrationBuilder.DropTable(
                name: "articulo");

            migrationBuilder.DropTable(
                name: "venta");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "rol");
        }
    }
}
