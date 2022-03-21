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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form6 f = new Form6();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

    }
}
