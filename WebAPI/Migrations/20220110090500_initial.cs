using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Age = table.Column<int>(maxLength: 6, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Age);
                });

            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    ChildOwnerOfToyAge = table.Column<int>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    IsFavorite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toys", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Toys_Children_ChildOwnerOfToyAge",
                        column: x => x.ChildOwnerOfToyAge,
                        principalTable: "Children",
                        principalColumn: "Age",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toys_ChildOwnerOfToyAge",
                table: "Toys",
                column: "ChildOwnerOfToyAge");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "Children");
        }
    }
}
