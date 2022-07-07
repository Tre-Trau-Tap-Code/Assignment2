using BusinessObject;
using DataAccess;

namespace SalesWinApp
{
    public partial class frmUser : Form
    {
        BindingSource source = null;
        IOrderRepository orderRepository = new OrderRepository();
        public frmUser()
        {
            InitializeComponent();
        }
        public Member Member { get; set; }
        private void frmUser_Load(object sender, EventArgs e)
        {
            LoadUserInfor();
            LoadOrders();
        }
        void LoadUserInfor()
        {
            lbId.Text = Member.MemberId.ToString();
            lbEmail.Text = Member.Email;
            lbCompanyName.Text = Member.CompanyName;
            lbCity.Text = Member.City;
            lbCountry.Text = Member.Country;
        }
        void LoadOrders()
        {
            source = new BindingSource();
            source.DataSource = orderRepository.GetOrderByMemberId(Convert.ToInt32(lbId.Text));
            dgvOrders.DataSource = source;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister() {
                InsertOrUpdate = true,
                Member = Member,
                MemberRepository = new DataAccess.MemberRepository()
            };
            frmRegister.ShowDialog();
            LoadUserInfor();
        }
    }
}
