using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendMVC.Migrations
{
    /// <inheritdoc />
    public partial class FileSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Filesize",
                table: "MidifileModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Filesize",
                table: "MidifileModel");
        }
    }
}
