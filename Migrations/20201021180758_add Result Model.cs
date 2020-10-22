using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoogleEngine.Migrations
{
    public partial class addResultModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SearchDate",
                table: "Result",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Terms",
                table: "Result",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchDate",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "Terms",
                table: "Result");
        }
    }
}
