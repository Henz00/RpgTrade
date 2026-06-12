using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RpgTrade.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModifierDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MinValue = table.Column<double>(type: "double precision", nullable: false),
                    MaxValue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifierDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ItemClassId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseTypes_ItemClasses_ItemClassId",
                        column: x => x.ItemClassId,
                        principalTable: "ItemClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModifierDefinitionItemClasses",
                columns: table => new
                {
                    ModifierDefinitionId = table.Column<int>(type: "integer", nullable: false),
                    ItemClassId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifierDefinitionItemClasses", x => new { x.ModifierDefinitionId, x.ItemClassId });
                    table.ForeignKey(
                        name: "FK_ModifierDefinitionItemClasses_ItemClasses_ItemClassId",
                        column: x => x.ItemClassId,
                        principalTable: "ItemClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModifierDefinitionItemClasses_ModifierDefinitions_ModifierD~",
                        column: x => x.ModifierDefinitionId,
                        principalTable: "ModifierDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Rarity = table.Column<string>(type: "text", nullable: false),
                    ItemLevel = table.Column<int>(type: "integer", nullable: false),
                    BaseTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_BaseTypes_BaseTypeId",
                        column: x => x.BaseTypeId,
                        principalTable: "BaseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemModifiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifierDefinitionId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemModifiers_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemModifiers_ModifierDefinitions_ModifierDefinitionId",
                        column: x => x.ModifierDefinitionId,
                        principalTable: "ModifierDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseTypes_ItemClassId",
                table: "BaseTypes",
                column: "ItemClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModifiers_ItemId",
                table: "ItemModifiers",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModifiers_ModifierDefinitionId",
                table: "ItemModifiers",
                column: "ModifierDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BaseTypeId",
                table: "Items",
                column: "BaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifierDefinitionItemClasses_ItemClassId",
                table: "ModifierDefinitionItemClasses",
                column: "ItemClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemModifiers");

            migrationBuilder.DropTable(
                name: "ModifierDefinitionItemClasses");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ModifierDefinitions");

            migrationBuilder.DropTable(
                name: "BaseTypes");

            migrationBuilder.DropTable(
                name: "ItemClasses");
        }
    }
}
