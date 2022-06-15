using System;
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

namespace FitnessForBusiness.Design
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            var user = SearchUser();
            if (user.Name == null)
            {
                MessageBox.Show("Incorrect Data");
                MessageBox.Show(LogInPasswordBox.Password);
            }
            else
            {
                TrainingCatalog trainingCatalog = new TrainingCatalog(user, _storage);
                trainingCatalog.Show();
                this.Close();
            }

        }

        private User SearchUser()
        {
            var userName = LogInUsernameBox.Text;
            var userPassword = LogInPasswordBox.Password;
            User userNow = new User();

            foreach (var user in _storage.GetUsers)
            {
                if (user.Login == userName && user.Password == userPassword)
                {
                    userNow = user;
                }
            }

            return userNow;
        }
    }
}
