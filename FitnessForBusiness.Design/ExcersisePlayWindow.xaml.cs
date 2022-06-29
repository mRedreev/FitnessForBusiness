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
    /// Логика взаимодействия для ExcersisePlayWindow.xaml
    /// </summary>
    public partial class ExcersisePlayWindow : Window
    {
        Training _training;
        User _user;
        IStorage _storage;
        public ExcersisePlayWindow(String mediaElement, Training training, User user, IStorage storage)
        {
            _training = training;
            _user = user;
            _storage = storage;
            InitializeComponent();
            InitialiserOfGeneralElements(mediaElement);
        }

        private void InitialiserOfGeneralElements(string mediaElement)
        {
            video.Source = new Uri(mediaElement);
            video.UnloadedBehavior = MediaState.Manual;

            lengthAndBreak.Text = $"Length: {functions.GetSeconds(_training.ExcerciseLength)}, break: {functions.GetSeconds(_training.BreakLength)}";

            video.Play();
        }

        private void playVideo_Click(object sender, RoutedEventArgs e)
        {
            var trainingWindow = new CurrentTrainingWindow(_training, _user, _storage);
            trainingWindow.Show();
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
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
    }
}
