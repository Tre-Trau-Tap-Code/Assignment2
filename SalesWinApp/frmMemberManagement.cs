using DataAccess;
using System.Data;

namespace SalesWinApp
{
    public partial class frmMemberManagement : Form
    {
        IMemberRepository MemberRepository = new MemberRepository();
        public frmMemberManagement()
        {
            InitializeComponent();
        }
        BindingSource source = null;
        private void frmMemberManagement_Load(object sender, EventArgs e)
        {
            LoadMembers(MemberRepository.GetMembers().ToList());
            dgvMembers.CellDoubleClick += DgvMembers_CellDoubleClick;
        }
        private void DgvMembers_CellDoubleClick(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister()
            {
                InsertOrUpdate = true,
                Member = MemberRepository.GetMemberById(Convert.ToInt32(lbId.Text)),
                MemberRepository = new MemberRepository()
            };

            if (frmRegister.ShowDialog() == DialogResult.OK)
            {
                source.Position = source.Count - 1;
            }
            LoadMembers(MemberRepository.GetMembers().ToList());
        }
        private void ClearText()
        {
            lbId.Text = string.Empty;
            lbEmail.Text = string.Empty;
            lbComapnyName.Text = string.Empty;
            lbCity.Text = string.Empty;
            lbCountry.Text = string.Empty;
        }
        private void LoadMembers(List<BusinessObject.Member> members)
        {
            try
            {
                source = new BindingSource();
                source.DataSource = members;

                lbId.DataBindings.Clear();
                lbEmail.DataBindings.Clear();
                lbComapnyName.DataBindings.Clear();
                lbCity.DataBindings.Clear();
                lbCountry.DataBindings.Clear();

                lbId.DataBindings.Add("Text", source, "MemberId");
                lbEmail.DataBindings.Add("Text", source, "Email");
                lbComapnyName.DataBindings.Add("Text", source, "CompanyName");
                lbCity.DataBindings.Add("Text", source, "City");
                lbCountry.DataBindings.Add("Text", source, "Country");

                dgvMembers.DataSource = null;
                dgvMembers.DataSource = source;
                if (members.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load members");
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<BusinessObject.Member> members = null;
            try
            {
                int number = Convert.ToInt32(txtSearch.Text.Trim());
                members = MemberRepository.GetMembers().Where(member => member.MemberId.Equals(number)).ToList();
            }
            catch (Exception)
            {
                string search = txtSearch.Text.ToLower().Trim();
                members = MemberRepository.GetMembers().Where(member => member.CompanyName.ToLower().Contains(search) ||
                                                                        member.City.ToLower().Contains(search) ||
                                                                        member.Country.ToLower().Contains(search) ||
                                                                        member.Email.ToLower().Contains(search)).ToList();
            }
            finally { LoadMembers(members); }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            MemberRepository.DeleteMember(Convert.ToInt32(lbId.Text));
            MessageBox.Show("Delete successfully!");
            LoadMembers(MemberRepository.GetMembers().ToList());
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister { InsertOrUpdate = false, MemberRepository = MemberRepository };
            register.ShowDialog();
            LoadMembers(MemberRepository.GetMembers().ToList());
        }
    }
}
