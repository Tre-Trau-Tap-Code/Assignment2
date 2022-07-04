using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository: IOrderDetailRepository
    {
        public OrderDetailObject GetOrderDetailByOrderID(int orderID) => OrderDetailDAO.Instance.GetOrderDetailByID(orderID);

        public OrderDetailObject GetOrderDetailByProductID(int productID) => OrderDetailDAO.Instance.GetOrderDetailByProductID(productID);

        public IEnumerable<OrderDetailObject> GetOrderDetails() => OrderDetailDAO.Instance.GetOrderDetailList();

        public IEnumerable<OrderDetailObject> GetOrderDetailsByOrderID(int orderID) => OrderDetailDAO.Instance.GetOrderDetailListByOrderID(orderID);

        public void InsertOrderDetail(OrderDetailObject orderDetail) => OrderDetailDAO.Instance.AddNew(orderDetail);

        public void UpdateOrderDetail(OrderDetailObject orderDetail) => OrderDetailDAO.Instance.Update(orderDetail);

        public void DeleteOrderDetail(int orderDetailID) => OrderDetailDAO.Instance.Remove(orderDetailID);
    }
}