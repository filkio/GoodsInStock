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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVotchet.Rows.Clear();
            DateTime dateTimeFrom = DateTime.MinValue;
            DateTime dateTimeTo = DateTime.MaxValue;
            Decimal sum = 0;
            if (DateTime.TryParse(textBox1.Text, out DateTime result1))
                dateTimeFrom = result1;
            if (DateTime.TryParse(textBox2.Text+" 23:59:59", out DateTime result2))
                dateTimeTo = result2;

            using (MyDbContext cont = new MyDbContext())
            {
                List<Good> goods = new List<Good>();
                if (comboBox1.SelectedIndex != 0)
                    goods = cont.Goods.Where(c => c.StatusId == comboBox1.SelectedIndex && c.Date>=dateTimeFrom && c.Date<=dateTimeTo).ToList();
                else
                    goods = cont.Goods.Where(c=>c.Date>=dateTimeFrom && c.Date<=dateTimeTo).ToList();

                foreach (Good item in goods)
                {
                    DGVotchet.Rows.Add(item.Name, item.Price, item.Status.Name, item.Date);
                    sum += item.Price;
                    label5.Text = Convert.ToString(sum);
                }
                

            }
        }
    }
}
