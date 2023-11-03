using ErrorOr;
using Loren_TPI_Prog3.ServiceErrors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loren_TPI_Prog3.Data.Entities
{
    public class Product
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 50;
        public const int MinDescriptionLength = 20;
        public const int MaxDescriptionLength = 150;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; } = DateTime.MinValue;
        public DateTime LastModifiedDateTime { get; set; } = DateTime.MinValue; //fecha por defecto nula
        public List<string> Color { get; set; } = new();
        public List<string> Size { get; set; } = new();
        public decimal Price {  get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }
        public int AdminId { get; set; }

        public Product() { } //constructor vacío para que funcione la clase derivada SaleOrderProduct

        private Product(
            Guid code,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime lastModifiedDateTime,
            List<string> color,
            List<string> size
        )
        {
            Code = code;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            Color = color;
            Size = size;
        }

        public static ErrorOr<Product> Create(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            List<string> color,
            List<string> size,
            Guid? id = null
        )
        {
            List<Error> errors = new();

            if (name.Length is < MinNameLength or > MaxNameLength)
            {
                errors.Add(Errors.Product.InvalidName);
            }
            if (description.Length is < MinNameLength or > MaxNameLength)
            {
                errors.Add(Errors.Product.InvalidDescription);
            }
            if (errors.Count > 0)
            {
                return errors;
            }
            return new Product(
            id ?? Guid.NewGuid(),
            name,
            description,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            color,
            size
        );
        }

        public static ErrorOr<Product> From(CreateProductRequest request)
        {
            return Create(
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                request.Color,
                request.Size
            );
        }
        public static ErrorOr<Product> From(Guid id, UpsertProductRequest request)
        {
            return Create(
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                request.Color,
                request.Size,
                id
            );
        }
    }
}
