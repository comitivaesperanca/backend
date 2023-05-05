using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComitivaEsperanca.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    NewsContent = table.Column<string>(type: "text", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CommodityType = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: false),
                    PositiveSentiment = table.Column<double>(type: "double precision", nullable: false),
                    NeutralSentiment = table.Column<double>(type: "double precision", nullable: false),
                    NegativeSentiment = table.Column<double>(type: "double precision", nullable: false),
                    FinalSentiment = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
