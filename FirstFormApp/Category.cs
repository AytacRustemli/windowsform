using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirstFormApp.Models;
using FirstFormApp.Services;

namespace FirstFormApp
{
    public partial class Category : Form
    {
        CategoryManager _categoryManager = new();
        public Category()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var name = TxtName.Text;

            if (String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Butun xanalari doldurun", "Diqqet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Categoryy category = new()
                    {
                        Name = name
                    };
                    _categoryManager.Add(category);
                    MessageBox.Show("Category ugurla elave edildi.");
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
