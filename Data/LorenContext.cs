using Loren_TPI_Prog3.Data.Entities;
using Loren_TPI_Prog3.Data.Entities.Products;
using Loren_TPI_Prog3.Enums;
using Microsoft.EntityFrameworkCore;

namespace Loren_TPI_Prog3.Data
{
    public class LorenContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }

        public LorenContext (DbContextOptions<LorenContext> dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType); //discriminamos a los usuarios por su rol

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Email = "leocabral@gmail.com",
                    Id = 1,
                    LastName = "Cabral",
                    Name = "Leandro",
                    Password = "leo123456",
                    UserName = "lean94",
                    Address = "Montevideo 1150 7B"
                });

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Email = "ezecoria@gmail.com",
                    Id = 2,
                    LastName = "Coria",
                    Name = "Ezequiel",
                    Password = "eze123456",
                    UserName = "eze95",
                    UserType = nameof(UserRoleEnum.Admin)
                });

            modelBuilder.Entity<SuperAdmin>().HasData(
                new SuperAdmin
                {
                    Email = "santibrasca@gmail.com",
                    Id = 3,
                    LastName = "Brasca",
                    Name = "Santiago",
                    Password = "santi123456",
                    UserName = "santi02",
                    UserType = nameof(UserRoleEnum.SuperAdmin)
                });

            //guardamos datos en la tabla de productos
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Code = Guid.NewGuid().ToString(),
                    Description = "Corpiño push-up de suave textura y excelente calidad",
                    CreationDate = new DateTime(2023, 10, 3),
                    Id = 1,
                    Name = "Corpiño",
                    Price = 12000.34M,
                    ImageLink = "https://http2.mlstatic.com/D_NQ_NP_692024-MLA53006038573_122022-O.webp",
                    Category = "Corpiños"
                },
                new Product
                {
                    Code = Guid.NewGuid().ToString(),
                    Description = "Malla de algodón",
                    CreationDate = new DateTime(2023, 10, 29),
                    Id = 2,
                    Name = "Malla",
                    Price = 9000.84M,
                    Discount = 10.5M,
                    ImageLink = "https://http2.mlstatic.com/D_NQ_NP_674011-MLA52236140541_112022-O.webp",
                    Category = "Mallas"

                },
                new Product
                {
                    Code = Guid.NewGuid().ToString(),
                    Description = "Camisón de seda confeccionado con un material suave y lujoso",
                    CreationDate = new DateTime(2023, 10, 3),
                    Id = 3,
                    Name = "Camisón",
                    Price = 5000.34M,
                    ImageLink = "https://selulen.vtexassets.com/arquivos/ids/179923/SL16202_vison_1-selu-camison-raso-pijama-regulable-enagua-puntilla-estampado.jpg?v=638104325419730000",
                    Category = "Camisones"
                }
                );

            //guardamos datos en la tabla de variantes de productos:
            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    Id = 1,
                    ProductId = 1, //el producto con Id 1 tiene este color, talle y stock
                    ColorId = 2,
                    SizeId = 3,
                    Stock = 14
                }, 
                new ProductVariant
                {
                    Id = 2,
                    ProductId = 2,
                    ColorId = 3,
                    SizeId = 1,
                    Stock = 24
                },
                new ProductVariant
                {
                    Id = 3,
                    ProductId = 3,
                    ColorId = 1,
                    SizeId = 2,
                    Stock = 5
                }
                );

            //guardamos datos en la tabla de órdenes de venta:
            modelBuilder.Entity<SaleOrder>().HasData(
                new SaleOrder
                {
                    Id = 1,
                    OrderCode = Guid.NewGuid().ToString(),
                    OrderDate = new DateTime(2023, 8, 14),
                    PaymentMethod = PaymentMethodEnum.TarjetaDeDebito,
                    //TotalPrice = 15000.34M,
                    ClientId = 1,
                },
                new SaleOrder
                {
                    Id = 2,
                    OrderCode = Guid.NewGuid().ToString(),
                    OrderDate = new DateTime(2023, 10, 11),
                    PaymentMethod = PaymentMethodEnum.TarjetaDeCredito,
                    //TotalPrice = 38000.95M,
                    ClientId = 1,
                    //Las SaleOrderLines se crean como entidades separadas ya que es una propiedad de navegación, y luego se relaciona a la SaleOrder correspondiente seteando la propiedad de foreign key llamada "SaleOrderId"
                }
                );

            modelBuilder.Entity<SaleOrderLine>().HasData(
                new SaleOrderLine
                {
                    Id= 1,
                    ProductId = 1,
                    QuantityOrdered = 2,
                    SaleOrderId = 1,
                    //si el total tira excepción, calculamos el Total en el servicio
                },
                new SaleOrderLine
                {
                    Id = 2,
                    ProductId = 2,
                    QuantityOrdered = 1,
                    SaleOrderId = 1,
                    //si el total tira excepción, calculamos el Total en el servicio
                },
                new SaleOrderLine
                {
                    Id = 3,
                    ProductId = 3,
                    QuantityOrdered = 3,
                    SaleOrderId = 2,
                    //si el total tira excepción, calculamos el Total en el servicio
                }
                );

            //guardamos datos en la tabla de colores:
            modelBuilder.Entity<Color>().HasData(
                new Color
                {
                    Id = 1,
                    ColorCode = 34,
                    Name = "Negro"
                },
                new Color
                {
                    Id = 2,
                    ColorCode = 65,
                    Name = "Blanco"
                },
                new Color
                {
                    Id = 3,
                    ColorCode = 28,
                    Name = "Rojo"
                }
                );

            //guardamos datos en la tabla de talles:
            modelBuilder.Entity<Size>().HasData(
                new Size
                {
                    Id = 1,
                    SizeCode = 23,
                    Name = "S"
                },
                new Size
                {
                    Id = 2,
                    SizeCode = 75,
                    Name = "M"
                },
                new Size
                {
                    Id = 3,
                    SizeCode = 12,
                    Name = "L"
                }
                );

            //relación uno (cliente) a muchos (órdenes de venta)
            modelBuilder.Entity<Client>()
                .HasMany(cl => cl.SaleOrders)
                .WithOne(so => so.Client)
                .HasForeignKey(so => so.ClientId);

            //relación uno (orden de venta) a muchos (líneas de orden de venta)
            modelBuilder.Entity<SaleOrder>()
                .HasMany(so => so.SaleOrderLines)
                .WithOne()
                .HasForeignKey(sol => sol.SaleOrderId);

            //relación muchos (líneas de orden de venta) a uno (producto)
            modelBuilder.Entity<SaleOrderLine>()
                .HasOne(sol => sol.Product)
                .WithMany() //vacío. No me interesa guardar la línea de venta a la que pertenece cada producto, sino al revés
                .HasForeignKey(sol => sol.ProductId);

            //relación uno (producto) a muchos (variantes de producto)
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Variants)
                .WithOne()
                .HasForeignKey(pv => pv.ProductId);
        }
    }
}
