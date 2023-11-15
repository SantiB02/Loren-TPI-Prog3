using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loren_TPI_Prog3.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSaleOrderProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "SaleOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "SaleOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("27730b68-4dff-4794-8157-4060ba9f34be"), new DateTime(2023, 11, 15, 17, 57, 22, 35, DateTimeKind.Local).AddTicks(4019) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("51d06564-9da9-4ce1-8ada-dde0b44443d6"), new DateTime(2023, 11, 15, 17, 57, 22, 35, DateTimeKind.Local).AddTicks(4066) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("19e5d76f-6571-484c-86e2-820f7b01ddab"), new DateTime(2023, 11, 15, 17, 57, 22, 35, DateTimeKind.Local).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Completed", "OrderCode", "State" },
                values: new object[] { false, new Guid("a1ba9393-cfc8-4e43-9e3f-b290e192431e"), true });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Completed", "OrderCode", "State" },
                values: new object[] { false, new Guid("0f73c644-8d63-4e12-ba12-719398267174"), true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "State",
                table: "SaleOrders");

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
    }
}
