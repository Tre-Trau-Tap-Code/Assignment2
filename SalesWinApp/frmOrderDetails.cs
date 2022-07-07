using DataAccess;
using BusinessObject;

namespace SalesWinApp
{
    public partial class frmOrderDetails : Form
    {
        public IOrderRepository OrderRepository { get; set; }
        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        BindingSource source = null;

        public frmOrderDetails()
        {
            InitializeComponent();
        }
        public bool InsertOrUpdate { get; set; }
        public Order Order { get; set; }

        private void frmOrderDetails_Load(object sender, EventArgs e)
        {
            btnAddDetail.Enabled = InsertOrUpdate;
            btnDeleteDetail.Enabled = InsertOrUpdate;
            btnSearchDetails.Enabled = InsertOrUpdate;
            txtSearchDetails.Enabled = InsertOrUpdate;
            if (InsertOrUpdate)
            {
                LoadOrder();
                LoadOrderDetails(orderDetailRepository.GetOrderDetailsByOrderId(Convert.ToInt32(lbOrderId.Text)).ToList());
            }
        }
        private void ClearText()
        {
            lbProductId.Text = string.Empty;
            lbUnitPrice.Text = string.Empty;
            lbQuantity.Text = string.Empty;
            lbDiscount.Text = string.Empty;
        }
        private void LoadOrderDetails(List<OrderDetail> orderdetails)
        {
            source = new BindingSource();
            
            source.DataSource = orderdetails;

            lbProductId.DataBindings.Clear();
            lbUnitPrice.DataBindings.Clear();
            lbQuantity.DataBindings.Clear();
            lbDiscount.DataBindings.Clear();

            lbProductId.DataBindings.Add("Text", source, "ProductId");
            lbUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
            lbQuantity.DataBindings.Add("Text", source, "Quantity");
            lbDiscount.DataBindings.Add("Text", source, "Discount");
            dgvOrderDetails.DataSource = null;
            dgvOrderDetails.DataSource = source;
            if (orderdetails.Count() == 0)
            {
                ClearText();
                btnDeleteDetail.Enabled = false;
            }
            else
            {
                btnDeleteDetail.Enabled = true;
            }
        }
        private void LoadOrder()
        {
            lbOrderId.Text=Order.OrderId.ToString();
            txtMemberId.Text=Order.MemberId.ToString();
            txtFreight.Text=Order.Freight.ToString();
            dtpOrderDate.Text=Order.OrderDate.ToString();
            dtpRequiredDate.Text=Order.RequiredDate.ToString();
            dtpShippedDate.Text = Order.ShippedDate.ToString();
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            var order = new Order
            {
                MemberId = int.Parse(txtMemberId.Text),
                Freight = decimal.Parse(txtFreight.Text),
                OrderDate = DateTime.Parse(dtpOrderDate.Text),
                RequiredDate = DateTime.Parse(dtpRequiredDate.Text),
                ShippedDate = DateTime.Parse(dtpShippedDate.Text),
            };
            if (!InsertOrUpdate)
            {
                OrderRepository.InsertOrder(order);
            }
            else
            {
                Order.MemberId = order.MemberId;
                Order.Freight = order.Freight;
                Order.OrderDate = order.OrderDate;
                Order.RequiredDate = order.RequiredDate;
                Order.ShippedDate = order.ShippedDate;
                OrderRepository.UpdateOrder();
            }
            MessageBox.Show($"{(InsertOrUpdate ? "Update" : "Insert")} order successfully!");
        }

        private void btnSearchDetails_Click(object sender, EventArgs e)
        {
            List<OrderDetail> orderdetails = new List<OrderDetail>();
            try
            {
                
                string number = txtSearchDetails.Text;
                orderdetails = (from iorderdetail in orderDetailRepository.GetOrderDetailsByOrderId(Convert.ToInt32(lbOrderId.Text)).ToList()
                                  where iorderdetail.ProductId.Equals(Convert.ToInt32(number))||
                                  iorderdetail.Quantity.Equals(Convert.ToInt32(number)) ||
                                  iorderdetail.UnitPrice.Equals(Convert.ToDecimal(number)) ||
                                  iorderdetail.Discount.Equals(Convert.ToDouble(number))
                                  select iorderdetail).ToList();
                LoadOrderDetails(orderdetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Value must be a number");
            }
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            orderDetailRepository.DeleteOrderDetail(Convert.ToInt32(lbOrderId.Text), Convert.ToInt32(lbProductId.Text));
            MessageBox.Show("Delete order detail successfully!");

            LoadOrderDetails(orderDetailRepository.GetOrderDetailsByOrderId(Convert.ToInt32(lbOrderId.Text)).ToList());
        }
    }
}
