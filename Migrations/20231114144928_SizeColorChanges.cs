using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loren_TPI_Prog3.Migrations
{
    /// <inheritdoc />
    public partial class SizeColorChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "Sizes",
                newName: "SizeCode");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Colors",
                newName: "ColorCode");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SizeCode",
                table: "Sizes",
                newName: "SizeId");

            migrationBuilder.RenameColumn(
                name: "ColorCode",
                table: "Colors",
                newName: "ColorId");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("78072502-dea9-4849-bd84-e8df3ebe6312"), new DateTime(2023, 11, 14, 3, 13, 33, 442, DateTimeKind.Local).AddTicks(2811) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("41167a9a-6f2e-4921-b1e6-e5efbc9ba46f"), new DateTime(2023, 11, 14, 3, 13, 33, 442, DateTimeKind.Local).AddTicks(2855) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("aee070b1-46ad-4d6d-8420-49042c103ba5"), new DateTime(2023, 11, 14, 3, 13, 33, 442, DateTimeKind.Local).AddTicks(2858) });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderCode",
                value: new Guid("4ceeba90-5f9d-4a0b-8ad2-27a65048ea83"));

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderCode",
                value: new Guid("27e2d92e-a298-491c-82c3-f7c1ca1ecce9"));
        }
    }
}
