using FitnessForBusiness.Core;
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
        public MainWindow()
        {
            InitializeComponent();
            TelegramBot.Main();
        }

        public MainWindow(bool wasAlreadyStarted)
        {
            InitializeComponent();
        }

        
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();

            loginWindow.Show();

            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();

            registrationWindow.Show();

            this.Close();
        }
        

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
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

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        //private void InitialUsers()
        //{
        //    using (Context context = new Context()) //Создание подключения (локальной копии БД)
        //    {
        //        User user1 = new User(
        //            "Mikhail",
        //            "Redreev",
        //           ".. / .. / Users /user1.jpg",
        //            DateTime.Parse("30.11.2002"),
        //            true,
        //            true,
        //            "MRedreev",
        //            "Misha2002"
        //            );
        //        context.Users.Add(user1);
        //        context.SaveChanges();
        //        MessageBox.Show("user1 saved");
        //    }
        //}

        //private void InitialUsers2()
        //{

        //    User user1 = new User(
        //        "Mikhail",
        //        "Redreev",
        //       ".. / .. / Users /user1.jpg",
        //        DateTime.Parse("30.11.2002"),
        //        true,
        //        true,
        //        "MRedreev",
        //        "Misha2002"
        //        );
        //    _storage.Registration(user1);
        //    MessageBox.Show("user1 saved");
        //}

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

        //private void TrainsInitialized(string type)
        //{
        //    var types = functions.MakeTrainingTypes();


        //    if (type == "yoga")
        //    {
        //        var yoga1 = new Training
        //        (
        //        "Good morning",
        //        types[1],
        //        null,
        //        yogaExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(0, 10),
        //        1,
        //        0.5,
        //        3
        //        );

        //        //var yoga2 = new Training
        //        //   (
        //        //   "Good night",
        //        //   types[2],
        //        //   false,
        //        //   yogaExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(10, 10),
        //        //   1,
        //        //   0.5,
        //        //   3
        //        //   );

        //        var yoga3 = new Training
        //            (
        //           "Feel good",
        //           types[1],
        //           false,
        //           yogaExcercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(0, 10),
        //           1,
        //           0.5,
        //           3
        //           );

        //        var yoga4 = new Training
        //              (
        //           "Breathe and feel",
        //           types[1],
        //           true,
        //           yogaExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(0, 10),
        //           1,
        //           0.5,
        //           3
        //           );

        //        //var yoga5 = new Training
        //        //      (
        //        //   "Yin yoga",
        //        //   types[2],
        //        //   true,
        //        //   yogaExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(10, 5),
        //        //   2,
        //        //   0.5,
        //        //   3
        //        //   );
        //        _storage.AddTraining(yoga1);
        //       // _storage.AddTraining(yoga2);
        //        _storage.AddTraining(yoga3);
        //        _storage.AddTraining(yoga4);
        //        //_storage.AddTraining(yoga5);
        //    }
        //    if (type == "warm-up")
        //    {
        //        var warmup1 = new Training
        //        (
        //        "Before running",
        //        types[2],
        //        null,
        //        warmupExercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(0, 5),
        //        0.5,
        //        0.25,
        //        5
        //        );

        //        var warmup2 = new Training
        //           (
        //           "Before main training",
        //           types[2],
        //           null,
        //           warmupExercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(5, 5),
        //           0.75,
        //           0.15,
        //           3
        //           );

        //        var warmup3 = new Training
        //            (
        //           "Before power trainig",
        //           types[2],
        //           null,
        //           warmupExercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(10, 5),
        //           0.5,
        //           0.5,
        //           5
        //           );

        //        var warmup4 = new Training
        //            (
        //            "Before cardio training",
        //            types[2],
        //            false,
        //            warmupExercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(15, 5),
        //            0.75,
        //            0.25,
        //            5
        //            );

        //        var warmup5 = new Training
        //           (
        //           "Universal warm-up",
        //           types[2],
        //           false,
        //           warmupExercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(20, 5),
        //           0.1,
        //           0.25,
        //           3
        //           );

        //        var warmup6 = new Training
        //            (
        //           "Try me",
        //           types[2],
        //           true,
        //           warmupExercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(25, 5),
        //           1.25,
        //           0.25,
        //           3
        //           );
        //        _storage.AddTraining(warmup1);
        //        _storage.AddTraining(warmup2);
        //        _storage.AddTraining(warmup3);
        //        _storage.AddTraining(warmup4);
        //        _storage.AddTraining(warmup5);
        //        _storage.AddTraining(warmup6);
        //    }
        //    if (type == "cardio")
        //    {
        //        var cardio1 = new Training
        //            (
        //            "Full body HIIT",
        //            types[0],
        //            null,
        //            cardioExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(0, 3),
        //            1,
        //            0.25,
        //            3
        //            );

        //        var cardio2 = new Training
        //            (
        //            "Burn calories HIIT",
        //            types[0],
        //            null,
        //            cardioExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(5, 5),
        //            0.75,
        //            0.15,
        //            3
        //            );

        //        var cardio3 = new Training
        //            (
        //            "Best full body burn",
        //            types[0],
        //            false,
        //            cardioExcercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(0, 5),
        //            1.5,
        //            0.5,
        //            4
        //            );

        //        var cardio4 = new Training
        //            (
        //            "Total burn",
        //            types[0],
        //            false,
        //            warmupExercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(5, 5),
        //            2,
        //            0.5,
        //            4
        //            );

        //        var cardio5 = new Training
        //            (
        //            "Intense full body",
        //            types[0],
        //            true,
        //            cardioExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(0, 5),
        //            3,
        //            0.5,
        //            5
        //            );

        //        //var cardio6 = new Training
        //        //    (
        //        //    "Get shredded",
        //        //    types[0],
        //        //    true,
        //        //    cardioExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(5, 5),
        //        //    3,
        //        //    0.5,
        //        //    5
        //        //    );

        //        _storage.AddTraining(cardio1);
        //        _storage.AddTraining(cardio2);
        //       _storage.AddTraining(cardio3);
        //        _storage.AddTraining(cardio4);
        //        _storage.AddTraining(cardio5);
        //       // _storage.AddTraining(cardio6);
        //    }
        //    if (type == "power")
        //    {
        //        var power1 = new Training
        //            (
        //            "Muscle up workout",
        //            types[3],
        //            null,
        //            powerExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(0, 5),
        //            1,
        //            0.25,
        //            2
        //            );

        //        var power2 = new Training
        //            (
        //            "Build muscle & strength",
        //            types[3],
        //            null,
        //            powerExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(5, 5),
        //            1,
        //            0.15,
        //            3
        //            );

        //        var power3 = new Training
        //            (
        //            "Shredded summer body",
        //            types[3],
        //            null,
        //            powerExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(10, 5),
        //            1.5,
        //            0.25,
        //            3
        //            );

        //        var power4 = new Training
        //            (
        //            "Muscle builder",
        //            types[3],
        //            false,
        //            powerExcercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(0, 7),
        //            0.75,
        //            0.15,
        //            4
        //            );

        //        var power5 = new Training
        //            (
        //            "Strength builder",
        //            types[3],
        //            false,
        //            powerExcercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(7, 4),
        //            1.5,
        //            0.25,
        //            5);

        //        var power6 = new Training
        //            (
        //            "Ultimate Physique",
        //            types[3],
        //            false,
        //            powerExcercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(11, 6),
        //            1,
        //            0.20,
        //            3
        //            );

        //        var power7 = new Training
        //            (
        //            "Build Mass",
        //            types[3],
        //            false,
        //            powerExcercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(17, 6),
        //            2.00,
        //            0.25,
        //            3
        //            );

        //        var power8 = new Training
        //            (
        //            "Begin your muscle journey",
        //            types[3],
        //            true,
        //            powerExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(0, 8),
        //            1.5,
        //            0.5,
        //            4
        //            );

        //        var power9 = new Training
        //            (
        //            "Malibu lifeguard",
        //            types[3],
        //            true,
        //            powerExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(8, 7),
        //            2,
        //            0.5,
        //            4
        //            );

        //        var power10 = new Training
        //            (
        //            "Attention catcher",
        //            types[3],
        //            true,
        //            powerExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(15, 10),
        //            2,
        //            0.5,
        //            3);
        //        _storage.AddTraining(power1);
        //        _storage.AddTraining(power2);
        //        _storage.AddTraining(power3);
        //        _storage.AddTraining(power4);
        //        _storage.AddTraining(power5);
        //        _storage.AddTraining(power6);
        //        _storage.AddTraining(power7);
        //        _storage.AddTraining(power8);
        //        _storage.AddTraining(power9);
        //        _storage.AddTraining(power10);
        //    }
        //    else if (type == "other")
        //    {
        //        var yoga6 = new Training
        //              (
        //           "Bright and shine",
        //           types[1],
        //           null,
        //           yogaExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(0, 5),
        //           1,
        //           0.15,
        //           3
        //           );
        //        var yoga7 = new Training
        //                              (
        //                           "The date with yourself",
        //                           types[1],
        //                           null,
        //                           yogaExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(2, 6),
        //                           1.5,
        //                           0.15,
        //                           3
        //                           );
        //        var yoga8 = new Training
        //                              (
        //                           "Feel completely at ease",
        //                           types[1],
        //                           false,
        //                           yogaExcercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(3, 7),
        //                           1,
        //                           0.15,
        //                           3
        //                           );
        //        var yoga9 = new Training
        //                              (
        //                           "Energy of the day",
        //                           types[1],
        //                           false,
        //                           yogaExcercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(2, 6),
        //                           1,
        //                           0.25,
        //                           3
        //                           );
        //        var yoga10 = new Training
        //                              (
        //                           "Yoga for every day",
        //                           types[1],
        //                           true,
        //                           yogaExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(3, 7),
        //                           1,
        //                           0.15,
        //                           3
        //                           );
        //        var yoga11 = new Training
        //                              (
        //                           "Yin-Yang",
        //                           types[1],
        //                           true,
        //                           yogaExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(1, 7),
        //                           1,
        //                           0.15,
        //                           3
        //                           );
        //        var yoga12 = new Training
        //                              (
        //                           "Fullness, symmetry and grace",
        //                           types[1],
        //                           true,
        //                           yogaExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(4, 5),
        //                           1,
        //                           0.15,
        //                           5
        //                           );


        //        _storage.AddTraining(yoga6);
        //        _storage.AddTraining(yoga7);
        //        _storage.AddTraining(yoga8);
        //        _storage.AddTraining(yoga9);
        //        _storage.AddTraining(yoga10);
        //        _storage.AddTraining(yoga11);
        //        _storage.AddTraining(yoga12);





        //        var warmup7 = new Training
        //                        (
        //                        "Before big achievements",
        //                        types[2],
        //                        null,
        //                        warmupExercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(0, 5),
        //                        1.0,
        //                        0.15,
        //                        3
        //                        );

        //        var warmup8 = new Training
        //           (
        //           "Warm up your body",
        //           types[2],
        //           true,
        //           warmupExercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(3, 4),
        //           1.5,
        //           0.15,
        //           3
        //           );

        //        var warmup9 = new Training
        //            (
        //           "For successful cardio",
        //           types[2],
        //           true,
        //           warmupExercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(4, 6),
        //           1.5,
        //           0.15,
        //           4
        //           );

        //        var warmup10 = new Training
        //            (
        //            "Provide safe strength training",
        //            types[2],
        //            true,
        //            warmupExercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(5, 7),
        //            0.75,
        //            0.25,
        //            4
        //            );

        //        var warmup11 = new Training
        //           (
        //           "Not for Mom, but for yourself",
        //           types[2],
        //           true,
        //           warmupExercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(6, 9),
        //           1,
        //           0.25,
        //           2
        //           );

        //        _storage.AddTraining(warmup7);
        //        _storage.AddTraining(warmup8);
        //        _storage.AddTraining(warmup9);
        //        _storage.AddTraining(warmup10);
        //        _storage.AddTraining(warmup11);




        //        var cardio7 = new Training
        //                   (
        //                   "Cardiac acceleration",
        //                   types[0],
        //                   null,
        //                   cardioExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(5, 4),
        //                   2,
        //                   0.25,
        //                   4
        //                   );

        //        var cardio8 = new Training
        //                    (
        //                    "Run Forrest run",
        //                    types[0],
        //                    null,
        //                    cardioExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(4, 5),
        //                    1,
        //                    0.15,
        //                    3
        //                    );

        //        var cardio9 = new Training
        //            (
        //            "Hot Monday",
        //            types[0],
        //            false,
        //            cardioExcercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(2, 5),
        //            1.5,
        //            0.5,
        //            4
        //            );

        //        var cardio10 = new Training
        //            (
        //            "Sweaty Thursday",
        //            types[0],
        //            true,
        //            cardioExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(0, 5),
        //            2,
        //            0.25,
        //            4
        //            );

        //        var cardio11 = new Training
        //            (
        //            "Training after a working week",
        //            types[0],
        //            true,
        //            cardioExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(1, 5),
        //            3,
        //            0.25,
        //            4
        //            );

        //        _storage.AddTraining(cardio7);
        //        _storage.AddTraining(cardio8);
        //        _storage.AddTraining(cardio9);
        //        _storage.AddTraining(cardio10);
        //        _storage.AddTraining(cardio11);
        //    }


        //}


    }
}

    