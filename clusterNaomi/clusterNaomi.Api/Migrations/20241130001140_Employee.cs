using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clusterNaomi.Api.Migrations
{
    /// <inheritdoc />
    public partial class Employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecreams_Stores_StoreId1",
                table: "Icecreams");

            migrationBuilder.DropIndex(
                name: "IX_Icecreams_StoreId1",
                table: "Icecreams");

            migrationBuilder.DropColumn(
                name: "StoreId1",
                table: "Icecreams");

            migrationBuilder.DropColumn(
                name: "StoreId2",
                table: "Icecreams");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "StoreId1",
                table: "Icecreams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreId2",
                table: "Icecreams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Icecreams_StoreId1",
                table: "Icecreams",
                column: "StoreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecreams_Stores_StoreId1",
                table: "Icecreams",
                column: "StoreId1",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
