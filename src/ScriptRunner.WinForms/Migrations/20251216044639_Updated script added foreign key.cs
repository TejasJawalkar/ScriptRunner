using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptRunner.WinForms.Migrations
{

    public partial class Updatedscriptaddedforeignkey : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TsyScripts_ProfileId",
                table: "TsyScripts",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_TsyScripts_TsyProfiles_ProfileId",
                table: "TsyScripts",
                column: "ProfileId",
                principalTable: "TsyProfiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TsyScripts_TsyProfiles_ProfileId",
                table: "TsyScripts");

            migrationBuilder.DropIndex(
                name: "IX_TsyScripts_ProfileId",
                table: "TsyScripts");
        }
    }
}
