using Loren_TPI_Prog3.Data.Entities;
using Loren_TPI_Prog3.Enums;
using Microsoft.EntityFrameworkCore;

namespace Loren_TPI_Prog3.Data
{
    public class LorenContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }

        public LorenContext (DbContextOptions<LorenContext> dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Email = "leocabral@gmail.com",
                    Id = 1,
                    LastName = "Cabral",
                    Name = "Leandro",
                    Password = "leo123456",
                    UserName = "lean94"
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
                    UserType = "admin"
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
                    UserType = "superadmin"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Code = Guid.NewGuid(),
                    Description = "Corpiño de suave textura y excelente calidad",
                    StartDateTime = new DateTime(2023, 10, 3),
                    Id = 1,
                    Name = "Corpiño",
                    Price = 5000.34M
                });

            modelBuilder.Entity<SaleOrder>().HasData(
                new SaleOrder
                {
                    Id = 1,
                    OrderCode = Guid.NewGuid(),
                    OrderDate = new DateTime(2023, 8, 14),
                    PaymentMethod = PaymentMethodEnum.TarjetaDeDebito,
                    TotalPrice = 15000.34M
                }
                );
            //relación uno (cliente) a muchos (órdenes de venta)
            modelBuilder.Entity<Client>()
                .HasMany(cl => cl.SaleOrders)
                .WithOne(so => so.Client)
                .HasForeignKey(so => so.ClientId);

            modelBuilder.Entity<SaleOrder>()
                .HasOne(so => so.Client)
                .WithMany(cl => cl.SaleOrders)
                .HasForeignKey(so => so.ClientId);

            //relación uno (admin) a muchos (productos)
            modelBuilder.Entity<Admin>()
                .HasMany(a => a.ModifiedProducts)
                .WithOne(p => p.Admin)
                .HasForeignKey(a => a.AdminId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Admin)
                .WithMany(a => a.ModifiedProducts)
                .HasForeignKey(a => a.AdminId);

            //relación uno (superadmin) a muchos (usuarios) REVISAR RELACIÓN ENTRE SUPERADMIN Y USUARIOS MODIFICADOS
            //modelBuilder.Entity<SuperAdmin>()
                //.HasMany(sa => sa.ModifiedUsers)
                //.WithOne(u => u.)

            //ACÁ IRÍAN RELACIONES ENTRE PRODUCTO Y SUS COLORES Y TALLES?
        }
    }
}
