using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teamProject.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Service_Id",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "Servuce_Id",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Provider_Package",
                columns: table => new
                {
                    Provider_Id = table.Column<int>(type: "int", nullable: false),
                    Package_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider_Package", x => new { x.Provider_Id, x.Package_Id });
                    table.ForeignKey(
                        name: "FK_Provider_Package_Packages_Package_Id",
                        column: x => x.Package_Id,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Provider_Package_ServiceProviders_Provider_Id",
                        column: x => x.Provider_Id,
                        principalTable: "ServiceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_Servuce_Id",
                table: "Offers",
                column: "Servuce_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Centrals_Gov_Id",
                table: "Centrals",
                column: "Gov_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_Package_Package_Id",
                table: "Provider_Package",
                column: "Package_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Centrals_Governerates_Gov_Id",
                table: "Centrals",
                column: "Gov_Id",
                principalTable: "Governerates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_ServiceProviders_Servuce_Id",
                table: "Offers",
                column: "Servuce_Id",
                principalTable: "ServiceProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centrals_Governerates_Gov_Id",
                table: "Centrals");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_ServiceProviders_Servuce_Id",
                table: "Offers");

            migrationBuilder.DropTable(
                name: "Provider_Package");

            migrationBuilder.DropIndex(
                name: "IX_Offers_Servuce_Id",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Centrals_Gov_Id",
                table: "Centrals");

            migrationBuilder.DropColumn(
                name: "Servuce_Id",
                table: "Offers");

            migrationBuilder.AddColumn<int>(
                name: "Service_Id",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
