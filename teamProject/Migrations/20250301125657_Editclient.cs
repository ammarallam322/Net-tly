using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teamProject.Migrations
{
    /// <inheritdoc />
    public partial class Editclient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Packages_Package_Id",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "Package_Id",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Packages_Package_Id",
                table: "Clients",
                column: "Package_Id",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Packages_Package_Id",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "Package_Id",
                table: "Clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Packages_Package_Id",
                table: "Clients",
                column: "Package_Id",
                principalTable: "Packages",
                principalColumn: "Id");
        }
    }
}
