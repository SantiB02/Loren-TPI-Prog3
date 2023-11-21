using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Loren_TPI_Prog3.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsRefreshFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorCode = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeCode = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOrders_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrderLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    QuantityOrdered = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOrderLine_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOrderLine_SaleOrders_SaleOrderId",
                        column: x => x.SaleOrderId,
                        principalTable: "SaleOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "ColorCode", "Name" },
                values: new object[,]
                {
                    { 1, 34, "Negro" },
                    { 2, 65, "Blanco" },
                    { 3, 28, "Rojo" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreationDate", "Description", "Discount", "ImageLink", "LastModifiedDate", "Name", "Price", "State" },
                values: new object[,]
                {
                    { 1, "Corpiños", "86a82f45-0b59-4a91-8a55-8310231d2145", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corpiño push-up de suave textura y excelente calidad", 0m, "https://http2.mlstatic.com/D_NQ_NP_692024-MLA53006038573_122022-O.webp", new DateTime(2023, 11, 21, 3, 47, 35, 645, DateTimeKind.Local).AddTicks(6278), "Corpiño", 12000.34m, true },
                    { 2, "Mallas", "c0a10729-935c-4b64-a759-8d41e5d7d17f", new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malla de algodón", 10.5m, "https://http2.mlstatic.com/D_NQ_NP_674011-MLA52236140541_112022-O.webp", new DateTime(2023, 11, 21, 3, 47, 35, 645, DateTimeKind.Local).AddTicks(6336), "Malla", 9000.84m, true },
                    { 3, "Camisones", "5d38a43d-b7dc-4c37-af67-ed67dec9fa69", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Camisón de seda confeccionado con un material suave y lujoso", 0m, "https://selulen.vtexassets.com/arquivos/ids/179923/SL16202_vison_1-selu-camison-raso-pijama-regulable-enagua-puntilla-estampado.jpg?v=638104325419730000", new DateTime(2023, 11, 21, 3, 47, 35, 645, DateTimeKind.Local).AddTicks(6341), "Camisón", 5000.34m, true }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name", "SizeCode" },
                values: new object[,]
                {
                    { 1, "S", 23 },
                    { 2, "M", 75 },
                    { 3, "L", 12 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "LastName", "Name", "Password", "State", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, "Montevideo 1150 7B", "leocabral@gmail.com", "Cabral", "Leandro", "leo123456", true, "lean94", "Client" },
                    { 2, null, "ezecoria@gmail.com", "Coria", "Ezequiel", "eze123456", true, "eze95", "Admin" },
                    { 3, null, "santibrasca@gmail.com", "Brasca", "Santiago", "santi123456", true, "santi02", "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "ColorId", "ProductId", "SizeId", "Stock" },
                values: new object[,]
                {
                    { 1, 2, 1, 3, 14 },
                    { 2, 3, 2, 1, 24 },
                    { 3, 1, 3, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "SaleOrders",
                columns: new[] { "Id", "ClientId", "Completed", "OrderCode", "OrderDate", "PaymentMethod", "State" },
                values: new object[,]
                {
                    { 1, 1, false, "f3077694-88c7-4904-b7cc-79c8211e17c5", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, true },
                    { 2, 1, false, "4de94d25-6ac4-45ea-b57a-77aa63d0d3ba", new DateTime(2023, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true }
                });

            migrationBuilder.InsertData(
                table: "SaleOrderLine",
                columns: new[] { "Id", "ProductId", "QuantityOrdered", "SaleOrderId", "Total" },
                values: new object[,]
                {
                    { 1, 1, 2, 1, 0m },
                    { 2, 2, 1, 1, 0m },
                    { 3, 3, 3, 2, 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ColorId",
                table: "ProductVariants",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_SizeId",
                table: "ProductVariants",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLine_ProductId",
                table: "SaleOrderLine",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLine_SaleOrderId",
                table: "SaleOrderLine",
                column: "SaleOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_ClientId",
                table: "SaleOrders",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "SaleOrderLine");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SaleOrders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
