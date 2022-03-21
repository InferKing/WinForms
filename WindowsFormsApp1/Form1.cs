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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //foreach (TextBox tb in this.Controls.OfType<TextBox>())
            //{
            //    tb.Enter += func;
            //}
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "1234567890`qwertyuiop[]a sdfghjkl;'zxcvbnm,.^%$#@!&*()_-+=/?><'";
            bool b = false;
            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (tb.Text.Contains(s[i]) || tb.Text == "")
                    {
                        b = true;
                        i = s.Length;
                    }
                }
            }
            if (!b)
            {
                Hide();
                Form4 form = new Form4();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
            }
            else
            {
                MessageBox.Show("Проверьте входные данные, разрешается использовать только русские буквы");
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }
    }
}
