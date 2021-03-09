using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEnterprise.Data.Migrations
{
    public partial class changListDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documents_FacultyOfDocumentID",
                table: "Documents");

            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "83e8b8ce-57ae-41e0-8bc9-c2b5ba5e4b48");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "73e0f1fb-817f-4aa4-b983-492ff7d42020", "AQAAAAEAACcQAAAAENkOvV39z6YoF+NFuKlHK93cl2BKwYcd6INbXlL71MWTCXH4HrXsvFn+pZZHUyzU0A==" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FacultyOfDocumentID",
                table: "Documents",
                column: "FacultyOfDocumentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documents_FacultyOfDocumentID",
                table: "Documents");

            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "6d157f2c-717f-4b65-bd3d-6860847c9308");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5bcce0f3-522d-4bb4-a396-cf943384b066", "AQAAAAEAACcQAAAAEFeT7Ht7mp1yIZn9DyStX2UPMCgEAOr9uz31PAQ4exUE3Pe169VpEc6n5dxXBU+Y1g==" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FacultyOfDocumentID",
                table: "Documents",
                column: "FacultyOfDocumentID",
                unique: true);
        }
    }
}
