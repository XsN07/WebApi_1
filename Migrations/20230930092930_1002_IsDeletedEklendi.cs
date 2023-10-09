using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P016_WeApi.Migrations
{
    /// <inheritdoc />
    public partial class _1002_IsDeletedEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Film",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Film");
        }
    }
}
