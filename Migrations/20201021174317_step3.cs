using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoogleEngine.Migrations
{
    public partial class step3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SearchDate",
                table: "Search",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ObjectResult",
                table: "Result",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchDate",
                table: "Search");

            migrationBuilder.DropColumn(
                name: "ObjectResult",
                table: "Result");
        }
    }
}
