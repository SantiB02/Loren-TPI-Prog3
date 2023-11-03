namespace Loren_TPI_Prog3.Data.Entities
{
    public class Admin : User
    {
        public ICollection<Product> ModifiedProducts { get; set; } = new List<Product>();
    }
}
