using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clusterNaomi.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreRelationToIcecream : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Icecreams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Icecreams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
