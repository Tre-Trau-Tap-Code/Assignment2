using BusinessObject;
using System;
namespace DataAccess;
public class OrderDetailRepository : IOrderDetailRepository
{
    public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId) => OrderDetailDAO.Instance.GetOrderDetailsByOrderId(orderId);
    public OrderDetail GetOrderDetailById(int orderId, int productId) => OrderDetailDAO.Instance.GetOrderDetailsById(orderId, productId);
    public void InsertOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddNew(orderDetail);
    public void UpdateOrderDetail() => OrderDetailDAO.Instance.Update();
    public void DeleteOrderDetail(int orderId, int productId) => OrderDetailDAO.Instance.Remove(orderId, productId);
}