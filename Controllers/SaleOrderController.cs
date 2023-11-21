using ErrorOr;
using Loren_TPI_Prog3.Data.Entities;
using Loren_TPI_Prog3.Data.Models;
using Loren_TPI_Prog3.ServiceErrors;
using Loren_TPI_Prog3.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Loren_TPI_Prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleOrderController : ControllerBase
    {
        private readonly ISaleOrderService _saleOrderService;
        public SaleOrderController(ISaleOrderService saleOrderService)
        {
            _saleOrderService = saleOrderService;
        }

        [HttpGet("{clientId}")]
        public IActionResult GetSaleOrdersByClient([FromRoute] int clientId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            int loggedUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value); //para el cliente

            if (role == "Client")
            {
                return Ok(_saleOrderService.GetSaleOrdersByClient(loggedUserId).Value);
            } else if (role == "Admin" || role == "SuperAdmin")
            {
                return Ok(_saleOrderService.GetSaleOrdersByClient(clientId).Value);
            }
            return Forbid();
        }

        [HttpGet]
        public IActionResult GetSaleOrders()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin" || role == "SuperAdmin")
            {
                return Ok(_saleOrderService.GetSaleOrders().Value);
            }
            return Forbid();
        }

        [HttpPost]
        public IActionResult CreateSaleOrder([FromBody] SaleOrderCreateDto saleOrderCreateDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Client")
            {
                SaleOrder saleOrder = new SaleOrder()
                {
                    OrderCode = Guid.NewGuid().ToString(),
                    SaleOrderLines = saleOrderCreateDto.SaleOrderLines.Select(lineDTO => new SaleOrderLine
                    {
                        ProductId = lineDTO.ProductId,
                        QuantityOrdered = lineDTO.QuantityOrdered,
                        //Total = _saleOrderService.CalculateLineTotal(lineDTO.ProductId, lineDTO.QuantityOrdered).Value,
                        SaleOrderId = lineDTO.SaleOrderId
                    }).ToList(),
                    PaymentMethod = saleOrderCreateDto.PaymentMethod,
                    OrderDate = DateTime.Now,
                    //TotalPrice = _saleOrderService.CalculateSaleOrderTotal(saleOrderCreateDto.SaleOrderLines.ToList()).Value,
                    ClientId = saleOrderCreateDto.ClientId
                };
                return Ok(_saleOrderService.CreateSaleOrder(saleOrder).Value);
            }
            return Forbid();
        }

        [HttpPut]
        public IActionResult CompleteSaleOrder([FromBody] int saleOrderId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin" || role == "SuperAdmin")
            {
                var completionResult = _saleOrderService.CompleteSaleOrder(saleOrderId);
                if (completionResult == Result.Updated)
                {
                    return Ok();
                } else if (completionResult == Errors.SaleOrder.AlreadyCompleted)
                {
                    return BadRequest(completionResult.FirstError);
                } else
                {
                    return NotFound(completionResult.FirstError);
                }
            }
            return Forbid();
        }

        [HttpDelete]
        public IActionResult DeleteSaleOrder([FromBody] int saleOrderId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin" || role == "SuperAdmin")
            {
                var deleteResult = _saleOrderService.DeleteSaleOrder(saleOrderId);
                if (deleteResult == Result.Deleted)
                {
                    return Ok();
                }
                else if (deleteResult == Errors.SaleOrder.AlreadyDeleted)
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
