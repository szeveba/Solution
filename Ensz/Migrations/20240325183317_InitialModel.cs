using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ensz.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Városok",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Név = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Népesség = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Városok", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Országok",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Név = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Terület = table.Column<int>(type: "int", nullable: false),
                    Népesség = table.Column<int>(type: "int", nullable: false),
                    FővárosID = table.Column<string>(type: "nvarchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Országok", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Országok_Városok_FővárosID",
                        column: x => x.FővárosID,
                        principalTable: "Városok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Országok_FővárosID",
                table: "Országok",
                column: "FővárosID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Országok");

            migrationBuilder.DropTable(
                name: "Városok");
        }
    }
}
