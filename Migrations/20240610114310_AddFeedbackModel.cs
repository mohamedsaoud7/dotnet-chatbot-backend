using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chatbot_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddFeedbackModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pdc");

            migrationBuilder.EnsureSchema(
                name: "mdm");

            migrationBuilder.CreateTable(
                name: "DraftForms",
                columns: table => new
                {
                    DRF_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    DRF_TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    DRF_UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DRF_DraftName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DRF_DraftNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DRF_Json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DRF_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    DRF_CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DRF_LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    DRF_LastModifiedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftForms", x => x.DRF_Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalizableEntries",
                schema: "mdm",
                columns: table => new
                {
                    LLE_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    LLE_TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    LLE_LocalizableType_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LLE_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    LLE_CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LLE_LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    LLE_LastModifiedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizableEntries", x => x.LLE_Id);
                });

            migrationBuilder.CreateTable(
                name: "DamageReasons",
                schema: "pdc",
                columns: table => new
                {
                    DR_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    DR_TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    DR_Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DR_ShortName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DR_LongName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DR_Inactive = table.Column<bool>(type: "bit", nullable: false),
                    DR_LocalizableEntry_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DR_IsMain = table.Column<bool>(type: "bit", nullable: false),
                    DR_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    DR_CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DR_LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    DR_LastModifiedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageReasons", x => x.DR_Id);
                    table.ForeignKey(
                        name: "FK_DamageReasons_LocalizableEntries",
                        column: x => x.DR_LocalizableEntry_Id,
                        principalSchema: "mdm",
                        principalTable: "LocalizableEntries",
                        principalColumn: "LLE_Id");
                });

            migrationBuilder.CreateTable(
                name: "LocalizedEntries",
                schema: "mdm",
                columns: table => new
                {
                    LLC_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    LLC_TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    LLC_LocalizableEntry_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LLC_CultureCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LLC_ShortTranslation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LLC_LongTranslation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LLC_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    LLC_CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LLC_LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    LLC_LastModifiedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedEntries", x => x.LLC_Id);
                    table.ForeignKey(
                        name: "FK_LocalizedEntries_LocalizableEntries",
                        column: x => x.LLC_LocalizableEntry_Id,
                        principalSchema: "mdm",
                        principalTable: "LocalizableEntries",
                        principalColumn: "LLE_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DamageReasons_DR_LocalizableEntry_Id",
                schema: "pdc",
                table: "DamageReasons",
                column: "DR_LocalizableEntry_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DraftForms_UserName_DraftName_DraftNumber",
                table: "DraftForms",
                columns: new[] { "DRF_UserName", "DRF_DraftName", "DRF_DraftNumber" },
                unique: true,
                filter: "[DRF_DraftNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedEntries_LocalizableEntry_Id",
                schema: "mdm",
                table: "LocalizedEntries",
                column: "LLC_LocalizableEntry_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DamageReasons",
                schema: "pdc");

            migrationBuilder.DropTable(
                name: "DraftForms");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "LocalizedEntries",
                schema: "mdm");

            migrationBuilder.DropTable(
                name: "LocalizableEntries",
                schema: "mdm");
        }
    }
}
