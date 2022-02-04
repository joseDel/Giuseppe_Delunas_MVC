using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ristorante.RepositoryEF.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    IdMenu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.IdMenu);
                });

            migrationBuilder.CreateTable(
                name: "Piatto",
                columns: table => new
                {
                    IdPiatto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipologia = table.Column<int>(type: "int", nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdMenu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piatto", x => x.IdPiatto);
                    table.ForeignKey(
                        name: "FK_Piatto_Menu_IdMenu",
                        column: x => x.IdMenu,
                        principalTable: "Menu",
                        principalColumn: "IdMenu");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_IdMenu",
                table: "Menu",
                column: "IdMenu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Piatto_IdMenu",
                table: "Piatto",
                column: "IdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_Piatto_IdPiatto",
                table: "Piatto",
                column: "IdPiatto",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piatto");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
