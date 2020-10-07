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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ShowSklad();
        }
        private void ShowSklad()
        {
            using (MyDbContext cont = new MyDbContext())
            {
                List<Good> goods = new List<Good>();
                goods = cont.Goods.Where(c=>c.StatusId==2).ToList();
                foreach (Good item in goods)
                {
                    DGVStore.Rows.Add(item.Id, item.Name, item.Price);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVStore.Rows.Clear();
            ShowSklad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selected = Convert.ToString(DGVStore.SelectedCells[0].Value);
            if (Int32.TryParse(selected, out int result) && DGVStore.SelectedCells != null)
            {

                using (MyDbContext cont = new MyDbContext())
                {
                    Good good = new Good();
                    good = cont.Goods.Where(c => c.Id == result).FirstOrDefault();
                    good.StatusId = 3;
                    good.Date = DateTime.Now;
                    cont.SaveChanges();

                }
            }
            else
            {
                MessageBox.Show("Не выбран товар!");
            }
            DGVStore.Rows.Clear();
            ShowSklad();
        }
    }
}
