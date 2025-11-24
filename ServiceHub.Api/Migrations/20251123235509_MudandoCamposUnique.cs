using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceHub.Api.Migrations
{
    /// <inheritdoc />
    public partial class MudandoCamposUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cidade_Ibge",
                table: "Cidade");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_Ibge",
                table: "Cidade",
                column: "Ibge");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cidade_Ibge",
                table: "Cidade");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_Ibge",
                table: "Cidade",
                column: "Ibge",
                unique: true);
        }
    }
}
