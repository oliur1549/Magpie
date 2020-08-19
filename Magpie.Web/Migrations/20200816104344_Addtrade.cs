using Microsoft.EntityFrameworkCore.Migrations;

namespace Magpie.Web.Migrations
{
    public partial class Addtrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trade_code",
                table: "StockMarkets");

            migrationBuilder.AddColumn<int>(
                name: "TradeCodeId",
                table: "StockMarkets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TradeCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trade_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeCodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockMarkets_TradeCodeId",
                table: "StockMarkets",
                column: "TradeCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMarkets_TradeCodes_TradeCodeId",
                table: "StockMarkets",
                column: "TradeCodeId",
                principalTable: "TradeCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMarkets_TradeCodes_TradeCodeId",
                table: "StockMarkets");

            migrationBuilder.DropTable(
                name: "TradeCodes");

            migrationBuilder.DropIndex(
                name: "IX_StockMarkets_TradeCodeId",
                table: "StockMarkets");

            migrationBuilder.DropColumn(
                name: "TradeCodeId",
                table: "StockMarkets");

            migrationBuilder.AddColumn<string>(
                name: "trade_code",
                table: "StockMarkets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
