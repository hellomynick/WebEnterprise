using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEnterprise.Data.Migrations
{
    public partial class deleteingrouptable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "e4d2421e-f50d-4c0f-8f7c-7bbcf030b90d");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "954551e0-9106-4cca-8a99-c6b298b0218e", "AQAAAAEAACcQAAAAEN9DGjtCeLKXoy+kv6LGSYc+/YXqv/pkVhUVpAvpmRAEuaA5kEWx0hS9+SHQ14jUew==" });
        }
    }
}
