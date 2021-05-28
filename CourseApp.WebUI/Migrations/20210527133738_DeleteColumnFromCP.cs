using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseApp.WebUI.Migrations
{
    public partial class DeleteColumnFromCP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseProgramStudent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseProgramStudent",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseProgramId = table.Column<int>(type: "int", nullable: false),
                    CourseProgramsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProgramStudent", x => new { x.StudentId, x.CourseProgramId });
                    table.ForeignKey(
                        name: "FK_CourseProgramStudent_CoursePrograms_CourseProgramsId",
                        column: x => x.CourseProgramsId,
                        principalTable: "CoursePrograms",
                        principalColumn: "CourseProgramsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProgramStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgramStudent_CourseProgramsId",
                table: "CourseProgramStudent",
                column: "CourseProgramsId");
        }
    }
}
