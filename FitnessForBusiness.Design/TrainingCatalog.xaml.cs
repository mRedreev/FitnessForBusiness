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
        TrainingType _type = null;
        public TrainingCatalog(User user, IStorage storage)
        {
            _storage = storage;
            _user = user;
            
            InitializeComponent();
            ProfilePanel.Visibility = Visibility.Collapsed;
            var types = _storage.GetTrainings.Select(t => t.Type).ToList();
            var distTypes = new List<TrainingType> { types[0] };
            foreach (var type in types)
            {
                if (!distTypes.Any(t => t.Name==type.Name))
                    distTypes.Add(type);
            }
            TypesListBox.ItemsSource = distTypes;
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

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //private void LevelTextBlock_Initialized_1(object sender, EventArgs e)
        //{
        //    var levelTextBlock = sender as TextBlock;
        //    levelTextBlock.Text = functions.NameOfLevel(_user.Level);
        //}

        private void SyncUserData()
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (var fileStream = new FileStream("../../" + _user.ImageSource, FileMode.Open))
            {
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = fileStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            UserAvatar.Source = bitmapImage;

            UsernameNameTextBox.Text = _user.Name;
            UserSurnameTextBox.Text = _user.Surname;
            UserGoalComboBox.Text = "Goal: " + functions.NameOfGoal(_user.Goal);
            UserLevelTextBox.Text = "Level: " + functions.NameOfLevel(_user.Level);
        }

        //private void UserAvatar_Initialized(object sender, EventArgs e)
        //{
        //    var userAvatarTextBlock = sender as Image;
        //    BitmapImage bitmapImage = new BitmapImage();
        //    using (var fileStream = new FileStream("../../" + _user.ImageSource, FileMode.Open))
        //    {
        //        bitmapImage.BeginInit();
        //        bitmapImage.StreamSource = fileStream;
        //        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        //        bitmapImage.EndInit();
        //    }
        //    userAvatarTextBlock.Source = bitmapImage;
        //}

        //private void UsernameNameTextBox_Initialized(object sender, EventArgs e)
        //{
        //    var userNameTextBox = sender as TextBlock;
        //    userNameTextBox.Text = _user.Name;
        //}

        //private void UserSurnameTextBox_Initialized(object sender, EventArgs e)
        //{
        //    var userSurnameTextBlock = sender as TextBlock;
        //    userSurnameTextBlock.Text = _user.Surname;
        //}

        //private void UserLevelTextBox_Initialized(object sender, EventArgs e)
        //{
        //    var levelTextBox = sender as TextBlock;
        //    levelTextBox.Text = functions.NameOfLevel(_user.Level);
        //}

        //private void UserGoalComboBox_Initialized(object sender, EventArgs e)
        //{
        //    var goalTextBlock = sender as TextBlock;
        //    goalTextBlock.Text = functions.NameOfGoal(_user.Goal);
        //}

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            var newAvatar = ChangeAvatarComboBox.Text;
            var newGoal = ChangeGoalComboBox.Text;
            var newLevel = ChangeLevelComboBox.Text;
            var newLogin = ChangeUsernameBox.Text;
            var newPassword = ChangePasswordBox.Password;

            if (newAvatar + newGoal + newLevel + newLogin + newPassword == "")
                MessageBox.Show("Enter data to change something");
            else
            {
                bool EqualnessOdNewAndOldData = false;
                if (((newAvatar != "") & (_user.ImageSource == functions.GetImageSourceOfAvatar(ChangeAvatarComboBox.SelectedIndex))) |
                    ((newGoal != "") & (_user.Goal == functions.CheckGoal(newGoal))) |
                    ((newLevel != "") & (_user.Level == functions.CheckLevel(newLevel))) |
                    ((newPassword != "") & (_user.Password == newPassword)) |
                    ((newLogin != "") & (_user.Login == newLogin))) 
                { EqualnessOdNewAndOldData = true; }

                if (EqualnessOdNewAndOldData)
                {
                    MessageBox.Show("New and current data can't be equal. Please, enter another");
                }
                else
                {
                    MessageBox.Show("Data has been changed successfully");
                    if (newAvatar != "")
                        _user.ImageSource = functions.GetImageSourceOfAvatar(ChangeAvatarComboBox.SelectedIndex);
                    if (newGoal != "")
                        _user.Goal = functions.CheckGoal(newGoal);
                    if (newLevel != "")
                        _user.Level = functions.CheckLevel(newLevel);
                    if (newLogin != "")
                        _user.Login = newLogin;
                    if (newPassword != "")
                        _user.Password = newPassword;
                    _storage.Save();

                    EditUserInfoPanel.Visibility = Visibility.Collapsed;
                    EditUserInformationButton.Visibility = Visibility.Visible;
                    SyncUserData();
                }
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentTypeImagePanel.Visibility = Visibility.Collapsed;
            TypesPanel.Visibility = Visibility.Collapsed;
            CompletedTrainingsPanel.Visibility = Visibility.Collapsed;
            RecommendedTrainingsPanel.Visibility = Visibility.Collapsed;

            SyncUserData();
            ProfilePanel.Visibility = Visibility.Visible;
            EditUserInfoPanel.Visibility = Visibility.Collapsed;

        }

        private void CompletedWorkoutsButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentTypeImagePanel.Visibility = Visibility.Collapsed;
            ProfilePanel.Visibility = Visibility.Collapsed;
            TypesPanel.Visibility = Visibility.Collapsed;
            RecommendedTrainingsPanel.Visibility = Visibility.Collapsed;

            CompletedTrainings.ItemsSource = _user.CompletedTrainings;
            CompletedTrainingsPanel.Visibility = Visibility.Visible;
           
        }

        private void CatalogButton_Click(object sender, RoutedEventArgs e)
        {

            CurrentTypeImagePanel.Visibility = Visibility.Collapsed;
            ProfilePanel.Visibility = Visibility.Collapsed;
            CompletedTrainingsPanel.Visibility = Visibility.Collapsed;
            RecommendedTrainingsPanel.Visibility = Visibility.Collapsed;
            TypesPanel.Visibility = Visibility.Visible;
        }

        private void RecommendedWorkoutsButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentTypeImagePanel.Visibility = Visibility.Collapsed;
            ProfilePanel.Visibility = Visibility.Collapsed;
            CompletedTrainingsPanel.Visibility = Visibility.Collapsed;
            TypesPanel.Visibility = Visibility.Collapsed;

            RecommendedTrainings.ItemsSource = GetRecommendedTrainings();
            RecommendedTrainingsPanel.Visibility = Visibility.Visible;
        }
        private List<Training> GetRecommendedTrainings()
        {
            var trainingsWithUsersLevel = _storage.GetTrainings.Where(t => t.Level == _user.Level).ToList();
            if (_user.Goal == null) return trainingsWithUsersLevel.Where(t => t.Type.Name == "cardio").ToList();
            else if (_user.Goal == true) return trainingsWithUsersLevel.Where(t => t.Type.Name == "power").ToList();
            else return trainingsWithUsersLevel.Where(t => t.Type.Name == "yoga").ToList();
        }

        private void TypesListBox_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void TypesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;

            _type = TypesListBox.SelectedItem as TrainingType;

            TypesListBox.SelectionChanged -= TypesListBox_SelectionChanged;
            TypesListBox.SelectedIndex = -1;
            TypesListBox.SelectionChanged += TypesListBox_SelectionChanged;
            TypesPanel.Visibility = Visibility.Collapsed;

            CurrentTypeTextBlock.Text = _type.Name;
            var trainingsWithCurrentType = _storage.GetTrainings.Where(t => t.Type.Name == _type.Name).ToList();

            BeginnerTrainingsListBox.ItemsSource = TrainingsWithCurrentLevel(trainingsWithCurrentType, null);
            IntermediateTrainingsListBox.ItemsSource = TrainingsWithCurrentLevel(trainingsWithCurrentType, false);
            AdvTrainingsListBox.ItemsSource= TrainingsWithCurrentLevel(trainingsWithCurrentType, true);

            BeginnerTrainingsListBox.Visibility = Visibility.Visible;
            IntermediateTrainingsListBox.Visibility = Visibility.Visible;
            AdvTrainingsListBox.Visibility = Visibility.Visible;
            CurrentTypeImagePanel.Visibility = Visibility.Visible;

            MakeCurrentTypeImage();
            MakeCurrentTypeTextBlock();
        }

        private void SwitchBackToTypesList()
        {
            _type = null;

            BeginnerTrainingsListBox.ItemsSource = null;
            IntermediateTrainingsListBox.ItemsSource = null;
            AdvTrainingsListBox.ItemsSource = null;

            CurrentTypeImagePanel.Visibility = Visibility.Collapsed;
            TypesPanel.Visibility = Visibility.Collapsed;

            //TypesListBox.ItemsSource = _storage.GetTrainings.Select(t => t.Type).Distinct().ToList();

            TypesPanel.Visibility = Visibility.Visible;

        }

        private List<Training> TrainingsWithCurrentLevel(List<Training> trainings, bool? level)
        {
            return trainings.Where(t => t.Level == level).ToList();
        }

        private void TypeImage_Initialized(object sender, EventArgs e)
        {
            var typeImage = sender as Image;
            var type = typeImage.DataContext as TrainingType;
           
            typeImage.Source = functions.GetbitmapImageFromType(type);
            typeImage.Height = 200;
            typeImage.Width = 500;
        }

        private void TrainingTypeTextBlock_Initialized(object sender, EventArgs e)
        {
            var typeName = sender as TextBlock;
            var type = typeName.DataContext as TrainingType;

            typeName.Text = type.Name;
        }

        //LevelsPanel
        private void CurrentTypeImage_Initialized(object sender, EventArgs e)
        {
            if (_type != null)
            {
                var currentTypeImage = sender as Image;
                currentTypeImage.Source = functions.GetbitmapImageFromType(_type);
            }
            
        }

        private void MakeCurrentTypeImage()
        {
            CurrentTypeImage.Source = functions.GetbitmapImageFromType(_type);
            CurrentTypeImage.Height = 200;
            CurrentTypeImage.Width = 500;
        }

        private void MakeCurrentTypeTextBlock()
        {
            CurrentTypeTextBlock.Text = _type.Name;
        }

        private void CurrentTypeTextBlock_Initialized(object sender, EventArgs e)
        {
            var typeName = sender as TextBlock;
            if (_type != null)  typeName.Text = _type.Name;
        }

        private void TrainingNameTextBlock_Initialized(object sender, EventArgs e)
        {
            var name = sender as TextBlock;
            var training = name.DataContext as Training;
            name.Text = training.Name;
        }

        private void BeginButton_Initialized(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.Content = "Begin";
        }

        private void BeginButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var training = button.DataContext as Training;
            var currentTrWindow = new CurrentTrainingWindow(training, _user, _storage);
            currentTrWindow.Show();
            this.Close();
        }

        private void EquipmentTextBlock_Initialized(object sender, EventArgs e)
        {
            var equipmentBlock = sender as TextBlock;
            var training = equipmentBlock.DataContext as Training;
            var equipment = training.Equipment.Select(eq => eq.Name).ToList();
            string equipmentString = "";
            foreach (var equipmentItem in equipment)
            {
                equipmentString = equipmentBlock.Text + equipmentItem + ", ";
            }
            if (equipmentString.Length > 2) equipmentString = equipmentString.Remove(equipmentString.Length - 2);
            equipmentBlock.Text = "Equipment: " + equipmentString;
        }

        private void BodyPartsTextBlock_Initialized(object sender, EventArgs e)
        {
            var bodyPartsBlock = sender as TextBlock;
            var training = bodyPartsBlock.DataContext as Training;
            var bodyParts = training.Description;
            bodyPartsBlock.Text = "BodyParts: " + bodyParts.Remove(bodyParts.Length-2);
        }

        private void IntermediateTrainingNameTextBlock_Initialized(object sender, EventArgs e)
        {
            TrainingNameTextBlock_Initialized(sender, e);
        }

        private void IntermediateBeginButton_Initialized(object sender, EventArgs e)
        {
            BeginButton_Initialized(sender, e);
        }

        private void IntermediateBeginButton_Click(object sender, RoutedEventArgs e)
        {
            BeginButton_Click(sender, e);
        }

        private void InterEquipment_Initialized(object sender, EventArgs e)
        {
            EquipmentTextBlock_Initialized(sender, e);
        }

        private void IntBodyPartsTextBlock_Initialized(object sender, EventArgs e)
        {
            BodyPartsTextBlock_Initialized(sender, e);
        }

        private void AdvTrainingNameTextBlock_Initialized(object sender, EventArgs e)
        {
            TrainingNameTextBlock_Initialized(sender, e);
        }

        private void AdvBeginButton_Initialized(object sender, EventArgs e)
        {
            BeginButton_Initialized(sender, e);

        }

        private void AdvBeginButton_Click(object sender, RoutedEventArgs e)
        {
            BeginButton_Click(sender, e);
        }

        private void AdvEquipmentTextBlock_Initialized(object sender, EventArgs e)
        {
            EquipmentTextBlock_Initialized(sender, e);
        }

        private void AdvBodyPartsTextBlock_Initialized(object sender, EventArgs e)
        {
            BodyPartsTextBlock_Initialized(sender, e);
        }

        private void BeginTrainingTimeTextBlock_Initialized(object sender, EventArgs e)
        {
            var timeBlock = sender as TextBlock;
            var training = timeBlock.DataContext as Training;
            timeBlock.Text = functions.GetMinutes(training.Length);
        }

        private void AdvTrainingTimeTextBlock_Initialized(object sender, EventArgs e)
        {
            BeginTrainingTimeTextBlock_Initialized(sender, e);
        }

        private void IntTrainingTimeTextBlock_Initialized(object sender, EventArgs e)
        {
            BeginTrainingTimeTextBlock_Initialized(sender, e);
        }

        private void GetBackToTypesButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchBackToTypesList();
        }

        private void TypesListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var listBoxBorder = VisualTreeHelper.GetChild(TypesListBox, 0) as Border;
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

        private void TypesListBox_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void CompletedTrainingNameBlock_Initialized(object sender, EventArgs e)
        {
            TrainingNameTextBlock_Initialized(sender, e);
        }

        private void CompletedTrainingNameButton_Initialized(object sender, EventArgs e)
        {
            BeginButton_Initialized(sender, e);
        }

        private void CompletedTrainingNameButton_Click(object sender, RoutedEventArgs e)
        {
            BeginButton_Click(sender, e);
        }

        private void CompletedTrainingTimeBlock_Initialized(object sender, EventArgs e)
        {
            BeginTrainingTimeTextBlock_Initialized(sender, e);
        }

        private void CompletedTrainingEqupmentBlock_Initialized(object sender, EventArgs e)
        {
            EquipmentTextBlock_Initialized(sender, e);
        }

        private void CompletedTrainingBodyPartsBlock_Initialized(object sender, EventArgs e)
        {
            BodyPartsTextBlock_Initialized(sender, e);
        }

        private void CompletedTrainingTypeBlock_Initialized(object sender, EventArgs e)
        {
            var textblock = sender as TextBlock;
            var training = textblock.DataContext as Training;
            textblock.Text = training.Type.Name;
        }

        private void RecommendedTrainingNameBlock_Initialized(object sender, EventArgs e)
        {
            TrainingNameTextBlock_Initialized(sender, e);
        }


        private void RecommendedTrainingNameButton_Initialized(object sender, EventArgs e)
        {
            BeginButton_Initialized(sender, e);
        }

        private void RecommendedTrainingNameButton_Click(object sender, RoutedEventArgs e)
        {
            BeginButton_Click(sender, e);
        }

        private void RecommendedTrainingTimeBlock_Initialized(object sender, EventArgs e)
        {
            BeginTrainingTimeTextBlock_Initialized(sender, e);
        }

        private void RecommendedTrainingEqupmentBlock_Initialized(object sender, EventArgs e)
        {
            EquipmentTextBlock_Initialized(sender, e);
        }

        private void RecommendedTrainingBodyPartsBlock_Initialized(object sender, EventArgs e)
        {
            BodyPartsTextBlock_Initialized(sender, e);
        }

        private void RecommendedTypeTextBlock_Initialized(object sender, EventArgs e)
        {
            CompletedTrainingTypeBlock_Initialized(sender, e);
        }

        private void RecommendedLevelTextBlock_Initialized(object sender, EventArgs e)
        {
            var textBlock = sender as TextBlock;
            var training = textBlock.DataContext as Training;
            textBlock.Text = functions.NameOfLevel(training.Level);
        }

        private void IntermediateTrainingsListBox_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void IntermediateTrainingsListBox_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void BeginnerTrainingsListBox_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void BeginnerTrainingsListBox_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void AdvTrainingsListBox_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void AdvTrainingsListBox_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void EditUserInformationButton_Click(object sender, RoutedEventArgs e)
        {
            EditUserInfoPanel.Visibility = Visibility.Visible;
            var button = sender as Button;
            button.Visibility = Visibility.Collapsed;
        }

        private void ShowRecommendedGoalAndLevel()
        {
            RecommendedLevelTextBlock.Text = functions.NameOfLevel(_user.Level);
            RecommendedGoalTextBlock.Text = functions.NameOfGoal(_user.Goal);
        }
    }
}