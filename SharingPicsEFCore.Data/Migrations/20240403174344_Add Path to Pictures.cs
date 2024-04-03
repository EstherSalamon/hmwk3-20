using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharingPicsEFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPathtoPictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Pictures");
        }
    }
}
