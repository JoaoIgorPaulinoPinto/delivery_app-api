using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comaagora.Migrations
{
    /// <inheritdoc />
    public partial class createEndPointUpdateProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Status_StatusId",
                table: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Produtos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoStatusId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProdutoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoStatus_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoStatus_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProdutoStatusId",
                table: "Produtos",
                column: "ProdutoStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoStatus_EstabelecimentoId",
                table: "ProdutoStatus",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoStatus_StatusId",
                table: "ProdutoStatus",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ProdutoStatus_ProdutoStatusId",
                table: "Produtos",
                column: "ProdutoStatusId",
                principalTable: "ProdutoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Status_StatusId",
                table: "Produtos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ProdutoStatus_ProdutoStatusId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Status_StatusId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "ProdutoStatus");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ProdutoStatusId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ProdutoStatusId",
                table: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Status_StatusId",
                table: "Produtos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
