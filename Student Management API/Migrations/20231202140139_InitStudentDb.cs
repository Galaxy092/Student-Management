using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_API.Migrations
{
    public partial class InitStudentDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Major = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentId = table.Column<string>(type: "varchar(36)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Code", "CreatedOn", "LastUpdatedOn", "Major", "Name" },
                values: new object[] { "3341eddb-9ded-4ef3-a269-3a3e2ee516f6", "STU002", new DateTime(2023, 12, 2, 21, 1, 38, 841, DateTimeKind.Local).AddTicks(4798), null, (byte)1, "Penh Vireak" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Code", "CreatedOn", "LastUpdatedOn", "Major", "Name" },
                values: new object[] { "b47e9365-2d42-4ede-911e-e41c377678f4", "STU001", new DateTime(2023, 12, 2, 21, 1, 38, 841, DateTimeKind.Local).AddTicks(4777), null, (byte)128, "Penh Polydet" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Code", "CreatedOn", "LastUpdatedOn", "Major", "Name" },
                values: new object[] { "f68c6e04-1168-4569-8a1c-259aea0f9f29", "STU003", new DateTime(2023, 12, 2, 21, 1, 38, 841, DateTimeKind.Local).AddTicks(4805), null, (byte)4, "Penh Veasna" });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Code",
                table: "Students",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
