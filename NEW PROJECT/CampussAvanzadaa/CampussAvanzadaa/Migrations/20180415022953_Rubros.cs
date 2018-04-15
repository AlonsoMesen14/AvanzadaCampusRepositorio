using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CampussAvanzadaa.Migrations
{
    public partial class Rubros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GrupoIdGrupo",
                table: "Rubros",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rubros_GrupoIdGrupo",
                table: "Rubros",
                column: "GrupoIdGrupo");

            migrationBuilder.AddForeignKey(
                name: "FK_Rubros_Grupos_GrupoIdGrupo",
                table: "Rubros",
                column: "GrupoIdGrupo",
                principalTable: "Grupos",
                principalColumn: "Id_Grupo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rubros_Grupos_GrupoIdGrupo",
                table: "Rubros");

            migrationBuilder.DropIndex(
                name: "IX_Rubros_GrupoIdGrupo",
                table: "Rubros");

            migrationBuilder.DropColumn(
                name: "GrupoIdGrupo",
                table: "Rubros");
        }
    }
}
