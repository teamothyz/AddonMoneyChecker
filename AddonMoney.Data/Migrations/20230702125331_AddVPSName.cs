using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddonMoney.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVPSName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VPS",
                table: "BlanceInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VPS",
                table: "BlanceInfo");
        }
    }
}
