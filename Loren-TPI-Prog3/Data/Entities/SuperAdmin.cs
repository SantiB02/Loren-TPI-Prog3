namespace Loren_TPI_Prog3.Data.Entities
{
    public class SuperAdmin : Admin
    {
        public ICollection<User> ModifiedUsers { get; set; } = new List<User>();
    }
}
