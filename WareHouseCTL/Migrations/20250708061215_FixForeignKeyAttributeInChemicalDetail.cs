using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHouseCTL.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyAttributeInChemicalDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChemicalDetails_Chemicals_ItemName",
                table: "ChemicalDetails");

            migrationBuilder.DropIndex(
                name: "IX_Shelves_ChemicalId",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "ChemicalName",
                table: "Shelves");

            migrationBuilder.RenameColumn(
                name: "ChemicalID",
                table: "Chemicals",
                newName: "ChemicalId");

            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "ChemicalDetails",
                newName: "ChemicalId");

            migrationBuilder.RenameIndex(
                name: "IX_ChemicalDetails_ItemName",
                table: "ChemicalDetails",
                newName: "IX_ChemicalDetails_ChemicalId");

            migrationBuilder.AlterColumn<string>(
                name: "ChemicalId",
                table: "Shelves",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ChemicalId",
                table: "ShelfContainers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_ChemicalId",
                table: "Shelves",
                column: "ChemicalId",
                unique: true,
                filter: "[ChemicalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShelfContainers_ChemicalId",
                table: "ShelfContainers",
                column: "ChemicalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChemicalDetails_Chemicals_ChemicalId",
                table: "ChemicalDetails",
                column: "ChemicalId",
                principalTable: "Chemicals",
                principalColumn: "ChemicalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShelfContainers_Chemicals_ChemicalId",
                table: "ShelfContainers",
                column: "ChemicalId",
                principalTable: "Chemicals",
                principalColumn: "ChemicalId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChemicalDetails_Chemicals_ChemicalId",
                table: "ChemicalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ShelfContainers_Chemicals_ChemicalId",
                table: "ShelfContainers");

            migrationBuilder.DropIndex(
                name: "IX_Shelves_ChemicalId",
                table: "Shelves");

            migrationBuilder.DropIndex(
                name: "IX_ShelfContainers_ChemicalId",
                table: "ShelfContainers");

            migrationBuilder.DropColumn(
                name: "ChemicalId",
                table: "ShelfContainers");

            migrationBuilder.RenameColumn(
                name: "ChemicalId",
                table: "Chemicals",
                newName: "ChemicalID");

            migrationBuilder.RenameColumn(
                name: "ChemicalId",
                table: "ChemicalDetails",
                newName: "ItemName");

            migrationBuilder.RenameIndex(
                name: "IX_ChemicalDetails_ChemicalId",
                table: "ChemicalDetails",
                newName: "IX_ChemicalDetails_ItemName");

            migrationBuilder.AlterColumn<string>(
                name: "ChemicalId",
                table: "Shelves",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChemicalName",
                table: "Shelves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_ChemicalId",
                table: "Shelves",
                column: "ChemicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChemicalDetails_Chemicals_ItemName",
                table: "ChemicalDetails",
                column: "ItemName",
                principalTable: "Chemicals",
                principalColumn: "ChemicalID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
