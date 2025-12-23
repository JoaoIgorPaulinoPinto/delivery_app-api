using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comaagora.Migrations
{
    /// <inheritdoc />
    public partial class fixconflit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Estabelecimentos_EstabelecimentoId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_EstabelecimentoId",
                table: "Enderecos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
