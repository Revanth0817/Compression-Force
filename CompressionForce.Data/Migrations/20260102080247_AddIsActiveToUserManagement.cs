using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompressionForce.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToUserManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangePw",
                table: "UserManagements");

            migrationBuilder.DropColumn(
                name: "ERexpiryDate",
                table: "UserManagements");

            migrationBuilder.DropColumn(
                name: "ERid",
                table: "UserManagements");

            migrationBuilder.DropColumn(
                name: "ERimage",
                table: "UserManagements");

            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "UserManagements");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserManagements",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserManagements");

            migrationBuilder.AddColumn<string>(
                name: "ChangePw",
                table: "UserManagements",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ERexpiryDate",
                table: "UserManagements",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ERid",
                table: "UserManagements",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ERimage",
                table: "UserManagements",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UserStatus",
                table: "UserManagements",
                type: "boolean",
                nullable: true);
        }
    }
}
