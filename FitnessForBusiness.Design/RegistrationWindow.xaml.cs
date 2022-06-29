using FitnessForBusiness.Core.Models;
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
using Microsoft.Win32;
using FitnessForBusiness.Core.Storages;
using FitnessForBusiness.Core;
using FitnessForBusiness.Core.Security;

namespace FitnessForBusiness.Design
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        IStorage _storage;
        public RegistrationWindow()
        {
            _storage = new JSONStorage();
            InitializeComponent();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var listTextBoxes = new List<TextBox>(){NameBox, SurnameTextBox, EmailTextBox};
            var listPasswordBoxes = new List<PasswordBox> { PasswordBox, PasswordAgianTextBox };
            var ifBoxesNotEmpty = CheckEmptyBoxes(listTextBoxes);


            if (ifBoxesNotEmpty)
            {
                if (PasswordBox.Password == PasswordAgianTextBox.Password)
                {
                    
                    PasswordBox.Background = Brushes.Transparent;
                    PasswordAgianTextBox.Background = Brushes.Transparent;

                    if (!functions.DoesUserExist(_storage, EmailTextBox.Text))
                    {
                        var name = NameBox.Text;
                        var surname = SurnameTextBox.Text;
                        var login = EmailTextBox.Text;
                        var password = GetHashPassword.GetHash(PasswordBox.Password);
                        var level = functions.CheckLevel(LeveloComboBox.Text);
                        var goal = functions.CheckGoal(GoalComboBox.Text);
                        var imageSource = functions.GetImageSourceOfAvatar(AvatarComboBox.SelectedIndex);
                        var born = DateTime.Parse(BitrhDateDatePicker.SelectedDate.ToString());

                        User newUser = new User(name, surname, imageSource, born, level, goal, login, password);
                        _storage.Registration(newUser);

                        TrainingCatalog trainingCatalog = new TrainingCatalog(newUser, _storage);
                        trainingCatalog.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("User with this email already exists");
                    }
                }
                else
                {
                    MessageBox.Show("Passwords don't match");

                    PasswordBox.Background = Brushes.PaleVioletRed;
                    PasswordAgianTextBox.Background = Brushes.PaleVioletRed;
                }
            }
            else
            {   
                MessageBox.Show("Enter full data");

                functions.MakeEmptyBoxRed(listTextBoxes);
                functions.MakeRedPasswordboxesIfEmpty(listPasswordBoxes);
            }

        }

        private bool CheckEmptyBoxes(List<TextBox> listTextBoxes)
        {
            return functions.TextsBoxIsNotEmpty(listTextBoxes) & functions.ComboBoxIsNotEmpty(GoalComboBox, "Your Main Goal")
              & functions.ComboBoxIsNotEmpty(LeveloComboBox, "Your Level")
              & functions.ComboBoxIsNotEmpty(AvatarComboBox, "")
              & (PasswordBox.Password != "")
              & (BitrhDateDatePicker.SelectedDate.ToString() != "");
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
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

        private void ExitButton_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(true);
            mainWindow.Show();
            this.Close();
        }
    }
}
