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
            _storage = new Context();
            InitializeComponent();
        }

        private void LevelButton_Checked(object sender, RoutedEventArgs e)
        {

        }


        private void AvatarButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imgDynamicImage.Source = new BitmapImage(fileUri);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        //      private void AddNewUser()
        //      {
        //          var name = NameBox.Text;
        //          var surname = ;
        //          var imageSource = ;
        //        var born = BitrhDateDatePicker;
        //        var login = EmailTextBox.Text;
        //        var password = PasswordBox.Text;
        //        var goal = GoalComboBox.Text

        //      }
    }
}
