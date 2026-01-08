using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Compression_Force.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAccessManagementTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecuritySettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationTimeoutMinutes = table.Column<int>(type: "integer", nullable: false),
                    PasswordExpiryDays = table.Column<int>(type: "integer", nullable: false),
                    MaxWrongAttempts = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecuritySettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AccessLevel = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccesses_UserManagements_UserId",
                        column: x => x.UserId,
                        principalTable: "UserManagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPrivileges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Recipe = table.Column<bool>(type: "boolean", nullable: false),
                    Operation = table.Column<bool>(type: "boolean", nullable: false),
                    Diagnostic = table.Column<bool>(type: "boolean", nullable: false),
                    SignalMonitoring = table.Column<bool>(type: "boolean", nullable: false),
                    Reports = table.Column<bool>(type: "boolean", nullable: false),
                    Backup = table.Column<bool>(type: "boolean", nullable: false),
                    Alarms = table.Column<bool>(type: "boolean", nullable: false),
                    Batch = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivileges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPrivileges_UserManagements_UserId",
                        column: x => x.UserId,
                        principalTable: "UserManagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_UserId",
                table: "UserAccesses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivileges_UserId",
                table: "UserPrivileges",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecuritySettings");

            migrationBuilder.DropTable(
                name: "UserAccesses");

            migrationBuilder.DropTable(
                name: "UserPrivileges");
        }
    }
}
