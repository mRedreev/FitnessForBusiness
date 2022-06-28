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
    /// Логика взаимодействия для CurrentTrainingWindow.xaml
    /// </summary>
    public partial class CurrentTrainingWindow : Window
    {
        IStorage _storage;
        Training _training;
        User _user;
        public CurrentTrainingWindow(Training training, User user, IStorage storage)
        {
            _training = training;
            _user = user;
            _storage = storage;
            InitializeComponent();
            ExcercizesListBox.ItemsSource = _storage.GetTrainings.Where(t => t.Id == training.Id).First().Excercises;
            
            //using (Context context = new Context())
            //{
            //    ExcercizesListBox.ItemsSource = context.Trainings.Include("Excercises").ToList().Where(t => t.Id == training.Id).First().Excercises;
            //}
        }

       

       
        private void TrainingNameTextBox_Initialized(object sender, EventArgs e)
        {
            var NameTextBlock = sender as TextBlock;
            NameTextBlock.Text = _training.Name;
        }

        private void ExcercizeGif_Initialized(object sender, EventArgs e)
        {
            var ExcercizeGifMediaElement = sender as MediaElement;
            var excercize = ExcercizeGifMediaElement.DataContext as Excercise;
            ExcercizeGifMediaElement.Source = new Uri(excercize.VideoSource);
            ExcercizeGifMediaElement.UnloadedBehavior = MediaState.Manual;
        }
        private void ExcerciseNameTextBlock_Initialized(object sender, EventArgs e)
        {
            var ExcercizeNameTextBlock = sender as TextBlock;
            var excercize = ExcercizeNameTextBlock.DataContext as Excercise;
            ExcercizeNameTextBlock.Text = excercize.Name;
        }

        private void LengthAndBreakTextBlock_Initialized(object sender, EventArgs e)
        {
            var LengthAndBreakTextBlock = sender as TextBlock;
            LengthAndBreakTextBlock.Text = $"Length: {functions.GetSeconds(_training.ExcerciseLength)}, break: {functions.GetSeconds(_training.BreakLength)}";
        }

       
        private void playVideo_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var excercize = button.DataContext as Excercise;
            var excersisePlay = new ExcersisePlayWindow(excercize.VideoSource, _training, _user, _storage);
            excersisePlay.Show();
            this.Close();
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Congratulations! You have completed training {_training.Name}");
            if (_user.CompletedTrainings == null)
                _user.CompletedTrainings = new List<Training>();
            else if (_user.CompletedTrainings.Any(t => t.Name==_training.Name))
                _user.CompletedTrainings.Remove(_training);
            
            _user.CompletedTrainings.Add(_training);
            _storage.Save();

            Back_Click(sender, e);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var trainingCatalog = new TrainingCatalog(_user, _storage);
            trainingCatalog.Show();
            this.Close();
        }

        private void NumberOfLoopsTextBlock_Initialized(object sender, EventArgs e)
        {
            var textblock = sender as TextBlock;
            textblock.Text = _training.CircleAmount.ToString() + " circles";
        }
    }
}
