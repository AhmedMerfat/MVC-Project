using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    DepartmentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerSsn = table.Column<int>(type: "int", nullable: true),
                    ManagerStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DepartmentNumber);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Ssn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    SupuervisorSsn = table.Column<int>(type: "int", nullable: true),
                    DepartmentNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Ssn);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_SupuervisorSsn",
                        column: x => x.SupuervisorSsn,
                        principalTable: "Employees",
                        principalColumn: "Ssn");
                    table.ForeignKey(
                        name: "FK_Employees_departments_DepartmentNumber",
                        column: x => x.DepartmentNumber,
                        principalTable: "departments",
                        principalColumn: "DepartmentNumber");
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjectNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.ProjectNumber);
                    table.ForeignKey(
                        name: "FK_projects_departments_DepartmentNumber",
                        column: x => x.DepartmentNumber,
                        principalTable: "departments",
                        principalColumn: "DepartmentNumber");
                });

            migrationBuilder.CreateTable(
                name: "dependents",
                columns: table => new
                {
                    EmployeeSsn = table.Column<int>(type: "int", nullable: false),
                    DependentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dependents", x => new { x.EmployeeSsn, x.DependentName });
                    table.ForeignKey(
                        name: "FK_dependents_Employees_EmployeeSsn",
                        column: x => x.EmployeeSsn,
                        principalTable: "Employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "worksOns",
                columns: table => new
                {
                    EmployeeSsn = table.Column<int>(type: "int", nullable: false),
                    ProjectNumber = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_worksOns", x => new { x.EmployeeSsn, x.ProjectNumber });
                    table.ForeignKey(
                        name: "FK_worksOns_Employees_EmployeeSsn",
                        column: x => x.EmployeeSsn,
                        principalTable: "Employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_worksOns_projects_ProjectNumber",
                        column: x => x.ProjectNumber,
                        principalTable: "projects",
                        principalColumn: "ProjectNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departments_ManagerSsn",
                table: "departments",
                column: "ManagerSsn");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentNumber",
                table: "Employees",
                column: "DepartmentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SupuervisorSsn",
                table: "Employees",
                column: "SupuervisorSsn");

            migrationBuilder.CreateIndex(
                name: "IX_projects_DepartmentNumber",
                table: "projects",
                column: "DepartmentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_worksOns_ProjectNumber",
                table: "worksOns",
                column: "ProjectNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Employees_ManagerSsn",
                table: "departments",
                column: "ManagerSsn",
                principalTable: "Employees",
                principalColumn: "Ssn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_Employees_ManagerSsn",
                table: "departments");

            migrationBuilder.DropTable(
                name: "dependents");

            migrationBuilder.DropTable(
                name: "worksOns");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
