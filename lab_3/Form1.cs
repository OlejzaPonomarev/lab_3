using Npgsql;
using System;
using System.Security.Cryptography;
using System.Text;

namespace lab_3
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=Qwerty123.;Database=lab_3;";
        int lenField3 = 60; //Длина 3его поля
        int lenDictionary = 103526; //Кол-во записей в словаре который используется
        int countRecord = 1000; //Кол-во записей которыые вносятся в начале

        public Form1()
        {
            InitializeComponent();
        }

        // Кнопка проверить подключение
        private void buttonIsConnected_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                MessageBox.Show(Text = "Подключение успешно");
                connection.Close();
            }
            catch (Exception ex)
            {
                { MessageBox.Show(Text = "Не удалось подключиться: " + ex.Message); }
            }
        }
        // Кнопка добавить 1кк записей
        private void buttonAddAll_Click(object sender, EventArgs e) {
            var connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                for (int i = 0; i < countRecord; i++)
                {
                    string sql = "INSERT INTO my_table (field_2, field_3) VALUES (@val2, @val3)";
                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("val2", RandomNumberGenerator.GetInt32(1, 4));
                        string sentence = "";
                        string line = "";
                        string filePath = "D:\\projectCs\\lab_3\\lab_3\\dictionary.txt";

                        while (true)
                        {
                            int numberRecord = RandomNumberGenerator.GetInt32(1, lenDictionary);
                            line = File.ReadLines(filePath, Encoding.UTF8).Skip(numberRecord - 1).First();
                            line = line.Substring(0, line.IndexOf(" "));
                            if (sentence.Length + line.Length < lenField3)
                            {
                                if (sentence.Length == 0)
                                {
                                    sentence += line;
                                }
                                else
                                {
                                    sentence = sentence + " " + line;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        cmd.Parameters.AddWithValue("val3", sentence); // это пойдёт в field_3
                        cmd.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show(Text = "Значения успешно добавлены");
                connection.Close();

            }
            catch (Exception ex) {
                MessageBox.Show("Не удалось добавить " + countRecord + " записей" + ex);
            }
        }
    }
}
