using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComitivaEsperanca.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableClassifiedNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassifiedNews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NewsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassifiedNews_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedNews_NewsId",
                table: "ClassifiedNews",
                column: "NewsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassifiedNews");
        }
    }
}
