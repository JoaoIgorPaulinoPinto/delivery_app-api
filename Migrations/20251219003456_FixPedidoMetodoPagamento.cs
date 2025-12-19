using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comaagora.Migrations
{
    /// <inheritdoc />
    public partial class FixPedidoMetodoPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_MetodoPagamento_MetodoPagamentoId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "MetodoPagamento");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_MetodoPagamentoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "MetodoPagamentoId",
                table: "Pedidos");
        }
    }
}
