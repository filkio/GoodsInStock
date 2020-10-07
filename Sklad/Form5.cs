using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklad
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((decimal.TryParse(textBox2.Text, out decimal result)) && !(string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                string name = textBox1.Text;
                decimal price = result;
                using (MyDbContext cont = new MyDbContext())
                {
                    Good good = new Good();
                    good.Name = name;
                    good.Price = price;
                    good.StatusId = 1;
                    good.Date = DateTime.Now;
                    cont.Goods.Add(good);
                    cont.SaveChanges();

                }
                
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверно указаны параметры!");
            }

        }
    }
}
