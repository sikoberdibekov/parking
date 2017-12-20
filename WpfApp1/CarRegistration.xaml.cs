using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CarRegistration.xaml
    /// </summary>
    public partial class CarRegistration : Window
    {
       
        string bday1;
        public CarRegistration()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=parking;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            int profile_user_id = 5;
            string surname = secname1.Text;
            string email = email1.Text;
            string marka = marka1.Text;
            string model = model1.Text;
            string nomer = sernomer1.Text;

            
            DateTime dateTimeVariable = DateTime.Now;
            string date = dateTimeVariable.ToString("yyyy-MM-dd H:mm:ss");
            string time1 = time.Text;
            int x = Convert.ToInt32(time1);

            DateTime bday=dateTimeVariable.AddHours(x).AddMinutes(0).AddSeconds(0);
            bday1 = bday. ToString("yyyy-MM-dd H:mm:ss");
           
            int price2= x * 250;
            MySqlCommand cd = new MySqlCommand("insert into profile_user ( profile_user_id,profile_user_secondname,profile_user_email,profile_user_marka," +
               "profile_user_model,profile_user_nomer,profile_user_vhod,profile_user_vyhod,profile_user_price)" +
              "values('"+ profile_user_id +"','" + surname + "','" + email + "','" + marka + "','" + model + "','" + nomer + "','"+date+ "','" + bday1 + "','" + price2 + "');", connection);
            DataTable dt = new DataTable();
            dt.Load(cd.ExecuteReader());
            connection.Close();
            dtGrid1.DataContext = dt;
            MessageBox.Show("К оплате "+price2);
           
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
      

        private void exit1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow b = new MainWindow();
            b.Show();
            this.Close();
        }  
          
    }
}
