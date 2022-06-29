using FitnessForBusiness.Core.Models;
using FitnessForBusiness.Core.Storages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FitnessForBusiness.Core
{
    public class functions
    {
        static IStorage _storage = new JSONStorage();
        public static List<Excercise> excersices = _storage.GetExcercises;

        public static List<Excercise> easyExercises = excersices.Where(e => e.Level == null).ToList();
        public static List<Excercise> middleExercises = excersices.Where(e => e.Level == false).ToList();
        public static List<Excercise> hardExercises = excersices.Where(e => e.Level == true).ToList();

        public static List<string> powerEquipment = new List<string> { "cable", "leverage machine", "barbell", "dumbbell", "kettlebell" };

        public static List<Excercise> powerExcercises = excersices.Where(e => powerEquipment.Contains(e.Equipment.Name)).ToList();

        public static List<Excercise> cardioExcercises = excersices.Where(e => e.BodyParts.Name == "cardio").ToList();

        public static List<Excercise> warmupExercises = excersices.Where(e => e.Equipment.Name == "body weight").ToList();

        public static List<Excercise> yogaExcercises = excersices.Where(e => e.Equipment.Name == "body weight").Where(e => e.Name.Contains("stretch")).ToList();

        public static string NameOfLevel(bool? level)
        {
            if (level == null) return "Beginner";
            else if (level == false) return "Intermediate";
            else if (level == true) return "Advanced";
            return null;
        }

        public static string NameOfGoal(bool? goal)
        {
            if (goal == null) return "Lose weight";
            else if (goal == true) return "Gain muscle mass";
            else if (goal == false) return "Maintain weight";
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


        public static bool DoesUserExist(IStorage storage, string login)
        {
            return storage.GetUsers.Any(x => x.Login == login);
        }

        public static User FindUser(IStorage storage, string login)
        {
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

        public static bool DoesUserAlreadyExistJSON(IStorage storage, string login)
        {
            try
            {
                var user = FindUserJSON(storage, login);
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

        public static BitmapImage GetbitmapImageFromType(TrainingType type)
        {
            BitmapImage bitmapImage = new BitmapImage();

            using (var fileStream = new FileStream(type.ImageSource, FileMode.Open))
            {
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = fileStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }

            return bitmapImage;
        }

        public static string GetSeconds(double minutes)
        {
            return (minutes * 60).ToString() + " seconds";
        }

        public static string GetMinutes(double minutes)
        {
            return minutes.ToString() + " minutes";
        }

        public static List<TrainingType> MakeTrainingTypes()
        {
            TrainingType typeCardio = new TrainingType("cardio", "../../Pictures/cardio.png");
            TrainingType typePower = new TrainingType("power", "../../Pictures/power.png");
            TrainingType typeYoga = new TrainingType("yoga", "../../Pictures/yoga.png");
            TrainingType typeWarmUp = new TrainingType("warm-up", "../../Pictures/warm-up.png");

            return new List<TrainingType>
            {typeCardio, typeYoga, typeWarmUp, typePower};
        }

    }
}
