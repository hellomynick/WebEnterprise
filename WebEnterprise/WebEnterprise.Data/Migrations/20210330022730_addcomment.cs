using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEnterprise.Data.Migrations
{
    public partial class addcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<Guid>(nullable: true),
                    DocumentID = table.Column<long>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "Documents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "8040a957-5d42-4144-a3f8-5e5f6ab88b5e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "847e80e9-b5ce-4b07-ac30-9f660d590e94", "AQAAAAEAACcQAAAAEJn649+eKBeYCokkaRBvnDLy3CyGc8es2scdIMJ0TFOJVEsr++Z1IczPV+wsjuBnBg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DocumentID",
                table: "Comments",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "d3eddad3-4115-40e1-a7cb-9a7d7dd0ac39");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "29237c70-7d25-4797-a8b6-56c231012088", "AQAAAAEAACcQAAAAEG/ARnbM6mPwqZ8KXWXuVMXXcCmgprSw1T3pflQxpy8cCkiZx9Ws8BbcVS3yXknhIQ==" });
        }
    }
}
