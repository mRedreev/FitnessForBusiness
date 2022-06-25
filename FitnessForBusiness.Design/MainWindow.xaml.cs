﻿using FitnessForBusiness.Core;
using FitnessForBusiness.Core.Models;
using FitnessForBusiness.Core.Storages;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessForBusiness.Design
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IStorage _storage;

        public MainWindow()
        {
            // storage = new Context();
            _storage = new JSONStorage();
            // InitialUsers2();
            //InitialTrainings2();
            InitializeComponent();

            //InitialTrainings();
            // InitialUsers();


            /*using (Context context = new Context())
            {
                MessageBox.Show(context.Users.ToList()[1].CompletedTrainings[0].ToString());
                context.Users.ToList()[1].CompletedTrainings = new List<Training>() { context.Trainings.ToList()[0] };
                context.SaveChanges();
                //context.Users.ToList()[1].CompletedTrainings = new List<Training>() { context.Trainings.ToList()[0] };
            }*/
        }

        private void InitialUsers()
        {
            using (Context context = new Context()) //Создание подключения (локальной копии БД)
            {
                User user1 = new User(
                    "Mikhail",
                    "Redreev",
                   ".. / .. / Users /user1.jpg",
                    DateTime.Parse("30.11.2002"),
                    true,
                    true,
                    "MRedreev",
                    "Misha2002"
                    );
                context.Users.Add(user1);
                context.SaveChanges();
                MessageBox.Show("user1 saved");
            }
        }

        private void InitialUsers2()
        {

            User user1 = new User(
                "Mikhail",
                "Redreev",
               ".. / .. / Users /user1.jpg",
                DateTime.Parse("30.11.2002"),
                true,
                true,
                "MRedreev",
                "Misha2002"
                );
            _storage.Registration(user1);
            MessageBox.Show("user1 saved");
        }

        //private void InitialTrainings()
        //{
        //    using (Context context = new Context()) //Создание подключения (локальной копии БД)
        //    {
        //        Excercise excercise1 = new Excercise
        //        (
        //            "Air bike",
        //            "http://d205bpvrqc9yn1.cloudfront.net/0003.gif",
        //            null,
        //            new List<string>() { "waist", "abs" },
        //            "mat"
        //        );

        //        Excercise excercise2 = new Excercise
        //        (
        //            "All fours squad stretch",
        //            "http://d205bpvrqc9yn1.cloudfront.net/1512.gif",
        //            null,
        //            new List<string>() { "quads" },
        //            "mat"
        //        );

        //        Excercise excercise3 = new Excercise
        //        (
        //            "ankle circles",
        //            "http://d205bpvrqc9yn1.cloudfront.net/1368.gif",
        //            null,
        //            new List<string>() { "calves" },
        //            "mat"
        //        );

        //        Excercise excercise4 = new Excercise
        //        (
        //            "astride jumps",
        //            "http://d205bpvrqc9yn1.cloudfront.net/3220.gif",
        //            null,
        //            new List<string>() { "cardiovascular system" },
        //            "mat"
        //        );

        //        TrainingType typeCardio = new TrainingType("cardio", ".. / .. / Pictures /cardio.png");
        //        TrainingType typePower = new TrainingType("power", ".. / .. / Pictures /power.png");
        //        TrainingType typeYoga = new TrainingType("yoga", ".. / .. / Pictures /yoga.png");
        //        TrainingType typeWarmUp = new TrainingType("warm-up", ".. / .. / Pictures /warm-up.png");



        //        Training training1 = new Training(
        //            "Short warm-up",
        //            typeWarmUp,
        //            null,
        //            new List<Excercise> { excercise1, excercise2, excercise3, excercise4 },
        //            0.5,
        //            0.25,
        //            2
        //            );
        //        context.Trainings.Add(training1);
        //        context.SaveChanges();
        //        MessageBox.Show("training1 saved");
        //    }
        //}

        //private void InitialTrainings2()
        //{
        //    Excercise excercise1 = new Excercise
        //    (
        //        "Air bike",
        //        "http://d205bpvrqc9yn1.cloudfront.net/0003.gif",
        //        null,
        //        new List<string>() { "waist", "abs" },
        //        "mat"
        //    );

        //    Excercise excercise2 = new Excercise
        //    (
        //        "All fours squad stretch",
        //        "http://d205bpvrqc9yn1.cloudfront.net/1512.gif",
        //        null,
        //        new List<string>() { "quads" },
        //        "mat"
        //    );

        //    Excercise excercise3 = new Excercise
        //    (
        //        "ankle circles",
        //        "http://d205bpvrqc9yn1.cloudfront.net/1368.gif",
        //        null,
        //        new List<string>() { "calves" },
        //        "mat"
        //    );

        //    Excercise excercise4 = new Excercise
        //    (
        //        "astride jumps",
        //        "http://d205bpvrqc9yn1.cloudfront.net/3220.gif",
        //        null,
        //        new List<string>() { "cardiovascular system" },
        //        "mat"
        //    );

        //    TrainingType typeCardio = new TrainingType("cardio", ".. / .. / Pictures /cardio.png");
        //    TrainingType typePower = new TrainingType("power", ".. / .. / Pictures /power.png");
        //    TrainingType typeYoga = new TrainingType("yoga", ".. / .. / Pictures /yoga.png");
        //    TrainingType typeWarmUp = new TrainingType("warm-up", ".. / .. / Pictures /warm-up.png");

        //    Training training1 = new Training(
        //        "Short warm-up",
        //        typeWarmUp,
        //        null,
        //        new List<Excercise> { excercise1, excercise2, excercise3, excercise4 },
        //        0.5,
        //        0.25,
        //        2
        //        );
        //    _storage.AddTraining(training1);
        //    MessageBox.Show("training1 saved");
        //}

        private List<TrainingType> MakeTrainingTypes()
        {
            TrainingType typeCardio = new TrainingType("cardio", ".. / .. / Pictures /cardio.png");
            TrainingType typePower = new TrainingType("power", ".. / .. / Pictures /power.png");
            TrainingType typeYoga = new TrainingType("yoga", ".. / .. / Pictures /yoga.png");
            TrainingType typeWarmUp = new TrainingType("warm-up", ".. / .. / Pictures /warm-up.png");

            return new List<TrainingType>
            {typeCardio, typeYoga, typeWarmUp, typePower};
        }

        private void TrainsInitialized()
        {
            var types = MakeTrainingTypes();
            var excersices = _storage.GetExcercises;

            var easyExercises = excersices.Where(e => e.Level == null).ToList();
            var middleExercises = excersices.Where(e => e.Level == false).ToList();
            var hardExercises = excersices.Where(e => e.Level == true).ToList();

            var powerEquipment = new List<string> { "cable", "leverage machine", "barbell", "dumbbell", "kettlebell"};

            var powerExcercises = excersices.Where(e => powerEquipment.Contains(e.Equipment.Name)).ToList();

            var cardioExcercises = excersices.Where(e => e.BodyParts.Name == "cardio").ToList();

            var warmupExcersises = excersices.Where(e => e.Equipment.Name == "body weight").ToList();

            var yogaExcercises = excersices.Where(e => e.Equipment.Name == "body weight").ToList();
            yogaExcercises = yogaExcercises.Where(e => e.Name.Contains("stretch")).ToList();

            var yoga1 = new Training
                (
                "Good morning",
                types[2],
                null,
                yogaExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(0, 10),
                1,
                0.5,
                3
                );

            var yoga2 = new Training
               (
               "Good night",
               types[2],
               false,
               yogaExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(11, 21),
               1,
               20,
               3
               );
            var yoga2 = new Training
                (
               "Feel good",
               types[2],
               false,
               yogaExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(11, 21),
               1,
               20,
               3
               );
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow(_storage);

            loginWindow.Show();

            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow(_storage);

            registrationWindow.Show();

            this.Close();
        }
        

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Minimized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

      
    }
}

    