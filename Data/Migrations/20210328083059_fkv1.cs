using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fkv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeBalances",
                columns: new[] { "ID", "Balance", "EmployeeID", "VacationID" },
                values: new object[,]
                {
                    { 1, 7, 4572, 1 },
                    { 2, 14, 4572, 2 },
                    { 3, 5, 4777, 1 },
                    { 4, 12, 4777, 2 },
                    { 5, 7, 4999, 1 },
                    { 6, 14, 4999, 2 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRequests",
                columns: new[] { "ID", "Days", "EmployeeID", "VacationID" },
                values: new object[,]
                {
                    { 1, 3, 4572, 1 },
                    { 2, 5, 4777, 2 },
                    { 3, 6, 4999, 2 },
                    { 4, 2, 4572, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeBalances",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeBalances",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeBalances",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeBalances",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmployeeBalances",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmployeeBalances",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EmployeeRequests",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeRequests",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeRequests",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeRequests",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
