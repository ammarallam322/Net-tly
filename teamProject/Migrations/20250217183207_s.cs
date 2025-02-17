using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teamProject.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Central_Id",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Offer_Id",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SSN",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Service_Id",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Central_Id",
                table: "Clients",
                column: "Central_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Offer_Id",
                table: "Clients",
                column: "Offer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Service_Id",
                table: "Clients",
                column: "Service_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Centrals_Central_Id",
                table: "Clients",
                column: "Central_Id",
                principalTable: "Centrals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Offers_Offer_Id",
                table: "Clients",
                column: "Offer_Id",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ServiceProviders_Service_Id",
                table: "Clients",
                column: "Service_Id",
                principalTable: "ServiceProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Centrals_Central_Id",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Offers_Offer_Id",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ServiceProviders_Service_Id",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Central_Id",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Offer_Id",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Service_Id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Central_Id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Offer_Id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "SSN",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Service_Id",
                table: "Clients");
        }
    }
}
