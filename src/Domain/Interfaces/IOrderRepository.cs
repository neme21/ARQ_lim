namespace Domain.Interfaces;
using System.Collections.Generic;
using Domain.Entities;

public interface IOrderRepository
{
    void Save(Order order);
}
