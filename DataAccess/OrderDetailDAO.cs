using BusinessObject;

namespace DataAccess
{
    internal class OrderDetailDAO : FStoreContext
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        public OrderDetail GetOrderDetailsById(int orderId, int productId) => OrderDetails.Find((orderId, productId));
        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId) => OrderDetails.Where(orderDetail => orderDetail.OrderId.Equals(orderId)).ToList();
        public void AddNew(OrderDetail orderDetail) { OrderDetails.Add(orderDetail); SaveChanges(); }
        public void Remove(int orderId, int productId) { OrderDetails.Remove(GetOrderDetailsById(orderId, productId)); SaveChanges(); }
        public void Update() => SaveChanges();
    }
}
