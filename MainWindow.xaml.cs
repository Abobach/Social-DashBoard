using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Media.SpeechSynthesis;



namespace Social_Blade_Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Dashboard());

            SpeechSynthesizer speech = new SpeechSynthesizer();




            string query = "SELECT * FROM Cars ";
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");
            SqlCommand data = new SqlCommand(query, con);
            SqlDataReader myReader;
            try
            {
                con.Open();

                myReader = data.ExecuteReader();

                while (myReader.Read())
                {
                    DataBank.Driver = myReader["Driver"].ToString();
                    DataBank.NumberCar = myReader["NumberCar"].ToString();
                    DataBank.MarksCar = myReader["MarksCar"].ToString();
                }

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Oplata());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Dashboard());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Settings());

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Maps());

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new zakaz());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new DriverReg());
        }
    }
  
    }



