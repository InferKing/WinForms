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
        private string filename = "data.dat";
        private string filepath = $"{Application.StartupPath}/data.dat";
        public string JsonString;
        public void WriteJson(List<DataForJson> list)
        {
            JsonString = JsonConvert.SerializeObject(list);
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
            FileStream file = File.Open(filepath, FileMode.Create);
            bf.Serialize(file, JsonString);
            file.Close();
        }

        public void LoadData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filepath))
            {
                FileStream file = File.Open(filepath, FileMode.Open);
                JsonString = (string)bf.Deserialize(file);
                file.Close();
            }
            else
            {
                FileStream file = File.Open(filepath, FileMode.CreateNew);
                file.Close();
            }
        }
    }
    class Question
    {
        public string TypeOfQuestion { get; set; }
        public string Answer { get; set; }
    }

    class DataForJson
    {
        private List<Person> listPerson;
        private List<Question> listQuestion;
        public DataForJson(List<Person> l1, List<Question> l2)
        {
            listPerson = l1;
            listQuestion = l2;
        }
    }



}

/*
Как выглядят данные json 
{
    "people":
    [
        {
            "Name":"Oleg",
            "Surname":"Vyachin"
        },
        {
            "Name":"Matvey",
            "Surname":"Demidov"
        }
    ],
    "Question":
    [
        {
            "Name":"Oleg",
            "Surname":"Vyachin"
        },
        {
            "Name":"Matvey",
            "Surname":"Demidov"
        }
    ]
}
*/
