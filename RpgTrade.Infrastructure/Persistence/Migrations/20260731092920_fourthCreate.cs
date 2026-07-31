using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgTrade.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fourthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemClassName",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemClassName",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
