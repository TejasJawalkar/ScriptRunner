using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptRunner.WinForms.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnofconnectionsourceinprofiletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionSource",
                table: "TsyProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionSource",
                table: "TsyProfiles");
        }
    }
}
