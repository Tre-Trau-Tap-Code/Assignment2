using BusinessObject;
using System;
namespace DataAccess;
public interface IProductRepository
{
    IEnumerable<Product> GetProducts();
    Product GetProductById(int productId);
    void InsertProduct(Product product);
    void DeleteProduct(int productId);
    void UpdateProduct();
}
