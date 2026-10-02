using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupportSystemApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketPriorities_PriorityId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketStatuses_StatusId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Tickets",
                newName: "UrgencyId");

            migrationBuilder.RenameColumn(
                name: "PriorityId",
                table: "Tickets",
                newName: "TicketStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                newName: "IX_Tickets_UrgencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PriorityId",
                table: "Tickets",
                newName: "IX_Tickets_TicketStatusId");

            migrationBuilder.AddColumn<Guid>(
                name: "ImpactId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TicketPriorityId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ImpactId",
                table: "Tickets",
                column: "ImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketPriorityId",
                table: "Tickets",
                column: "TicketPriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Impacts_ImpactId",
                table: "Tickets",
                column: "ImpactId",
                principalTable: "Impacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketPriorities_TicketPriorityId",
                table: "Tickets",
                column: "TicketPriorityId",
                principalTable: "TicketPriorities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketStatuses_TicketStatusId",
                table: "Tickets",
                column: "TicketStatusId",
                principalTable: "TicketStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Urgencies_UrgencyId",
                table: "Tickets",
                column: "UrgencyId",
                principalTable: "Urgencies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Impacts_ImpactId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketPriorities_TicketPriorityId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketStatuses_TicketStatusId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Urgencies_UrgencyId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ImpactId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketPriorityId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ImpactId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketPriorityId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "UrgencyId",
                table: "Tickets",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "TicketStatusId",
                table: "Tickets",
                newName: "PriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UrgencyId",
                table: "Tickets",
                newName: "IX_Tickets_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketStatusId",
                table: "Tickets",
                newName: "IX_Tickets_PriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketPriorities_PriorityId",
                table: "Tickets",
                column: "PriorityId",
                principalTable: "TicketPriorities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketStatuses_StatusId",
                table: "Tickets",
                column: "StatusId",
                principalTable: "TicketStatuses",
                principalColumn: "Id");
        }
    }
}
