using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEnterprise.Data.Migrations
{
    public partial class changepassadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "75384f80-b661-4ec3-9c67-6964dfe29263");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6677d4f8-85b3-4dac-879c-2d9acc5dbda3", "AQAAAAEAACcQAAAAEGsQp67cxrGSoow8jiMrfnxGk8Yq3NmTQ2d/VHLIYzm5aR+w/J/o7rdHa7Kf4FCMhw==" });
        }
    }
}
