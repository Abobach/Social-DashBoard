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
    /// Логика взаимодействия для Cars.xaml
    /// </summary>
    public partial class Cars : UserControl
    {

        private SqlConnection sqlConnection = null;

        private SqlCommandBuilder commandBuilder = null;

        private SqlDataAdapter dataAdapter = null;

        private DataSet dataSet = null;
        public Cars()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Cars", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable d = new DataTable();
            adapter.Fill(d);
            tabgrid.ItemsSource = d.DefaultView;
            con.Close();

            sqlConnection = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");
            sqlConnection.Open();
        }

       

        
        private void tabgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         


                DataRowView row = tabgrid.SelectedItem as DataRowView;
                row.Row.ItemArray[0].ToString();

                string s = row.Row.ItemArray[0].ToString();


                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");
                DataTable table = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand command = new SqlCommand("DELETE FROM Cars WHERE ID ='" + s + "'", con);
                adapter.SelectCommand = command;
                adapter.Fill(table);
            
           


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddDr a = new AddDr();
            a.Show();

            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

       


            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QCH79F1\SQLEXPRESS;Initial Catalog=Taxi;Integrated Security=True");
            DataTable table = new DataTable();

            

            string query = "SELECT * FROM Cars";
            SqlDataAdapter adapter = new SqlDataAdapter(query,con);

            
            
            adapter.Fill(table);
            tabgrid.ItemsSource = table.DefaultView;

        }
    }
}
