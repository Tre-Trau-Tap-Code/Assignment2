using BusinessObject;

namespace DataAccess
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProductById(int productId) => ProductDAO.Instance.GetProductByID(productId);

        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProducts;

        public void InsertProduct(Product product) => ProductDAO.Instance.AddNew(product);

        public void UpdateProduct() => ProductDAO.Instance.Update();

        public void DeleteProduct(int productID) => ProductDAO.Instance.Remove(productID);
    }
}
