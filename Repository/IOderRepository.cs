using BussinessObject;
using System;
using System.Collections.Generic;

namespace DataAccess.Repository{
    public interface IOderRepository{
        IEnumerable<OrderObject> GetOrders();
        List<Object> GetOrderListTotalByID(DateTime StartDate, DateTime EndDate);
        List<OrderObject> GetOrderByMemberID(int memberID);
        OrderObject GetOrderByMemberID(int memberID);
        void InsertOrder(OrderObject order);
        void UpadteOrder(OrderObject order);
        void DeleteOrder(int orderID);
    }
}