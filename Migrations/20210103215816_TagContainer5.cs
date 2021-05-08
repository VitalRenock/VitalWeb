using Microsoft.EntityFrameworkCore.Migrations;

namespace VitalWeb.Migrations
{
    public partial class TagContainer5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TagsContainer_TagContainerID",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "TagsContainer");

            migrationBuilder.RenameColumn(
                name: "TagContainerID",
                table: "Tags",
                newName: "MyTagContainerID");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_TagContainerID",
                table: "Tags",
                newName: "IX_Tags_MyTagContainerID");

            migrationBuilder.CreateTable(
                name: "MyTagContainers",
                columns: table => new
                {
                    MyTagContainerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TagID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTagContainers", x => x.MyTagContainerID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_MyTagContainers_MyTagContainerID",
                table: "Tags",
                column: "MyTagContainerID",
                principalTable: "MyTagContainers",
                principalColumn: "MyTagContainerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_MyTagContainers_MyTagContainerID",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "MyTagContainers");

            migrationBuilder.RenameColumn(
                name: "MyTagContainerID",
                table: "Tags",
                newName: "TagContainerID");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_MyTagContainerID",
                table: "Tags",
                newName: "IX_Tags_TagContainerID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TagsContainer_TagContainerID",
                table: "Tags",
                column: "TagContainerID",
                principalTable: "TagsContainer",
                principalColumn: "TagContainerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
