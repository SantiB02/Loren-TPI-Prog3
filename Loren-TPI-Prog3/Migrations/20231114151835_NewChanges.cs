using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loren_TPI_Prog3.Migrations
{
    /// <inheritdoc />
    public partial class NewChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("a6aa104c-f10a-45f1-9ce2-9e8b7d11a810"), new DateTime(2023, 11, 14, 12, 18, 34, 920, DateTimeKind.Local).AddTicks(3517) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("537889eb-4747-4b1e-8342-fb72ad5073c8"), new DateTime(2023, 11, 14, 12, 18, 34, 920, DateTimeKind.Local).AddTicks(3587) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("f55ff686-73e5-44b3-a4ff-affe8793d4d1"), new DateTime(2023, 11, 14, 12, 18, 34, 920, DateTimeKind.Local).AddTicks(3590) });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderCode",
                value: new Guid("eef95c60-c0e9-41ad-a3f3-37692203f8d2"));

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderCode",
                value: new Guid("5ec84537-14e0-450b-9463-0b505dbad8b4"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("27bb2cdb-8ad5-4d9b-8348-a96456a4e527"), new DateTime(2023, 11, 14, 11, 49, 27, 913, DateTimeKind.Local).AddTicks(8282) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("dadcf011-d66d-40fd-96ed-0eab4e072049"), new DateTime(2023, 11, 14, 11, 49, 27, 913, DateTimeKind.Local).AddTicks(8444) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("288fbb32-6206-4b01-a7de-2a971004aae1"), new DateTime(2023, 11, 14, 11, 49, 27, 913, DateTimeKind.Local).AddTicks(8448) });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderCode",
                value: new Guid("e144963e-2797-4693-a13e-352a5e823333"));

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderCode",
                value: new Guid("58c5d47b-25a5-4000-a046-d0c20f648dd7"));
        }
    }
}
