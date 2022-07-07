using BusinessObject;
using DataAccess;
using System.Data;

namespace SalesWinApp
{
    public partial class frmProductDetail : Form
    {
        public IProductRepository ProductRepository { get; set; }
        public frmProductDetail()
        {
            InitializeComponent();
        }
        public bool InsertOrUpdate { get; set; }
        public Product Product { get; set; }
        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            lbId.Enabled = !InsertOrUpdate;
            cbCategory.DataSource = CategoryDAO.Instance.Categories.Select(category=>category.CategoryName).ToList();
            if (InsertOrUpdate)
            {
                lbId.Text = Product.ProductId.ToString();
                cbCategory.Text = CategoryDAO.Instance.Categories.Where(category=>category.CategoryId==Product.CategoryId).Single().CategoryName;
                txtProductName.Text = Product.ProductName;
                txtWeight.Text = Product.Weight;
                txtUnitPrice.Text = Product.UnitPrice.ToString();
                txtUnitsInStock.Text = Product.UnitsInStock.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new Product()
                {
                    ProductName = txtProductName.Text.Trim(),
                    CategoryId = CategoryDAO.Instance.Categories.Where(category => category.CategoryName.Equals(cbCategory.Text)).Single().CategoryId,
                    Weight = txtWeight.Text.Trim(),
                    UnitPrice = decimal.Parse(txtUnitPrice.Text.Trim()),
                    UnitsInStock= int.Parse(txtUnitsInStock.Text.Trim())
                };
                if (InsertOrUpdate == false)
                {
                    ProductRepository.InsertProduct(product);
                    MessageBox.Show("Insert successfully!");
                }
                else
                {
                    Product.ProductName = product.ProductName;
                    Product.CategoryId = product.CategoryId;
                    Product.Weight = product.Weight;
                    Product.UnitPrice = product.UnitPrice;
                    Product.UnitsInStock = product.UnitsInStock;
                    ProductRepository.UpdateProduct();
                    MessageBox.Show("Update successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add new product" : "Update product");
            }
        }
    }
}
