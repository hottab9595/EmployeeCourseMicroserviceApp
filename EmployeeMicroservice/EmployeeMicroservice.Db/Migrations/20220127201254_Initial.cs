using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeMicroservice.Db.Migrations
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
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Signature = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[,]
                {
                    { 1, 6, false, ".NET" },
                    { 2, 6, false, "Java" },
                    { 3, 1, false, "SQL" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "IsDeleted", "ParentID", "Signature" },
                values: new object[,]
                {
                    { 1, false, null, "Developers" },
                    { 2, false, null, "Administration" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "IsDeleted", "ParentID", "Signature" },
                values: new object[] { 3, false, 1, "HR department" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "DepartmentID", "IsDeleted", "Name", "Patronymic", "Surname" },
                values: new object[] { 1, 1, false, "Egor", "Viktotovich", "Koshel" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "DepartmentID", "IsDeleted", "Name", "Patronymic", "Surname" },
                values: new object[] { 2, 2, false, "TestName", "TestPatronymic", "TestSurname" });

            migrationBuilder.InsertData(
                table: "CourseEmployees",
                columns: new[] { "ID", "CourseId", "EmployeeId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "CourseEmployees",
                columns: new[] { "ID", "CourseId", "EmployeeId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "DepartmentID", "IsDeleted", "Name", "Patronymic", "Surname" },
                values: new object[] { 3, 3, false, "TestName1", "TestPatronymic1", "TestSurname1" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEmployees_CourseId",
                table: "CourseEmployees",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEmployees_EmployeeId",
                table: "CourseEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentID",
                table: "Departments",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEmployees");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
