using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseMicroservice.Db.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Signature = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                });
            
            migrationBuilder.CreateTable(
                name: "CourseEmployees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEmployees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseEmployees_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Duration", "IsDeleted", "Signature" },
                values: new object[] { 1, 6, false, ".NET" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Duration", "IsDeleted", "Signature" },
                values: new object[] { 2, 6, false, "Java" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Duration", "IsDeleted", "Signature" },
                values: new object[] { 3, 1, false, "SQL" });

            migrationBuilder.InsertData(
                table: "CourseEmployees",
                columns: new[] { "ID", "CourseId", "EmployeeId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "CourseEmployees",
                columns: new[] { "ID", "CourseId", "EmployeeId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEmployees_CourseId",
                table: "CourseEmployees",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEmployees_EmployeeId",
                table: "CourseEmployees",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEmployees");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
