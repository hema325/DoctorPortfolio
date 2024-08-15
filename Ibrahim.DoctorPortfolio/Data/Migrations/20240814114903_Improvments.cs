using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ibrahim.DoctorPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class Improvments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Videos_Type",
                table: "Videos",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_FAQTexts_Type",
                table: "FAQTexts",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_BeforeAfterImages_ImageType",
                table: "BeforeAfterImages",
                column: "ImageType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Videos_Type",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_FAQTexts_Type",
                table: "FAQTexts");

            migrationBuilder.DropIndex(
                name: "IX_BeforeAfterImages_ImageType",
                table: "BeforeAfterImages");
        }
    }
}
