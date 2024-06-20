using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProConsulta.Migrations
{
    /// <inheritdoc />
    public partial class initialapp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(60)", nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Documento = table.Column<string>(type: "NVarchar(11)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Celular = table.Column<string>(type: "NVarchar(11)", nullable: false),
                    DataNasicmento = table.Column<DateTime>(type: "datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Documento = table.Column<string>(type: "NVarchar(11)", nullable: false),
                    CRM = table.Column<string>(type: "NVarchar(8)", nullable: false),
                    Celular = table.Column<string>(type: "NVarchar(11)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observacao = table.Column<string>(type: "Varchar(250)", nullable: true),
                    HoraConsulta = table.Column<TimeSpan>(type: "time", nullable: false),
                    DataConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3363b173-2672-4281-ba10-9ea1d27e4a02", null, "Atendente", "ATENDENTE" },
                    { "3b050464-9dcd-4d8d-81b7-27649f00e4ac", null, "Medico", "MEDICO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f7a39a6e-5b10-4daf-a580-628b50b6073b", 0, "908297be-c61f-4fa2-8da1-68191661472f", "Atendende", "proconsulta@gmail.com", true, false, null, "Pro Consulta", "PROCONSULTA@GMAIL.COM", "PROCONSULTA@GMAIL.COM", "AQAAAAIAAYagAAAAELFfuKMMCcvp33a+Xico7kdxiXmXuW0vxzBekGjRnPS/GmpyM/2KKxQLDJYmm9Bjrg==", null, false, "43484cf0-acce-464f-ac63-a58762f556e1", false, "PROCONSULTA@GMAIL.COM" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Especialidade médica que trata doenças do sistema cardiovascular.", "Cardiologia" },
                    { 2, "Especialidade médica que trata doenças do estômago e intestino.", "Gastroenterologia" },
                    { 3, "Especialidade médica que trata doenças do sistema urinário e masculino.", "Urologia" },
                    { 4, "Especialidade médica que trata doenças do sistema nervoso.", "Neurologia" },
                    { 5, "Especialidade médica que trata de crianças e adolescentes.", "Pediatria" },
                    { 6, "Especialidade médica que trata da pele e suas doenças.", "Dermatologia" },
                    { 7, "Especialidade médica que trata doenças e distúrbios psicológicos.", "Psiquiatria" },
                    { 8, "Especialidade médica que trata dos olhos e sua visão.", "Oftalmologia" },
                    { 9, "Especialidade médica que trata o câncer.", "Oncologia" },
                    { 10, "Especialidade médica que trata do sistema reprodutor feminino", "Ginecologia" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3363b173-2672-4281-ba10-9ea1d27e4a02", "f7a39a6e-5b10-4daf-a580-628b50b6073b" });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_MedicoId",
                table: "Agendamentos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_PacienteId",
                table: "Agendamentos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_Documento",
                table: "Medicos",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadeId",
                table: "Medicos",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Documento",
                table: "Pacientes",
                column: "Documento",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b050464-9dcd-4d8d-81b7-27649f00e4ac");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3363b173-2672-4281-ba10-9ea1d27e4a02", "f7a39a6e-5b10-4daf-a580-628b50b6073b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3363b173-2672-4281-ba10-9ea1d27e4a02");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7a39a6e-5b10-4daf-a580-628b50b6073b");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");
        }
    }
}
