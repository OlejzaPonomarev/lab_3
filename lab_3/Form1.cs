using Npgsql;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace lab_3
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=Qwerty123.;Database=lab_3;";
        int lenField3 = 60; //Длина 3его поля
        int lenDictionary = 103526; //Кол-во записей в словаре который используется
        int countRecord = 5000; //Кол-во записей которые вносятся в начале
        int countTest = 3; //Кол-во повторений испытаний
        int countTestRecord = 200; //Кол-во записей в этих испытаниях

        //Хранение реезультатов
        TimeSpan avgTimeAddBTree = TimeSpan.Zero;

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
                MessageBox.Show("Подключение успешно");
                connection.Close();
            }
            catch (Exception ex)
            {
                { MessageBox.Show("Не удалось подключиться: " + ex.Message); }
            }
        }
        // Кнопка добавить 1кк записей
        private void buttonAddAll_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                insertFromTable(countRecord: countRecord, connection: connection);

                MessageBox.Show("Значения успешно добавлены");
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось добавить " + countRecord + " записей" + ex);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Кнопка B-Tree (сбалансированное дерево)
        private void buttonBTree_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                string addIndexSql = "CREATE INDEX idx_field_1_btree ON my_table USING btree (field_1)";
                using (var cmd = new NpgsqlCommand(addIndexSql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                for (int i = 0; i < countTest; i++)
                {

                    TimeSpan totalTime = insertFromTable(countRecord: countTestRecord, connection: connection);
                    avgTimeAddBTree += totalTime;

                }
                connection.Close();
                avgTimeAddBTree /= 5;
                MessageBox.Show($"Успех!\nСреднее время вставки в BTree: {avgTimeAddBTree}");

            }
            catch { }
        }

        //Метод внесения записеей в базу данных
        private TimeSpan insertFromTable(int countRecord, NpgsqlConnection connection)
        {
            TimeSpan total = TimeSpan.Zero;
            Stopwatch tempTimeInsertBTree = new Stopwatch();
            tempTimeInsertBTree.Start();
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
            tempTimeInsertBTree.Stop();
            total += tempTimeInsertBTree.Elapsed;
            return total;

        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            var formResult = new Form2(avgTimeAddBTree);
         
            formResult.Show();
        }

        public TimeSpan getAvgTimeAddBTree() { return avgTimeAddBTree; }
    }
}
