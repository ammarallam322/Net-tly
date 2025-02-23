using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teamProject.Migrations
{
    /// <inheritdoc />
    public partial class mohabMigIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Manager_Id",
                table: "Branches",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Manager_Id",
                table: "Branches",
                column: "Manager_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_AspNetUsers_Manager_Id",
                table: "Branches",
                column: "Manager_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_AspNetUsers_Manager_Id",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_Manager_Id",
                table: "Branches");

            migrationBuilder.AlterColumn<string>(
                name: "Manager_Id",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
