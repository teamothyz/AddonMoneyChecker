using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddonMoney.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEarningLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EarningLevel",
                table: "BlanceInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EarningLevel",
                table: "BlanceInfo");
        }
    }
}
