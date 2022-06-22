﻿using FitnessForBusiness.Core.Models;
using FitnessForBusiness.Core.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace FitnessForBusiness.Core
{
    public class functions
    {
        public static string NameOfLevel(bool? level)
        {
            if (level == null) return "Beginner";
            else if (level == false) return "Intermediate";
            else if (level == true) return "Advanced";
            return null;
        }

        public static string NameOfGoal(bool? goal)
        {
            if (goal == null) return "Losing weight";
            else if (goal == true) return "Gaining muscels";
            else if (goal == false) return "Keeping fit";
            return null;
        }

        public static bool? CheckGoal(string goal)
        {
            bool? result = null;

            if (goal == "Lose weight") result = null;
            else if (goal == "Maintain weight") result = false;
            else if (goal == "Gain muscle mass") result = true;

            return result;
        }

        public static bool? CheckLevel(string level)
        {
            bool? result = null;

            if (level == "Beginner") result = null;
            else if (level == "Intermediate") result = false;
            else if (level == "Advanced") result = true;

            return result;
        }

        public static User FindUser(string login)
        {
            IStorage storage = new Context();
            var user = storage.GetUsers.Where(u => u.Login == login).First();
            return user;
        }

        public static bool TextsBoxIsNotEmpty(List<TextBox> textBoxes)
        {

            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Text == "") return false;
            }

            return true;
        }

        public static bool ComboBoxIsNotEmpty(ComboBox comboBox, string startText)
        {
            if (comboBox.Text == startText) return false;
            else if (comboBox.Text == "") return false;
            else return true;
        }

        
        public static string GetImageSourceOfAvatar(int index)
        {
            if (index == 0) return "/Pictures/san.jpg";
            else if (index == 1) return "/Pictures/suboch.jpg";
            else if (index == 2) return "/Pictures/becl2.jpg";
            else if (index == 3) return "/Pictures/lom2.jpg";
            else return "";
        }

        public static bool DoesUserAlreadyExist(string login)
        {
            try
            {
                var user = FindUser(login);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void MakeEmptyBoxRed(List<TextBox> boxes)
        {
            foreach (TextBox box in boxes)
            {
                if (box.Text == "")
                    box.Background = Brushes.PaleVioletRed;
                else if (box.Text != "")
                    box.Background = Brushes.Transparent;
            }
        }

        public static void MakeRedPasswordboxesIfEmpty(List<PasswordBox> passwordBoxes)
        {
            foreach (PasswordBox box in passwordBoxes)
            {
                if (box.Password == "")
                    box.Background = Brushes.PaleVioletRed;
                else if (box.Password != "")
                    box.Background = Brushes.Transparent;
            }
        }

    }
}