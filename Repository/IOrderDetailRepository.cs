using BussinessObject;
using System.Collections.Generic;

namespace DataAccess.Repository{
    public interface IOrderDetailRepository{
        IEnumerable<OrderDetailObject> GetOrderDetails();
        IEnumerable<OrderDetailObject> GetOrderDetailsByOrderID(int orderID);

        OrderDetailObject GetOrderDetailsByOrderID(int orderDetail);
        OrderDetailObject GetOrderDetailsByProductID(int productID);

        void InsertOrderDetail(OrderDetailObject orderDetail);
        void DeleteOrderDetail(int orderDetailID);
        void UpdateOrderDetail(OrderDetailObject orderDetail);
    }
}