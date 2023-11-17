using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loren_TPI_Prog3.Migrations
{
    /// <inheritdoc />
    public partial class MovedAddressIntoUserClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("b8fc619e-7922-44b5-98f2-6eab1eeb6ac3"), new DateTime(2023, 11, 16, 14, 23, 44, 956, DateTimeKind.Local).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("69abb697-e7c5-45df-a479-9b3b45a5bce3"), new DateTime(2023, 11, 16, 14, 23, 44, 956, DateTimeKind.Local).AddTicks(1463) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("ed9bf2e4-ac08-4344-85de-51e3b1be731e"), new DateTime(2023, 11, 16, 14, 23, 44, 956, DateTimeKind.Local).AddTicks(1467) });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderCode",
                value: new Guid("4f3cb87b-6b92-4130-b6b9-18849f0e2e04"));

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderCode",
                value: new Guid("7fd697d3-9a61-4c6a-a4fa-85a6702a325b"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("ac58590b-118e-41bb-9fb2-936582b3eb4e"), new DateTime(2023, 11, 16, 14, 0, 23, 734, DateTimeKind.Local).AddTicks(5859) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("5ad4a8ed-ccc8-4014-865b-e1d8528c293f"), new DateTime(2023, 11, 16, 14, 0, 23, 734, DateTimeKind.Local).AddTicks(5912) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("4942f8ea-58ad-4c4f-b45b-1210bdf29857"), new DateTime(2023, 11, 16, 14, 0, 23, 734, DateTimeKind.Local).AddTicks(5917) });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderCode",
                value: new Guid("b9707a68-b1f5-448d-8d45-54da7882cfe3"));

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderCode",
                value: new Guid("fba287de-334f-4768-9e5c-dfed2e13f952"));
        }
    }
}
