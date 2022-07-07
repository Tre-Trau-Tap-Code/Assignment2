using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderDAO : FStoreContext
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public Order GetOrderByID(int orderID) => Orders.Find(orderID);
        public IEnumerable<Order> GetOrders => Orders;
        public List<Order> GetOrderByMemberID(int memberID) => Orders.Where(order=>order.MemberId.Equals(memberID)).ToList();
        public void AddNew(Order order) { Orders.Add(order); SaveChanges(); }
        public void Update() => SaveChanges();
        public void Remove(int orderID) { Orders.Remove(GetOrderByID(orderID)); SaveChanges(); }
    }
}
