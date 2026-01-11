using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptRunner.WinForms.Migrations
{
    /// <inheritdoc />
    public partial class NewDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TsyProfiles",
                columns: table => new
                {
                    ProfileId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConnectionName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncryptedConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TsyProfiles", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "TsyScripts",
                columns: table => new
                {
                    ScriptId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScriptText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TsyScripts", x => x.ScriptId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TsyProfiles_ConnectionName",
                table: "TsyProfiles",
                column: "ConnectionName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TsyProfiles");

            migrationBuilder.DropTable(
                name: "TsyScripts");
        }
    }
}
