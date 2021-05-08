using Microsoft.EntityFrameworkCore.Migrations;

namespace VitalWeb.Migrations
{
    public partial class NewTest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_MyTagContainers_MyTagContainerID",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_MyTagContainerID",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "MyTagContainerID",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagID",
                table: "MyTagContainers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MyTagContainers",
                type: "TEXT",
                maxLength: 55,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MyTagContainerTag",
                columns: table => new
                {
                    AllTagsContainerMyTagContainerID = table.Column<int>(type: "INTEGER", nullable: false),
                    AllTagsTagID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTagContainerTag", x => new { x.AllTagsContainerMyTagContainerID, x.AllTagsTagID });
                    table.ForeignKey(
                        name: "FK_MyTagContainerTag_MyTagContainers_AllTagsContainerMyTagContainerID",
                        column: x => x.AllTagsContainerMyTagContainerID,
                        principalTable: "MyTagContainers",
                        principalColumn: "MyTagContainerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyTagContainerTag_Tags_AllTagsTagID",
                        column: x => x.AllTagsTagID,
                        principalTable: "Tags",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyTagContainerTag_AllTagsTagID",
                table: "MyTagContainerTag",
                column: "AllTagsTagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyTagContainerTag");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MyTagContainers");

            migrationBuilder.AddColumn<int>(
                name: "MyTagContainerID",
                table: "Tags",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagID",
                table: "MyTagContainers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_MyTagContainerID",
                table: "Tags",
                column: "MyTagContainerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_MyTagContainers_MyTagContainerID",
                table: "Tags",
                column: "MyTagContainerID",
                principalTable: "MyTagContainers",
                principalColumn: "MyTagContainerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
