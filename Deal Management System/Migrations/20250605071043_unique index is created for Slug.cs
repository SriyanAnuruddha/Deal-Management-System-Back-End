using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class uniqueindexiscreatedforSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Deals",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_Slug",
                table: "Deals",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Deals_Slug",
                table: "Deals");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
