using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupportSystemApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ServiceCategoryId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TicketModeId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TicketTypeId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Impacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impacts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ServiceCategoryId",
                table: "Tickets",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketModeId",
                table: "Tickets",
                column: "TicketModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ServiceCategories_ServiceCategoryId",
                table: "Tickets",
                column: "ServiceCategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketModes_TicketModeId",
                table: "Tickets",
                column: "TicketModeId",
                principalTable: "TicketModes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId",
                principalTable: "TicketTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ServiceCategories_ServiceCategoryId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketModes_TicketModeId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Impacts");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ServiceCategoryId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketModeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ServiceCategoryId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketModeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketTypeId",
                table: "Tickets");
        }
    }
}
