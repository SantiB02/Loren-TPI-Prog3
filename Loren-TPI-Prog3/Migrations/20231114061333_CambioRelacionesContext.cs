using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loren_TPI_Prog3.Migrations
{
    /// <inheritdoc />
    public partial class CambioRelacionesContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("d3919bcc-a4cf-4eb8-b537-2c2a569576ad"), new DateTime(2023, 11, 14, 0, 34, 47, 136, DateTimeKind.Local).AddTicks(7879) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("665dcbfa-88b6-4ef7-baa5-ba3e0584b095"), new DateTime(2023, 11, 14, 0, 34, 47, 136, DateTimeKind.Local).AddTicks(7958) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("fc499a24-0f99-486e-86aa-293b82cd0518"), new DateTime(2023, 11, 14, 0, 34, 47, 136, DateTimeKind.Local).AddTicks(7961) });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderCode",
                value: new Guid("c919d149-e37e-488d-a6d4-dee164229102"));

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderCode",
                value: new Guid("3c843d48-795a-4de0-a4a9-3891fcffe99d"));
        }
    }
}
