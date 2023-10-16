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
    /// Логика взаимодействия для UserZakaz.xaml
    /// </summary>
    public partial class UserZakaz : UserControl
    {
        public UserZakaz()
        {
            InitializeComponent();
        }

        private void tabgrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = tabgrid2.SelectedItem as DataRowView;
            row.Row.ItemArray[0].ToString();

            string s = row.Row.ItemArray[0].ToString();


            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");
            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("DELETE FROM Zakaz WHERE ID ='" + s + "'", con);
            adapter.SelectCommand = command;
            adapter.Fill(table);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");
            DataTable table = new DataTable();



            string query = "SELECT * FROM Zakaz";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);



            adapter.Fill(table);
            tabgrid2.ItemsSource = table.DefaultView;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Zakaz", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable d = new DataTable();
            adapter.Fill(d);
            tabgrid2.ItemsSource = d.DefaultView;
            con.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
