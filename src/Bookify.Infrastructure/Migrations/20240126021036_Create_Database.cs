using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apartments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    addresscountry = table.Column<string>(name: "address_country", type: "text", nullable: false),
                    addressstate = table.Column<string>(name: "address_state", type: "text", nullable: false),
                    addresszipcode = table.Column<string>(name: "address_zip_code", type: "text", nullable: false),
                    addresscity = table.Column<string>(name: "address_city", type: "text", nullable: false),
                    addressstreet = table.Column<string>(name: "address_street", type: "text", nullable: false),
                    priceamount = table.Column<decimal>(name: "price_amount", type: "numeric", nullable: false),
                    pricecurrency = table.Column<string>(name: "price_currency", type: "text", nullable: false),
                    cleaningfeeamount = table.Column<decimal>(name: "cleaning_fee_amount", type: "numeric", nullable: false),
                    cleaningfeecurrency = table.Column<string>(name: "cleaning_fee_currency", type: "text", nullable: false),
                    lastbookedonutc = table.Column<DateTime>(name: "last_booked_on_utc", type: "timestamp with time zone", nullable: true),
                    amenities = table.Column<int[]>(type: "integer[]", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_apartments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "character varying(200)", maxLength: 200, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "character varying(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    identityid = table.Column<string>(name: "identity_id", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    apartmentid = table.Column<Guid>(name: "apartment_id", type: "uuid", nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: false),
                    durationstart = table.Column<DateOnly>(name: "duration_start", type: "date", nullable: false),
                    durationend = table.Column<DateOnly>(name: "duration_end", type: "date", nullable: false),
                    priceforperiodamount = table.Column<decimal>(name: "price_for_period_amount", type: "numeric", nullable: false),
                    priceforperiodcurrency = table.Column<string>(name: "price_for_period_currency", type: "text", nullable: false),
                    cleaningfeeamount = table.Column<decimal>(name: "cleaning_fee_amount", type: "numeric", nullable: false),
                    cleaningfeecurrency = table.Column<string>(name: "cleaning_fee_currency", type: "text", nullable: false),
                    amenitiesupchargeamount = table.Column<decimal>(name: "amenities_up_charge_amount", type: "numeric", nullable: false),
                    amenitiesupchargecurrency = table.Column<string>(name: "amenities_up_charge_currency", type: "text", nullable: false),
                    totalpriceamount = table.Column<decimal>(name: "total_price_amount", type: "numeric", nullable: false),
                    totalpricecurrency = table.Column<string>(name: "total_price_currency", type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    createdonutc = table.Column<DateTime>(name: "created_on_utc", type: "timestamp with time zone", nullable: false),
                    confirmedonutc = table.Column<DateTime>(name: "confirmed_on_utc", type: "timestamp with time zone", nullable: false),
                    rejectedonutc = table.Column<DateTime>(name: "rejected_on_utc", type: "timestamp with time zone", nullable: false),
                    completedonutc = table.Column<DateTime>(name: "completed_on_utc", type: "timestamp with time zone", nullable: false),
                    cancelledonutc = table.Column<DateTime>(name: "cancelled_on_utc", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bookings", x => x.id);
                    table.ForeignKey(
                        name: "fk_bookings_apartments_apartment_id1",
                        column: x => x.apartmentid,
                        principalTable: "apartments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bookings_user_user_temp_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    apartmentid = table.Column<Guid>(name: "apartment_id", type: "uuid", nullable: false),
                    bookingid = table.Column<Guid>(name: "booking_id", type: "uuid", nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    comment = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    createdonutc = table.Column<DateTime>(name: "created_on_utc", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reviews", x => x.id);
                    table.ForeignKey(
                        name: "fk_reviews_apartments_apartment_id1",
                        column: x => x.apartmentid,
                        principalTable: "apartments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reviews_bookings_booking_id1",
                        column: x => x.bookingid,
                        principalTable: "bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reviews_user_user_temp_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_bookings_apartment_id",
                table: "bookings",
                column: "apartment_id");

            migrationBuilder.CreateIndex(
                name: "ix_bookings_user_id",
                table: "bookings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_apartment_id",
                table: "reviews",
                column: "apartment_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_booking_id",
                table: "reviews",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_user_id",
                table: "reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "apartments");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
