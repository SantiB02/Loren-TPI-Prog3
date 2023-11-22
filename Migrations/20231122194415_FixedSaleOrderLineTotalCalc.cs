using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loren_TPI_Prog3.Migrations
{
    /// <inheritdoc />
    public partial class FixedSaleOrderLineTotalCalc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "SaleOrderLine");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { "b934046e-762b-4839-bdad-3aad039e5ce7", new DateTime(2023, 11, 22, 16, 44, 15, 440, DateTimeKind.Local).AddTicks(8444) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { "ea1250dd-1178-4b88-b68b-82a5b8c2441e", new DateTime(2023, 11, 22, 16, 44, 15, 440, DateTimeKind.Local).AddTicks(8501) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { "45b20fa5-2709-48d1-b31f-3715d00ed642", new DateTime(2023, 11, 22, 16, 44, 15, 440, DateTimeKind.Local).AddTicks(8521) });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderCode",
                value: "fd03262b-b014-4699-82fe-f7364d614857");

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderCode",
                value: "a479e224-ba32-44ba-8f9a-b50b3ac6e555");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "SaleOrderLine",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
                table: "SaleOrderLine",
                keyColumn: "Id",
                keyValue: 1,
                column: "Total",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "SaleOrderLine",
                keyColumn: "Id",
                keyValue: 2,
                column: "Total",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "SaleOrderLine",
                keyColumn: "Id",
                keyValue: 3,
                column: "Total",
                value: 0m);

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
    }
}
