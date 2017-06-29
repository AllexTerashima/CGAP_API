using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CGAP_API.Migrations
{
    public partial class FirstUse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cidade = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Pais = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoID);
                });

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    PerfilID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Auditorar = table.Column<bool>(nullable: false),
                    Emitir = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Receber = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.PerfilID);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartamentoID = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Tag = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaID);
                    table.ForeignKey(
                        name: "FK_Salas_Departamentos_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(nullable: false),
                    DepartamentoID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Nascimento = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    PerfilID = table.Column<int>(nullable: false),
                    Rg = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Usuarios_Departamentos_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Perfis_PerfilID",
                        column: x => x.PerfilID,
                        principalTable: "Perfis",
                        principalColumn: "PerfilID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(nullable: false),
                    SalaID = table.Column<int>(nullable: false),
                    Tag = table.Column<string>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Valor = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoID);
                    table.ForeignKey(
                        name: "FK_Produtos_Salas_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Salas",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_SalaID",
                table: "Produtos",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_DepartamentoID",
                table: "Salas",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DepartamentoID",
                table: "Usuarios",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilID",
                table: "Usuarios",
                column: "PerfilID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
