using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bookify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addpermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bookings_apartments_apartment_id1",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "fk_bookings_user_user_temp_id1",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_apartments_apartment_id1",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_bookings_booking_id1",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_user_user_temp_id1",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_role_user_user_users_temp_id",
                table: "role_user");

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    roleid = table.Column<int>(name: "role_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_permissions_role_role_id",
                        column: x => x.roleid,
                        principalTable: "roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                columns: table => new
                {
                    roleid = table.Column<int>(name: "role_id", type: "integer", nullable: false),
                    permissionid = table.Column<int>(name: "permission_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_permissions", x => new { x.roleid, x.permissionid });
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "role_id" },
                values: new object[] { 1, "users:read", null });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "ix_permissions_role_id",
                table: "permissions",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "fk_bookings_apartments_apartment_id",
                table: "bookings",
                column: "apartment_id",
                principalTable: "apartments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_bookings_user_user_id",
                table: "bookings",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_apartments_apartment_id",
                table: "reviews",
                column: "apartment_id",
                principalTable: "apartments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_bookings_booking_id",
                table: "reviews",
                column: "booking_id",
                principalTable: "bookings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_user_user_id",
                table: "reviews",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_user_user_users_id",
                table: "role_user",
                column: "users_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bookings_apartments_apartment_id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "fk_bookings_user_user_id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_apartments_apartment_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_bookings_booking_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_user_user_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_role_user_user_users_id",
                table: "role_user");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "role_permissions");

            migrationBuilder.AddForeignKey(
                name: "fk_bookings_apartments_apartment_id1",
                table: "bookings",
                column: "apartment_id",
                principalTable: "apartments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_bookings_user_user_temp_id1",
                table: "bookings",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_apartments_apartment_id1",
                table: "reviews",
                column: "apartment_id",
                principalTable: "apartments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_bookings_booking_id1",
                table: "reviews",
                column: "booking_id",
                principalTable: "bookings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_user_user_temp_id1",
                table: "reviews",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_user_user_users_temp_id",
                table: "role_user",
                column: "users_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
