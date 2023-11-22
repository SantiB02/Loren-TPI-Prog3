using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loren_TPI_Prog3.Migrations
{
    /// <inheritdoc />
    public partial class SimplifiedSaleOrderLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { "e9ad0c5a-3750-4259-8fef-4dfc35230982", new DateTime(2023, 11, 22, 4, 57, 9, 765, DateTimeKind.Local).AddTicks(1279) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { "ad8a1576-c105-4094-9423-43dd154f4bf0", new DateTime(2023, 11, 22, 4, 57, 9, 765, DateTimeKind.Local).AddTicks(1335) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { "8166fdb2-c2a1-4135-bcc7-1ec2f65d03e2", new DateTime(2023, 11, 22, 4, 57, 9, 765, DateTimeKind.Local).AddTicks(1339) });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderCode",
                value: "c426f069-dfce-4af4-9a2c-5b48b3036a13");

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderCode",
                value: "286cbe9f-d33e-49f2-b0a8-1148d35cc5cf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { "86a82f45-0b59-4a91-8a55-8310231d2145", new DateTime(2023, 11, 21, 3, 47, 35, 645, DateTimeKind.Local).AddTicks(6278) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { "c0a10729-935c-4b64-a759-8d41e5d7d17f", new DateTime(2023, 11, 21, 3, 47, 35, 645, DateTimeKind.Local).AddTicks(6336) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { "5d38a43d-b7dc-4c37-af67-ed67dec9fa69", new DateTime(2023, 11, 21, 3, 47, 35, 645, DateTimeKind.Local).AddTicks(6341) });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderCode",
                value: "f3077694-88c7-4904-b7cc-79c8211e17c5");

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderCode",
                value: "4de94d25-6ac4-45ea-b57a-77aa63d0d3ba");
        }
    }
}
