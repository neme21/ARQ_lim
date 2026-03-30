using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Application.UseCases;

namespace WebApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly CreateOrderUseCase _useCase;

    public OrdersController(CreateOrderUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] CreateOrderRequest request)
    {
        var order = _useCase.Execute(
            request.Customer,
            request.Product,
            request.Quantity!.Value,
            request.Price!.Value);

        return Ok(order);
    }
}

public class CreateOrderRequest
{
    [Required]
    public required string Customer { get; set; }

    [Required]
    public required string Product { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? Quantity { get; set; }

    [Required]
    [Range(typeof(decimal), "0.01", "999999999")]
    public decimal? Price { get; set; }
}
