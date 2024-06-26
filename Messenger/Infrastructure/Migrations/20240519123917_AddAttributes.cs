using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Users",
                schema: "public",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UserPhotos",
                schema: "public",
                newName: "UserPhotos");

            migrationBuilder.RenameTable(
                name: "MessageTypes",
                schema: "public",
                newName: "MessageTypes");

            migrationBuilder.RenameTable(
                name: "Messages",
                schema: "public",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "ChatTypes",
                schema: "public",
                newName: "ChatTypes");

            migrationBuilder.RenameTable(
                name: "Chats",
                schema: "public",
                newName: "Chats");

            migrationBuilder.RenameTable(
                name: "ChatMembers",
                schema: "public",
                newName: "ChatMembers");

            migrationBuilder.RenameTable(
                name: "ChatAccessibilities",
                schema: "public",
                newName: "ChatAccessibilities");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(120)",
                oldMaxLength: 120);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "UserPhotos",
                newName: "UserPhotos",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "MessageTypes",
                newName: "MessageTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Messages",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ChatTypes",
                newName: "ChatTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Chats",
                newName: "Chats",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ChatMembers",
                newName: "ChatMembers",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ChatAccessibilities",
                newName: "ChatAccessibilities",
                newSchema: "public");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "public",
                table: "Users",
                type: "character varying(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(320)",
                oldMaxLength: 320);
        }
    }
}
