using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form2 f = new Form2();
            f.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(f);
        }

       public static List<string> Cutter(string s)
        {
            List<string> list = new List<string>();
            var k = s.Split(';');
            foreach (var k2 in k)
            {
                list.Add(k2);
            }
            return list;
        }

    }

    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Score { get; set; }

        public Person(string name, string surname, string patr, string score)
        {
            Name = name;
            Surname = surname;
            Patronymic = patr;
            Score = score;
        }
    }

    class Data
    {
        private readonly string filename = "/data.json";
        private string filepath = $"{Application.StartupPath}/data.json";
        public string JsonString;
        public DataForJson EditData;

        public void WriteJson(DataForJson list)
        {
            EditData = list;
            JsonString = JsonConvert.SerializeObject(list);
            SaveData();
        }

        public void WriteJson()
        {
            JsonString = JsonConvert.SerializeObject(EditData);
            SaveData();
        }

        public void RemoveData()
        {
            if (File.Exists(filepath))
            {
                try
                {
                    File.Delete(filepath);
                }
                catch (IOException e)
                {
                    MessageBox.Show($"Ошибка! Файл {filename} используется сторонней программой.");
                }
            }
        }
        public void SaveData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.StartupPath + filename, FileMode.Create);
            bf.Serialize(file, JsonString);
            file.Close();
        }

        public void LoadData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(Application.StartupPath + filename))
            {
                FileStream file = File.Open(Application.StartupPath + filename, FileMode.Open);
                JsonString = (string)bf.Deserialize(file);
                EditData = JsonConvert.DeserializeObject<DataForJson>(JsonString);
                file.Close();
            }
            else
            {
                FileStream file = File.Open(Application.StartupPath + filename, FileMode.CreateNew);
                file.Close();
            }
        }
    }

    class Question
    {
        public string TypeOfQuestion { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        public string WrongAnswer { get; set; }
        public Question(string t, string q, string a, string w)
        {
            TypeOfQuestion = t;
            QuestionText = q;
            Answer = a;
            WrongAnswer = w;
        }
    }

    class DataForJson
    {
        public List<Question> questions;
        public List<Person> persons;
    }

}
