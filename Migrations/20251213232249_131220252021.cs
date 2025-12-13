using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comaagora.Migrations
{
    /// <inheritdoc />
    public partial class _131220252021 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Status",
                type: "datetime(6)",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Status",
                type: "datetime(6)",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Produtos",
                type: "datetime(6)",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Produtos",
                type: "datetime(6)",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProdutoCategorias",
                type: "datetime(6)",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ProdutoCategorias",
                type: "datetime(6)",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EstabelecimentoStatus",
                type: "datetime(6)",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EstabelecimentoStatus",
                type: "datetime(6)",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Estabelecimentos",
                type: "datetime(6)",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Estabelecimentos",
                type: "datetime(6)",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EstabelecimentoCategoria",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EstabelecimentoCategoria",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProdutoCategorias");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ProdutoCategorias");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EstabelecimentoStatus");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EstabelecimentoStatus");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EstabelecimentoCategoria");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EstabelecimentoCategoria");
        }
    }
}
