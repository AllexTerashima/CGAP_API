using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CGAP_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Products",
                column: "ProdutoID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SalaID",
                table: "Products",
                newName: "IX_Produtos_SalaID");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Produtos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Produtos",
                column: "ProdutoID");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_SalaID",
                table: "Produtos",
                newName: "IX_Products_SalaID");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Products");
        }
    }
}
