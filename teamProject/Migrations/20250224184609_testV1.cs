using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teamProject.Migrations
{
    /// <inheritdoc />
    public partial class testV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_AspNetUsers_Manager_Id",
                table: "Branches");

            migrationBuilder.AlterColumn<string>(
                name: "Manager_Id",
                table: "Branches",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_AspNetUsers_Manager_Id",
                table: "Branches",
                column: "Manager_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_AspNetUsers_Manager_Id",
                table: "Branches");

            migrationBuilder.AlterColumn<string>(
                name: "Manager_Id",
                table: "Branches",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_AspNetUsers_Manager_Id",
                table: "Branches",
                column: "Manager_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
