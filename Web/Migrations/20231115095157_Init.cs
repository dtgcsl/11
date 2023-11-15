using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberOfCredits = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HomeroomTeacher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classrooms_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClassroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SujectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Results_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Results_Subjects_SujectId",
                        column: x => x.SujectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "FacultyId", "HomeroomTeacher", "Name" },
                values: new object[,]
                {
                    { new Guid("0bf765e0-2299-49dd-93a6-34d7eba7e04e"), null, "Tam", "cntt4" },
                    { new Guid("695485ee-f0d4-4e4a-a636-f2243e91aa54"), null, "Tam", "cntt5" },
                    { new Guid("8458b3db-193f-4a81-ad1d-744c75419026"), null, "Tam", "cntt1" },
                    { new Guid("ccd254dd-37fb-4ae3-9138-f8edea478608"), null, "Tam", "cntt3" },
                    { new Guid("fe1059fc-de63-4dfd-b5f3-5800d1128657"), null, "Tam", "cntt2" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03577a21-a18e-43c1-901f-10f6b8cbbca3"), "dia chat" },
                    { new Guid("1ce21ba4-2a22-4c49-b2b0-faa525319a10"), "kinh te" },
                    { new Guid("25d5cfdb-b9c8-486a-b135-b1344be0cecb"), "moi truong" },
                    { new Guid("75549c32-e787-4b7b-82a7-555c2b0fa786"), "co dien" },
                    { new Guid("fb3026ff-8507-4f5b-a318-66611edff090"), "mo" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "ClassroomId", "Email", "FullName", "Gender" },
                values: new object[,]
                {
                    { new Guid("104c5cc3-4458-4604-9c6b-9969de6f2445"), "Son La", null, "dtg.csl@gmail.com", "Giang1", false },
                    { new Guid("1fb214d1-3e54-4038-89eb-a48b8a9334dd"), "Son La", null, "dtg.csl@gmail.com", "Giang3", false },
                    { new Guid("62c4e7e3-7e42-4b13-b7fb-0bdebb71037c"), "Son La", null, "dtg.csl@gmail.com", "Giang2", false },
                    { new Guid("d13ed707-d793-4aa3-aaf5-943112725c46"), "Son La", null, "dtg.csl@gmail.com", "Giang", false },
                    { new Guid("f71543da-ada6-4916-ac01-9ed7b2066f26"), "Son La", null, "dtg.csl@gmail.com", "Giang3", false }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreateAt", "Name", "NumberOfCredits", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("99095f8a-3f0c-4c9b-b2a3-50d0df5e6bcd"), null, "c#", 3, null },
                    { new Guid("a96434e2-2a0b-41b8-b412-4083eb9083f9"), null, "java", 3, null },
                    { new Guid("afd93aef-d360-458e-8688-2af4d60f1b1e"), null, "c++", 3, null },
                    { new Guid("b86ece5b-2d73-48d1-a74d-ff40ae0f5c75"), null, "js", 3, null },
                    { new Guid("ba1a28b7-ae46-4a4c-bad6-a0f812dbd6ec"), null, "c", 3, null },
                    { new Guid("e7847cdf-96e8-4147-8da8-0ea1cde7ccff"), null, "ctdl", 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_FacultyId",
                table: "Classrooms",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ClassroomId",
                table: "Results",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_StudentId",
                table: "Results",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_SujectId",
                table: "Results",
                column: "SujectId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassroomId",
                table: "Students",
                column: "ClassroomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
