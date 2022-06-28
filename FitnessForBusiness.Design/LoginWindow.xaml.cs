using FitnessForBusiness.Core;
using FitnessForBusiness.Core.Models;
using FitnessForBusiness.Core.Security;
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
        public LoginWindow(IStorage storage)
        {
            InitializeComponent();
            _storage = storage;
        }


        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if (LogInUsernameBox.Text != "")
            {
                try
                {
                    User user = functions.FindUserJSON(_storage, LogInUsernameBox.Text);
                    if (LogInPasswordBox.Password == "") MessageBox.Show("Enter password");
                    else if (user.Password != GetHashPassword.GetHash(LogInPasswordBox.Password)) MessageBox.Show("Wrong password");
                    else
                    {
                        TrainingCatalog trainingCatalog = new TrainingCatalog(user, _storage);
                        trainingCatalog.Show();
                        this.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("User is not found");
                }
            }
            else MessageBox.Show("Enter your email");
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(true);
            mainWindow.Show();
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
                WindowStateButton.IsChecked = false;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                WindowStateButton.IsChecked = false;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
