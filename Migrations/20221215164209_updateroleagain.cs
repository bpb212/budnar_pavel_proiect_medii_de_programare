using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace budnar_pavel_proiect_medii_de_programare.Migrations
{
    public partial class updateroleagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RoleDuty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    DutyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleDuty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoleDuty_Duty_DutyID",
                        column: x => x.DutyID,
                        principalTable: "Duty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleDuty_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleDuty_DutyID",
                table: "RoleDuty",
                column: "DutyID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleDuty_RoleID",
                table: "RoleDuty",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleDuty");

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
    }
}
