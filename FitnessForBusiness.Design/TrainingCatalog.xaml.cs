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
    /// Логика взаимодействия для TrainingCatalog.xaml
    /// </summary>
    public partial class TrainingCatalog : Window
    {
        User _user;



        IStorage _storage;
        public TrainingCatalog(User user, IStorage storage)
        {
            InitializeComponent();
            _storage = storage;
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

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Minimized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        private void TrainigsListBox_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void TrainigsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void LevelTextBlock_Initialized(object sender, EventArgs e)
        {

        }

        private void NameTextBlock_Initialized(object sender, EventArgs e)
        {

        }

        private void Trainings2ListBox_Initialized(object sender, EventArgs e)
        {

        }

        private void Begin_Initialized(object sender, EventArgs e)
        {

        }

        private void Begin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExerciseAmountTextBlock_Initialized(object sender, EventArgs e)
        {

        }

        private void LevelTextBlock_Initialized_1(object sender, EventArgs e)
        {

        }

        private void ListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {

        }

        private void ExercisesListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {

        }

        private void ExercisesListBox_Initialized(object sender, EventArgs e)
        {

        }

        private void LevelTextBlock_Initialized_2(object sender, EventArgs e)
        {

        }

        private void UserAvatar_Initialized(object sender, EventArgs e)
        {
            //аватар текущего пользователя
        }

        private void UsernameNameTextBox_Initialized(object sender, EventArgs e)
        {
            //имя текущего пользователя
        }

        private void UserSurnameTextBox_Initialized(object sender, EventArgs e)
        {
            //фамилия текущего пользователя
        }

        private void UserLevelTextBox_Initialized(object sender, EventArgs e)
        {
            //уровень текущего пользователя
        }

        private void UserGoalComboBox_Initialized(object sender, EventArgs e)
        {
            //цель текущего пользователя
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            //применить изменения редактирования
        }
    }
}