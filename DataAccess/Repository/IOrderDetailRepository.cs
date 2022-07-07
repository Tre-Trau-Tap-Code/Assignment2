using BusinessObject;
using System;

namespace DataAccess;
public interface IOrderDetailRepository
{
    IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId);
    OrderDetail GetOrderDetailById(int orderId, int productId);
    void InsertOrderDetail(OrderDetail orderDetail);
    void DeleteOrderDetail(int orderId, int productId);
    void UpdateOrderDetail();
}
