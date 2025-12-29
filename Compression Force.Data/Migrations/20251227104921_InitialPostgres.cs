using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Compression_Force.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlarmLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlramCode = table.Column<string>(type: "text", nullable: true),
                    AlarmCreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AlarmDescription = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    BatchNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditTrails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    EventDescription = table.Column<string>(type: "text", nullable: true),
                    Activity = table.Column<string>(type: "text", nullable: true),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RecipeCode = table.Column<string>(type: "text", nullable: true),
                    BatchCode = table.Column<string>(type: "text", nullable: true),
                    BatchSize = table.Column<string>(type: "text", nullable: true),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    ProdusedQty = table.Column<string>(type: "text", nullable: true),
                    LeftQty = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    BatchStatus = table.Column<string>(type: "text", nullable: true),
                    GoodQty = table.Column<string>(type: "text", nullable: true),
                    RejectionQty = table.Column<string>(type: "text", nullable: true),
                    S2GoodQty = table.Column<string>(type: "text", nullable: true),
                    S2RejectionQty = table.Column<string>(type: "text", nullable: true),
                    TabletQty = table.Column<string>(type: "text", nullable: true),
                    BatchQty = table.Column<string>(type: "text", nullable: true),
                    BatchCondition = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BatchHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RecipeCode = table.Column<string>(type: "text", nullable: true),
                    BatchCode = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    BatchSize = table.Column<long>(type: "bigint", nullable: true),
                    EReventType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentBatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    TurretRpm = table.Column<string>(type: "text", nullable: true),
                    S1FeederRatio = table.Column<string>(type: "text", nullable: true),
                    S2FeederRatio = table.Column<string>(type: "text", nullable: true),
                    S1FillDepth = table.Column<string>(type: "text", nullable: true),
                    S1PreThickness = table.Column<string>(type: "text", nullable: true),
                    S1MainThickness = table.Column<string>(type: "text", nullable: true),
                    S1PrePenetration = table.Column<string>(type: "text", nullable: true),
                    S1MainPenetration = table.Column<string>(type: "text", nullable: true),
                    S2FillDepth = table.Column<string>(type: "text", nullable: true),
                    S2PreThickness = table.Column<string>(type: "text", nullable: true),
                    S2MainThickness = table.Column<string>(type: "text", nullable: true),
                    S2PrePenetration = table.Column<string>(type: "text", nullable: true),
                    S2MainPenetration = table.Column<string>(type: "text", nullable: true),
                    S1RejUpperLimit = table.Column<string>(type: "text", nullable: true),
                    S1AwcUpperLimit = table.Column<string>(type: "text", nullable: true),
                    S1AwcSetLimit = table.Column<string>(type: "text", nullable: true),
                    S1AwcLowerLimit = table.Column<string>(type: "text", nullable: true),
                    S1RejLowerLimit = table.Column<string>(type: "text", nullable: true),
                    S2RejUpperLimit = table.Column<string>(type: "text", nullable: true),
                    S2AwcUpperLimit = table.Column<string>(type: "text", nullable: true),
                    S2AwcSetLimit = table.Column<string>(type: "text", nullable: true),
                    S2AwcLowerLimit = table.Column<string>(type: "text", nullable: true),
                    S2RejLowerLimit = table.Column<string>(type: "text", nullable: true),
                    S1FillCam = table.Column<string>(type: "text", nullable: true),
                    S2FillCam = table.Column<string>(type: "text", nullable: true),
                    AwcUpper = table.Column<string>(type: "text", nullable: true),
                    AwcLower = table.Column<string>(type: "text", nullable: true),
                    RejUpper = table.Column<string>(type: "text", nullable: true),
                    RejLower = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentBatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrivilageHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupLevel = table.Column<string>(type: "text", nullable: true),
                    Recipe = table.Column<bool>(type: "boolean", nullable: true),
                    Batch = table.Column<bool>(type: "boolean", nullable: true),
                    Security = table.Column<bool>(type: "boolean", nullable: true),
                    Reports = table.Column<bool>(type: "boolean", nullable: true),
                    Alarms = table.Column<bool>(type: "boolean", nullable: true),
                    Backup = table.Column<bool>(type: "boolean", nullable: true),
                    Operation = table.Column<bool>(type: "boolean", nullable: true),
                    Calibration = table.Column<bool>(type: "boolean", nullable: true),
                    Diagnostics = table.Column<bool>(type: "boolean", nullable: true),
                    SignalMonitor = table.Column<bool>(type: "boolean", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EventType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivilageHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Privilages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupLevel = table.Column<string>(type: "text", nullable: true),
                    Recipe = table.Column<bool>(type: "boolean", nullable: true),
                    Batch = table.Column<bool>(type: "boolean", nullable: true),
                    Security = table.Column<bool>(type: "boolean", nullable: true),
                    Reports = table.Column<bool>(type: "boolean", nullable: true),
                    Alarms = table.Column<bool>(type: "boolean", nullable: true),
                    Backup = table.Column<bool>(type: "boolean", nullable: true),
                    Operation = table.Column<bool>(type: "boolean", nullable: true),
                    Calibration = table.Column<bool>(type: "boolean", nullable: true),
                    Diagnostics = table.Column<bool>(type: "boolean", nullable: true),
                    AuditTrail = table.Column<bool>(type: "boolean", nullable: true),
                    SignalMonitor = table.Column<bool>(type: "boolean", nullable: true),
                    AwcParameter = table.Column<bool>(type: "boolean", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeHistroys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventType = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RecipeAlteredBy = table.Column<string>(type: "text", nullable: true),
                    RecipeName = table.Column<string>(type: "text", nullable: true),
                    RecipeCode = table.Column<string>(type: "text", nullable: true),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    Shape = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    ToolType = table.Column<string>(type: "text", nullable: true),
                    TabletThickness = table.Column<float>(type: "real", nullable: true),
                    TabletHardness = table.Column<float>(type: "real", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    MaxTurretRpm = table.Column<float>(type: "real", nullable: true),
                    ForceFeederRatioS1 = table.Column<float>(type: "real", nullable: true),
                    FillDepthS1 = table.Column<float>(type: "real", nullable: true),
                    MainPenetrationPositionS1 = table.Column<float>(type: "real", nullable: true),
                    MainThicknessPositionS1 = table.Column<float>(type: "real", nullable: true),
                    PrePenetrationPositionS1 = table.Column<float>(type: "real", nullable: true),
                    PreThicknessPositionS1 = table.Column<float>(type: "real", nullable: true),
                    SampleIntervalS1 = table.Column<float>(type: "real", nullable: true),
                    SampleRevolutionQtyS1 = table.Column<float>(type: "real", nullable: true),
                    MaxMainCompForceS1 = table.Column<float>(type: "real", nullable: true),
                    MaxPreCompForceS1 = table.Column<float>(type: "real", nullable: true),
                    MaxEjectionForceS1 = table.Column<float>(type: "real", nullable: true),
                    RejectionForceLimitMaxS1 = table.Column<float>(type: "real", nullable: true),
                    AwcForceLimitMaxS1 = table.Column<float>(type: "real", nullable: true),
                    AwcForceSetPointS1 = table.Column<float>(type: "real", nullable: true),
                    AwcForceLimitMinS1 = table.Column<float>(type: "real", nullable: true),
                    RejectionForceLimitMinS1 = table.Column<float>(type: "real", nullable: true),
                    ForceFeederRatioS2 = table.Column<float>(type: "real", nullable: true),
                    FillDepthS2 = table.Column<float>(type: "real", nullable: true),
                    MainPenetrationPositionS2 = table.Column<float>(type: "real", nullable: true),
                    MainThicknessPositionS2 = table.Column<float>(type: "real", nullable: true),
                    PrePenetrationPositionS2 = table.Column<float>(type: "real", nullable: true),
                    PreThicknessPositionS2 = table.Column<float>(type: "real", nullable: true),
                    SampleIntervalS2 = table.Column<float>(type: "real", nullable: true),
                    SampleRevolutionQtyS2 = table.Column<float>(type: "real", nullable: true),
                    MaxMainCompForceS2 = table.Column<float>(type: "real", nullable: true),
                    MaxPreCompForceS2 = table.Column<float>(type: "real", nullable: true),
                    MaxEjectionForceS2 = table.Column<float>(type: "real", nullable: true),
                    RejectionForceLimitMaxS2 = table.Column<float>(type: "real", nullable: true),
                    AwcForceLimitMaxS2 = table.Column<float>(type: "real", nullable: true),
                    AwcForceSetPointS2 = table.Column<float>(type: "real", nullable: true),
                    AwcForceLimitMinS2 = table.Column<float>(type: "real", nullable: true),
                    RejectionForceLimitMinS2 = table.Column<float>(type: "real", nullable: true),
                    AwcUpper = table.Column<float>(type: "real", nullable: true),
                    AwcLower = table.Column<float>(type: "real", nullable: true),
                    RejUpper = table.Column<float>(type: "real", nullable: true),
                    RejLower = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeHistroys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RecipeCreatedBy = table.Column<string>(type: "text", nullable: true),
                    RecipeName = table.Column<string>(type: "text", nullable: true),
                    RecipeCode = table.Column<string>(type: "text", nullable: true),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    Shape = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    ToolType = table.Column<string>(type: "text", nullable: true),
                    TabletThickness = table.Column<float>(type: "real", nullable: true),
                    TabletHardness = table.Column<float>(type: "real", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    MaxTurretRpm = table.Column<float>(type: "real", nullable: true),
                    ForceFeederRatioS1 = table.Column<float>(type: "real", nullable: true),
                    FillDepthS1 = table.Column<float>(type: "real", nullable: true),
                    MainPenetrationPositionS1 = table.Column<float>(type: "real", nullable: true),
                    MainThicknessPositionS1 = table.Column<float>(type: "real", nullable: true),
                    PrePenetrationPositionS1 = table.Column<float>(type: "real", nullable: true),
                    PreThicknessPositionS1 = table.Column<float>(type: "real", nullable: true),
                    SampleIntervalS1 = table.Column<float>(type: "real", nullable: true),
                    SampleRevolutionQtyS1 = table.Column<float>(type: "real", nullable: true),
                    MaxMainCompForceS1 = table.Column<float>(type: "real", nullable: true),
                    MaxPreCompForceS1 = table.Column<float>(type: "real", nullable: true),
                    MaxEjectionForceS1 = table.Column<float>(type: "real", nullable: true),
                    RejectionForceLimitMaxS1 = table.Column<float>(type: "real", nullable: true),
                    AwcForceLimitMaxS1 = table.Column<float>(type: "real", nullable: true),
                    AwcForceSetPointS1 = table.Column<float>(type: "real", nullable: true),
                    AwcForceLimitMinS1 = table.Column<float>(type: "real", nullable: true),
                    RejectionForceLimitMinS1 = table.Column<float>(type: "real", nullable: true),
                    ForceFeederRatioS2 = table.Column<float>(type: "real", nullable: true),
                    FillDepthS2 = table.Column<float>(type: "real", nullable: true),
                    MainPenetrationPositionS2 = table.Column<float>(type: "real", nullable: true),
                    MainThicknessPositionS2 = table.Column<float>(type: "real", nullable: true),
                    PrePenetrationPositionS2 = table.Column<float>(type: "real", nullable: true),
                    PreThicknessPositionS2 = table.Column<float>(type: "real", nullable: true),
                    SampleIntervalS2 = table.Column<float>(type: "real", nullable: true),
                    SampleRevolutionQtyS2 = table.Column<float>(type: "real", nullable: true),
                    MaxMainCompForceS2 = table.Column<float>(type: "real", nullable: true),
                    MaxPreCompForceS2 = table.Column<float>(type: "real", nullable: true),
                    MaxEjectionForceS2 = table.Column<float>(type: "real", nullable: true),
                    RejectionForceLimitMaxS2 = table.Column<float>(type: "real", nullable: true),
                    AwcForceLimitMaxS2 = table.Column<float>(type: "real", nullable: true),
                    AwcForceSetPointS2 = table.Column<float>(type: "real", nullable: true),
                    AwcForceLimitMinS2 = table.Column<float>(type: "real", nullable: true),
                    RejectionForceLimitMinS2 = table.Column<float>(type: "real", nullable: true),
                    AwcUpper = table.Column<float>(type: "real", nullable: true),
                    AwcLower = table.Column<float>(type: "real", nullable: true),
                    RejUpper = table.Column<float>(type: "real", nullable: true),
                    RejLower = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultEjectLoadS1Bs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    RecipeName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Revolution = table.Column<long>(type: "bigint", nullable: true),
                    P1 = table.Column<double>(type: "double precision", nullable: true),
                    P2 = table.Column<double>(type: "double precision", nullable: true),
                    P3 = table.Column<double>(type: "double precision", nullable: true),
                    P4 = table.Column<double>(type: "double precision", nullable: true),
                    P5 = table.Column<double>(type: "double precision", nullable: true),
                    P6 = table.Column<double>(type: "double precision", nullable: true),
                    P7 = table.Column<double>(type: "double precision", nullable: true),
                    P8 = table.Column<double>(type: "double precision", nullable: true),
                    P9 = table.Column<double>(type: "double precision", nullable: true),
                    P10 = table.Column<double>(type: "double precision", nullable: true),
                    P11 = table.Column<double>(type: "double precision", nullable: true),
                    P12 = table.Column<double>(type: "double precision", nullable: true),
                    P13 = table.Column<double>(type: "double precision", nullable: true),
                    P14 = table.Column<double>(type: "double precision", nullable: true),
                    P15 = table.Column<double>(type: "double precision", nullable: true),
                    P16 = table.Column<double>(type: "double precision", nullable: true),
                    P17 = table.Column<double>(type: "double precision", nullable: true),
                    P18 = table.Column<double>(type: "double precision", nullable: true),
                    P19 = table.Column<double>(type: "double precision", nullable: true),
                    P20 = table.Column<double>(type: "double precision", nullable: true),
                    P21 = table.Column<double>(type: "double precision", nullable: true),
                    P22 = table.Column<double>(type: "double precision", nullable: true),
                    P23 = table.Column<double>(type: "double precision", nullable: true),
                    P24 = table.Column<double>(type: "double precision", nullable: true),
                    P25 = table.Column<double>(type: "double precision", nullable: true),
                    P26 = table.Column<double>(type: "double precision", nullable: true),
                    P27 = table.Column<double>(type: "double precision", nullable: true),
                    P28 = table.Column<double>(type: "double precision", nullable: true),
                    P29 = table.Column<double>(type: "double precision", nullable: true),
                    P30 = table.Column<double>(type: "double precision", nullable: true),
                    P31 = table.Column<double>(type: "double precision", nullable: true),
                    P32 = table.Column<double>(type: "double precision", nullable: true),
                    P33 = table.Column<double>(type: "double precision", nullable: true),
                    P34 = table.Column<double>(type: "double precision", nullable: true),
                    P35 = table.Column<double>(type: "double precision", nullable: true),
                    P36 = table.Column<double>(type: "double precision", nullable: true),
                    P37 = table.Column<double>(type: "double precision", nullable: true),
                    P38 = table.Column<double>(type: "double precision", nullable: true),
                    P39 = table.Column<double>(type: "double precision", nullable: true),
                    P40 = table.Column<double>(type: "double precision", nullable: true),
                    P41 = table.Column<double>(type: "double precision", nullable: true),
                    P42 = table.Column<double>(type: "double precision", nullable: true),
                    P43 = table.Column<double>(type: "double precision", nullable: true),
                    P44 = table.Column<double>(type: "double precision", nullable: true),
                    P45 = table.Column<double>(type: "double precision", nullable: true),
                    P46 = table.Column<double>(type: "double precision", nullable: true),
                    P47 = table.Column<double>(type: "double precision", nullable: true),
                    P48 = table.Column<double>(type: "double precision", nullable: true),
                    P49 = table.Column<double>(type: "double precision", nullable: true),
                    P50 = table.Column<double>(type: "double precision", nullable: true),
                    P51 = table.Column<double>(type: "double precision", nullable: true),
                    P52 = table.Column<double>(type: "double precision", nullable: true),
                    P53 = table.Column<double>(type: "double precision", nullable: true),
                    P54 = table.Column<double>(type: "double precision", nullable: true),
                    P55 = table.Column<double>(type: "double precision", nullable: true),
                    P56 = table.Column<double>(type: "double precision", nullable: true),
                    P57 = table.Column<double>(type: "double precision", nullable: true),
                    P58 = table.Column<double>(type: "double precision", nullable: true),
                    P59 = table.Column<double>(type: "double precision", nullable: true),
                    P60 = table.Column<double>(type: "double precision", nullable: true),
                    P61 = table.Column<double>(type: "double precision", nullable: true),
                    P62 = table.Column<double>(type: "double precision", nullable: true),
                    P63 = table.Column<double>(type: "double precision", nullable: true),
                    P64 = table.Column<double>(type: "double precision", nullable: true),
                    P65 = table.Column<double>(type: "double precision", nullable: true),
                    AverageLoad = table.Column<double>(type: "double precision", nullable: true),
                    TurretSpeed = table.Column<double>(type: "double precision", nullable: true),
                    S1FeederSpeed = table.Column<double>(type: "double precision", nullable: true),
                    S2FeederSpeed = table.Column<double>(type: "double precision", nullable: true),
                    SrelValue = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultEjectLoadS1Bs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultEjectLoadS2Bs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    RecipeName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Revolution = table.Column<long>(type: "bigint", nullable: true),
                    P1 = table.Column<double>(type: "double precision", nullable: true),
                    P2 = table.Column<double>(type: "double precision", nullable: true),
                    P3 = table.Column<double>(type: "double precision", nullable: true),
                    P4 = table.Column<double>(type: "double precision", nullable: true),
                    P5 = table.Column<double>(type: "double precision", nullable: true),
                    P6 = table.Column<double>(type: "double precision", nullable: true),
                    P7 = table.Column<double>(type: "double precision", nullable: true),
                    P8 = table.Column<double>(type: "double precision", nullable: true),
                    P9 = table.Column<double>(type: "double precision", nullable: true),
                    P10 = table.Column<double>(type: "double precision", nullable: true),
                    P11 = table.Column<double>(type: "double precision", nullable: true),
                    P12 = table.Column<double>(type: "double precision", nullable: true),
                    P13 = table.Column<double>(type: "double precision", nullable: true),
                    P14 = table.Column<double>(type: "double precision", nullable: true),
                    P15 = table.Column<double>(type: "double precision", nullable: true),
                    P16 = table.Column<double>(type: "double precision", nullable: true),
                    P17 = table.Column<double>(type: "double precision", nullable: true),
                    P18 = table.Column<double>(type: "double precision", nullable: true),
                    P19 = table.Column<double>(type: "double precision", nullable: true),
                    P20 = table.Column<double>(type: "double precision", nullable: true),
                    P21 = table.Column<double>(type: "double precision", nullable: true),
                    P22 = table.Column<double>(type: "double precision", nullable: true),
                    P23 = table.Column<double>(type: "double precision", nullable: true),
                    P24 = table.Column<double>(type: "double precision", nullable: true),
                    P25 = table.Column<double>(type: "double precision", nullable: true),
                    P26 = table.Column<double>(type: "double precision", nullable: true),
                    P27 = table.Column<double>(type: "double precision", nullable: true),
                    P28 = table.Column<double>(type: "double precision", nullable: true),
                    P29 = table.Column<double>(type: "double precision", nullable: true),
                    P30 = table.Column<double>(type: "double precision", nullable: true),
                    P31 = table.Column<double>(type: "double precision", nullable: true),
                    P32 = table.Column<double>(type: "double precision", nullable: true),
                    P33 = table.Column<double>(type: "double precision", nullable: true),
                    P34 = table.Column<double>(type: "double precision", nullable: true),
                    P35 = table.Column<double>(type: "double precision", nullable: true),
                    P36 = table.Column<double>(type: "double precision", nullable: true),
                    P37 = table.Column<double>(type: "double precision", nullable: true),
                    P38 = table.Column<double>(type: "double precision", nullable: true),
                    P39 = table.Column<double>(type: "double precision", nullable: true),
                    P40 = table.Column<double>(type: "double precision", nullable: true),
                    P41 = table.Column<double>(type: "double precision", nullable: true),
                    P42 = table.Column<double>(type: "double precision", nullable: true),
                    P43 = table.Column<double>(type: "double precision", nullable: true),
                    P44 = table.Column<double>(type: "double precision", nullable: true),
                    P45 = table.Column<double>(type: "double precision", nullable: true),
                    P46 = table.Column<double>(type: "double precision", nullable: true),
                    P47 = table.Column<double>(type: "double precision", nullable: true),
                    P48 = table.Column<double>(type: "double precision", nullable: true),
                    P49 = table.Column<double>(type: "double precision", nullable: true),
                    P50 = table.Column<double>(type: "double precision", nullable: true),
                    P51 = table.Column<double>(type: "double precision", nullable: true),
                    P52 = table.Column<double>(type: "double precision", nullable: true),
                    P53 = table.Column<double>(type: "double precision", nullable: true),
                    P54 = table.Column<double>(type: "double precision", nullable: true),
                    P55 = table.Column<double>(type: "double precision", nullable: true),
                    P56 = table.Column<double>(type: "double precision", nullable: true),
                    P57 = table.Column<double>(type: "double precision", nullable: true),
                    P58 = table.Column<double>(type: "double precision", nullable: true),
                    P59 = table.Column<double>(type: "double precision", nullable: true),
                    P60 = table.Column<double>(type: "double precision", nullable: true),
                    P61 = table.Column<double>(type: "double precision", nullable: true),
                    P62 = table.Column<double>(type: "double precision", nullable: true),
                    P63 = table.Column<double>(type: "double precision", nullable: true),
                    P64 = table.Column<double>(type: "double precision", nullable: true),
                    P65 = table.Column<double>(type: "double precision", nullable: true),
                    AverageLoad = table.Column<double>(type: "double precision", nullable: true),
                    TurretSpeed = table.Column<double>(type: "double precision", nullable: true),
                    S1FeederSpeed = table.Column<double>(type: "double precision", nullable: true),
                    S2FeederSpeed = table.Column<double>(type: "double precision", nullable: true),
                    SrelValue = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultEjectLoadS2Bs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultMainLoadS1Bs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    RecipeName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Revolution = table.Column<long>(type: "bigint", nullable: true),
                    P1 = table.Column<double>(type: "double precision", nullable: true),
                    P2 = table.Column<double>(type: "double precision", nullable: true),
                    P3 = table.Column<double>(type: "double precision", nullable: true),
                    P4 = table.Column<double>(type: "double precision", nullable: true),
                    P5 = table.Column<double>(type: "double precision", nullable: true),
                    P6 = table.Column<double>(type: "double precision", nullable: true),
                    P7 = table.Column<double>(type: "double precision", nullable: true),
                    P8 = table.Column<double>(type: "double precision", nullable: true),
                    P9 = table.Column<double>(type: "double precision", nullable: true),
                    P10 = table.Column<double>(type: "double precision", nullable: true),
                    P11 = table.Column<double>(type: "double precision", nullable: true),
                    P12 = table.Column<double>(type: "double precision", nullable: true),
                    P13 = table.Column<double>(type: "double precision", nullable: true),
                    P14 = table.Column<double>(type: "double precision", nullable: true),
                    P15 = table.Column<double>(type: "double precision", nullable: true),
                    P16 = table.Column<double>(type: "double precision", nullable: true),
                    P17 = table.Column<double>(type: "double precision", nullable: true),
                    P18 = table.Column<double>(type: "double precision", nullable: true),
                    P19 = table.Column<double>(type: "double precision", nullable: true),
                    P20 = table.Column<double>(type: "double precision", nullable: true),
                    P21 = table.Column<double>(type: "double precision", nullable: true),
                    P22 = table.Column<double>(type: "double precision", nullable: true),
                    P23 = table.Column<double>(type: "double precision", nullable: true),
                    P24 = table.Column<double>(type: "double precision", nullable: true),
                    P25 = table.Column<double>(type: "double precision", nullable: true),
                    P26 = table.Column<double>(type: "double precision", nullable: true),
                    P27 = table.Column<double>(type: "double precision", nullable: true),
                    P28 = table.Column<double>(type: "double precision", nullable: true),
                    P29 = table.Column<double>(type: "double precision", nullable: true),
                    P30 = table.Column<double>(type: "double precision", nullable: true),
                    P31 = table.Column<double>(type: "double precision", nullable: true),
                    P32 = table.Column<double>(type: "double precision", nullable: true),
                    P33 = table.Column<double>(type: "double precision", nullable: true),
                    P34 = table.Column<double>(type: "double precision", nullable: true),
                    P35 = table.Column<double>(type: "double precision", nullable: true),
                    P36 = table.Column<double>(type: "double precision", nullable: true),
                    P37 = table.Column<double>(type: "double precision", nullable: true),
                    P38 = table.Column<double>(type: "double precision", nullable: true),
                    P39 = table.Column<double>(type: "double precision", nullable: true),
                    P40 = table.Column<double>(type: "double precision", nullable: true),
                    P41 = table.Column<double>(type: "double precision", nullable: true),
                    P42 = table.Column<double>(type: "double precision", nullable: true),
                    P43 = table.Column<double>(type: "double precision", nullable: true),
                    P44 = table.Column<double>(type: "double precision", nullable: true),
                    P45 = table.Column<double>(type: "double precision", nullable: true),
                    P46 = table.Column<double>(type: "double precision", nullable: true),
                    P47 = table.Column<double>(type: "double precision", nullable: true),
                    P48 = table.Column<double>(type: "double precision", nullable: true),
                    P49 = table.Column<double>(type: "double precision", nullable: true),
                    P50 = table.Column<double>(type: "double precision", nullable: true),
                    P51 = table.Column<double>(type: "double precision", nullable: true),
                    P52 = table.Column<double>(type: "double precision", nullable: true),
                    P53 = table.Column<double>(type: "double precision", nullable: true),
                    P54 = table.Column<double>(type: "double precision", nullable: true),
                    P55 = table.Column<double>(type: "double precision", nullable: true),
                    P56 = table.Column<double>(type: "double precision", nullable: true),
                    P57 = table.Column<double>(type: "double precision", nullable: true),
                    P58 = table.Column<double>(type: "double precision", nullable: true),
                    P59 = table.Column<double>(type: "double precision", nullable: true),
                    P60 = table.Column<double>(type: "double precision", nullable: true),
                    P61 = table.Column<double>(type: "double precision", nullable: true),
                    P62 = table.Column<double>(type: "double precision", nullable: true),
                    P63 = table.Column<double>(type: "double precision", nullable: true),
                    P64 = table.Column<double>(type: "double precision", nullable: true),
                    P65 = table.Column<double>(type: "double precision", nullable: true),
                    AverageLoad = table.Column<double>(type: "double precision", nullable: true),
                    TurretSpeed = table.Column<double>(type: "double precision", nullable: true),
                    S1FeederSpeed = table.Column<double>(type: "double precision", nullable: true),
                    S2FeederSpeed = table.Column<double>(type: "double precision", nullable: true),
                    SrelValue = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultMainLoadS1Bs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultMainLoadS2Bs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    RecipeName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Revolution = table.Column<long>(type: "bigint", nullable: true),
                    P1 = table.Column<double>(type: "double precision", nullable: true),
                    P2 = table.Column<double>(type: "double precision", nullable: true),
                    P3 = table.Column<double>(type: "double precision", nullable: true),
                    P4 = table.Column<double>(type: "double precision", nullable: true),
                    P5 = table.Column<double>(type: "double precision", nullable: true),
                    P6 = table.Column<double>(type: "double precision", nullable: true),
                    P7 = table.Column<double>(type: "double precision", nullable: true),
                    P8 = table.Column<double>(type: "double precision", nullable: true),
                    P9 = table.Column<double>(type: "double precision", nullable: true),
                    P10 = table.Column<double>(type: "double precision", nullable: true),
                    P11 = table.Column<double>(type: "double precision", nullable: true),
                    P12 = table.Column<double>(type: "double precision", nullable: true),
                    P13 = table.Column<double>(type: "double precision", nullable: true),
                    P14 = table.Column<double>(type: "double precision", nullable: true),
                    P15 = table.Column<double>(type: "double precision", nullable: true),
                    P16 = table.Column<double>(type: "double precision", nullable: true),
                    P17 = table.Column<double>(type: "double precision", nullable: true),
                    P18 = table.Column<double>(type: "double precision", nullable: true),
                    P19 = table.Column<double>(type: "double precision", nullable: true),
                    P20 = table.Column<double>(type: "double precision", nullable: true),
                    P21 = table.Column<double>(type: "double precision", nullable: true),
                    P22 = table.Column<double>(type: "double precision", nullable: true),
                    P23 = table.Column<double>(type: "double precision", nullable: true),
                    P24 = table.Column<double>(type: "double precision", nullable: true),
                    P25 = table.Column<double>(type: "double precision", nullable: true),
                    P26 = table.Column<double>(type: "double precision", nullable: true),
                    P27 = table.Column<double>(type: "double precision", nullable: true),
                    P28 = table.Column<double>(type: "double precision", nullable: true),
                    P29 = table.Column<double>(type: "double precision", nullable: true),
                    P30 = table.Column<double>(type: "double precision", nullable: true),
                    P31 = table.Column<double>(type: "double precision", nullable: true),
                    P32 = table.Column<double>(type: "double precision", nullable: true),
                    P33 = table.Column<double>(type: "double precision", nullable: true),
                    P34 = table.Column<double>(type: "double precision", nullable: true),
                    P35 = table.Column<double>(type: "double precision", nullable: true),
                    P36 = table.Column<double>(type: "double precision", nullable: true),
                    P37 = table.Column<double>(type: "double precision", nullable: true),
                    P38 = table.Column<double>(type: "double precision", nullable: true),
                    P39 = table.Column<double>(type: "double precision", nullable: true),
                    P40 = table.Column<double>(type: "double precision", nullable: true),
                    P41 = table.Column<double>(type: "double precision", nullable: true),
                    P42 = table.Column<double>(type: "double precision", nullable: true),
                    P43 = table.Column<double>(type: "double precision", nullable: true),
                    P44 = table.Column<double>(type: "double precision", nullable: true),
                    P45 = table.Column<double>(type: "double precision", nullable: true),
                    P46 = table.Column<double>(type: "double precision", nullable: true),
                    P47 = table.Column<double>(type: "double precision", nullable: true),
                    P48 = table.Column<double>(type: "double precision", nullable: true),
                    P49 = table.Column<double>(type: "double precision", nullable: true),
                    P50 = table.Column<double>(type: "double precision", nullable: true),
                    P51 = table.Column<double>(type: "double precision", nullable: true),
                    P52 = table.Column<double>(type: "double precision", nullable: true),
                    P53 = table.Column<double>(type: "double precision", nullable: true),
                    P54 = table.Column<double>(type: "double precision", nullable: true),
                    P55 = table.Column<double>(type: "double precision", nullable: true),
                    P56 = table.Column<double>(type: "double precision", nullable: true),
                    P57 = table.Column<double>(type: "double precision", nullable: true),
                    P58 = table.Column<double>(type: "double precision", nullable: true),
                    P59 = table.Column<double>(type: "double precision", nullable: true),
                    P60 = table.Column<double>(type: "double precision", nullable: true),
                    P61 = table.Column<double>(type: "double precision", nullable: true),
                    P62 = table.Column<double>(type: "double precision", nullable: true),
                    P63 = table.Column<double>(type: "double precision", nullable: true),
                    P64 = table.Column<double>(type: "double precision", nullable: true),
                    P65 = table.Column<double>(type: "double precision", nullable: true),
                    AverageLoad = table.Column<double>(type: "double precision", nullable: true),
                    TurretSpeed = table.Column<double>(type: "double precision", nullable: true),
                    S1FeederSpeed = table.Column<double>(type: "double precision", nullable: true),
                    S2FeederSpeed = table.Column<double>(type: "double precision", nullable: true),
                    SrelValue = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultMainLoadS2Bs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultMainSrelS1Bs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    TabletQtyS1 = table.Column<double>(type: "double precision", nullable: true),
                    AverageS1 = table.Column<double>(type: "double precision", nullable: true),
                    SrelValueS1 = table.Column<double>(type: "double precision", nullable: true),
                    TurretSpeed = table.Column<double>(type: "double precision", nullable: true),
                    FeederSpeedS1 = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultMainSrelS1Bs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultMainSrelS2Bs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    TabletQtyS2 = table.Column<double>(type: "double precision", nullable: true),
                    AverageS2 = table.Column<double>(type: "double precision", nullable: true),
                    SrelValueS2 = table.Column<double>(type: "double precision", nullable: true),
                    TurretSpeed = table.Column<double>(type: "double precision", nullable: true),
                    FeederSpeedS2 = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultMainSrelS2Bs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultPreLoadS1Bs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    RecipeName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Revolution = table.Column<long>(type: "bigint", nullable: true),
                    P1 = table.Column<double>(type: "double precision", nullable: true),
                    P2 = table.Column<double>(type: "double precision", nullable: true),
                    P3 = table.Column<double>(type: "double precision", nullable: true),
                    P4 = table.Column<double>(type: "double precision", nullable: true),
                    P5 = table.Column<double>(type: "double precision", nullable: true),
                    P6 = table.Column<double>(type: "double precision", nullable: true),
                    P7 = table.Column<double>(type: "double precision", nullable: true),
                    P8 = table.Column<double>(type: "double precision", nullable: true),
                    P9 = table.Column<double>(type: "double precision", nullable: true),
                    P10 = table.Column<double>(type: "double precision", nullable: true),
                    P11 = table.Column<double>(type: "double precision", nullable: true),
                    P12 = table.Column<double>(type: "double precision", nullable: true),
                    P13 = table.Column<double>(type: "double precision", nullable: true),
                    P14 = table.Column<double>(type: "double precision", nullable: true),
                    P15 = table.Column<double>(type: "double precision", nullable: true),
                    P16 = table.Column<double>(type: "double precision", nullable: true),
                    P17 = table.Column<double>(type: "double precision", nullable: true),
                    P18 = table.Column<double>(type: "double precision", nullable: true),
                    P19 = table.Column<double>(type: "double precision", nullable: true),
                    P20 = table.Column<double>(type: "double precision", nullable: true),
                    P21 = table.Column<double>(type: "double precision", nullable: true),
                    P22 = table.Column<double>(type: "double precision", nullable: true),
                    P23 = table.Column<double>(type: "double precision", nullable: true),
                    P24 = table.Column<double>(type: "double precision", nullable: true),
                    P25 = table.Column<double>(type: "double precision", nullable: true),
                    P26 = table.Column<double>(type: "double precision", nullable: true),
                    P27 = table.Column<double>(type: "double precision", nullable: true),
                    P28 = table.Column<double>(type: "double precision", nullable: true),
                    P29 = table.Column<double>(type: "double precision", nullable: true),
                    P30 = table.Column<double>(type: "double precision", nullable: true),
                    P31 = table.Column<double>(type: "double precision", nullable: true),
                    P32 = table.Column<double>(type: "double precision", nullable: true),
                    P33 = table.Column<double>(type: "double precision", nullable: true),
                    P34 = table.Column<double>(type: "double precision", nullable: true),
                    P35 = table.Column<double>(type: "double precision", nullable: true),
                    P36 = table.Column<double>(type: "double precision", nullable: true),
                    P37 = table.Column<double>(type: "double precision", nullable: true),
                    P38 = table.Column<double>(type: "double precision", nullable: true),
                    P39 = table.Column<double>(type: "double precision", nullable: true),
                    P40 = table.Column<double>(type: "double precision", nullable: true),
                    P41 = table.Column<double>(type: "double precision", nullable: true),
                    P42 = table.Column<double>(type: "double precision", nullable: true),
                    P43 = table.Column<double>(type: "double precision", nullable: true),
                    P44 = table.Column<double>(type: "double precision", nullable: true),
                    P45 = table.Column<double>(type: "double precision", nullable: true),
                    P46 = table.Column<double>(type: "double precision", nullable: true),
                    P47 = table.Column<double>(type: "double precision", nullable: true),
                    P48 = table.Column<double>(type: "double precision", nullable: true),
                    P49 = table.Column<double>(type: "double precision", nullable: true),
                    P50 = table.Column<double>(type: "double precision", nullable: true),
                    P51 = table.Column<double>(type: "double precision", nullable: true),
                    P52 = table.Column<double>(type: "double precision", nullable: true),
                    P53 = table.Column<double>(type: "double precision", nullable: true),
                    P54 = table.Column<double>(type: "double precision", nullable: true),
                    P55 = table.Column<double>(type: "double precision", nullable: true),
                    P56 = table.Column<double>(type: "double precision", nullable: true),
                    P57 = table.Column<double>(type: "double precision", nullable: true),
                    P58 = table.Column<double>(type: "double precision", nullable: true),
                    P59 = table.Column<double>(type: "double precision", nullable: true),
                    P60 = table.Column<double>(type: "double precision", nullable: true),
                    P61 = table.Column<double>(type: "double precision", nullable: true),
                    P62 = table.Column<double>(type: "double precision", nullable: true),
                    P63 = table.Column<double>(type: "double precision", nullable: true),
                    P64 = table.Column<double>(type: "double precision", nullable: true),
                    P65 = table.Column<double>(type: "double precision", nullable: true),
                    AverageLoad = table.Column<double>(type: "double precision", nullable: true),
                    TurretSpeed = table.Column<double>(type: "double precision", nullable: true),
                    S1FeederSpeed = table.Column<double>(type: "double precision", nullable: true),
                    S2FeederSpeed = table.Column<double>(type: "double precision", nullable: true),
                    SrelValue = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultPreLoadS1Bs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultPreLoadS2Bs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    RecipeName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Revolution = table.Column<long>(type: "bigint", nullable: true),
                    P1 = table.Column<double>(type: "double precision", nullable: true),
                    P2 = table.Column<double>(type: "double precision", nullable: true),
                    P3 = table.Column<double>(type: "double precision", nullable: true),
                    P4 = table.Column<double>(type: "double precision", nullable: true),
                    P5 = table.Column<double>(type: "double precision", nullable: true),
                    P6 = table.Column<double>(type: "double precision", nullable: true),
                    P7 = table.Column<double>(type: "double precision", nullable: true),
                    P8 = table.Column<double>(type: "double precision", nullable: true),
                    P9 = table.Column<double>(type: "double precision", nullable: true),
                    P10 = table.Column<double>(type: "double precision", nullable: true),
                    P11 = table.Column<double>(type: "double precision", nullable: true),
                    P12 = table.Column<double>(type: "double precision", nullable: true),
                    P13 = table.Column<double>(type: "double precision", nullable: true),
                    P14 = table.Column<double>(type: "double precision", nullable: true),
                    P15 = table.Column<double>(type: "double precision", nullable: true),
                    P16 = table.Column<double>(type: "double precision", nullable: true),
                    P17 = table.Column<double>(type: "double precision", nullable: true),
                    P18 = table.Column<double>(type: "double precision", nullable: true),
                    P19 = table.Column<double>(type: "double precision", nullable: true),
                    P20 = table.Column<double>(type: "double precision", nullable: true),
                    P21 = table.Column<double>(type: "double precision", nullable: true),
                    P22 = table.Column<double>(type: "double precision", nullable: true),
                    P23 = table.Column<double>(type: "double precision", nullable: true),
                    P24 = table.Column<double>(type: "double precision", nullable: true),
                    P25 = table.Column<double>(type: "double precision", nullable: true),
                    P26 = table.Column<double>(type: "double precision", nullable: true),
                    P27 = table.Column<double>(type: "double precision", nullable: true),
                    P28 = table.Column<double>(type: "double precision", nullable: true),
                    P29 = table.Column<double>(type: "double precision", nullable: true),
                    P30 = table.Column<double>(type: "double precision", nullable: true),
                    P31 = table.Column<double>(type: "double precision", nullable: true),
                    P32 = table.Column<double>(type: "double precision", nullable: true),
                    P33 = table.Column<double>(type: "double precision", nullable: true),
                    P34 = table.Column<double>(type: "double precision", nullable: true),
                    P35 = table.Column<double>(type: "double precision", nullable: true),
                    P36 = table.Column<double>(type: "double precision", nullable: true),
                    P37 = table.Column<double>(type: "double precision", nullable: true),
                    P38 = table.Column<double>(type: "double precision", nullable: true),
                    P39 = table.Column<double>(type: "double precision", nullable: true),
                    P40 = table.Column<double>(type: "double precision", nullable: true),
                    P41 = table.Column<double>(type: "double precision", nullable: true),
                    P42 = table.Column<double>(type: "double precision", nullable: true),
                    P43 = table.Column<double>(type: "double precision", nullable: true),
                    P44 = table.Column<double>(type: "double precision", nullable: true),
                    P45 = table.Column<double>(type: "double precision", nullable: true),
                    P46 = table.Column<double>(type: "double precision", nullable: true),
                    P47 = table.Column<double>(type: "double precision", nullable: true),
                    P48 = table.Column<double>(type: "double precision", nullable: true),
                    P49 = table.Column<double>(type: "double precision", nullable: true),
                    P50 = table.Column<double>(type: "double precision", nullable: true),
                    P51 = table.Column<double>(type: "double precision", nullable: true),
                    P52 = table.Column<double>(type: "double precision", nullable: true),
                    P53 = table.Column<double>(type: "double precision", nullable: true),
                    P54 = table.Column<double>(type: "double precision", nullable: true),
                    P55 = table.Column<double>(type: "double precision", nullable: true),
                    P56 = table.Column<double>(type: "double precision", nullable: true),
                    P57 = table.Column<double>(type: "double precision", nullable: true),
                    P58 = table.Column<double>(type: "double precision", nullable: true),
                    P59 = table.Column<double>(type: "double precision", nullable: true),
                    P60 = table.Column<double>(type: "double precision", nullable: true),
                    P61 = table.Column<double>(type: "double precision", nullable: true),
                    P62 = table.Column<double>(type: "double precision", nullable: true),
                    P63 = table.Column<double>(type: "double precision", nullable: true),
                    P64 = table.Column<double>(type: "double precision", nullable: true),
                    P65 = table.Column<double>(type: "double precision", nullable: true),
                    AverageLoad = table.Column<double>(type: "double precision", nullable: true),
                    TurretSpeed = table.Column<double>(type: "double precision", nullable: true),
                    S1FeederSpeed = table.Column<double>(type: "double precision", nullable: true),
                    S2FeederSpeed = table.Column<double>(type: "double precision", nullable: true),
                    SrelValue = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultPreLoadS2Bs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServoCalibrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Axis1Position = table.Column<double>(type: "double precision", nullable: true),
                    Axis2Position = table.Column<double>(type: "double precision", nullable: true),
                    Axis3Position = table.Column<double>(type: "double precision", nullable: true),
                    Axis4Position = table.Column<double>(type: "double precision", nullable: true),
                    Axis5Position = table.Column<double>(type: "double precision", nullable: true),
                    Axis6Position = table.Column<double>(type: "double precision", nullable: true),
                    Axis7Position = table.Column<double>(type: "double precision", nullable: true),
                    Axis8Position = table.Column<double>(type: "double precision", nullable: true),
                    Axis9Position = table.Column<double>(type: "double precision", nullable: true),
                    Axis10Position = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServoCalibrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginHistroys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EReventType = table.Column<string>(type: "text", nullable: true),
                    ERname = table.Column<string>(type: "text", nullable: true),
                    ERdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ERlevel = table.Column<string>(type: "text", nullable: true),
                    UserStatus = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginHistroys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ERname = table.Column<string>(type: "text", nullable: true),
                    ERdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ERlevel = table.Column<string>(type: "text", nullable: true),
                    UserStatus = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserManagementHistroys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EReventType = table.Column<string>(type: "text", nullable: true),
                    ERid = table.Column<int>(type: "integer", nullable: true),
                    ERname = table.Column<string>(type: "text", nullable: true),
                    ERdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ERlevel = table.Column<string>(type: "text", nullable: true),
                    ERpassword = table.Column<string>(type: "text", nullable: true),
                    ERexpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserStatus = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserManagementHistroys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserManagements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ERid = table.Column<int>(type: "integer", nullable: true),
                    ERname = table.Column<string>(type: "text", nullable: true),
                    ERdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ERlevel = table.Column<string>(type: "text", nullable: true),
                    ERpassword = table.Column<string>(type: "text", nullable: true),
                    ERimage = table.Column<string>(type: "text", nullable: true),
                    ERexpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserStatus = table.Column<bool>(type: "boolean", nullable: true),
                    ChangePw = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserManagements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PasswordExpiryDate = table.Column<int>(type: "integer", nullable: true),
                    NoOfWrongAttempt = table.Column<int>(type: "integer", nullable: true),
                    ApplicationLogout = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmLogs");

            migrationBuilder.DropTable(
                name: "AuditTrails");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "BatchHistories");

            migrationBuilder.DropTable(
                name: "CurrentBatches");

            migrationBuilder.DropTable(
                name: "PrivilageHistories");

            migrationBuilder.DropTable(
                name: "Privilages");

            migrationBuilder.DropTable(
                name: "RecipeHistroys");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "ResultEjectLoadS1Bs");

            migrationBuilder.DropTable(
                name: "ResultEjectLoadS2Bs");

            migrationBuilder.DropTable(
                name: "ResultMainLoadS1Bs");

            migrationBuilder.DropTable(
                name: "ResultMainLoadS2Bs");

            migrationBuilder.DropTable(
                name: "ResultMainSrelS1Bs");

            migrationBuilder.DropTable(
                name: "ResultMainSrelS2Bs");

            migrationBuilder.DropTable(
                name: "ResultPreLoadS1Bs");

            migrationBuilder.DropTable(
                name: "ResultPreLoadS2Bs");

            migrationBuilder.DropTable(
                name: "ServoCalibrations");

            migrationBuilder.DropTable(
                name: "UserLoginHistroys");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserManagementHistroys");

            migrationBuilder.DropTable(
                name: "UserManagements");

            migrationBuilder.DropTable(
                name: "UserSettings");
        }
    }
}
