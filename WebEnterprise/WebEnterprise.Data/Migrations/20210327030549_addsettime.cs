using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEnterprise.Data.Migrations
{
    public partial class addsettime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Language",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Language",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SetTimeSystem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDay = table.Column<DateTime>(nullable: false),
                    EndDay = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetTimeSystem", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetTimeSystem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Languages",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "bf27b050-76ee-4363-9b06-526c5dcea544");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b766c89-0a9a-400f-a969-cac72ebf08a4", "AQAAAAEAACcQAAAAENABOOtJzrjcpYVOeXyaRhTU2atjJMlzsJrXVSWbvEkjx4KfApvl2FBoIm1iZ6ruag==" });
        }
    }
}
