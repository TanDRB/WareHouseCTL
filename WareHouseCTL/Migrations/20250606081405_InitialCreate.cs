using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHouseCTL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chemicals",
                columns: table => new
                {
                    ChemicalID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChemicalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChemicalDescribe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chemicals", x => x.ChemicalID);
                });

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    ShelfID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShelfName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChemicalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChemicalName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.ShelfID);
                    table.ForeignKey(
                        name: "FK_Shelves_Chemicals_ChemicalId",
                        column: x => x.ChemicalId,
                        principalTable: "Chemicals",
                        principalColumn: "ChemicalID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShelfContainers",
                columns: table => new
                {
                    ShelfContainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelfContainerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShelfID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StorageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfContainers", x => x.ShelfContainerId);
                    table.ForeignKey(
                        name: "FK_ShelfContainers_Shelves_ShelfID",
                        column: x => x.ShelfID,
                        principalTable: "Shelves",
                        principalColumn: "ShelfID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChemicalDetails",
                columns: table => new
                {
                    DetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShelfContainerId = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StorageDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_ChemicalDetails_Chemicals_ItemName",
                        column: x => x.ItemName,
                        principalTable: "Chemicals",
                        principalColumn: "ChemicalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChemicalDetails_ShelfContainers_ShelfContainerId",
                        column: x => x.ShelfContainerId,
                        principalTable: "ShelfContainers",
                        principalColumn: "ShelfContainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalDetails_ItemName",
                table: "ChemicalDetails",
                column: "ItemName");

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalDetails_ShelfContainerId",
                table: "ChemicalDetails",
                column: "ShelfContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelfContainers_ShelfID",
                table: "ShelfContainers",
                column: "ShelfID");

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_ChemicalId",
                table: "Shelves",
                column: "ChemicalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChemicalDetails");

            migrationBuilder.DropTable(
                name: "ShelfContainers");

            migrationBuilder.DropTable(
                name: "Shelves");

            migrationBuilder.DropTable(
                name: "Chemicals");
        }
    }
}
