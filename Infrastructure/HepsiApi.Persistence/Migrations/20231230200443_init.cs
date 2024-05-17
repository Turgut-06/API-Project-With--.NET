using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HepsiApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 30, 23, 4, 43, 750, DateTimeKind.Local).AddTicks(9342), "Books & Movies" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 30, 23, 4, 43, 750, DateTimeKind.Local).AddTicks(9444), "Electronics, Movies & Music" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 30, 23, 4, 43, 750, DateTimeKind.Local).AddTicks(9461), "Electronics & Health" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 30, 23, 4, 43, 751, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 30, 23, 4, 43, 751, DateTimeKind.Local).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 30, 23, 4, 43, 751, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 30, 23, 4, 43, 751, DateTimeKind.Local).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 12, 30, 23, 4, 43, 752, DateTimeKind.Local).AddTicks(5519), "Quia karşıdakine vitae masanın eaque.", "Veritatis." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 12, 30, 23, 4, 43, 752, DateTimeKind.Local).AddTicks(5555), "Esse domates mıknatıslı minima yazın.", "Modi gülüyorum." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 12, 30, 23, 4, 43, 752, DateTimeKind.Local).AddTicks(5582), "Nihil lambadaki dağılımı reprehenderit esse.", "Laboriosam." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2023, 12, 30, 23, 4, 43, 753, DateTimeKind.Local).AddTicks(9915), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 0.5473060126212890m, 579.70m, "Handmade Wooden Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2023, 12, 30, 23, 4, 43, 753, DateTimeKind.Local).AddTicks(9940), "The Football Is Good For Training And Recreational Purposes", 9.351746391088850m, 526.71m, "Gorgeous Fresh Gloves" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 30, 22, 59, 56, 94, DateTimeKind.Local).AddTicks(189), "Books" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 30, 22, 59, 56, 94, DateTimeKind.Local).AddTicks(592), "Grocery, Shoes & Kids" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 30, 22, 59, 56, 94, DateTimeKind.Local).AddTicks(613), "Grocery, Music & Sports" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 30, 22, 59, 56, 94, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 30, 22, 59, 56, 94, DateTimeKind.Local).AddTicks(3411));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 30, 22, 59, 56, 94, DateTimeKind.Local).AddTicks(3413));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 30, 22, 59, 56, 94, DateTimeKind.Local).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 12, 30, 22, 59, 56, 95, DateTimeKind.Local).AddTicks(9621), "Ad ama tv velit anlamsız.", "Işık." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 12, 30, 22, 59, 56, 95, DateTimeKind.Local).AddTicks(9655), "İnventore nemo otobüs dağılımı hesap.", "Ki veritatis." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 12, 30, 22, 59, 56, 95, DateTimeKind.Local).AddTicks(9684), "Quam sed sit minima dignissimos.", "Molestiae." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2023, 12, 30, 22, 59, 56, 97, DateTimeKind.Local).AddTicks(3680), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 2.147289928317130m, 277.07m, "Unbranded Metal Hat" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2023, 12, 30, 22, 59, 56, 97, DateTimeKind.Local).AddTicks(3706), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 6.449847519843360m, 82.21m, "Refined Cotton Towels" });
        }
    }
}
