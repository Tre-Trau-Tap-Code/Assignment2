using BusinessObject;
using DataAccess;

namespace SalesWinApp
{
    public partial class frmRegister : Form
    {
        public IMemberRepository MemberRepository { get; set; }
        public frmRegister()
        {
            InitializeComponent();
        }
        public bool InsertOrUpdate { get; set; }
        public Member Member { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new Member()
                {
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text
                };
                if (!InsertOrUpdate)
                {
                    MemberRepository.InsertMember(member);
                    MessageBox.Show("Create successfully!");
                }
                else
                {
                    Member.Email = member.Email;
                    Member.CompanyName = member.CompanyName;
                    Member.City = member.City;
                    Member.Country = member.Country;
                    Member.Password = member.Password;
                    MemberRepository.UpdateMember();
                    MessageBox.Show("Edit successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add new member" : "Update member");
            }
        }
        private void frmRegister_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate)
            {
                lbId.Text = Member.MemberId.ToString();
                txtEmail.Text = Member.Email;
                txtCompanyName.Text = Member.CompanyName;
                txtCity.Text = Member.City;
                txtCountry.Text = Member.Country;
                txtPassword.Text = Member.Password;
            }
        }
    }
}
