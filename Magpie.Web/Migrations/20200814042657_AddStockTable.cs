using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Magpie.Web.Migrations
{
    public partial class AddStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockMarkets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    trade_code = table.Column<string>(nullable: true),
                    high = table.Column<float>(nullable: false),
                    low = table.Column<float>(nullable: false),
                    open = table.Column<float>(nullable: false),
                    close = table.Column<float>(nullable: false),
                    volumn = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMarkets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockMarkets");
        }
    }
}
