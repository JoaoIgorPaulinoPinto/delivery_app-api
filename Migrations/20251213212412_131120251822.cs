using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comaagora.Migrations
{
    /// <inheritdoc />
    public partial class _131120251822 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categoria_categoriaId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Status_StatusId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropColumn(
                name: "descricao",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "preco",
                table: "Produtos",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Produtos",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "categoriaId",
                table: "Produtos",
                newName: "CategoriaId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Produtos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_categoriaId",
                table: "Produtos",
                newName: "IX_Produtos_CategoriaId");

            migrationBuilder.AddColumn<int>(
                name: "EstabelecimentoId",
                table: "Status",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produtos",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Nome",
                keyValue: null,
                column: "Nome",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produtos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstabelecimentoId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstabelecimentoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoStatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstabelecimentoCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    statusId = table.Column<int>(type: "int", nullable: true),
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoCategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoCategoria_Status_statusId",
                        column: x => x.statusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    slug = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeFantasia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RazaoSocial = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cnpj = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Whatsapp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rua = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abertura = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Fechamento = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    TaxaEntrega = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PedidoMinimo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EstabelecimentoStatusId = table.Column<int>(type: "int", nullable: false),
                    ProdutoCategoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_EstabelecimentoStatus_EstabelecimentoStatus~",
                        column: x => x.EstabelecimentoStatusId,
                        principalTable: "EstabelecimentoStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutoCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoCategorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoCategorias_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoCategorias_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Status_EstabelecimentoId",
                table: "Status",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_EstabelecimentoId",
                table: "Produtos",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoCategoria_EstabelecimentoId",
                table: "EstabelecimentoCategoria",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoCategoria_statusId",
                table: "EstabelecimentoCategoria",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_EstabelecimentoStatusId",
                table: "Estabelecimentos",
                column: "EstabelecimentoStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_ProdutoCategoriaId",
                table: "Estabelecimentos",
                column: "ProdutoCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoCategorias_EstabelecimentoId",
                table: "ProdutoCategorias",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoCategorias_StatusId",
                table: "ProdutoCategorias",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Estabelecimentos_EstabelecimentoId",
                table: "Produtos",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ProdutoCategorias_CategoriaId",
                table: "Produtos",
                column: "CategoriaId",
                principalTable: "ProdutoCategorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Status_StatusId",
                table: "Produtos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Estabelecimentos_EstabelecimentoId",
                table: "Status",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstabelecimentoCategoria_Estabelecimentos_EstabelecimentoId",
                table: "EstabelecimentoCategoria",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_ProdutoCategorias_ProdutoCategoriaId",
                table: "Estabelecimentos",
                column: "ProdutoCategoriaId",
                principalTable: "ProdutoCategorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Estabelecimentos_EstabelecimentoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ProdutoCategorias_CategoriaId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Status_StatusId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Estabelecimentos_EstabelecimentoId",
                table: "Status");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoCategorias_Estabelecimentos_EstabelecimentoId",
                table: "ProdutoCategorias");

            migrationBuilder.DropTable(
                name: "EstabelecimentoCategoria");

            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "EstabelecimentoStatus");

            migrationBuilder.DropTable(
                name: "ProdutoCategorias");

            migrationBuilder.DropIndex(
                name: "IX_Status_EstabelecimentoId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_EstabelecimentoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "EstabelecimentoId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "EstabelecimentoId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Produtos",
                newName: "preco");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Produtos",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Produtos",
                newName: "categoriaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Produtos",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                newName: "IX_Produtos_categoriaId");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Produtos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "preco",
                table: "Produtos",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Produtos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "categoriaId",
                table: "Produtos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "Produtos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_StatusId",
                table: "Categoria",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categoria_categoriaId",
                table: "Produtos",
                column: "categoriaId",
                principalTable: "Categoria",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Status_StatusId",
                table: "Produtos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
