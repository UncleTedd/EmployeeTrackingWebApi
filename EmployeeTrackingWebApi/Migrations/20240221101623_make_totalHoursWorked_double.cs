using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeTrackingWebApi.Migrations
{
    /// <inheritdoc />
    public partial class make_totalHoursWorked_double : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalHoursWorked",
                table: "Shifts",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalHoursWorked",
                table: "Shifts",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
