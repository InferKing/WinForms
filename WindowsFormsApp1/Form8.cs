using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            Data d = new Data();
            d.LoadData();
            textBox1.Text = "";
            foreach (Person pers in d.EditData.persons)
            {
                string st = "";
                double x = Math.Round(int.Parse(pers.Score) / 20f, 2) * 100;
                if (x > 80)
                {
                    st = "5";
                }
                else if (x > 60)
                {
                    st = "4";
                }
                else if (x > 40)
                {
                    st = "3";
                }
                else
                {
                    st = "2";
                }
                textBox1.Text += $"{pers.Surname} {pers.Name} {pers.Patronymic} | Результат: {pers.Score}/20 | Оценка: {st}{Environment.NewLine}";
            }
        }
    }
}
