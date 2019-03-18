using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace delopgave.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haandvaerkers",
                columns: table => new
                {
                    HvAnsaettelsedatao = table.Column<string>(nullable: true),
                    HvEfternavn = table.Column<string>(nullable: true),
                    HvFagomraade = table.Column<string>(nullable: true),
                    HvFornavn = table.Column<string>(nullable: true),
                    HaandvaerkerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haandvaerkers", x => x.HaandvaerkerId);
                });

            migrationBuilder.CreateTable(
                name: "Vaerktoejskasses",
                columns: table => new
                {
                    VtkAnskaffet = table.Column<string>(nullable: true),
                    VtkEjesAf = table.Column<string>(nullable: true),
                    VtkFabrikat = table.Column<string>(nullable: true),
                    VtkFarve = table.Column<string>(nullable: true),
                    VtkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VtkModel = table.Column<string>(nullable: true),
                    VtkSerienummer = table.Column<string>(nullable: true),
                    HaandvaerkerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaerktoejskasses", x => x.VtkId);
                    table.ForeignKey(
                        name: "FK_Vaerktoejskasses_Haandvaerkers_HaandvaerkerId",
                        column: x => x.HaandvaerkerId,
                        principalTable: "Haandvaerkers",
                        principalColumn: "HaandvaerkerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vaerktoejs",
                columns: table => new
                {
                    LiggerIvkt = table.Column<string>(nullable: true),
                    VtAnskaffet = table.Column<string>(nullable: true),
                    VtFabrikat = table.Column<string>(nullable: true),
                    VtId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VtModel = table.Column<string>(nullable: true),
                    VtSerienr = table.Column<string>(nullable: true),
                    VtType = table.Column<string>(nullable: true),
                    VaerktoejskasseVtkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaerktoejs", x => x.VtId);
                    table.ForeignKey(
                        name: "FK_Vaerktoejs_Vaerktoejskasses_VaerktoejskasseVtkId",
                        column: x => x.VaerktoejskasseVtkId,
                        principalTable: "Vaerktoejskasses",
                        principalColumn: "VtkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaerktoejs_VaerktoejskasseVtkId",
                table: "Vaerktoejs",
                column: "VaerktoejskasseVtkId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaerktoejskasses_HaandvaerkerId",
                table: "Vaerktoejskasses",
                column: "HaandvaerkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaerktoejs");

            migrationBuilder.DropTable(
                name: "Vaerktoejskasses");

            migrationBuilder.DropTable(
                name: "Haandvaerkers");
        }
    }
}
