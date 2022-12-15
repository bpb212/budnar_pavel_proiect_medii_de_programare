using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace budnar_pavel_proiect_medii_de_programare.Migrations
{
    public partial class UpdateMRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MechanicRoles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    MechanincID = table.Column<int>(type: "int", nullable: false),
                    MechanicID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MechanicRoles_Mechanic_MechanicID",
                        column: x => x.MechanicID,
                        principalTable: "Mechanic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicRoles_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MechanicRoles_MechanicID",
                table: "MechanicRoles",
                column: "MechanicID");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicRoles_RoleID",
                table: "MechanicRoles",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicRoles");
        }
    }
}
