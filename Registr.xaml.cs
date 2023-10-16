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
using System.Windows.Threading;

namespace Social_Blade_Dashboard
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : UserControl
    {
        public Registr()
        {
            InitializeComponent();
           
        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "" | txtNumber.Text == "" | txtPass.Password == "" | txtPatranomic.Text == "" | txtSurname.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");
                string email = txtLogin.Text;
                string pass = txtPass.Password;
                SqlDataAdapter da = new SqlDataAdapter("SELECT Email, Password FROM Userse WHERE Email= '" + email + "'and Password ='" + pass + "'", con1);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Пользователь с такой почтой уже существует");
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");

                    SqlCommand command = new SqlCommand("INSERT INTO Userse (Surname, Name, Patranomic, Email,Password, NumberPhone, Data) VALUES (@sr, @nm, @pt, @em, @ps, @np, @dt)", con);
                    command.Parameters.Add("@sr", SqlDbType.VarChar).Value = txtSurname.Text;
                    command.Parameters.Add("@nm", SqlDbType.VarChar).Value = txtUsername1.Text;
                    command.Parameters.Add("@pt", SqlDbType.VarChar).Value = txtPatranomic.Text;
                    command.Parameters.Add("@em", SqlDbType.VarChar).Value = txtLogin.Text;
                    command.Parameters.Add("@ps", SqlDbType.VarChar).Value = txtPass.Password;
                    command.Parameters.Add("@np", SqlDbType.VarChar).Value = txtNumber.Text;
                    command.Parameters.Add("@dt", SqlDbType.VarChar).Value = datatime.Content;

                    con.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Аккаунт был создан, Нажмите ОК,чтоб продолжить");
                        LoginApp log = new LoginApp();
                        log.Show();


                    }
                    else
                        MessageBox.Show("Аккаунт не был создан");
                    con.Close();



                }
            }
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (object s, EventArgs ev) =>
            {
                datatime.Content = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            }, this.Dispatcher);
            timer.Start();
        }
    }
}
