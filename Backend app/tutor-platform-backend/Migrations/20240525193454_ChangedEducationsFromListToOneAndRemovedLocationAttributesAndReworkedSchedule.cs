using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorPlatformBackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEducationsFromListToOneAndRemovedLocationAttributesAndReworkedSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tutors_EFBoolCollection_ScheduleId",
                table: "Tutors");

            migrationBuilder.DropTable(
                name: "EFBoolCollection");

            migrationBuilder.DropIndex(
                name: "IX_Tutors_ScheduleId",
                table: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Education_TutorId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "CanCome",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "CanHost",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "CanTeachOnline",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Tutors");

            migrationBuilder.AddColumn<string>(
                name: "Schedule",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.CreateIndex(
                name: "IX_Education_TutorId",
                table: "Education",
                column: "TutorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Education_TutorId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "Tutors");

            migrationBuilder.AddColumn<bool>(
                name: "CanCome",
                table: "Tutors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanHost",
                table: "Tutors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanTeachOnline",
                table: "Tutors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Tutors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Tutors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EFBoolCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFBoolCollection", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_ScheduleId",
                table: "Tutors",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_TutorId",
                table: "Education",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tutors_EFBoolCollection_ScheduleId",
                table: "Tutors",
                column: "ScheduleId",
                principalTable: "EFBoolCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
