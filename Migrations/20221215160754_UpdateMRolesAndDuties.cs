using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace budnar_pavel_proiect_medii_de_programare.Migrations
{
    public partial class UpdateMRolesAndDuties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Duty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Duty_RoleID",
                table: "Duty",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Duty_Role_RoleID",
                table: "Duty",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duty_Role_RoleID",
                table: "Duty");

            migrationBuilder.DropIndex(
                name: "IX_Duty_RoleID",
                table: "Duty");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Duty");
        }
    }
}
