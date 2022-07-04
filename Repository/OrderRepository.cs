using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class OrderRepository: IOrderRepository
    {
        public OrderObject GetOrderByID(int orderID) => OrderDAO.Instance.GetOrderByID(orderID);
        public IEnumerable<OrderObject> GetOrders() => OrderDAO.Instance.GetOrderList();
        public List<Object> GetOrderListTotalByID(DateTime StartDate, DateTime EndDate) => OrderDAO.Instance.GetOrderListTotalByID(StartDate,EndDate);
        public List<OrderObject> GetOrderByMemberID(int memberID) => OrderDAO.Instance.GetOrderByMemberID(memberID);
        public void InsertOrder(OrderObject order) => OrderDAO.Instance.AddNew(order);
        public void UpdateOrder(OrderObject order) => OrderDAO.Instance.Update(order);
        public void DeleteOrder(int orderID) => OrderDAO.Instance.Remove(orderID);
        
    }
}
