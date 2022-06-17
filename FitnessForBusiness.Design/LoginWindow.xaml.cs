using FitnessForBusiness.Core;
using FitnessForBusiness.Core.Models;
using FitnessForBusiness.Core.Storages;
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
        IStorage _storage;
        public LoginWindow()
        {
            InitializeComponent();
            _storage = new Context();
        }


        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if (LogInUsernameBox.Text != "")
            {
                try
                {
                    User user = functions.FindUser(LogInUsernameBox.Text);
                    if (user.Password != LogInPasswordBox.Password) MessageBox.Show("Wrong password");
                    else if (LogInPasswordBox.Password == "") MessageBox.Show("Enter password");
                    else
                    {
                        TrainingCatalog trainingCatalog = new TrainingCatalog(user, _storage);
                        trainingCatalog.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("User is not found");
                }
            }
            else MessageBox.Show("Enter your email");
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
