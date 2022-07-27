using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirstFormApp.Data;
using FirstFormApp.Models;
using FirstFormApp.Services;

namespace FirstFormApp
{
    public partial class Register : Form
    {
        AuthManager _authManager = new();
        public Register()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var name = TxtName.Text;
            var surname = TxtSurname.Text;
            var email = TxtEmail.Text;
            var password = Txtpassword.Text;
            var confirmPassword = TxtConfirmPassword.Text;

            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(surname) || String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Butun xanalari doldurun", "Diqqet",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (confirmPassword != password)
                {
                    MessageBox.Show("Sifreler eyni deyil");
                }
                else
                {
                    try
                    {
                        User newUser = new()
                        {
                            Email = email,
                            Password = password,
                            Name = name,
                            Surname = surname,
                        };
                        _authManager.Register(newUser);
                        MessageBox.Show("Qeydiyyatdan ugurla kecdiniz.");
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xeta bas verdi yeniden cehd edin");
                    }
                }
            }

            
        }
    }
}
