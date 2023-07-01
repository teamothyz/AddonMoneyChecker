using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddonMoney.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlanceInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    LastBalance = table.Column<int>(type: "int", nullable: false),
                    TodayEarn = table.Column<int>(type: "int", nullable: false),
                    LastTodayEarn = table.Column<int>(type: "int", nullable: false),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlanceInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErrorInfo_Host",
                table: "ErrorInfo",
                column: "Host");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlanceInfo");

            migrationBuilder.DropTable(
                name: "ErrorInfo");
        }
    }
}
