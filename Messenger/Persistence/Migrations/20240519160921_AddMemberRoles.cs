using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddMemberRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MemberRoleId",
                table: "ChatMembers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MemberRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMembers_MemberRoleId",
                table: "ChatMembers",
                column: "MemberRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMembers_MemberRoles_MemberRoleId",
                table: "ChatMembers",
                column: "MemberRoleId",
                principalTable: "MemberRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMembers_MemberRoles_MemberRoleId",
                table: "ChatMembers");

            migrationBuilder.DropTable(
                name: "MemberRoles");

            migrationBuilder.DropIndex(
                name: "IX_ChatMembers_MemberRoleId",
                table: "ChatMembers");

            migrationBuilder.DropColumn(
                name: "MemberRoleId",
                table: "ChatMembers");
        }
    }
}
