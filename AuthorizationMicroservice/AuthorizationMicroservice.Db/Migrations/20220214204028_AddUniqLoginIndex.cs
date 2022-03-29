using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorizationMicroservice.Db.Migrations
{
    public partial class AddUniqLoginIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: new Guid("217ccd1e-f256-4e83-9014-3c673059f83c"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: new Guid("94b90977-7e77-4df0-9b27-72e03b715c34"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("3bc3bd5f-c0ed-4e4f-bfd4-bf3a94ee83af"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("c97736b5-a78e-48ce-9f42-4d5b823fb72d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("059454e3-d89b-44ed-b0ec-4f3feecd227a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("21255c40-92e0-4084-b69c-8be4b86890bb"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("cf34f038-c26f-4579-8fd9-1eaa66a6f727"), "Admin" },
                    { new Guid("a896256c-ce78-4010-b8be-335737cfc787"), "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Login", "Password" },
                values: new object[,]
                {
                    { new Guid("ce06ee28-912b-4fa6-bd2c-9583aca76115"), "admin", "admin" },
                    { new Guid("d2a10481-6fa2-45f0-bd42-5182d4fb24c3"), "guest", "guest" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "ID", "RoleId", "UserId" },
                values: new object[] { new Guid("0d2fd55f-e672-40e1-8d00-9c5b8a933458"), new Guid("cf34f038-c26f-4579-8fd9-1eaa66a6f727"), new Guid("ce06ee28-912b-4fa6-bd2c-9583aca76115") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "ID", "RoleId", "UserId" },
                values: new object[] { new Guid("80455e73-a751-4a9d-9596-5c8f61b6a71b"), new Guid("a896256c-ce78-4010-b8be-335737cfc787"), new Guid("d2a10481-6fa2-45f0-bd42-5182d4fb24c3") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: new Guid("0d2fd55f-e672-40e1-8d00-9c5b8a933458"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: new Guid("80455e73-a751-4a9d-9596-5c8f61b6a71b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("a896256c-ce78-4010-b8be-335737cfc787"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("cf34f038-c26f-4579-8fd9-1eaa66a6f727"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("ce06ee28-912b-4fa6-bd2c-9583aca76115"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("d2a10481-6fa2-45f0-bd42-5182d4fb24c3"));

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
        }
    }
}
