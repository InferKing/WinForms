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
            Data d = new Data();
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
        private string filename = "/data.dat";

        public static string jsonString;
        public void SaveData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.StartupPath + filename, FileMode.Create);
            bf.Serialize(file, jsonString);
            file.Close();
        }

        public void LoadData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(Application.StartupPath + filename))
            {
                FileStream file = File.Open(Application.StartupPath + filename, FileMode.Open);
                jsonString = (string)bf.Deserialize(file);
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
        public string Answer { get; set; }

    }



}
