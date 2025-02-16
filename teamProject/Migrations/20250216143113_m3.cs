using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teamProject.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Branch_Id",
                table: "Governerates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Governerates_Branch_Id",
                table: "Governerates",
                column: "Branch_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Governerates_Branches_Branch_Id",
                table: "Governerates",
                column: "Branch_Id",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Governerates_Branches_Branch_Id",
                table: "Governerates");

            migrationBuilder.DropIndex(
                name: "IX_Governerates_Branch_Id",
                table: "Governerates");

            migrationBuilder.DropColumn(
                name: "Branch_Id",
                table: "Governerates");
        }
    }
}
