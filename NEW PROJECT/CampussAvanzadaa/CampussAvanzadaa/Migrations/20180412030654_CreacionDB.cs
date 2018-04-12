using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CampussAvanzadaa.Migrations
{
    public partial class CreacionDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPersona",
                columns: table => new
                {
                    IdTipoPersona = table.Column<string>(maxLength: 50, nullable: false),
                    Descripción = table.Column<string>(type: "nchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersona", x => x.IdTipoPersona);
                });

            migrationBuilder.CreateTable(
                name: "Ventanas",
                columns: table => new
                {
                    Id_Ventana = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventanas", x => x.Id_Ventana);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id_Persona = table.Column<string>(maxLength: 50, nullable: false),
                    carnet = table.Column<string>(maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(maxLength: 50, nullable: true),
                    Correo = table.Column<string>(maxLength: 50, nullable: false),
                    genero = table.Column<string>(maxLength: 1, nullable: true),
                    idTipoPersona = table.Column<string>(maxLength: 50, nullable: true),
                    NombreCompleto = table.Column<string>(maxLength: 50, nullable: false),
                    Pais = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id_Persona);
                    table.ForeignKey(
                        name: "FK_Persona_TipoPersona",
                        column: x => x.idTipoPersona,
                        principalTable: "TipoPersona",
                        principalColumn: "IdTipoPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VentanasXPerfil",
                columns: table => new
                {
                    TipoPersona = table.Column<string>(maxLength: 50, nullable: false),
                    Id_Ventana = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentanasXPerfil", x => x.TipoPersona);
                    table.ForeignKey(
                        name: "FK_VentanasXPerfil_Ventanas",
                        column: x => x.Id_Ventana,
                        principalTable: "Ventanas",
                        principalColumn: "Id_Ventana",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    id_carrera = table.Column<string>(maxLength: 50, nullable: false),
                    id_persona = table.Column<string>(maxLength: 50, nullable: true),
                    NombreCarrera = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.id_carrera);
                    table.ForeignKey(
                        name: "FK_Carreras_Persona",
                        column: x => x.id_persona,
                        principalTable: "Persona",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    id_matricula = table.Column<string>(maxLength: 50, nullable: false),
                    creidtomatriculado = table.Column<string>(type: "nchar(10)", nullable: true),
                    fecha = table.Column<DateTime>(type: "date", nullable: false),
                    id_estudiante = table.Column<string>(maxLength: 50, nullable: true),
                    id_matriculante = table.Column<string>(maxLength: 50, nullable: true),
                    monto = table.Column<string>(type: "nchar(10)", nullable: true),
                    nota = table.Column<int>(nullable: false),
                    periodo = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.id_matricula);
                    table.ForeignKey(
                        name: "FK_Matricula_Persona2",
                        column: x => x.id_estudiante,
                        principalTable: "Persona",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matricula_Persona3",
                        column: x => x.id_matriculante,
                        principalTable: "Persona",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonaXTipo",
                columns: table => new
                {
                    Id_Persona = table.Column<string>(maxLength: 50, nullable: false),
                    Id_TipoPersona = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaXTipo", x => new { x.Id_Persona, x.Id_TipoPersona });
                    table.ForeignKey(
                        name: "FK_PersonaXTipo_Persona",
                        column: x => x.Id_Persona,
                        principalTable: "Persona",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonaXTipo_TipoPersona",
                        column: x => x.Id_TipoPersona,
                        principalTable: "TipoPersona",
                        principalColumn: "IdTipoPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id_Curso = table.Column<string>(maxLength: 50, nullable: false),
                    id_carrera = table.Column<string>(maxLength: 50, nullable: false),
                    creditos = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    estado = table.Column<int>(nullable: false),
                    id_materiarequerida = table.Column<string>(maxLength: 50, nullable: true),
                    id_persona = table.Column<string>(maxLength: 50, nullable: true),
                    precio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => new { x.Id_Curso, x.id_carrera });
                    table.ForeignKey(
                        name: "FK_Cursos_Carreras",
                        column: x => x.id_carrera,
                        principalTable: "Carreras",
                        principalColumn: "id_carrera",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleMatricula",
                columns: table => new
                {
                    idDetalleMatricula = table.Column<string>(maxLength: 50, nullable: false),
                    id_carrera = table.Column<string>(maxLength: 50, nullable: true),
                    id_Curso = table.Column<string>(maxLength: 50, nullable: true),
                    id_Matricula = table.Column<string>(maxLength: 50, nullable: false),
                    nota = table.Column<int>(nullable: false),
                    submonto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleMatricula", x => x.idDetalleMatricula);
                    table.ForeignKey(
                        name: "FK_DetalleMatricula_Matricula",
                        column: x => x.id_Matricula,
                        principalTable: "Matricula",
                        principalColumn: "id_matricula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleMatricula_Cursos",
                        columns: x => new { x.id_Curso, x.id_carrera },
                        principalTable: "Cursos",
                        principalColumns: new[] { "Id_Curso", "id_carrera" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id_Grupo = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    id_carrera = table.Column<string>(maxLength: 50, nullable: true),
                    id_curso = table.Column<string>(maxLength: 50, nullable: true),
                    id_horario = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id_Grupo);
                    table.ForeignKey(
                        name: "FK_Grupos_Cursos",
                        columns: x => new { x.id_carrera, x.id_curso },
                        principalTable: "Cursos",
                        principalColumns: new[] { "Id_Curso", "id_carrera" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    id_historico = table.Column<string>(maxLength: 50, nullable: false),
                    id_curso = table.Column<string>(maxLength: 50, nullable: true),
                    id_persona = table.Column<string>(maxLength: 50, nullable: true),
                    id_tipopersona = table.Column<string>(maxLength: 50, nullable: true),
                    idcarrera = table.Column<string>(maxLength: 50, nullable: true),
                    ind_estado = table.Column<string>(maxLength: 50, nullable: true),
                    nota = table.Column<int>(nullable: false),
                    periodo = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.id_historico);
                    table.ForeignKey(
                        name: "FK_Notas_Persona",
                        column: x => x.id_persona,
                        principalTable: "Persona",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notas_Cursos",
                        columns: x => new { x.id_curso, x.idcarrera },
                        principalTable: "Cursos",
                        principalColumns: new[] { "Id_Curso", "id_carrera" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historico_PersonaXTipo",
                        columns: x => new { x.id_tipopersona, x.id_persona },
                        principalTable: "PersonaXTipo",
                        principalColumns: new[] { "Id_Persona", "Id_TipoPersona" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rubros",
                columns: table => new
                {
                    IdRubro = table.Column<string>(maxLength: 50, nullable: false),
                    id_Carrera = table.Column<string>(maxLength: 50, nullable: true),
                    id_Curso = table.Column<string>(maxLength: 50, nullable: true),
                    NombreRubro = table.Column<string>(type: "nchar(10)", nullable: true),
                    Porcentaje = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubros", x => x.IdRubro);
                    table.ForeignKey(
                        name: "FK_Rubros_Cursos",
                        columns: x => new { x.id_Curso, x.id_Carrera },
                        principalTable: "Cursos",
                        principalColumns: new[] { "Id_Curso", "id_carrera" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AsistenciaEstudiantes",
                columns: table => new
                {
                    ind_asistencia = table.Column<string>(maxLength: 50, nullable: false),
                    comentarios = table.Column<string>(maxLength: 50, nullable: true),
                    estado = table.Column<int>(nullable: false),
                    fechaasistencia = table.Column<DateTime>(type: "date", nullable: false),
                    id_grupo = table.Column<string>(maxLength: 50, nullable: false),
                    id_persona = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistenciaEstudiantes", x => x.ind_asistencia);
                    table.ForeignKey(
                        name: "FK_DetalleGrupo_Grupos",
                        column: x => x.id_grupo,
                        principalTable: "Grupos",
                        principalColumn: "Id_Grupo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleGrupo_Persona",
                        column: x => x.id_persona,
                        principalTable: "Persona",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AsistenciaProfesor",
                columns: table => new
                {
                    id_Asistencia = table.Column<string>(maxLength: 50, nullable: false),
                    comentarios = table.Column<string>(maxLength: 50, nullable: true),
                    estado = table.Column<int>(nullable: false),
                    horaingreso = table.Column<DateTime>(type: "datetime", nullable: false),
                    horasalida = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_grupo = table.Column<string>(maxLength: 50, nullable: true),
                    id_persona = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistenciaProfesor", x => x.id_Asistencia);
                    table.ForeignKey(
                        name: "FK_AsistenciaProfesor_Grupos",
                        column: x => x.id_grupo,
                        principalTable: "Grupos",
                        principalColumn: "Id_Grupo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AsistenciaProfesor_Persona",
                        column: x => x.id_persona,
                        principalTable: "Persona",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleNotas",
                columns: table => new
                {
                    id_DetalleNota = table.Column<string>(maxLength: 50, nullable: false),
                    id_historico = table.Column<string>(maxLength: 50, nullable: true),
                    id_Rubro = table.Column<string>(maxLength: 50, nullable: true),
                    porcentajeganado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleNotas", x => x.id_DetalleNota);
                    table.ForeignKey(
                        name: "FK_DetalleNotas_Notas",
                        column: x => x.id_historico,
                        principalTable: "Notas",
                        principalColumn: "id_historico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleNotas_Rubros",
                        column: x => x.id_Rubro,
                        principalTable: "Rubros",
                        principalColumn: "IdRubro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaEstudiantes_id_grupo",
                table: "AsistenciaEstudiantes",
                column: "id_grupo");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaEstudiantes_id_persona",
                table: "AsistenciaEstudiantes",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaProfesor_id_grupo",
                table: "AsistenciaProfesor",
                column: "id_grupo");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaProfesor_id_persona",
                table: "AsistenciaProfesor",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_Carreras_id_persona",
                table: "Carreras",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_id_carrera",
                table: "Cursos",
                column: "id_carrera");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMatricula_id_Matricula",
                table: "DetalleMatricula",
                column: "id_Matricula");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMatricula_id_Curso_id_carrera",
                table: "DetalleMatricula",
                columns: new[] { "id_Curso", "id_carrera" });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleNotas_id_historico",
                table: "DetalleNotas",
                column: "id_historico");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleNotas_id_Rubro",
                table: "DetalleNotas",
                column: "id_Rubro");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_id_carrera_id_curso",
                table: "Grupos",
                columns: new[] { "id_carrera", "id_curso" });

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_id_estudiante",
                table: "Matricula",
                column: "id_estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_id_matriculante",
                table: "Matricula",
                column: "id_matriculante");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_id_persona",
                table: "Notas",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_id_curso_idcarrera",
                table: "Notas",
                columns: new[] { "id_curso", "idcarrera" });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_id_tipopersona_id_persona",
                table: "Notas",
                columns: new[] { "id_tipopersona", "id_persona" });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_idTipoPersona",
                table: "Persona",
                column: "idTipoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaXTipo_Id_TipoPersona",
                table: "PersonaXTipo",
                column: "Id_TipoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Rubros_id_Curso_id_Carrera",
                table: "Rubros",
                columns: new[] { "id_Curso", "id_Carrera" });

            migrationBuilder.CreateIndex(
                name: "IX_VentanasXPerfil_Id_Ventana",
                table: "VentanasXPerfil",
                column: "Id_Ventana");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsistenciaEstudiantes");

            migrationBuilder.DropTable(
                name: "AsistenciaProfesor");

            migrationBuilder.DropTable(
                name: "DetalleMatricula");

            migrationBuilder.DropTable(
                name: "DetalleNotas");

            migrationBuilder.DropTable(
                name: "VentanasXPerfil");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Rubros");

            migrationBuilder.DropTable(
                name: "Ventanas");

            migrationBuilder.DropTable(
                name: "PersonaXTipo");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "TipoPersona");
        }
    }
}
