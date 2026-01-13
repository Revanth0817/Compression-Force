using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompressionForce.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddServoCalibrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServoCalibrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServoCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ServoName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    JogSpeed = table.Column<decimal>(type: "numeric", nullable: false),
                    SetPosition = table.Column<decimal>(type: "numeric", nullable: false),
                    SetSpeed = table.Column<decimal>(type: "numeric", nullable: false),
                    TorqueLimit = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServoCalibrations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServoCalibrations");
        }
    }
}
