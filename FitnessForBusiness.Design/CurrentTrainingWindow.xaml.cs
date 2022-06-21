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
        Training _training;

        public CurrentTrainingWindow()
        {
            IStorage _storage = new Context();
            _training = _storage.GetTrainings.First();
            InitializeComponent();

            using (Context context = new Context())
            {
                ExcercizesListBox.ItemsSource = context.Trainings.Include("Excercises").First().Excercises;
            }
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
            ExcercizeGifMediaElement.Play();
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
            LengthAndBreakTextBlock.Text = $"Длительность упражнения: {_training.ExcerciseLength.ToString()}, перерыв: {_training.BreakLength.ToString()}";
        }
    }
}
