using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DBinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(type: "varchar(254)", nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: false),
                    Balance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBalances",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    VacationID = table.Column<int>(nullable: false),
                    Balance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBalances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeBalances_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeBalances_Vacations_VacationID",
                        column: x => x.VacationID,
                        principalTable: "Vacations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRequests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    VacationID = table.Column<int>(nullable: false),
                    Days = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeRequests_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRequests_Vacations_VacationID",
                        column: x => x.VacationID,
                        principalTable: "Vacations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "BirthDate", "Email", "FullName", "Gender" },
                values: new object[,]
                {
                    { 4572, new DateTime(1998, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@gmail.com", "Ahmed Mahmouud", "Male" },
                    { 4777, new DateTime(1998, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "marwan@gmail.com", "Marwan Salem", "Male" },
                    { 4999, new DateTime(1999, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "nadine@gmail.com", "Nadine Ahmed", "Female" }
                });

            migrationBuilder.InsertData(
                table: "Vacations",
                columns: new[] { "ID", "Balance", "Type" },
                values: new object[,]
                {
                    { 1, 7, "casual" },
                    { 2, 14, "schedule" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBalances_EmployeeID",
                table: "EmployeeBalances",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBalances_VacationID",
                table: "EmployeeBalances",
                column: "VacationID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequests_EmployeeID",
                table: "EmployeeRequests",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequests_VacationID",
                table: "EmployeeRequests",
                column: "VacationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeBalances");

            migrationBuilder.DropTable(
                name: "EmployeeRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Vacations");
        }
    }
}
