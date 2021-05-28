using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseApp.WebUI.Migrations
{
    public partial class ChangeRTCourseProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursePrograms_Branchs_BranchId",
                table: "CoursePrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursePrograms_Courses_CourseId",
                table: "CoursePrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursePrograms_Teachers_TeacherId",
                table: "CoursePrograms");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "CoursePrograms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CoursePrograms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "CoursePrograms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePrograms_Branchs_BranchId",
                table: "CoursePrograms",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePrograms_Courses_CourseId",
                table: "CoursePrograms",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePrograms_Teachers_TeacherId",
                table: "CoursePrograms",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursePrograms_Branchs_BranchId",
                table: "CoursePrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursePrograms_Courses_CourseId",
                table: "CoursePrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursePrograms_Teachers_TeacherId",
                table: "CoursePrograms");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "CoursePrograms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CoursePrograms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "CoursePrograms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePrograms_Branchs_BranchId",
                table: "CoursePrograms",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePrograms_Courses_CourseId",
                table: "CoursePrograms",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePrograms_Teachers_TeacherId",
                table: "CoursePrograms",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
