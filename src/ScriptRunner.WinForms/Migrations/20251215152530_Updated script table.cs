using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptRunner.WinForms.Migrations
{
    /// <inheritdoc />
    public partial class Updatedscripttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProfileId",
                table: "TsyScripts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "TsyScripts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "TsyScripts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TsyScripts");
        }
    }
}
