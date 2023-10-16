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

namespace Social_Blade_Dashboard
{
    /// <summary>
    /// Логика взаимодействия для MainOplata.xaml
    /// </summary>
    public partial class MainOplata : Window
    {
        public MainOplata()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int value = r.Next(0, 10);

            rnd.Content = value;

            LabelName.Content = DataBank.name + " " + DataBank.surname + " " + DataBank.patranomic;
            Adres.Content = DataBank.Otkudas + "-" + DataBank.Kudas;
            Driver.Content = DataBank.Driver;
            Cars.Content = DataBank.MarksCar + " " + DataBank.NumberCar;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
