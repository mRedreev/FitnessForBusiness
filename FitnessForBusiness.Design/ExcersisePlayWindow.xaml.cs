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

namespace FitnessForBusiness.Design
{
    /// <summary>
    /// Логика взаимодействия для ExcersisePlayWindow.xaml
    /// </summary>
    public partial class ExcersisePlayWindow : Window
    {
        Training _training;
        public ExcersisePlayWindow(String mediaElement)
        {
            InitializeComponent();
            video.Source = new Uri(mediaElement);
            video.UnloadedBehavior = MediaState.Manual;
            video.Play();
        }

        private void playVideo_Click(object sender, RoutedEventArgs e)
        {
            var trainingWindow = new CurrentTrainingWindow();
            trainingWindow.Show();
            this.Close();
        }
    }
}
