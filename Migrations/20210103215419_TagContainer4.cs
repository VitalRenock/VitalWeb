using Microsoft.EntityFrameworkCore.Migrations;

namespace VitalWeb.Migrations
{
    public partial class TagContainer4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagContainerID",
                table: "Tags",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TagsContainer",
                columns: table => new
                {
                    TagContainerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TagID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsContainer", x => x.TagContainerID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagContainerID",
                table: "Tags",
                column: "TagContainerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TagsContainer_TagContainerID",
                table: "Tags",
                column: "TagContainerID",
                principalTable: "TagsContainer",
                principalColumn: "TagContainerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TagsContainer_TagContainerID",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "TagsContainer");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TagContainerID",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagContainerID",
                table: "Tags");
        }
    }
}
