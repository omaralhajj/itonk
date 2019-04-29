using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockBroker.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shares",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TraderID = table.Column<Guid>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    SharesForSale = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shares", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Traders",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Credit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BuyerID = table.Column<Guid>(nullable: false),
                    ShareID = table.Column<Guid>(nullable: false),
                    SellerID = table.Column<Guid>(nullable: false),
                    TransferValue = table.Column<decimal>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shares");

            migrationBuilder.DropTable(
                name: "Traders");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
