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

namespace Social_Blade_Dashboard
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Nameaccaunt.Text = DataBank.email;
            Passwords.Text = DataBank.password;
            number.Text = DataBank.phone;
            dete.Text = DataBank.date;
            Name.Text = DataBank.surname + " " + DataBank.name + " " + DataBank.patranomic;
        }
    }
}
