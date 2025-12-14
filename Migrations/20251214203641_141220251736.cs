using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comaagora.Migrations
{
    /// <inheritdoc />
    public partial class _141220251736 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Enderecos_EnderecoId1",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_EnderecoId1",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "EnderecoId1",
                table: "Estabelecimentos");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_EnderecoId",
                table: "Estabelecimentos",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Enderecos_EnderecoId",
                table: "Estabelecimentos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Enderecos_EnderecoId",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_EnderecoId",
                table: "Estabelecimentos");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId1",
                table: "Estabelecimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_EnderecoId1",
                table: "Estabelecimentos",
                column: "EnderecoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Enderecos_EnderecoId1",
                table: "Estabelecimentos",
                column: "EnderecoId1",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
