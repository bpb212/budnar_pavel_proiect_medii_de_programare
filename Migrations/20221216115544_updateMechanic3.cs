using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace budnar_pavel_proiect_medii_de_programare.Migrations
{
    public partial class updateMechanic3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Team_TeamID",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Mechanic_Team_TeamID",
                table: "Mechanic");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Mechanic",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DutyName",
                table: "Duty",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Team_TeamID",
                table: "Driver",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mechanic_Team_TeamID",
                table: "Mechanic",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Team_TeamID",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Mechanic_Team_TeamID",
                table: "Mechanic");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Mechanic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DutyName",
                table: "Duty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Driver",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Team_TeamID",
                table: "Driver",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mechanic_Team_TeamID",
                table: "Mechanic",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID");
        }
    }
}
