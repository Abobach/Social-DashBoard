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
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Data.SqlClient;
using System.Windows.Threading;
using System.Data;

namespace Social_Blade_Dashboard
{
    /// <summary>
    /// Логика взаимодействия для LoginApp.xaml
    /// </summary>
    public partial class LoginApp : Window
    {
        public LoginApp()
        {
            InitializeComponent();

            DoubleAnimation d = new DoubleAnimation();
            d.From = 0;
            d.To = 250;
            d.Duration = TimeSpan.FromSeconds(3);
            btnLogin.BeginAnimation(Button.WidthProperty, d);
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "Admin" | txtPassword.Password == "123")
            {
                admin ad = new admin();
                ad.Show();
                this.Hide();
            }
            else
            {

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");
                string email = txtUsername.Text;
                string pass = txtPassword.Password;
                SqlDataAdapter da = new SqlDataAdapter("SELECT Surname, Name, Patranomic, Email, Password, NumberPhone, Data FROM Userse WHERE Email = '" + email + "'and Password ='" + pass + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MainWindow m = new MainWindow();
                    DataBank.email = dt.Rows[0]["Email"].ToString();
                    DataBank.name = dt.Rows[0]["Name"].ToString();
                    DataBank.surname = dt.Rows[0]["Surname"].ToString();
                    DataBank.patranomic = dt.Rows[0]["Patranomic"].ToString();
                    DataBank.password = dt.Rows[0]["Password"].ToString();
                    DataBank.phone = dt.Rows[0]["NumberPhone"].ToString();
                    DataBank.date = dt.Rows[0]["Data"].ToString();

                    m.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Данные были введены неверно!", "Ошибка");
                }
            }
        }
        int count = 0;
        private void btnRidht_Click(object sender, RoutedEventArgs e)
        {
            
            
                switch (count)
                {
                    case 0:
                        Arrow.Kind = MaterialDesignThemes.Wpf.PackIconKind.ArrowLeft;
                        count = 1;
                        LoginPages.Children.Clear();
                        LoginPages.Children.Add(new Registr());
                        break;
                    case 1:
                        Arrow.Kind = MaterialDesignThemes.Wpf.PackIconKind.ArrowRight;
                        count = 2;
                        LoginPages.Children.Clear();
                        LoginPages.Children.Add(new Login());
                        break;
                }
           
                
            

           
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (object s, EventArgs ev) =>
            {
                datatime1.Content = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            }, this.Dispatcher);
            timer.Start();
        }
    }
}

