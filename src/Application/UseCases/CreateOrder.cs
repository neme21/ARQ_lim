using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class CreateOrderUseCase
{
    private readonly IOrderRepository _repository;

    public CreateOrderUseCase(IOrderRepository repository)
    {
        _repository = repository;
    }

    public Order Execute(string customer, string product, int qty, decimal price)
    {
        var order = new Order(customer, product, qty, price);

        _repository.Save(order);

        return order;
    }
}
