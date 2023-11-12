using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Loren_TPI_Prog3.Enums;

namespace Loren_TPI_Prog3.Data.Entities
{
    public abstract class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public string UserType { get; set; } = nameof(UserRoleEnum.Client); //para usar el nombre de la propiedad del enum
        public bool State { get; set; } = true;
    }
}
