using BusinessObject;
using System;
namespace DataAccess;
public class OrderRepository : IOrderRepository
{
    public Order GetOrderById(int orderId) => OrderDAO.Instance.GetOrderByID(orderId);
    public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrders;
    public List<Order> GetOrderByMemberId(int memberId) => OrderDAO.Instance.GetOrderByMemberID(memberId);
    public void InsertOrder(Order order) => OrderDAO.Instance.AddNew(order);
    public void UpdateOrder() => OrderDAO.Instance.Update();
    public void DeleteOrder(int orderID) => OrderDAO.Instance.Remove(orderID);

}
