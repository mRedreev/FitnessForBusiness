using System;
using System.Collections.Generic;
using System.Linq;
using FitnessForBusiness.Core.Models;
using FitnessForBusiness.Core.Storages;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessForBusiness.Design.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        IStorage _storage;

        User _user;
        public ProfileView(IStorage storage, User user)
        {
            InitializeComponent();

            _storage = storage;
            _user = user;
        }

        public ProfileView()
        {

        }
        private void Image_Initialized(object sender, EventArgs e)
        {
            var image = sender as Image;

            BitmapImage myBitmapImage = new BitmapImage();

            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(_user.ImageSource);
        }

        private void NameTextBox_Initialized(object sender, EventArgs e)
        {
            //имя текущего пользователя
        }

        private void SurnameTextBox_Initialized(object sender, EventArgs e)
        {
            //фамилия текущего пользователя
        }
        private void LevelTextBox_Initialized(object sender, EventArgs e)
        {
            //уровень текущего пользователя
        }

        private void GoalComboBox_Initialized(object sender, EventArgs e)
        {
            //цель текущего пользователя
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            //применить изменения всего, что было отредактировано
        }
    }
}
