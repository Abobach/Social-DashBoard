using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Social_Blade_Dashboard
{
    /// <summary>
    /// Логика взаимодействия для AddDr.xaml
    /// </summary>
    public partial class AddDr : Window
    {
        public AddDr()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");

            SqlCommand command = new SqlCommand("INSERT INTO Cars (Driver, NumberCar, MarksCar) VALUES (@dr, @nc, @mc)", con);
            command.Parameters.Add("@dr", SqlDbType.VarChar).Value = Driver.Text;
            command.Parameters.Add("@nc", SqlDbType.VarChar).Value = NumbtrBox.Text;
            command.Parameters.Add("@mc", SqlDbType.VarChar).Value = ComboBox1.Text;


            con.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Водитель добавлен, Нажмите ОК,чтоб продолжить");
                this.Hide();


            }
            else
                MessageBox.Show("Аккаунт не был создан");
            con.Close();
        }

        private void ComboBox1_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void NumbtrBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void NumbtrBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
