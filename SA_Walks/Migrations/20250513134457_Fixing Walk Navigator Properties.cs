using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SA_Walks.API.Migrations
{
    public partial class FixingWalkNavigatorProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Walks");

            migrationBuilder.RenameColumn(
                name: "RegionID",
                table: "Walks",
                newName: "RegionId");

            migrationBuilder.RenameColumn(
                name: "DifficultyID",
                table: "Walks",
                newName: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walks",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionId",
                table: "Walks",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks");

            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks");

            migrationBuilder.DropIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walks");

            migrationBuilder.DropIndex(
                name: "IX_Walks_RegionId",
                table: "Walks");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Walks",
                newName: "RegionID");

            migrationBuilder.RenameColumn(
                name: "DifficultyId",
                table: "Walks",
                newName: "DifficultyID");

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
