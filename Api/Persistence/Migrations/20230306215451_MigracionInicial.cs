using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiasSemana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HorasConfiguradas = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasSemana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposEstados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEstados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposTiempo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTiempo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<int>(type: "int", nullable: false),
                    TipoEstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_TiposEstados_TipoEstadoId",
                        column: x => x.TipoEstadoId,
                        principalTable: "TiposEstados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProyecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposProyecto_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TiposProyecto_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TiposProyecto_Usuarios_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AsignacionesTipoProyectoPorDia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PorcentajePorDia = table.Column<float>(type: "real", nullable: false),
                    DiasSemanaId = table.Column<int>(type: "int", nullable: false),
                    TipoProyectoId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionesTipoProyectoPorDia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsignacionesTipoProyectoPorDia_DiasSemana_DiasSemanaId",
                        column: x => x.DiasSemanaId,
                        principalTable: "DiasSemana",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignacionesTipoProyectoPorDia_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AsignacionesTipoProyectoPorDia_TiposProyecto_TipoProyectoId",
                        column: x => x.TipoProyectoId,
                        principalTable: "TiposProyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposActividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    TipoProyectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposActividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposActividades_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TiposActividades_TiposProyecto_TipoProyectoId",
                        column: x => x.TipoProyectoId,
                        principalTable: "TiposProyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsignacionesProyectoPorDia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PorcentajePorDia = table.Column<float>(type: "real", nullable: false),
                    AsignacionTipoProyectoPorDiaId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionesProyectoPorDia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsignacionesProyectoPorDia_AsignacionesTipoProyectoPorDia_AsignacionTipoProyectoPorDiaId",
                        column: x => x.AsignacionTipoProyectoPorDiaId,
                        principalTable: "AsignacionesTipoProyectoPorDia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignacionesProyectoPorDia_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalEstimada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracionMinutos = table.Column<int>(type: "int", nullable: false),
                    AsignacionProyectoPorDiaId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    TipoProyectoId = table.Column<int>(type: "int", nullable: false),
                    TipoProyectoId1 = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectos_AsignacionesProyectoPorDia_AsignacionProyectoPorDiaId",
                        column: x => x.AsignacionProyectoPorDiaId,
                        principalTable: "AsignacionesProyectoPorDia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proyectos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proyectos_TiposProyecto_TipoProyectoId",
                        column: x => x.TipoProyectoId,
                        principalTable: "TiposProyecto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proyectos_TiposProyecto_TipoProyectoId1",
                        column: x => x.TipoProyectoId1,
                        principalTable: "TiposProyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanesActividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuracionMinutos = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEstimadaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrdenEjecucion = table.Column<int>(type: "int", nullable: false),
                    TipoActividadId = table.Column<int>(type: "int", nullable: false),
                    TipoTiempoId = table.Column<int>(type: "int", nullable: false),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    TipoActividadId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesActividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanesActividad_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanesActividad_TiposActividades_TipoActividadId",
                        column: x => x.TipoActividadId,
                        principalTable: "TiposActividades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanesActividad_TiposActividades_TipoActividadId1",
                        column: x => x.TipoActividadId1,
                        principalTable: "TiposActividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanesActividad_TiposTiempo_TipoTiempoId",
                        column: x => x.TipoTiempoId,
                        principalTable: "TiposTiempo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiemposReales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanActividadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiemposReales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiemposReales_PlanesActividad_PlanActividadId",
                        column: x => x.PlanActividadId,
                        principalTable: "PlanesActividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesProyectoPorDia_AsignacionTipoProyectoPorDiaId",
                table: "AsignacionesProyectoPorDia",
                column: "AsignacionTipoProyectoPorDiaId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesProyectoPorDia_EstadoId",
                table: "AsignacionesProyectoPorDia",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesTipoProyectoPorDia_DiasSemanaId",
                table: "AsignacionesTipoProyectoPorDia",
                column: "DiasSemanaId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesTipoProyectoPorDia_EstadoId",
                table: "AsignacionesTipoProyectoPorDia",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesTipoProyectoPorDia_TipoProyectoId",
                table: "AsignacionesTipoProyectoPorDia",
                column: "TipoProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_DiasSemana_Nombre",
                table: "DiasSemana",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_TipoEstadoId",
                table: "Estados",
                column: "TipoEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesActividad_ProyectoId",
                table: "PlanesActividad",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesActividad_TipoActividadId",
                table: "PlanesActividad",
                column: "TipoActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesActividad_TipoActividadId1",
                table: "PlanesActividad",
                column: "TipoActividadId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesActividad_TipoTiempoId",
                table: "PlanesActividad",
                column: "TipoTiempoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_AsignacionProyectoPorDiaId",
                table: "Proyectos",
                column: "AsignacionProyectoPorDiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_EstadoId",
                table: "Proyectos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_TipoProyectoId",
                table: "Proyectos",
                column: "TipoProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_TipoProyectoId1",
                table: "Proyectos",
                column: "TipoProyectoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_UsuarioId",
                table: "Proyectos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TiemposReales_PlanActividadId",
                table: "TiemposReales",
                column: "PlanActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposActividades_EstadoId",
                table: "TiposActividades",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposActividades_TipoProyectoId",
                table: "TiposActividades",
                column: "TipoProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposProyecto_EstadoId",
                table: "TiposProyecto",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposProyecto_UsuarioId",
                table: "TiposProyecto",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposProyecto_UsuarioId1",
                table: "TiposProyecto",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstadoId",
                table: "Usuarios",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NombreUsuario",
                table: "Usuarios",
                column: "NombreUsuario",
                unique: true,
                filter: "[NombreUsuario] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "TiemposReales");

            migrationBuilder.DropTable(
                name: "PlanesActividad");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "TiposActividades");

            migrationBuilder.DropTable(
                name: "TiposTiempo");

            migrationBuilder.DropTable(
                name: "AsignacionesProyectoPorDia");

            migrationBuilder.DropTable(
                name: "AsignacionesTipoProyectoPorDia");

            migrationBuilder.DropTable(
                name: "DiasSemana");

            migrationBuilder.DropTable(
                name: "TiposProyecto");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TiposEstados");
        }
    }
}
