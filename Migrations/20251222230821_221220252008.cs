using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comaagora.Migrations
{
    /// <inheritdoc />
    public partial class _221220252008 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Enderecos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
