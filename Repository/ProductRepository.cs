using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductRepository: IProductRepository
    {
        public ProductObject GetProductByID(int productID) => ProductDAO.Instance.GetProductByID(productID);

        public IEnumerable<ProductObject> GetProducts() => ProductDAO.Instance.GetProductList();

        public void InsertProduct(ProductObject product) => ProductDAO.Instance.AddNew(product);

        public void UpdateProduct(ProductObject product) => ProductDAO.Instance.Update(product);

        public void DeleteProduct(int productID) => ProductDAO.Instance.Remove(productID);
    }
}