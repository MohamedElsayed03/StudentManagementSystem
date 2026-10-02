using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InaitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instuctors",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instuctors", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Instuctors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instuctors",
                        principalColumn: "InstructorId");
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "date", nullable: false),
                    Grade = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Credits", "Description", "InstructorId", "Title" },
                values: new object[] { 3, 3, "Fundamentals of C#", null, "C#" });

            migrationBuilder.InsertData(
                table: "Instuctors",
                columns: new[] { "InstructorId", "FullName" },
                values: new object[,]
                {
                    { 1, "Issam abdelnaby" },
                    { 2, "Mohamed Hisham" },
                    { 3, "Omar Khaled" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DateOfBirth", "Email", "EnrollmentDate", "FullName" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "mo7amed0518@gmail.com", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mohamed Elsayed" },
                    { 2, new DateTime(2001, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed.hassan@.com", new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmed Hassan" },
                    { 3, new DateTime(2003, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.ali@.com", new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omar Ali" },
                    { 4, new DateTime(2002, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssefmohamed@gmail.com", new DateTime(2026, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Youssef Mohamed" },
                    { 5, new DateTime(2001, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mahmoud.adel@gmail.com", new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahmoud Adel" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Credits", "Description", "InstructorId", "Title" },
                values: new object[,]
                {
                    { 1, 3, "Code_First Migration", 1, "EFCore" },
                    { 2, 3, "Fundamentals of Physics", 1, "Physics" },
                    { 4, 4, "SQL Server and Database Design", 2, "Database Systems" },
                    { 5, 4, "Introduction to Programming and Problem Solving", 3, "Programming" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "EnrollmentDate", "Grade" },
                values: new object[,]
                {
                    { 3, 2, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 5, new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 94 },
                    { 1, 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95 },
                    { 2, 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88 },
                    { 1, 2, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 2, 3, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 85 },
                    { 4, 3, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 4, new DateTime(2026, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 92 },
                    { 5, 4, new DateTime(2026, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 89 },
                    { 5, 5, new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Instuctors");
        }
    }
}
