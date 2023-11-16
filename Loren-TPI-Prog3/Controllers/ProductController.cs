using ErrorOr;
using Loren_TPI_Prog3.Data.Entities.Products;
using Loren_TPI_Prog3.Data.Models;
using Loren_TPI_Prog3.ServiceErrors;
using Loren_TPI_Prog3.Services.Implementations;
using Loren_TPI_Prog3.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Loren_TPI_Prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts().Value);
        }
        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            return Ok(_productService.GetProduct(productId).Value);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreateDto productCreateDto)

        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin" || role == "SuperAdmin")
            {
                Product productCreate = new Product()
                {
                    Name = productCreateDto.Name,
                    Description = productCreateDto.Description,
                    Variants = productCreateDto.VariantsDto.Select(v => new ProductVariant { 
                        ColorId = v.ColorId,
                        SizeId = v.SizeId,
                        Stock = v.Stock
                    }).ToList(),

                    Price = productCreateDto.Price,
                    CreationDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    Code = Guid.NewGuid(),
                    Discount = productCreateDto.Discount,
                    ImageLink = productCreateDto.ImageLink,
                    Category = productCreateDto.Category
                };
                
                _productService.CreateProduct(productCreate);
                return Ok(productCreate.Code);
            }
            return Forbid();
        }

        [Authorize]
        [HttpPut("{productId}")]
        public IActionResult UpdateProduct([FromRoute] int productId, [FromBody] ProductUpdateDto product)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin" || role == "SuperAdmin")
            {

                Product productUpdate = new Product()
                {
                    Id = productId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    LastModifiedDate = DateTime.Now,
                    Discount = product.Discount,
                    ImageLink = product.ImageLink,
                    Category = product.Category
                };

                var updateResult = _productService.UpdateProduct(productId, productUpdate);

                if (updateResult.Value == Result.Updated)
                {
                    return Ok();
                }
                return BadRequest();
            }

            return Forbid();
        }

        [Authorize]
        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct([FromRoute] int productId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin" || role == "SuperAdmin")
            {
                var deleteResult = _productService.DeleteProduct(productId);
                if (deleteResult == Result.Deleted)
                {
                    return Ok();
                }
                else if (deleteResult == Errors.Product.AlreadyDeleted)
                {
                    return BadRequest(deleteResult.FirstError);
                }
                else
                {
                    return NotFound(deleteResult.FirstError);
                }
            }
            return Forbid();
        }
    }
}