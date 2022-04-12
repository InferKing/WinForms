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
    public class WasUsed // храним промежуточные данные в этом классе
    {
        public static List<int> indexes = new List<int>();
        public static List<string> names = new List<string>();
        public static int score = 0;
    }

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
                Data data = new Data();
                data.LoadData();
                foreach (TextBox tb in Controls.OfType<TextBox>())
                {
                    WasUsed.names.Add(tb.Text);
                }
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
            else
            {
                MessageBox.Show("Проверьте входные данные, разрешается использовать только русские буквы");
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

//List<Question> questions = new List<Question>();
//List<Person> person = new List<Person>();
//questions.Add(new Question("0", "6-2*2+1= ?", "3", "9;1;2"));
//questions.Add(new Question("1", "x^2=4; x = ?", "2;-2", "0;4"));
//questions.Add(new Question("0", "2*2*2*2*2:8= ?", "4", "6;12;8"));
//questions.Add(new Question("2", "Если свернуть по формуле сокр. умножения a^2+2ab +b^2, то получится", "(a+b)^2", ""));
//questions.Add(new Question("2", "В уравнении x^2-10x+25=0 X равен", "5", ""));
//questions.Add(new Question("0", "Графиком функции y=1/x является", "гипербола", "парабола;прямая;синусоида"));
//questions.Add(new Question("1", "Среди чисел 1, 2, 3, 4, 5, 6 простыми являются", "2;3;5", "1"));
//questions.Add(new Question("2", "В уравнении -x^2+7x+8=0 X равен", "-1.8", ""));
//questions.Add(new Question("0", "Укажите суждение, в котором описан признак делимости на 3", "сумма цифр должна делиться на 3", "сумма цифр должна быть больше 3;число должно быть больше 3;сумма цифр должна делиться на 9"));
//questions.Add(new Question("2", "Сколько битов в 1 Кбайте", "1024", ""));
//questions.Add(new Question("2", "Какое расширение имеет текстовый документ(запишите ответ без точки)", "txt", ""));
//questions.Add(new Question("0", "Устройства для вывода визуальной информации", "монитор (дисплей)", "клавиатура;мышь;принтер"));
//questions.Add(new Question("1", "Web-страницы имеют расширение", ".html;.php", ".txt;.png"));
//questions.Add(new Question("2", "Как называется группа файлов, которая хранится отдельной группой и имеет собственное имя", "каталог", ""));
//questions.Add(new Question("2", "Сколько байт в 2^10 битах", "128", ""));
//questions.Add(new Question("0", "Архивация файлов – это", "сжатие файлов", "сокрытие данных;запись данных;распаковка данных"));
//questions.Add(new Question("2", "Верно ли, что 99/3<11*3", "нет", ""));
//questions.Add(new Question("0", "Устройство для ввода буквенной и числовой информации", "клавиатура", "мышь;экран;планшет"));
//questions.Add(new Question("2", "За минимальную единицу измерения количества информации принято считать", "бит", ""));
//questions.Add(new Question("0", "Интернет - это", "всемирная компьютерная сеть", "компьютер;взаимосвязанные элементы;сетевое подключение"));
//DataForJson d = new DataForJson();
//d.questions = questions;
//d.persons = person;

//data.WriteJson(d);
