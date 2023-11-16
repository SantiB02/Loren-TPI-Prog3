using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loren_TPI_Prog3.Migrations
{
    /// <inheritdoc />
    public partial class FixedProductImagesInContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "ImageLink", "LastModifiedDate" },
                values: new object[] { new Guid("ac58590b-118e-41bb-9fb2-936582b3eb4e"), "https://http2.mlstatic.com/D_NQ_NP_692024-MLA53006038573_122022-O.webp", new DateTime(2023, 11, 16, 14, 0, 23, 734, DateTimeKind.Local).AddTicks(5859) });

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
                columns: new[] { "Code", "ImageLink", "LastModifiedDate" },
                values: new object[] { new Guid("4942f8ea-58ad-4c4f-b45b-1210bdf29857"), "https://selulen.vtexassets.com/arquivos/ids/179923/SL16202_vison_1-selu-camison-raso-pijama-regulable-enagua-puntilla-estampado.jpg?v=638104325419730000", new DateTime(2023, 11, 16, 14, 0, 23, 734, DateTimeKind.Local).AddTicks(5917) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "ImageLink", "LastModifiedDate" },
                values: new object[] { new Guid("591b2bc8-88e4-45b5-915c-1b86cfca12c6"), "https://selulen.vtexassets.com/arquivos/ids/179923/SL16202_vison_1-selu-camison-raso-pijama-regulable-enagua-puntilla-estampado.jpg?v=638104325419730000", new DateTime(2023, 11, 16, 2, 2, 25, 46, DateTimeKind.Local).AddTicks(5113) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "LastModifiedDate" },
                values: new object[] { new Guid("44df6d9e-4819-47dc-bfd2-11b08dd1abdb"), new DateTime(2023, 11, 16, 2, 2, 25, 46, DateTimeKind.Local).AddTicks(5162) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "ImageLink", "LastModifiedDate" },
                values: new object[] { new Guid("8da9543c-a534-47f4-9930-efdc2d91c226"), "https://http2.mlstatic.com/D_NQ_NP_692024-MLA53006038573_122022-O.webp", new DateTime(2023, 11, 16, 2, 2, 25, 46, DateTimeKind.Local).AddTicks(5166) });

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
    }
}
