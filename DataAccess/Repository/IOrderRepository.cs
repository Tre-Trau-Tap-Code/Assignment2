using BusinessObject;
using System;
namespace DataAccess;
public interface IOrderRepository
{
    IEnumerable<Order> GetOrders();
    List<Order> GetOrderByMemberId(int memberId);
    Order GetOrderById(int orderId);
    void InsertOrder(Order order);
    void DeleteOrder(int orderId);
    void UpdateOrder();
}
