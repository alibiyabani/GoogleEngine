using Microsoft.EntityFrameworkCore.Migrations;

namespace GoogleEngine.Migrations
{
    public partial class step2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResultSearchId",
                table: "Search",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    SearchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.SearchId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Search_ResultSearchId",
                table: "Search",
                column: "ResultSearchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Search_Result_ResultSearchId",
                table: "Search",
                column: "ResultSearchId",
                principalTable: "Result",
                principalColumn: "SearchId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Search_Result_ResultSearchId",
                table: "Search");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Search_ResultSearchId",
                table: "Search");

            migrationBuilder.DropColumn(
                name: "ResultSearchId",
                table: "Search");
        }
    }
}
