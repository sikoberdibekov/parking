using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connection = @"server=localhost;database=parking;uid=root;password=root";
            string userLogin = user_login.Text;
            string userPassword = user_pwd.Password.ToString();
            string userName = user_name.Text;
            int statusId = 2;
            MySqlConnection mySql = new MySqlConnection(connection);
            string insertUserCommand = "insert into authorization(user_login, " +
                "user_password,user_name, user_status) " +
                "values" +
                "('" + userLogin +
                "','" + userPassword + "','"+userName+
                "'," + statusId + ");";
            MySqlCommand command = new MySqlCommand(insertUserCommand, mySql);

            try
            {
                if (mySql.State == System.Data.ConnectionState.Closed)
                {
                    mySql.Open();
                }

                //command.ExecuteReader();
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("Регистрация прошла успешно!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Пользователь уже с таким логином существует!");



            }
            finally
            {
                mySql.Close();
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
