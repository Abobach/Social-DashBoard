using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;
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
using Windows.UI;


namespace Social_Blade_Dashboard
{
    /// <summary>
    /// Логика взаимодействия для Maps.xaml
    /// </summary>
    public partial class Maps : UserControl
    {
        public Maps()
        {
             InitializeComponent();
            mapControl.Loaded += MapControl_Loaded;


        }

        private async void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Specify a known location.
            
                BasicGeoposition geoposition = new BasicGeoposition() { Latitude = 56.03361, Longitude = 35.96944 };
                var center = new Geopoint(geoposition);

                await ((MapControl)sender).TrySetViewAsync(center, 13);
            

            // Set the map location.

          

            

        }

        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            if (Kuda.Text == "" | Otkuda.Text == "" | ComboBox.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");

                SqlCommand command = new SqlCommand("INSERT INTO Maps (Otkuda, Kuda, Tip, Price) VALUES (@ot, @ku, @tp, @pr)", con);
                command.Parameters.Add("@ot", SqlDbType.VarChar).Value = Otkuda.Text;
                command.Parameters.Add("@ku", SqlDbType.VarChar).Value = Kuda.Text;
                command.Parameters.Add("@tp", SqlDbType.VarChar).Value = ComboBox.Text;
                command.Parameters.Add("@pr", SqlDbType.VarChar).Value = price.Content;



                con.Open();
                if (command.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Ваш заказ пошел в обработку, Ожидайте");
                   



                }
                else
                    MessageBox.Show("Ошибка");
                con.Close();



                DataBank.Otkudas = Otkuda.Text;
                DataBank.Kudas = Kuda.Text;
                DataBank.Tips = ComboBox.Text;
                DataBank.Price = (string)price.Content;


                


            }
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void ComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ComboBox.Text == "Эконом")
            {
                price.Content = "200р";
            }
            if (ComboBox.Text == "Комфорт")
            {
                price.Content = "300р";
            }
            if (ComboBox.Text == "Бизнес")
            {
                price.Content = "500р";
            }
        }
    }
}
