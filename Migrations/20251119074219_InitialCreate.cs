using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_proyect.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "conceptos_entrada_salida",
                columns: table => new
                {
                    id_concepto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipo_movimiento = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conceptos_entrada_salida", x => x.id_concepto);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estado_productos",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_productos", x => x.id_estado);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "excepciones_productos",
                columns: table => new
                {
                    id_excepcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_excepciones_productos", x => x.id_excepcion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "familias",
                columns: table => new
                {
                    id_familia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_familias", x => x.id_familia);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "motivos_traspasos",
                columns: table => new
                {
                    id_motivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motivos_traspasos", x => x.id_motivo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pasillos",
                columns: table => new
                {
                    id_pasillo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pasillos", x => x.id_pasillo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "perfiles",
                columns: table => new
                {
                    id_perfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfiles", x => x.id_perfil);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "presentacion",
                columns: table => new
                {
                    id_presentacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_presentacion", x => x.id_presentacion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "subtipos_productos",
                columns: table => new
                {
                    id_subtipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subtipos_productos", x => x.id_subtipo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipos_productos",
                columns: table => new
                {
                    id_tipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_productos", x => x.id_tipo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "racks",
                columns: table => new
                {
                    id_rack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_pasillo = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    columns = table.Column<int>(type: "int", nullable: false),
                    nivel = table.Column<int>(type: "int", nullable: false),
                    subnivel = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_racks", x => x.id_rack);
                    table.ForeignKey(
                        name: "FK_racks_pasillos_id_pasillo",
                        column: x => x.id_pasillo,
                        principalTable: "pasillos",
                        principalColumn: "id_pasillo",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_perfil = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_usuarios_perfiles_id_perfil",
                        column: x => x.id_perfil,
                        principalTable: "perfiles",
                        principalColumn: "id_perfil",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fotografia = table.Column<byte[]>(type: "longblob", nullable: false),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    id_tipo = table.Column<int>(type: "int", nullable: false),
                    id_subtipo = table.Column<int>(type: "int", nullable: false),
                    id_familia = table.Column<int>(type: "int", nullable: false),
                    id_presentacion = table.Column<int>(type: "int", nullable: false),
                    id_excepcion = table.Column<int>(type: "int", nullable: false),
                    id_estado = table.Column<int>(type: "int", nullable: false),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK_productos_estado_productos_id_estado",
                        column: x => x.id_estado,
                        principalTable: "estado_productos",
                        principalColumn: "id_estado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productos_excepciones_productos_id_excepcion",
                        column: x => x.id_excepcion,
                        principalTable: "excepciones_productos",
                        principalColumn: "id_excepcion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productos_familias_id_familia",
                        column: x => x.id_familia,
                        principalTable: "familias",
                        principalColumn: "id_familia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productos_presentacion_id_presentacion",
                        column: x => x.id_presentacion,
                        principalTable: "presentacion",
                        principalColumn: "id_presentacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productos_subtipos_productos_id_subtipo",
                        column: x => x.id_subtipo,
                        principalTable: "subtipos_productos",
                        principalColumn: "id_subtipo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productos_tipos_productos_id_tipo",
                        column: x => x.id_tipo,
                        principalTable: "tipos_productos",
                        principalColumn: "id_tipo",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InformacionContacto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false),
                    UsuarioMovimientoIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id_cliente);
                    table.ForeignKey(
                        name: "FK_clientes_usuarios_UsuarioMovimientoIdUsuario",
                        column: x => x.UsuarioMovimientoIdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empresas",
                columns: table => new
                {
                    id_empresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    razon_social = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rfc = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    calle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    no_exterior = table.Column<int>(type: "int", nullable: true),
                    no_interior = table.Column<int>(type: "int", nullable: true),
                    colonia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo_postal = table.Column<int>(type: "int", nullable: true),
                    telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ciudad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    municipio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false),
                    UsuarioMovimientoIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresas", x => x.id_empresa);
                    table.ForeignKey(
                        name: "FK_empresas_usuarios_UsuarioMovimientoIdUsuario",
                        column: x => x.UsuarioMovimientoIdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    id_proveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InformacionContacto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false),
                    UsuarioMovimientoIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.id_proveedor);
                    table.ForeignKey(
                        name: "FK_proveedores_usuarios_UsuarioMovimientoIdUsuario",
                        column: x => x.UsuarioMovimientoIdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "almacenes",
                columns: table => new
                {
                    id_almacen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_empresa = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InformacionContacto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pertenece_es = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    fecha_ult_mov = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_ult_mov = table.Column<int>(type: "int", nullable: false),
                    UsuarioMovimientoIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_almacenes", x => x.id_almacen);
                    table.ForeignKey(
                        name: "FK_almacenes_empresas_id_empresa",
                        column: x => x.id_empresa,
                        principalTable: "empresas",
                        principalColumn: "id_empresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_almacenes_usuarios_UsuarioMovimientoIdUsuario",
                        column: x => x.UsuarioMovimientoIdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_almacenes_id_empresa",
                table: "almacenes",
                column: "id_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_almacenes_UsuarioMovimientoIdUsuario",
                table: "almacenes",
                column: "UsuarioMovimientoIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_UsuarioMovimientoIdUsuario",
                table: "clientes",
                column: "UsuarioMovimientoIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_empresas_UsuarioMovimientoIdUsuario",
                table: "empresas",
                column: "UsuarioMovimientoIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_estado",
                table: "productos",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_excepcion",
                table: "productos",
                column: "id_excepcion");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_familia",
                table: "productos",
                column: "id_familia");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_presentacion",
                table: "productos",
                column: "id_presentacion");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_subtipo",
                table: "productos",
                column: "id_subtipo");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_tipo",
                table: "productos",
                column: "id_tipo");

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_UsuarioMovimientoIdUsuario",
                table: "proveedores",
                column: "UsuarioMovimientoIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_racks_id_pasillo",
                table: "racks",
                column: "id_pasillo");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_id_perfil",
                table: "usuarios",
                column: "id_perfil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "almacenes");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "conceptos_entrada_salida");

            migrationBuilder.DropTable(
                name: "motivos_traspasos");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "racks");

            migrationBuilder.DropTable(
                name: "empresas");

            migrationBuilder.DropTable(
                name: "estado_productos");

            migrationBuilder.DropTable(
                name: "excepciones_productos");

            migrationBuilder.DropTable(
                name: "familias");

            migrationBuilder.DropTable(
                name: "presentacion");

            migrationBuilder.DropTable(
                name: "subtipos_productos");

            migrationBuilder.DropTable(
                name: "tipos_productos");

            migrationBuilder.DropTable(
                name: "pasillos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "perfiles");
        }
    }
}
