using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loren_TPI_Prog3.Migrations
{
    /// <inheritdoc />
    public partial class ProductPropertiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Discount", "ImageLink", "LastModifiedDate" },
                values: new object[] { new Guid("7bef2d98-d02e-49af-aba6-bcd87df1938c"), 0m, "https://selulen.vtexassets.com/arquivos/ids/179923/SL16202_vison_1-selu-camison-raso-pijama-regulable-enagua-puntilla-estampado.jpg?v=638104325419730000", new DateTime(2023, 11, 15, 19, 47, 41, 517, DateTimeKind.Local).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "Discount", "ImageLink", "LastModifiedDate" },
                values: new object[] { new Guid("c7b04819-c0b1-47cf-b197-0cd3e3080ae9"), 10.5m, "https://http2.mlstatic.com/D_NQ_NP_674011-MLA52236140541_112022-O.webp", new DateTime(2023, 11, 15, 19, 47, 41, 517, DateTimeKind.Local).AddTicks(5989) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "Discount", "ImageLink", "LastModifiedDate" },
                values: new object[] { new Guid("2e055364-d547-41f7-8499-19a9fa8db522"), 0m, "https://http2.mlstatic.com/D_NQ_NP_692024-MLA53006038573_122022-O.webp", new DateTime(2023, 11, 15, 19, 47, 41, 517, DateTimeKind.Local).AddTicks(5992) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Products");

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
                column: "OrderCode",
                value: new Guid("a1ba9393-cfc8-4e43-9e3f-b290e192431e"));

            migrationBuilder.UpdateData(
                table: "SaleOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderCode",
                value: new Guid("0f73c644-8d63-4e12-ba12-719398267174"));
        }
    }
}
