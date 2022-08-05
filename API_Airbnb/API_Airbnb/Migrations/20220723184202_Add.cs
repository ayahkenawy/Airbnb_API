using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Airbnb.Migrations
{
    public partial class Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.CreateTable(
                name: "ar_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ar_countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ar_currencies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    icon_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_currencies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ar_promo_codes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    discount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_promo_codes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ar_property_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    icon_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_property_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ar_room_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    icon_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_room_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ar_users",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_type = table.Column<bool>(type: "bit", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "datetime", nullable: true),
                    facebook_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    twitter_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    about = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recieve_coupon = table.Column<bool>(type: "bit", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ar_subcategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_subcategories", x => x.id);
                    table.ForeignKey(
                        name: "FK__ar_subcat__categ__2739D489",
                        column: x => x.category_id,
                        principalTable: "ar_categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ar_Cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    country_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_Cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_ar_Cities_ar_countries",
                        column: x => x.country_id,
                        principalTable: "ar_countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ar_states",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_states", x => x.id);
                    table.ForeignKey(
                        name: "FK_ar_states_ar_Cities",
                        column: x => x.city_id,
                        principalTable: "ar_Cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ar_properties",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    property_type_id = table.Column<int>(type: "int", nullable: true),
                    room_type_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    subcategory_id = table.Column<int>(type: "int", nullable: true),
                    country_id = table.Column<int>(type: "int", nullable: true),
                    state_id = table.Column<int>(type: "int", nullable: true),
                    city_id = table.Column<int>(type: "int", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    latitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    longitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bedroom_count = table.Column<byte>(type: "tinyint", nullable: true),
                    bed_count = table.Column<byte>(type: "tinyint", nullable: true),
                    bathroom_count = table.Column<byte>(type: "tinyint", nullable: true),
                    accomodates_count = table.Column<byte>(type: "tinyint", nullable: true),
                    availability_type = table.Column<bool>(type: "bit", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    currency_id = table.Column<int>(type: "int", nullable: true),
                    price_type = table.Column<byte>(type: "tinyint", nullable: true),
                    minimum_stay = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    minimum_stay_type = table.Column<byte>(type: "tinyint", nullable: true),
                    refund_type = table.Column<bool>(type: "bit", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_properties", x => x.id);
                    table.ForeignKey(
                        name: "FK_ar_properties_ar_categories",
                        column: x => x.category_id,
                        principalTable: "ar_categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ar_properties_ar_Cities",
                        column: x => x.city_id,
                        principalTable: "ar_Cities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ar_properties_ar_countries",
                        column: x => x.country_id,
                        principalTable: "ar_countries",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ar_properties_ar_currencies",
                        column: x => x.currency_id,
                        principalTable: "ar_currencies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ar_properties_ar_property_type",
                        column: x => x.property_type_id,
                        principalTable: "ar_property_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ar_properties_ar_room_type",
                        column: x => x.room_type_id,
                        principalTable: "ar_room_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ar_properties_ar_states",
                        column: x => x.state_id,
                        principalTable: "ar_states",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ar_properties_ar_subcategories",
                        column: x => x.subcategory_id,
                        principalTable: "ar_subcategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ar_properties_ar_users",
                        column: x => x.user_id,
                        principalTable: "ar_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ar_bookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    property_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    check_in_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    check_out_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    price_per_day = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    price_per_stay = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    tax_paid = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    site_fees = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    amount_paid = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    is_refund = table.Column<bool>(type: "bit", nullable: true),
                    cancel_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    refund_paid = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    booking_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_bookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_ar_bookings_ar_properties1",
                        column: x => x.property_id,
                        principalTable: "ar_properties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ar_bookings_ar_users",
                        column: x => x.user_id,
                        principalTable: "ar_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ar_property_images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    property_id = table.Column<int>(type: "int", nullable: true),
                    added_by_user = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_property_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_ar_property_images_ar_properties",
                        column: x => x.property_id,
                        principalTable: "ar_properties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ar_property_images_ar_users",
                        column: x => x.added_by_user,
                        principalTable: "ar_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ar_transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    property_id = table.Column<int>(type: "int", nullable: true),
                    reciever_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    booking_id = table.Column<int>(type: "int", nullable: true),
                    site_frees = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    transfer_on = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    currency_id = table.Column<int>(type: "int", nullable: true),
                    promo_code_id = table.Column<int>(type: "int", nullable: true),
                    discound_amt = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK__ar_transa__curre__282DF8C2",
                        column: x => x.currency_id,
                        principalTable: "ar_currencies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__ar_transa__promo__29221CFB",
                        column: x => x.promo_code_id,
                        principalTable: "ar_promo_codes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__ar_transa__prope__5FB337D6",
                        column: x => x.property_id,
                        principalTable: "ar_properties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__ar_transa__recie__2B0A656D",
                        column: x => x.reciever_id,
                        principalTable: "ar_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ar_disputes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    property_id = table.Column<int>(type: "int", nullable: true),
                    booking_id = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_disputes", x => x.id);
                    table.ForeignKey(
                        name: "FK__ar_disput__booki__5812160E",
                        column: x => x.booking_id,
                        principalTable: "ar_bookings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__ar_disput__prope__59063A47",
                        column: x => x.property_id,
                        principalTable: "ar_properties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__ar_disput__user___17F790F9",
                        column: x => x.user_id,
                        principalTable: "ar_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ar_property_reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    property_id = table.Column<int>(type: "int", nullable: true),
                    review_by_user = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    booking_id = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<byte>(type: "tinyint", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ar_property_reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_ar_property_reviews_ar_bookings",
                        column: x => x.booking_id,
                        principalTable: "ar_bookings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ar_property_reviews_ar_properties",
                        column: x => x.property_id,
                        principalTable: "ar_properties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ar_property_reviews_ar_users",
                        column: x => x.review_by_user,
                        principalTable: "ar_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ar_bookings_property_id",
                table: "ar_bookings",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_bookings_user_id",
                table: "ar_bookings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_Cities_country_id",
                table: "ar_Cities",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_disputes_booking_id",
                table: "ar_disputes",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_disputes_property_id",
                table: "ar_disputes",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_disputes_user_id",
                table: "ar_disputes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_properties_category_id",
                table: "ar_properties",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_properties_city_id",
                table: "ar_properties",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_properties_country_id",
                table: "ar_properties",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_properties_currency_id",
                table: "ar_properties",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_properties_property_type_id",
                table: "ar_properties",
                column: "property_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_properties_room_type_id",
                table: "ar_properties",
                column: "room_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_properties_state_id",
                table: "ar_properties",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_properties_subcategory_id",
                table: "ar_properties",
                column: "subcategory_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_properties_user_id",
                table: "ar_properties",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_property_images_added_by_user",
                table: "ar_property_images",
                column: "added_by_user");

            migrationBuilder.CreateIndex(
                name: "IX_ar_property_images_property_id",
                table: "ar_property_images",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_property_reviews_booking_id",
                table: "ar_property_reviews",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_property_reviews_property_id",
                table: "ar_property_reviews",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_property_reviews_review_by_user",
                table: "ar_property_reviews",
                column: "review_by_user");

            migrationBuilder.CreateIndex(
                name: "IX_ar_states_city_id",
                table: "ar_states",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_subcategories_category_id",
                table: "ar_subcategories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_transactions_currency_id",
                table: "ar_transactions",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_transactions_promo_code_id",
                table: "ar_transactions",
                column: "promo_code_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_transactions_property_id",
                table: "ar_transactions",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_ar_transactions_reciever_id",
                table: "ar_transactions",
                column: "reciever_id");
            */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ar_disputes");

            migrationBuilder.DropTable(
                name: "ar_property_images");

            migrationBuilder.DropTable(
                name: "ar_property_reviews");

            migrationBuilder.DropTable(
                name: "ar_transactions");

            migrationBuilder.DropTable(
                name: "ar_bookings");

            migrationBuilder.DropTable(
                name: "ar_promo_codes");

            migrationBuilder.DropTable(
                name: "ar_properties");

            migrationBuilder.DropTable(
                name: "ar_currencies");

            migrationBuilder.DropTable(
                name: "ar_property_type");

            migrationBuilder.DropTable(
                name: "ar_room_type");

            migrationBuilder.DropTable(
                name: "ar_states");

            migrationBuilder.DropTable(
                name: "ar_subcategories");

            migrationBuilder.DropTable(
                name: "ar_users");

            migrationBuilder.DropTable(
                name: "ar_Cities");

            migrationBuilder.DropTable(
                name: "ar_categories");

            migrationBuilder.DropTable(
                name: "ar_countries");
        }

    }
}
