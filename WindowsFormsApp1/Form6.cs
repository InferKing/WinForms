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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Data data = new Data();
            data.LoadData();
            Question q = data.EditData.questions[WasUsed.indexes[WasUsed.indexes.Count - 1]];
            bool b = false;
            foreach (CheckBox rb in Controls.OfType<CheckBox>())
            {
                if (rb.Checked)
                {
                    if (!Program.Cutter(q.Answer).Contains(rb.Text))
                    {
                        b = true;
                    }
                }
                else
                {
                    if (Program.Cutter(q.Answer).Contains(rb.Text))
                    {
                        b = true;
                    }
                }
            }
            if (!b) WasUsed.score++;
            if (WasUsed.indexes.Count == 20)
            {
                Form7 form = new Form7();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
            }
            else
            {
                int r = new Random().Next(0, data.EditData.questions.Count);
                while (WasUsed.indexes.Contains(r))
                {
                    r = new Random().Next(0, data.EditData.questions.Count);
                }
                Question quest = data.EditData.questions[r];
                WasUsed.indexes.Add(r);
                switch (quest.TypeOfQuestion)
                {
                    case "0":
                        Form4 form4 = new Form4();
                        form4.StartPosition = FormStartPosition.CenterScreen;
                        form4.Show();
                        break;
                    case "1":
                        Form6 form6 = new Form6();
                        form6.StartPosition = FormStartPosition.CenterScreen;
                        form6.Show();
                        break;
                    case "2":
                        Form5 form5 = new Form5();
                        form5.StartPosition = FormStartPosition.CenterScreen;
                        form5.Show();
                        break;
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Data data = new Data();
            data.LoadData();
            Question q = data.EditData.questions[WasUsed.indexes[WasUsed.indexes.Count - 1]];
            label1.Text = q.QuestionText;
            label2.Text = label2.Text + WasUsed.indexes.Count.ToString();
            List<string> allAnswers;
            List<string> wrongAnswers;
            allAnswers = Program.Cutter(q.Answer);
            wrongAnswers = Program.Cutter(q.WrongAnswer);
            allAnswers.AddRange(wrongAnswers);

            int rand = new Random().Next(0, allAnswers.Count);
            checkBox1.Text = allAnswers[rand];
            allAnswers.RemoveAt(rand);
            rand = new Random().Next(0, allAnswers.Count);
            checkBox2.Text = allAnswers[rand];
            allAnswers.RemoveAt(rand);
            rand = new Random().Next(0, allAnswers.Count);
            checkBox3.Text = allAnswers[rand];
            allAnswers.RemoveAt(rand);
            rand = new Random().Next(0, allAnswers.Count);
            checkBox4.Text = allAnswers[rand];
        }
    }
    
}
