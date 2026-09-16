using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DaniilBudanovKt_31_23.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSpecialties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "credits");

            migrationBuilder.DropColumn(
                name: "specialty",
                table: "academic_groups");

            migrationBuilder.AddColumn<int>(
                name: "specialty_id",
                table: "academic_groups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "specialties",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    is_deleted = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialties", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_academic_groups_specialty_id",
                table: "academic_groups",
                column: "specialty_id");

            migrationBuilder.AddForeignKey(
                name: "FK_academic_groups_specialties_specialty_id",
                table: "academic_groups",
                column: "specialty_id",
                principalTable: "specialties",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_academic_groups_specialties_specialty_id",
                table: "academic_groups");

            migrationBuilder.DropTable(
                name: "specialties");

            migrationBuilder.DropIndex(
                name: "IX_academic_groups_specialty_id",
                table: "academic_groups");

            migrationBuilder.DropColumn(
                name: "specialty_id",
                table: "academic_groups");

            migrationBuilder.AddColumn<string>(
                name: "specialty",
                table: "academic_groups",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "credits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    student_id = table.Column<int>(type: "int4", nullable: false),
                    subject_id = table.Column<int>(type: "int4", nullable: false),
                    is_passed = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credits", x => x.id);
                    table.ForeignKey(
                        name: "FK_credits_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_credits_subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_credits_student_id",
                table: "credits",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_credits_subject_id",
                table: "credits",
                column: "subject_id");
        }
    }
}
