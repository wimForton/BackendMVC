using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendMVC.Migrations
{
    /// <inheritdoc />
    public partial class composer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Composer",
                table: "MidifileModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Composer",
                table: "MidifileModel");
        }
    }
}
