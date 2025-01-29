using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActDigital.Store.Sales.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProductItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProductItems");
        }
    }
}
