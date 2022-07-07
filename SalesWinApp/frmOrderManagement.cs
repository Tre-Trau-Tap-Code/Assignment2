using DataAccess;

namespace SalesWinApp
{
    public partial class frmOrderManagement : Form
    {
        IOrderRepository orderRepository = new OrderRepository();
        BindingSource source = null;
        public frmOrderManagement()
        {
            InitializeComponent();
        }

        private void frmOrderManagement_Load(object sender, EventArgs e)
        {
            LoadOrders(orderRepository.GetOrders().ToList());
            dgvOrders.CellDoubleClick += DgvOrders_CellContentClick;
        }
        private void LoadOrders(List<BusinessObject.Order> orders)
        {
            try
            {
                source = new BindingSource();
                source.DataSource = orders;

                lbOrderId.DataBindings.Clear();
                lbMemberId.DataBindings.Clear();
                lbOrderDate.DataBindings.Clear();
                lbRequiredDate.DataBindings.Clear();
                lbShippedDate.DataBindings.Clear();
                lbFreight.DataBindings.Clear();

                lbOrderId.DataBindings.Add("Text", source, "OrderId");
                lbMemberId.DataBindings.Add("Text", source, "MemberId");
                lbOrderDate.DataBindings.Add("Text", source, "OrderDate");
                lbRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                lbShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                lbFreight.DataBindings.Add("Text", source, "Freight");

                dgvOrders.DataSource = null;
                dgvOrders.DataSource = source;
                if (orders.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load orders");
            }
        }
        private void ClearText()
        {
            lbOrderId.Text = string.Empty;
            lbMemberId.Text = string.Empty;
            lbOrderDate.Text = string.Empty;
            lbRequiredDate.Text = string.Empty;
            lbShippedDate.Text = string.Empty;
            lbFreight.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            orderRepository.DeleteOrder(Convert.ToInt32(lbOrderId.Text));
            MessageBox.Show("Delete successfully!");
            LoadOrders(orderRepository.GetOrders().ToList());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOrderDetails frmOrderDetails = new frmOrderDetails { 
                InsertOrUpdate = false,
                OrderRepository = orderRepository
            };
            frmOrderDetails.ShowDialog();
            LoadOrders(orderRepository.GetOrders().ToList());
        }
        private void DgvOrders_CellContentClick(object sender, EventArgs e)
        {
            frmOrderDetails frmOrderDetails = new frmOrderDetails
            {
                InsertOrUpdate = true,
                OrderRepository = orderRepository,
                Order = orderRepository.GetOrderById(Convert.ToInt32(lbOrderId.Text)),
            };
            frmOrderDetails.ShowDialog();
            LoadOrders(orderRepository.GetOrders().ToList());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            var orders = new List<BusinessObject.Order>();
            try
            {
                orders = (from order in orderRepository.GetOrders()
                             where order.OrderId.ToString().Contains(search)||
                                    order.MemberId.ToString().Contains(search) ||
                                    order.Freight.ToString().Contains(search)
                             select order).ToList();
            }
            catch (Exception)
            {

                MessageBox.Show($"No order have detail info like '{search}'");
            }
            finally
            {
                LoadOrders(orders);
            }

        }
    }
}
