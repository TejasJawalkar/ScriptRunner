using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptRunner.WinForms.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TsyScripts_TsyProfiles_ProfileId",
                table: "TsyScripts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TsyScripts",
                table: "TsyScripts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TsyProfiles",
                table: "TsyProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TsyExceptionLogs",
                table: "TsyExceptionLogs");

            migrationBuilder.RenameTable(
                name: "TsyScripts",
                newName: "TSYScripts");

            migrationBuilder.RenameTable(
                name: "TsyProfiles",
                newName: "TSYProfiles");

            migrationBuilder.RenameTable(
                name: "TsyExceptionLogs",
                newName: "TSYExceptionLogs");

            migrationBuilder.RenameIndex(
                name: "IX_TsyScripts_ProfileId",
                table: "TSYScripts",
                newName: "IX_TSYScripts_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_TsyProfiles_ConnectionName",
                table: "TSYProfiles",
                newName: "IX_TSYProfiles_ConnectionName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSYScripts",
                table: "TSYScripts",
                column: "ScriptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSYProfiles",
                table: "TSYProfiles",
                column: "ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TSYExceptionLogs",
                table: "TSYExceptionLogs",
                column: "ExceptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TSYScripts_TSYProfiles_ProfileId",
                table: "TSYScripts",
                column: "ProfileId",
                principalTable: "TSYProfiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TSYScripts_TSYProfiles_ProfileId",
                table: "TSYScripts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSYScripts",
                table: "TSYScripts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSYProfiles",
                table: "TSYProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TSYExceptionLogs",
                table: "TSYExceptionLogs");

            migrationBuilder.RenameTable(
                name: "TSYScripts",
                newName: "TsyScripts");

            migrationBuilder.RenameTable(
                name: "TSYProfiles",
                newName: "TsyProfiles");

            migrationBuilder.RenameTable(
                name: "TSYExceptionLogs",
                newName: "TsyExceptionLogs");

            migrationBuilder.RenameIndex(
                name: "IX_TSYScripts_ProfileId",
                table: "TsyScripts",
                newName: "IX_TsyScripts_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_TSYProfiles_ConnectionName",
                table: "TsyProfiles",
                newName: "IX_TsyProfiles_ConnectionName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TsyScripts",
                table: "TsyScripts",
                column: "ScriptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TsyProfiles",
                table: "TsyProfiles",
                column: "ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TsyExceptionLogs",
                table: "TsyExceptionLogs",
                column: "ExceptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TsyScripts_TsyProfiles_ProfileId",
                table: "TsyScripts",
                column: "ProfileId",
                principalTable: "TsyProfiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
