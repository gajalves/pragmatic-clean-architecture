using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changerole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_permissions_role_role_id",
                table: "permissions");

            migrationBuilder.DropIndex(
                name: "ix_permissions_role_id",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "permissions");

            migrationBuilder.CreateIndex(
                name: "ix_role_permissions_role_id",
                table: "role_permissions",
                column: "role_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_role_permissions_role_id",
                table: "role_permissions");

            migrationBuilder.AddColumn<int>(
                name: "role_id",
                table: "permissions",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: 1,
                column: "role_id",
                value: null);

            migrationBuilder.CreateIndex(
                name: "ix_permissions_role_id",
                table: "permissions",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "fk_permissions_role_role_id",
                table: "permissions",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id");
        }
    }
}
