using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comaagora.Migrations
{
    public partial class RemoveDuplicatePedidoEnderecoFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Enderecos_EnderecoId1",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_EnderecoId1",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EnderecoId1",
                table: "Pedidos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId1",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EnderecoId1",
                table: "Pedidos",
                column: "EnderecoId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Enderecos_EnderecoId1",
                table: "Pedidos",
                column: "EnderecoId1",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }
    }
}
