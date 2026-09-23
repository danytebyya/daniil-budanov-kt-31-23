using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaniilBudanovKt_31_23.Migrations
{
    /// <inheritdoc />
    public partial class SplitStudentFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "full_name",
                table: "students");

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "students",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "students",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "middle_name",
                table: "students",
                type: "varchar",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "first_name",
                table: "students");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "students");

            migrationBuilder.DropColumn(
                name: "middle_name",
                table: "students");

            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "students",
                type: "varchar",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
