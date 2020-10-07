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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ShowSell();
        }
        private void ShowSell()
        {
            using (MyDbContext cont = new MyDbContext())
            {
                List<Good> goods = new List<Good>();
                goods = cont.Goods.Where(c => c.StatusId == 3).ToList();
                foreach (Good item in goods)
                {
                    DGVSell.Rows.Add(item.Id, item.Name, item.Price);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVSell.Rows.Clear();
            ShowSell();
           
        }
    }
}
