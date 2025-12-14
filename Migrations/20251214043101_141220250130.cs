using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comaagora.Migrations
{
    /// <inheritdoc />
    public partial class _141220250130 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Enderecos_EnderecoId",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_EnderecoId",
                table: "Estabelecimentos");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "ProdutoPedidos",
                newName: "Quantidade");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId1",
                table: "Estabelecimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstabelecimentoId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_EnderecoId1",
                table: "Estabelecimentos",
                column: "EnderecoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EstabelecimentoId",
                table: "Enderecos",
                column: "EstabelecimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Estabelecimentos_EstabelecimentoId",
                table: "Enderecos",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Enderecos_EnderecoId1",
                table: "Estabelecimentos",
                column: "EnderecoId1",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Estabelecimentos_EstabelecimentoId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Enderecos_EnderecoId1",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_EnderecoId1",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_EstabelecimentoId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EnderecoId1",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "EstabelecimentoId",
                table: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "ProdutoPedidos",
                newName: "quantidade");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_EnderecoId",
                table: "Estabelecimentos",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Enderecos_EnderecoId",
                table: "Estabelecimentos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }
    }
}
