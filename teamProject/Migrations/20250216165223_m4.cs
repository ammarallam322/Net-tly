using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teamProject.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Package_ServiceProviders_Provider_Id",
                table: "Provider_Package");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provider_Package",
                table: "Provider_Package");

            migrationBuilder.DropIndex(
                name: "IX_Provider_Package_Package_Id",
                table: "Provider_Package");

            migrationBuilder.RenameColumn(
                name: "Provider_Id",
                table: "Provider_Package",
                newName: "provider_Id");

            migrationBuilder.AddColumn<int>(
                name: "Package_Id",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provider_Package",
                table: "Provider_Package",
                columns: new[] { "Package_Id", "provider_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Provider_Package_provider_Id",
                table: "Provider_Package",
                column: "provider_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Package_Id",
                table: "Clients",
                column: "Package_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Packages_Package_Id",
                table: "Clients",
                column: "Package_Id",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Package_ServiceProviders_provider_Id",
                table: "Provider_Package",
                column: "provider_Id",
                principalTable: "ServiceProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Packages_Package_Id",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Package_ServiceProviders_provider_Id",
                table: "Provider_Package");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provider_Package",
                table: "Provider_Package");

            migrationBuilder.DropIndex(
                name: "IX_Provider_Package_provider_Id",
                table: "Provider_Package");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Package_Id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Package_Id",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "provider_Id",
                table: "Provider_Package",
                newName: "Provider_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provider_Package",
                table: "Provider_Package",
                columns: new[] { "Provider_Id", "Package_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Provider_Package_Package_Id",
                table: "Provider_Package",
                column: "Package_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Package_ServiceProviders_Provider_Id",
                table: "Provider_Package",
                column: "Provider_Id",
                principalTable: "ServiceProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
