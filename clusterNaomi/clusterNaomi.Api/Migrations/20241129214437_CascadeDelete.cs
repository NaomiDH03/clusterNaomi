using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clusterNaomi.Api.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecreams_Stores_StoreId",
                table: "Icecreams");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecreams_Stores_StoreId",
                table: "Icecreams",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecreams_Stores_StoreId",
                table: "Icecreams");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecreams_Stores_StoreId",
                table: "Icecreams",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }
    }
}
