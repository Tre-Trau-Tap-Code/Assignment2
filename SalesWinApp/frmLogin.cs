using DataAccess;

namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        IMemberRepository MemberRepository = new MemberRepository();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister register = new frmRegister { InsertOrUpdate = false, MemberRepository = MemberRepository };
            register.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();
                if (email.Equals("admin@fstore.com") && password.Equals("admin@@"))
                {
                    frmMain frmMain = new frmMain();
                    MessageBox.Show("Login successfully!\nWelcome admin!");
                    frmMain.ShowDialog();
                    Close();
                }
                else if (MemberRepository.GetMemberByEmailAndPassword(email, password) is var member && member != null)
                {
                    frmUser frmUser = new frmUser { Member = member };
                    MessageBox.Show($"Login successfully!\nWelcome {member.CompanyName}!");
                    frmUser.ShowDialog();
                    Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Incorrect email or password!");
            }
        }
    }
}
