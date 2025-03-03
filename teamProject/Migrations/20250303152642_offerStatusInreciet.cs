using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teamProject.Migrations
{
    /// <inheritdoc />
    public partial class offerStatusInreciet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "offerStatus",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "offerStatus",
                table: "Offers");
        }
    }
}
