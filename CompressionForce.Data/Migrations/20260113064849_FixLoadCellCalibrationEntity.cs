using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompressionForce.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixLoadCellCalibrationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalibratedBy",
                table: "LoadCellCalibrations");

            migrationBuilder.RenameColumn(
                name: "CalibratedOn",
                table: "LoadCellCalibrations",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<decimal>(
                name: "Offset",
                table: "LoadCellCalibrations",
                type: "numeric(18,8)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinVolt",
                table: "LoadCellCalibrations",
                type: "numeric(10,4)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinValue",
                table: "LoadCellCalibrations",
                type: "numeric(10,4)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxVolt",
                table: "LoadCellCalibrations",
                type: "numeric(10,4)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxValue",
                table: "LoadCellCalibrations",
                type: "numeric(10,4)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "Factor",
                table: "LoadCellCalibrations",
                type: "numeric(18,8)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "LoadCellCalibrations",
                newName: "CalibratedOn");

            migrationBuilder.AlterColumn<double>(
                name: "Offset",
                table: "LoadCellCalibrations",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,8)");

            migrationBuilder.AlterColumn<double>(
                name: "MinVolt",
                table: "LoadCellCalibrations",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,4)");

            migrationBuilder.AlterColumn<double>(
                name: "MinValue",
                table: "LoadCellCalibrations",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,4)");

            migrationBuilder.AlterColumn<double>(
                name: "MaxVolt",
                table: "LoadCellCalibrations",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,4)");

            migrationBuilder.AlterColumn<double>(
                name: "MaxValue",
                table: "LoadCellCalibrations",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,4)");

            migrationBuilder.AlterColumn<double>(
                name: "Factor",
                table: "LoadCellCalibrations",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,8)");

            migrationBuilder.AddColumn<string>(
                name: "CalibratedBy",
                table: "LoadCellCalibrations",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
