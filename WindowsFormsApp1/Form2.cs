using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f1 = new Form1();
            f1.StartPosition = FormStartPosition.CenterScreen;
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 f3 = new Form3();
            f3.StartPosition = FormStartPosition.CenterScreen;
            f3.Show();
        }

        private void испытуемыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start($"{Application.StartupPath}/polz.txt");
        }

        private void проверяющийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start($"{Application.StartupPath}/prov.txt");
        }
    }
}
