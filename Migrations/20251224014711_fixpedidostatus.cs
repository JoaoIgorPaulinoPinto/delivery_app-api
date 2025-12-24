using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comaagora.Migrations
{
    /// <inheritdoc />
    public partial class fixpedidostatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstabelecimentoId",
                table: "PedidoStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoStatus_EstabelecimentoId",
                table: "PedidoStatus",
                column: "EstabelecimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoStatus_Estabelecimentos_EstabelecimentoId",
                table: "PedidoStatus",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoStatus_Estabelecimentos_EstabelecimentoId",
                table: "PedidoStatus");

            migrationBuilder.DropIndex(
                name: "IX_PedidoStatus_EstabelecimentoId",
                table: "PedidoStatus");

            migrationBuilder.DropColumn(
                name: "EstabelecimentoId",
                table: "PedidoStatus");
        }
    }
}
