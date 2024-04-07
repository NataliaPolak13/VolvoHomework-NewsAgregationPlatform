using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllAroundNews.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class NewPartsDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountRecipient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    ValidationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discount_PlaceId",
                table: "Discount",
                column: "PlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");
        }
    }
}
