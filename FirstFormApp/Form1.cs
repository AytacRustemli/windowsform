using FirstFormApp.Services;

namespace FirstFormApp
{
    public partial class Form1 : Form
    {
        AuthManager _authManager = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {

            var txtEmail = Tttemail.Text;
            var txtPassword = Tttpassword.Text; 

            var user = _authManager.Login(txtEmail, txtPassword);

            if (user != null)
            {
                //MessageBox.Show("Ugurla daxil oldunuz");
                Dashboard dashboard = new();
                dashboard.ShowDialog();
            }
            else
            {
                MessageBox.Show("Email ve ya sifre sehvdir","Diqqet",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new();
            register.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category category = new();
            category.ShowDialog();
        }
    }
}