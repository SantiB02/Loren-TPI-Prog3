using ErrorOr;
using Loren_TPI_Prog3.Data.Entities.Products;
using Loren_TPI_Prog3.Data.Models;
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
            return Ok(_productService.GetProducts());
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            return Ok(_productService.GetProduct(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateProduct(ProductCreateDto productCreateDto)

        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin" || role == "SuperAdmin")
            {
                Product productCreate = new Product()
                {
                    Name = productCreateDto.Name,
                    Description = productCreateDto.Description,
                    Variants = productCreateDto.Variants,
                    Price = productCreateDto.Price,
                    CreationDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    Code = Guid.NewGuid(),
                };
                _productService.CreateProduct(productCreate);
                return Ok(productCreate.Code);
            }
            return Forbid();
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateProduct(ProductUpdateDto product)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin" || role == "SuperAdmin")
            {

                Product productUpdate = new Product()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                };

                var updateResult = _productService.UpdateProduct(productUpdate, product.Code);

                if (updateResult.Value == Result.Updated)
                {
                    return Ok();
                }
                return BadRequest();
            }

            return Forbid();
        }

        //FALTA ENDPOINT DELETEPRODUCT

    }
}


        //{
        //    Product productUpdate = new Product()
        //    {
        //        Code = product.Code,
        //        Name = product.Name,
        //        Description = product.Description,
        //        Price = product.Price
        //    };
        //    return Ok(_productService.UpdateProduct(productUpdate));
        //    };


