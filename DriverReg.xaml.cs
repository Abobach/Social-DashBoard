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
    /// Логика взаимодействия для DriverReg.xaml
    /// </summary>
    public partial class DriverReg : UserControl
    {
        public DriverReg()
        {
            InitializeComponent();
        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");
            string email = txtLogin.Text;
            string pass = txtPass.Password;
            SqlDataAdapter da = new SqlDataAdapter("SELECT Name, Password FROM Drivers WHERE Name= '" + email + "'and Password ='" + pass + "'", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь с такой почтой уже существует");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");

                SqlCommand command = new SqlCommand("INSERT INTO Drivers (Surname, Name, Patronomic, Certificate,Password,Phone) VALUES (@sr, @nm, @pt, @em, @ps, @np)", con);
                command.Parameters.Add("@sr", SqlDbType.VarChar).Value = txtSurname.Text;
                command.Parameters.Add("@nm", SqlDbType.VarChar).Value = txtUsername1.Text;
                command.Parameters.Add("@pt", SqlDbType.VarChar).Value = txtPatranomic.Text;
                command.Parameters.Add("@em", SqlDbType.VarChar).Value = txtLogin.Text;
                command.Parameters.Add("@ps", SqlDbType.VarChar).Value = txtPass.Password;
                command.Parameters.Add("@np", SqlDbType.VarChar).Value = txtNumber.Text;
                

                con.Open();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт был создан, Нажмите ОК,чтоб продолжить");

                    registrу.Children.Clear();
                    registrу.Children.Add(new Login());


                }
                else
                    MessageBox.Show("Аккаунт не был создан");
                con.Close();
            }
        }

        private void btnregr_Click(object sender, RoutedEventArgs e)
        {
            registrу.Children.Clear();
            registrу.Children.Add(new Login());
        }
    }
}
