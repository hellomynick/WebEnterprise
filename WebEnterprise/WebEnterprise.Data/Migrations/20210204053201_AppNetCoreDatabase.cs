using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEnterprise.Data.Migrations
{
    public partial class AppNetCoreDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserToken", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    NameStreet = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    TotalofDocument = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Magazines",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazines", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FacultyOfDocument",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FacultyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyOfDocument", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FacultyOfDocument_Faculty_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<bool>(nullable: false),
                    FacultyID = table.Column<int>(nullable: false),
                    ContactID = table.Column<long>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Faculty_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: false),
                    FileType = table.Column<string>(nullable: true),
                    DataFile = table.Column<byte[]>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    MagazineID = table.Column<int>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    FacultyOfDocumentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Documents_FacultyOfDocument_FacultyOfDocumentID",
                        column: x => x.FacultyOfDocumentID,
                        principalTable: "FacultyOfDocument",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Magazines_MagazineID",
                        column: x => x.MagazineID,
                        principalTable: "Magazines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYears",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<Guid>(nullable: false),
                    StartDayYear = table.Column<DateTime>(nullable: false),
                    EndDayYear = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYears", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SchoolYears_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"), new Guid("9936b153-37a9-41d8-9781-f0532c25e732") });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "ApartmentNumber", "Image", "NameStreet", "TotalofDocument" },
                values: new object[] { 1L, "04", null, "Doan Uan", 0 });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "Design" },
                    { 3, "Business" },
                    { 4, "Tourism" }
                });

            migrationBuilder.InsertData(
                table: "GroupUsers",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("9936b153-37a9-41d8-9781-f0532c25e732"), "8e7b7ada-68a6-4260-8ea3-0c3bcd26a920", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Magazines",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Magazine Information Technology" },
                    { 2, "Magazine Design" },
                    { 3, "Magazine Business" },
                    { 4, "Magazine Tourism" },
                    { 5, "Magazine Information Technology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ContactID", "CreateOn", "DateOfBirth", "Email", "EmailConfirmed", "FacultyID", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a0626e5f-0945-425c-9135-421ce9ffd4a1"), 0, "a92934ce-dcd5-486e-a3e4-6441382ecf61", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "minhvu09033@gmail.com", true, 1, "Tran Van", "Minh Vu", false, null, "minhvu09033@gmail.com", "admin", "AQAAAAEAACcQAAAAEHs5MSOw9fRQSt3I/79qFB5C4n1M2jNEnijlCAeQLMI4o4y76qscuOW4A9ObrBs8MA==", null, false, "", false, false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FacultyOfDocumentID",
                table: "Documents",
                column: "FacultyOfDocumentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_MagazineID",
                table: "Documents",
                column: "MagazineID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UserID",
                table: "Documents",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyOfDocument_FacultyID",
                table: "FacultyOfDocument",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolYears_UserID",
                table: "SchoolYears",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ContactID",
                table: "Users",
                column: "ContactID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacultyID",
                table: "Users",
                column: "FacultyID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaim");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserToken");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.DropTable(
                name: "SchoolYears");

            migrationBuilder.DropTable(
                name: "FacultyOfDocument");

            migrationBuilder.DropTable(
                name: "Magazines");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
