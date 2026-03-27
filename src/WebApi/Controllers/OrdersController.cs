using Microsoft.AspNetCore.Mvc;
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
        var order = _useCase.Execute(
            request.Customer,
            request.Product,
            request.Quantity,
            request.Price);

        return Ok(order);
    }
}

public class CreateOrderRequest
{
    public string Customer { get; set; }
    public string Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
