using BusinessObject;

namespace DataAccess
{
    public class ProductDAO : FStoreContext
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        public Product GetProductByID(int productID) => Products.Find(productID);
        public IEnumerable<Product> GetProducts => Products.ToList();
        public void AddNew(Product product) { Products.Add(product); SaveChanges(); }
        public void Update() => SaveChanges();
        public void Remove(int productID) { Products.Remove(GetProductByID(productID)); SaveChanges(); }
    }
}
