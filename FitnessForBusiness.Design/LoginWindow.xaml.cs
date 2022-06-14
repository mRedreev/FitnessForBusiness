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
using FitnessForBusiness.Core.Storages;

namespace FitnessForBusiness.Design
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IStorage _storage;

        public LoginWindow()
        {
            _storage = new Context();
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            TrainingCatalog trainingCatalog = new TrainingCatalog();
            trainingCatalog.Show();
            this.Close();
        }

        private User SearchUser()
        {
            var userName = LogInUserNameBox.Text;
            var userPassword = LogInPasswordBox.Text;
            User userNow = new User();

            foreach (var user in _storage.GetUsers)
            {
                if (user.Login == userName && user.Password == user.Password)
                {
                    userNow = user;
                }
            }

            return userNow;
        }
    }
}
