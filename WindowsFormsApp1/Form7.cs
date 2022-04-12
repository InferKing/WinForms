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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Data d = new Data();
            d.LoadData();
            Person p = new Person(WasUsed.names[0], WasUsed.names[1], WasUsed.names[2],WasUsed.score.ToString());
            d.EditData.persons.Add(p);
            d.WriteJson();
            label2.Text += $"{WasUsed.score.ToString()}/20";
            double x = Math.Round(WasUsed.score / 20f, 2) * 100;
            if (x > 80)
            {
                label3.Text += "5";
            }
            else if (x > 60)
            {
                label3.Text += "4";
            }
            else if (x > 40)
            {
                label3.Text += "3";
            }
            else
            {
                label3.Text += "2";
            }

        }
    }
}
