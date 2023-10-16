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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Social_Blade_Dashboard
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");
        public Login()
        {
            
            InitializeComponent();
        }

      

        private void btnLogina_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogina_Click_1(object sender, RoutedEventArgs e)

        {


            bool auth = false;
            using(var con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True"))
            {
                var command = new SqlCommand("SELECT COUNT(*) FROM Drivers WHERE Name = @Name and Password = @Password", con);
                command.Parameters.AddWithValue("@Name", txtUsername.Text);
                command.Parameters.AddWithValue("@Password", txtPassword.Password);
                con.Open();
                DataTable dt = new DataTable();
                
                auth = (int)command.ExecuteScalar() == 1;
            }

            if (auth)
            {
                MessageBox.Show("Вы вошли в свой профиль", "Уведомление");
                DriverReg f1 = new DriverReg();
                
                
            }
            else
            {
                MessageBox.Show("кексик");
            }
        }

    }
}
