
using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompressionForce.Data.Migrations
{
    public partial class Recreate_Recipes_Module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ===== Recipes =====
            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (SELECT 1 FROM information_schema.tables
                               WHERE table_schema = 'public' AND table_name = 'Recipes') THEN
                        DROP TABLE public.""Recipes"" CASCADE;
                    END IF;
                END $$;
            ");

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecipeCode = table.Column<string>(type: "text", nullable: false),
                    RecipeName = table.Column<string>(type: "text", nullable: false),
                    Parameters = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "[]")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeCode",
                table: "Recipes",
                column: "RecipeCode",
                unique: true
            );

            migrationBuilder.Sql(@"
                CREATE INDEX IF NOT EXISTS ""IX_Recipes_Parameters_GIN""
                ON public.""Recipes"" USING GIN (""Parameters"" jsonb_path_ops);
            ");

            // ===== RecipeHistories =====
            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (SELECT 1 FROM information_schema.tables
                               WHERE table_schema = 'public' AND table_name = 'RecipeHistories') THEN
                        DROP TABLE public.""RecipeHistories"" CASCADE;
                    END IF;
                END $$;
            ");

            migrationBuilder.CreateTable(
                name: "RecipeHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecipeCode = table.Column<string>(type: "text", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    ChangedBy = table.Column<string>(type: "text", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OldParameters = table.Column<string>(type: "jsonb", nullable: true),
                    NewParameters = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeHistories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeHistories_RecipeCode_ChangedAt",
                table: "RecipeHistories",
                columns: new[] { "RecipeCode", "ChangedAt" }
            );

            // ===== LookupValues =====
            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (SELECT 1 FROM information_schema.tables
                               WHERE table_schema = 'public' AND table_name = 'LookupValues') THEN
                        DROP TABLE public.""LookupValues"" CASCADE;
                    END IF;
                END $$;
            ");

            migrationBuilder.CreateTable(
                name: "LookupValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupValues", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookupValues_Category_Code",
                table: "LookupValues",
                columns: new[] { "Category", "Code" },
                unique: true
            );

            // ===== RecipeValidationRules (optional)
            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (SELECT 1 FROM information_schema.tables
                               WHERE table_schema = 'public' AND table_name = 'RecipeValidationRules') THEN
                        DROP TABLE public.""RecipeValidationRules"" CASCADE;
                    END IF;
                END $$;
            ");

            migrationBuilder.CreateTable(
                name: "RecipeValidationRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Required = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Min = table.Column<decimal>(type: "numeric", nullable: true),
                    Max = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxLength = table.Column<int>(type: "integer", nullable: true),
                    Regex = table.Column<string>(type: "text", nullable: true),
                    LookupCategory = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeValidationRules", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeValidationRules_Name",
                table: "RecipeValidationRules",
                column: "Name",
                unique: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "RecipeValidationRules");
            migrationBuilder.DropTable(name: "LookupValues");
            migrationBuilder.DropTable(name: "RecipeHistories");
            migrationBuilder.DropTable(name: "Recipes");
        }
    }
}
