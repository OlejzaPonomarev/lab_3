using System;
using Npgsql;

namespace lab_3
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=Qwerty123.;Database=lab_3;";
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddAll_Click(object sender, EventArgs e) { }

        //Кнопка проверить подключение
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
                {
                    MessageBox.Show(Text = "Не удалось подключиться: " + ex.Message);
                }
            }
        }
    }
}
