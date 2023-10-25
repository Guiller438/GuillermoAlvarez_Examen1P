using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuillermoAlvarez_Examen1P.Migrations
{
    public partial class GuillermoAlvarez_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuillermoAlvarez_Tabla",
                columns: table => new
                {
                    GA_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GA_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GA_ClienteTelevisor = table.Column<bool>(type: "bit", nullable: false),
                    GA_ClieneInternet = table.Column<bool>(type: "bit", nullable: false),
                    GA_Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GA_Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuillermoAlvarez_Tabla", x => x.GA_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuillermoAlvarez_Tabla");
        }
    }
}
