using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace budnar_pavel_proiect_medii_de_programare.Migrations
{
    public partial class updateMechanic2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Mechanic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mechanic_RoleID",
                table: "Mechanic",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mechanic_Role_RoleID",
                table: "Mechanic",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mechanic_Role_RoleID",
                table: "Mechanic");

            migrationBuilder.DropIndex(
                name: "IX_Mechanic_RoleID",
                table: "Mechanic");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Mechanic");
        }
    }
}
