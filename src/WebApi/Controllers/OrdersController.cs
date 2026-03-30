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
    public IActionResult Create([FromBody] CreateOrderRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var order = _useCase.Execute(
            request.Customer!,
            request.Product!,
            request.Quantity!.Value,
            request.Price!.Value);

        return Ok(order);
    }
}

public class CreateOrderRequest
{
    [Required]
    public string Customer { get; set; } = string.Empty;

    [Required]
    public string Product { get; set; } = string.Empty;

    [Required]
    public int? Quantity { get; set; }

    [Required]
    public decimal? Price { get; set; }
}
