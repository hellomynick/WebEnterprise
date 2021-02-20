using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WebEnterprise.Data.Migrations
{
    public partial class addnewtablelanguge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFile",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentPath",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Documents",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "75384f80-b661-4ec3-9c67-6964dfe29263");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "vi", true, "Tiếng Việt" },
                    { "en", false, "English" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6677d4f8-85b3-4dac-879c-2d9acc5dbda3", "AQAAAAEAACcQAAAAEGsQp67cxrGSoow8jiMrfnxGk8Yq3NmTQ2d/VHLIYzm5aR+w/J/o7rdHa7Kf4FCMhw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentPath",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Documents");

            migrationBuilder.AddColumn<byte[]>(
                name: "DataFile",
                table: "Documents",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "abac7402-b589-49ad-9ac2-9766760b55d3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bbee473a-7066-45fa-903d-289e396401ea", "AQAAAAEAACcQAAAAEGT2Ncep9ZimL2wd9LNsdwCZ6HbJcKWh3aVxuX9Q1hWM2x/4EaUEvXTWEXn78uXdyQ==" });
        }
    }
}
