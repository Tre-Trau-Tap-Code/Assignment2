using BusinessObject;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductObject> GetProducts();
        ProductObject GetProductByID(int productID);
        void InsertProduct(ProductObject product);
        void DeleteProduct(int productID);
        void UpdateProduct(ProductObject product);
    }
}