using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CA_School_Project.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_localization_to_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "Subjects",
                newName: "SubjectName_En");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "Name_En");

            migrationBuilder.RenameColumn(
                name: "DName",
                table: "Departments",
                newName: "DName_En");

            migrationBuilder.AddColumn<string>(
                name: "SubjectName_Ar",
                table: "Subjects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DName_Ar",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectName_Ar",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DName_Ar",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "SubjectName_En",
                table: "Subjects",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "Name_En",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DName_En",
                table: "Departments",
                newName: "DName");
        }
    }
}
