namespace Domain.Interfaces;

using Domain.Entities;

public interface IOrderRepository
{
    void Save(Order order);
}
