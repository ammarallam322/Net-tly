using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teamProject.Migrations
{
    /// <inheritdoc />
    public partial class editgoverv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Governerates_Branches_Branch_Id",
                table: "Governerates");

            migrationBuilder.AlterColumn<int>(
                name: "Branch_Id",
                table: "Governerates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Governerates_Branches_Branch_Id",
                table: "Governerates",
                column: "Branch_Id",
                principalTable: "Branches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Governerates_Branches_Branch_Id",
                table: "Governerates");

            migrationBuilder.AlterColumn<int>(
                name: "Branch_Id",
                table: "Governerates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Governerates_Branches_Branch_Id",
                table: "Governerates",
                column: "Branch_Id",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
