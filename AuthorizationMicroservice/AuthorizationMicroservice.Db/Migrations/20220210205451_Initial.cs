using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorizationMicroservice.Db.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("3bc3bd5f-c0ed-4e4f-bfd4-bf3a94ee83af"), "Admin" },
                    { new Guid("c97736b5-a78e-48ce-9f42-4d5b823fb72d"), "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Login", "Password" },
                values: new object[,]
                {
                    { new Guid("21255c40-92e0-4084-b69c-8be4b86890bb"), "admin", "admin" },
                    { new Guid("059454e3-d89b-44ed-b0ec-4f3feecd227a"), "guest", "guest" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "ID", "RoleId", "UserId" },
                values: new object[] { new Guid("94b90977-7e77-4df0-9b27-72e03b715c34"), new Guid("3bc3bd5f-c0ed-4e4f-bfd4-bf3a94ee83af"), new Guid("21255c40-92e0-4084-b69c-8be4b86890bb") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "ID", "RoleId", "UserId" },
                values: new object[] { new Guid("217ccd1e-f256-4e83-9014-3c673059f83c"), new Guid("c97736b5-a78e-48ce-9f42-4d5b823fb72d"), new Guid("059454e3-d89b-44ed-b0ec-4f3feecd227a") });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
