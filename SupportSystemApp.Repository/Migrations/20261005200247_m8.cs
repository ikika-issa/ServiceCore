using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupportSystemApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class m8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Item_ItemId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Tickets",
                newName: "Service_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ItemId",
                table: "Tickets",
                newName: "IX_Tickets_Service_CategoryId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryItemId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resolution",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CategoryItemId",
                table: "Tickets",
                column: "CategoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_CategoryItems_CategoryItemId",
                table: "Tickets",
                column: "CategoryItemId",
                principalTable: "CategoryItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ServiceCategories_Service_CategoryId",
                table: "Tickets",
                column: "Service_CategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_CategoryItems_CategoryItemId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ServiceCategories_Service_CategoryId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CategoryItemId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CategoryItemId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Service_CategoryId",
                table: "Tickets",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Service_CategoryId",
                table: "Tickets",
                newName: "IX_Tickets_ItemId");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubcategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_SubCategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_SubcategoryId",
                table: "Item",
                column: "SubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Item_ItemId",
                table: "Tickets",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id");
        }
    }
}
