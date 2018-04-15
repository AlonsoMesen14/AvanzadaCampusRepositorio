using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CampussAvanzadaa.Migrations
{
    public partial class GruposFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GrupoIdGrupo",
                table: "Persona",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_GrupoIdGrupo",
                table: "Persona",
                column: "GrupoIdGrupo");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Grupos_GrupoIdGrupo",
                table: "Persona",
                column: "GrupoIdGrupo",
                principalTable: "Grupos",
                principalColumn: "Id_Grupo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Grupos_GrupoIdGrupo",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_GrupoIdGrupo",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "GrupoIdGrupo",
                table: "Persona");
        }
    }
}
