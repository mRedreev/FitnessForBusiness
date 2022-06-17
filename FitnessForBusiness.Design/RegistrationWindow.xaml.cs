﻿using FitnessForBusiness.Core.Models;
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

      //  private void LevelButton_Checked(object sender, RoutedEventArgs e)
      //  {

      //  }



        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BitrhDateDatePicker_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //DateTime dt = (DateTime)this.BitrhDateDatePicker.SelectedDate;
            //MessageBox.Show(dt.ToString("dd-MM-yyyy"));

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            bool userExists;
            var listTextBoxes = new List<TextBox>(){NameBox, SurnameTextBox, EmailTextBox};
            var listPasswordBoxes = new List<PasswordBox> { PasswordBox, PasswordAgianTextBox };
            bool ifBoxesNotEmpty = functions.TextsBoxIsNotEmpty(listTextBoxes) & functions.ComboBoxIsNotEmpty(GoalComboBox, "Your Main Goal")
                & functions.ComboBoxIsNotEmpty(LeveloComboBox, "Your Level")
                & functions.ComboBoxIsNotEmpty(AvatarComboBox, "")
                & (PasswordBox.Password != "")
                & (BitrhDateDatePicker.SelectedDate.ToString() != "");
            functions.MakeEmptyBoxRed(listTextBoxes);
            functions.MakeRedPasswordboxesIfEmpty(listPasswordBoxes);
            if (ifBoxesNotEmpty)
            {
                if (PasswordBox.Password == PasswordAgianTextBox.Password)
                {
                    
                    PasswordBox.Background = Brushes.Transparent;
                    PasswordAgianTextBox.Background = Brushes.Transparent;
                    userExists = functions.DoesUserAlreadyExist(EmailTextBox.Text);
                    if (!userExists)
                    {
                        var name = NameBox.Text;
                        var surname = SurnameTextBox.Text;
                        var login = EmailTextBox.Text;
                        var password = PasswordBox.Password;
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
            }

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
