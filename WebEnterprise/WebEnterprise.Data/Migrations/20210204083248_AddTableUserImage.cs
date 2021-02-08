using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEnterprise.Data.Migrations
{
    public partial class AddTableUserImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Contacts");

            migrationBuilder.CreateTable(
                name: "UserImage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactID = table.Column<long>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DayCreated = table.Column<DateTime>(nullable: false),
                    FileSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserImage_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "1016ab92-315a-459e-92f0-6780af90c71f");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75f1bf52-0548-41bb-a874-9779dcb52589", "AQAAAAEAACcQAAAAEKgLPEGZl0ZRSB87/+wHFuHHW54+3NDG5bJExIdJO3LGfWcE4SgCwALKA3P78pa0jA==" });

            migrationBuilder.CreateIndex(
                name: "IX_UserImage_ContactID",
                table: "UserImage",
                column: "ContactID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserImage");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Contacts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "GroupUsers",
                keyColumn: "Id",
                keyValue: new Guid("9936b153-37a9-41d8-9781-f0532c25e732"),
                column: "ConcurrencyStamp",
                value: "8e7b7ada-68a6-4260-8ea3-0c3bcd26a920");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a92934ce-dcd5-486e-a3e4-6441382ecf61", "AQAAAAEAACcQAAAAEHs5MSOw9fRQSt3I/79qFB5C4n1M2jNEnijlCAeQLMI4o4y76qscuOW4A9ObrBs8MA==" });
        }
    }
}
