using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklad
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ShowReceived();
        }
        private void ShowReceived() 
        {
            
            using (MyDbContext cont = new MyDbContext())
            {
                List<Good> ReceivedGoods = new List<Good>();
                ReceivedGoods = cont.Goods.Where(c => c.StatusId == 1).ToList();
                foreach (Good item in ReceivedGoods)
                {
                   DGVReceived.Rows.Add(item.Id, item.Name, item.Price);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVReceived.Rows.Clear();
            ShowReceived();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selected = Convert.ToString(DGVReceived.SelectedCells[0].Value);
            if (Int32.TryParse(selected, out int result) && DGVReceived.SelectedCells!=null)
            {
               
                using (MyDbContext cont = new MyDbContext())
                {
                    Good good = new Good();
                    good = cont.Goods.Where(c => c.Id == result).FirstOrDefault();
                    good.StatusId = 2;
                    good.Date = DateTime.Now;
                    cont.SaveChanges();

                }
            }
            else
            {
                MessageBox.Show("Не выбран товар!");
            }
            DGVReceived.Rows.Clear();
            ShowReceived();
        }
    }
}
