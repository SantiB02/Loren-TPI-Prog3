using Loren_TPI_Prog3.Data.Entities;
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

                );
        }
    }
}
