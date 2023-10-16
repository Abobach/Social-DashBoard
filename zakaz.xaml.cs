using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для zakaz.xaml
    /// </summary>
    public partial class zakaz : UserControl
    {
        public zakaz()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            list.Items.Clear();
          
                
                   string email1 = DataBank.surname + " " + DataBank.name + " " + DataBank.patranomic;
                    string email2 = DataBank.phone;
                    string email3 = DataBank.Otkudas + DataBank.Kudas;
                   string email4 = DataBank.Tips;
                string email5 = DataBank.Driver;
                    

                    list.Items.Insert(0,"Заказчик: "
                        + email1 +
                        "Ваш номер телефона: "
                        + email2 +
                        "Маршрут: "
                        + email3 +
                        "Тип поездки: "
                       + email4 +
                       " Водитель: "
                       + email5);

                

        
 

        }
    }
}
