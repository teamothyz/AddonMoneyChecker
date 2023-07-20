using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddonMoney.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailAndProxyStat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "BlanceInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ProxyDie",
                table: "BlanceInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "BlanceInfo");

            migrationBuilder.DropColumn(
                name: "ProxyDie",
                table: "BlanceInfo");
        }
    }
}
