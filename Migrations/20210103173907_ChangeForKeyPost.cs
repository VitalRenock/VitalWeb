using Microsoft.EntityFrameworkCore.Migrations;

namespace VitalWeb.Migrations
{
    public partial class ChangeForKeyPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_TagID",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "TagID",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TagID",
                table: "Posts",
                column: "TagID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Tags_TagID",
                table: "Posts",
                column: "TagID",
                principalTable: "Tags",
                principalColumn: "TagID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Tags_TagID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TagID",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "TagID",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_TagID",
                table: "Tags",
                column: "TagID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
