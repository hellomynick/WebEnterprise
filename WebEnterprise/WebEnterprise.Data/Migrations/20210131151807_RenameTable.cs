using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEnterprise.Data.Migrations
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Megazines_ID",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Megazines");

            migrationBuilder.DropIndex(
                name: "IX_Documents_UserID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentID",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentCatelogorysID",
                table: "Documents",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Selecteds",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DocumentID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selecteds", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "22088324-c1e5-489e-a471-959b4e7423c7");

            migrationBuilder.InsertData(
                table: "Selecteds",
                columns: new[] { "ID", "DocumentID", "Name" },
                values: new object[,]
                {
                    { 1L, 0L, "Magazine Information Technology" },
                    { 2L, 0L, "Magazine Design" },
                    { 3L, 0L, "Magazine Business" },
                    { 4L, 0L, "Magazine Tourism" },
                    { 5L, 0L, "Magazine Information Technology" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d845352-9b2c-40ab-bfae-66b6cec15e5d", "AQAAAAEAACcQAAAAEBCjTOcOBxjysdP1tM7Wd63ffTlTzFiFHV2lc5cBbF0umUxzk2JxkCLtiV4Rip1vYA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DepartmentCatelogorysID",
                table: "Documents",
                column: "DepartmentCatelogorysID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UserID",
                table: "Documents",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DepartmentCatelogorys_DepartmentCatelogorysID",
                table: "Documents",
                column: "DepartmentCatelogorysID",
                principalTable: "DepartmentCatelogorys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Selecteds_ID",
                table: "Documents",
                column: "ID",
                principalTable: "Selecteds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DepartmentCatelogorys_DepartmentCatelogorysID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Selecteds_ID",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Selecteds");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DepartmentCatelogorysID",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_UserID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DepartmentCatelogorysID",
                table: "Documents");

            migrationBuilder.AddColumn<long>(
                name: "DocumentID",
                table: "Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Megazines",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Megazines", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "bfd4b872-223d-4306-80f7-05dfe881552c");

            migrationBuilder.InsertData(
                table: "Megazines",
                columns: new[] { "ID", "DocumentID", "Name" },
                values: new object[,]
                {
                    { 1L, 0L, "Magazine Information Technology" },
                    { 2L, 0L, "Magazine Design" },
                    { 3L, 0L, "Magazine Business" },
                    { 4L, 0L, "Magazine Tourism" },
                    { 5L, 0L, "Magazine Information Technology" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cf53790e-e5ae-440e-b3c6-f29f9e6330fd", "AQAAAAEAACcQAAAAEKOig9PeN+y77FvGGb8k4kAmYZUxZY20wa14yod3TMsv7yoWkw00KO3KHkPOu4BAPw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UserID",
                table: "Documents",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Megazines_ID",
                table: "Documents",
                column: "ID",
                principalTable: "Megazines",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
