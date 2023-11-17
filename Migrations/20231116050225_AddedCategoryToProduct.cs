using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loren_TPI_Prog3.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Code", "LastModifiedDate" },
                values: new object[] { "Corpiños", new Guid("591b2bc8-88e4-45b5-915c-1b86cfca12c6"), new DateTime(2023, 11, 16, 2, 2, 25, 46, DateTimeKind.Local).AddTicks(5113) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Code", "LastModifiedDate" },
                values: new object[] { "Mallas", new Guid("44df6d9e-4819-47dc-bfd2-11b08dd1abdb"), new DateTime(2023, 11, 16, 2, 2, 25, 46, DateTimeKind.Local).AddTicks(5162) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Code", "LastModifiedDate" },
                values: new object[] { "Camisones", new Guid("8da9543c-a534-47f4-9930-efdc2d91c226"), new DateTime(2023, 11, 16, 2, 2, 25, 46, DateTimeKind.Local).AddTicks(5166) });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderCode",
                value: new Guid("31143cac-2b7a-44ea-b5cc-e06a07735d05"));

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderCode",
                value: new Guid("1e6f81c3-a248-4de9-b004-7853af8791d2"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("7bef2d98-d02e-49af-aba6-bcd87df1938c"), new DateTime(2023, 11, 15, 19, 47, 41, 517, DateTimeKind.Local).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("c7b04819-c0b1-47cf-b197-0cd3e3080ae9"), new DateTime(2023, 11, 15, 19, 47, 41, 517, DateTimeKind.Local).AddTicks(5989) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("2e055364-d547-41f7-8499-19a9fa8db522"), new DateTime(2023, 11, 15, 19, 47, 41, 517, DateTimeKind.Local).AddTicks(5992) });

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderCode",
                value: new Guid("072d5c83-6a0b-4f2f-bf44-3f7d511aceb4"));

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderCode",
                value: new Guid("4582aa3d-66a3-4bb1-9f7b-db82fc0b2bd8"));
        }
    }
}
