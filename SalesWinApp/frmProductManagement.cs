using DataAccess;
using System.Data;

namespace SalesWinApp
{
    public partial class frmProductManagement : Form
    {

        private class ProductShow
        {
            public int ProductId { get; set; }
            public string category { get; set; }
            public string ProductName { get; set; }
            public string Weight { get; set; }
            public decimal UnitPrice { get; set; }
            public int UnitsInStock { get; set; }
        }

        IProductRepository productRepository = new ProductRepository();
        BindingSource source = null;
        public frmProductManagement()
        {
            InitializeComponent();
        }

        private void frmProductManagement_Load(object sender, EventArgs e)
        {
            LoadProducts();
            dgvProduct.CellDoubleClick += DgvProduct_CellDoubleClick;
        }
        private void DgvProduct_CellDoubleClick(object sender, EventArgs e)
        {
            frmProductDetail frmProductDetail = new frmProductDetail
            {
                Text = "Update product",
                InsertOrUpdate = true,
                Product = productRepository.GetProductById(Convert.ToInt32(lbId.Text)),
                ProductRepository = productRepository
            };
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
            {
                source.Position = source.Count - 1;
            }
            LoadProducts();
        }
        private void ClearText()
        {
            lbId.Text = string.Empty;
            lbCategory.Text = string.Empty;
            lbProductName.Text = string.Empty;
            lbWeight.Text = string.Empty;
            lbUnitPrice.Text = string.Empty;
            lbUnitsInStock.Text = string.Empty;
        }
        public void LoadProducts()
        {
            List<ProductShow> products = (from product in ProductDAO.Instance.Products
                           select new ProductShow
                           {
                               ProductId = product.ProductId,
                               category = product.Category.CategoryName,
                               ProductName = product.ProductName,
                               Weight = product.Weight,
                               UnitPrice = product.UnitPrice,
                               UnitsInStock = product.UnitsInStock
                           }).ToList();
            ShowProduct(products);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductDetail frmProductDetail = new frmProductDetail
            {
                Text = "Add product",
                InsertOrUpdate = false,
                ProductRepository = productRepository
            };
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
            {
                source.Position = source.Count - 1;
            }
            LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            productRepository.DeleteProduct(Convert.ToInt32(lbId.Text));
            MessageBox.Show("Delete successfully!");
            LoadProducts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ProductShow> products = null;
            try
            {
                int number = Convert.ToInt32(txtSearch.Text);
                products = (from product in ProductDAO.Instance.Products
                            where product.ProductId.Equals(number)||product.UnitPrice.Equals(number)||product.UnitsInStock.Equals(number)
                            select new ProductShow
                            {
                                ProductId = product.ProductId,
                                category = product.Category.CategoryName,
                                ProductName = product.ProductName,
                                Weight = product.Weight,
                                UnitPrice = product.UnitPrice,
                                UnitsInStock = product.UnitsInStock
                            }).ToList();
            }
            catch (Exception)
            {

                products = (from product in ProductDAO.Instance.Products
                            where product.ProductName.ToLower().Contains(txtSearch.Text.Trim().ToLower())
                            select new ProductShow
                            {
                                ProductId = product.ProductId,
                                category = product.Category.CategoryName,
                                ProductName = product.ProductName,
                                Weight = product.Weight,
                                UnitPrice = product.UnitPrice,
                                UnitsInStock = product.UnitsInStock
                            }).ToList();
            }
            finally { ShowProduct(products); }
        }
        private void ShowProduct(List<ProductShow> products)
        {
            try
            {
                source = new BindingSource();
                source.DataSource = products.ToList();

                lbId.DataBindings.Clear();
                lbCategory.DataBindings.Clear();
                lbProductName.DataBindings.Clear();
                lbWeight.DataBindings.Clear();
                lbUnitPrice.DataBindings.Clear();
                lbUnitsInStock.DataBindings.Clear();

                lbId.DataBindings.Add("Text", source, "ProductId");
                lbCategory.DataBindings.Add("Text", source, "category");
                lbProductName.DataBindings.Add("Text", source, "ProductName");
                lbWeight.DataBindings.Add("Text", source, "Weight");
                lbUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                lbUnitsInStock.DataBindings.Add("Text", source, "UnitsInStock");

                dgvProduct.DataSource = null;
                dgvProduct.DataSource = source;
                if (products.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load products");
            }
        }
    }
}
