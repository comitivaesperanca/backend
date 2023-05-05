using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComitivaEsperanca.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterAtributteFinalSentimentOnTableNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FinalSentiment",
                table: "News",
                type: "text",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "FinalSentiment",
                table: "News",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
