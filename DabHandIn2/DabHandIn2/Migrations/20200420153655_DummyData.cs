using Microsoft.EntityFrameworkCore.Migrations;

namespace DabHandIn2.Migrations
{
    public partial class DummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Students_StudentauId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Students_StudentauId",
                table: "Exercises");

            migrationBuilder.AlterColumn<int>(
                name: "StudentauId",
                table: "Exercises",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentauId",
                table: "Assignments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Name" },
                values: new object[,]
                {
                    { 1, "Databaser" },
                    { 2, "GUI" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "auId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Agri@Agri.com", "Nikolaj AGRI" },
                    { 2, "Rosendal@Rosendal.com", "Fredeirk" }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "CourseId", "Name", "StudentauId" },
                values: new object[,]
                {
                    { 1, 1, "Dab HandIn #2", 1 },
                    { 2, 2, "GUI for coffee shop", 2 }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Lecture", "Number", "CourseId", "StudentauId" },
                values: new object[] { "Seeding Data in EF Core", 56, 1, 1 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "auId", "CourseId", "Active", "Semester" },
                values: new object[,]
                {
                    { 1, 1, true, 4 },
                    { 1, 2, true, 4 },
                    { 2, 1, true, 4 },
                    { 2, 2, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "auId", "CourseId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Henrik Kirk" },
                    { 2, 2, "Poul Ejnar" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Students_StudentauId",
                table: "Assignments",
                column: "StudentauId",
                principalTable: "Students",
                principalColumn: "auId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Students_StudentauId",
                table: "Exercises",
                column: "StudentauId",
                principalTable: "Students",
                principalColumn: "auId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Students_StudentauId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Students_StudentauId",
                table: "Exercises");

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumns: new[] { "Lecture", "Number" },
                keyValues: new object[] { "Seeding Data in EF Core", 56 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "auId", "CourseId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "auId", "CourseId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "auId", "CourseId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "auId", "CourseId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "auId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "auId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "auId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "auId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "StudentauId",
                table: "Exercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StudentauId",
                table: "Assignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Students_StudentauId",
                table: "Assignments",
                column: "StudentauId",
                principalTable: "Students",
                principalColumn: "auId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Students_StudentauId",
                table: "Exercises",
                column: "StudentauId",
                principalTable: "Students",
                principalColumn: "auId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
