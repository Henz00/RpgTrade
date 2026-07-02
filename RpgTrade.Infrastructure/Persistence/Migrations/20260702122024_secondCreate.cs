using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgTrade.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class secondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemModifiers_ModifierDefinitionId",
                table: "ItemModifiers");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModifiers_ModifierDefinitionId_Value",
                table: "ItemModifiers",
                columns: new[] { "ModifierDefinitionId", "Value" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemModifiers_ModifierDefinitionId_Value",
                table: "ItemModifiers");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModifiers_ModifierDefinitionId",
                table: "ItemModifiers",
                column: "ModifierDefinitionId");
        }
    }
}
