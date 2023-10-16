using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Data.SqlClient;
using System.Data;

namespace Social_Blade_Dashboard
{
    /// <summary>
    /// Логика взаимодействия для Oplata.xaml
    /// </summary>
    public partial class Oplata : UserControl
    {
        public Oplata()
        {
            InitializeComponent();
            Number1.MaxLength = 4;
            Number2.MaxLength = 4;
            Number3.MaxLength = 4;
            Number4.MaxLength = 4;
            DoubleAnimation s = new DoubleAnimation();
            DoubleAnimation a = new DoubleAnimation();
            a.From = 0;
            a.To = 98;
            s.From = 0;
            s.To = 680;
            s.Duration = TimeSpan.FromSeconds(1);
            a.Duration = TimeSpan.FromSeconds(1);
            Carts.BeginAnimation(Button.WidthProperty, s);
            Number1.BeginAnimation(TextBox.WidthProperty, a);
            Number2.BeginAnimation(TextBox.WidthProperty, a);
            Number3.BeginAnimation(TextBox.WidthProperty, a);
            Number4.BeginAnimation(TextBox.WidthProperty, a);
          

        }
       
        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cone = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");

            string query = "SELECT * FROM Cars ORDER BY NEWID()";
            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand commands = new SqlCommand(query, cone);
            adapter.SelectCommand = commands;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {

                int count = table.Rows.Count;
                Random rnd = new Random();
                //Получить очередное случайное число
                int z1 = rnd.Next(0, count);
                DataBank.Driver = table.Rows[z1][1].ToString();
                DataBank.MarksCar = table.Rows[z1][2].ToString();
                DataBank.NumberCar = table.Rows[z1][3].ToString();

            }

                if (Number1.Text == "" | Number2.Text == "" | Number3.Text == "" | Number4.Text == "")
                {
                    MessageBox.Show("Заполните все поля");
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");

                    SqlCommand command = new SqlCommand("INSERT INTO Zakaz (FIO, Phone, Maps, Tip,NumberCar, MarksCar, Driver) VALUES (@Fi, @ph, @mp, @tp, @nc, @mc, @dr)", con);
                    command.Parameters.Add("@Fi", SqlDbType.VarChar).Value = DataBank.name + DataBank.surname + DataBank.patranomic;
                    command.Parameters.Add("@ph", SqlDbType.VarChar).Value = DataBank.phone;
                    command.Parameters.Add("@mp", SqlDbType.VarChar).Value = DataBank.Otkudas + "-" + DataBank.Kudas;
                    command.Parameters.Add("@tp", SqlDbType.VarChar).Value = DataBank.Tips;
                    command.Parameters.Add("@nc", SqlDbType.VarChar).Value = DataBank.NumberCar;
                    command.Parameters.Add("@mc", SqlDbType.VarChar).Value = DataBank.MarksCar;
                    command.Parameters.Add("@dr", SqlDbType.VarChar).Value = DataBank.Driver;

                    con.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MainOplata m = new MainOplata();
                        m.Show();





                    }
                    else
                        MessageBox.Show("Ошибка");
                    con.Close();
                }

            }
        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Otkudae.Text = DataBank.Otkudas;
           Kudae.Text = DataBank.Kudas;
            tipe.Text = DataBank.Tips;
            pri.Text =  DataBank.Price;

        }
    }
}
