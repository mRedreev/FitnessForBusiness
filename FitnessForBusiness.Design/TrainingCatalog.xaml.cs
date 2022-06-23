using FitnessForBusiness.Core;
using FitnessForBusiness.Core.Models;
using FitnessForBusiness.Core.Storages;
using System;
using System.Collections.Generic;
using System.IO;
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
            _storage = storage;
            _user = user;
            InitializeComponent();

            TrainigsListBox.ItemsSource = _storage.GetTrainings;
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
            var listBoxBorder = VisualTreeHelper.GetChild(TrainigsListBox, 0) as Border;
            var scrollViewer = VisualTreeHelper.GetChild(listBoxBorder, 0) as ScrollViewer;
           

            if (e.Delta > 0)
            {
                scrollViewer.LineLeft();
            }

            else
            {
                scrollViewer.LineRight();
            }

            e.Handled = true;
        }

        private void TrainigsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void LevelTextBlock_Initialized(object sender, EventArgs e)
        {

        }

        

        private void Trainings2ListBox_Initialized(object sender, EventArgs e)
        {

        }

        private void Begin_Initialized(object sender, EventArgs e)
        {

        }

        

        private void ExerciseAmountTextBlock_Initialized(object sender, EventArgs e)
        {

        }

        private void LevelTextBlock_Initialized_1(object sender, EventArgs e)
        {
            var levelTextBlock = sender as TextBlock;
            levelTextBlock.Text = functions.NameOfLevel(_user.Level);
        }

        private void ListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {

        }

      

        private void UserAvatar_Initialized(object sender, EventArgs e)
        {
            var userAvatarTextBlock = sender as Image;
            BitmapImage bitmapImage = new BitmapImage();
            using (var fileStream = new FileStream("../../" + _user.ImageSource, FileMode.Open))
            {
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = fileStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            userAvatarTextBlock.Source = bitmapImage;
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

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            //TitleTextBlock.Visibility = Visibility.Collapsed;
            BackButton.Visibility = Visibility.Collapsed;
            TrainigsListBox.Visibility = Visibility.Collapsed;
            ProfilePanel.Visibility = Visibility.Visible;
        }

        private void TrainingTypeTextBlock_Initialized(object sender, EventArgs e)
        {

        }

        private void TrainingsByNameListBox_Initialized(object sender, EventArgs e)
        {

        }

       

        private void NumberOfExercisesinTrainigTextBlock_Initialized(object sender, EventArgs e)
        {

        }

        private void TrainingsByNameSlotsListBox_Initialized(object sender, EventArgs e)
        {

        }

        private void TrainingsByNameSlotsListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {

        }

        private void TrainingImage_Initialized(object sender, EventArgs e)
        {

        }

        private void BeginButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}