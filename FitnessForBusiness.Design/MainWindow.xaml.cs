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
        IStorage _storage;

        public MainWindow()
        {
            // storage = new Context();
            _storage = new JSONStorage();
            // InitialUsers2();
            //InitialTrainings2();
           // TrainsInitialized("cardio");
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
            TrainingType typeCardio = new TrainingType("cardio", "../../Pictures/cardio.png");
            TrainingType typePower = new TrainingType("power", "../../Pictures/power.png");
            TrainingType typeYoga = new TrainingType("yoga", "../../Pictures/yoga.png");
            TrainingType typeWarmUp = new TrainingType("warm-up", "../../Pictures/warm-up.png");

            return new List<TrainingType>
            {typeCardio, typeYoga, typeWarmUp, typePower};
        }

        private void TrainsInitialized(string type)
        {
            var types = MakeTrainingTypes();
            var excersices = _storage.GetExcercises;

            var easyExercises = excersices.Where(e => e.Level == null).ToList();
            var middleExercises = excersices.Where(e => e.Level == false).ToList();
            var hardExercises = excersices.Where(e => e.Level == true).ToList();

            var powerEquipment = new List<string> { "cable", "leverage machine", "barbell", "dumbbell", "kettlebell"};

            var powerExcercises = excersices.Where(e => powerEquipment.Contains(e.Equipment.Name)).ToList();

            var cardioExcercises = excersices.Where(e => e.BodyParts.Name == "cardio").ToList();

            var warmupExercises = excersices.Where(e => e.Equipment.Name == "body weight").ToList();

            var yogaExcercises = excersices.Where(e => e.Equipment.Name == "body weight").ToList();
            yogaExcercises = yogaExcercises.Where(e => e.Name.Contains("stretch")).ToList();

            if (type == "yoga")
            {
                var yoga1 = new Training
                (
                "Good morning",
                types[1],
                null,
                yogaExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(0, 10),
                1,
                0.5,
                3
                );

                //var yoga2 = new Training
                //   (
                //   "Good night",
                //   types[2],
                //   false,
                //   yogaExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(10, 10),
                //   1,
                //   0.5,
                //   3
                //   );

                var yoga3 = new Training
                    (
                   "Feel good",
                   types[1],
                   false,
                   yogaExcercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(0, 10),
                   1,
                   0.5,
                   3
                   );

                var yoga4 = new Training
                      (
                   "Breathe and feel",
                   types[1],
                   true,
                   yogaExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(0, 10),
                   1,
                   0.5,
                   3
                   );

                //var yoga5 = new Training
                //      (
                //   "Yin yoga",
                //   types[2],
                //   true,
                //   yogaExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(10, 5),
                //   2,
                //   0.5,
                //   3
                //   );
                _storage.AddTraining(yoga1);
               // _storage.AddTraining(yoga2);
                _storage.AddTraining(yoga3);
                _storage.AddTraining(yoga4);
                //_storage.AddTraining(yoga5);
            }
            if (type == "warm-up")
            {
                var warmup1 = new Training
                (
                "Before running",
                types[2],
                null,
                warmupExercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(0, 5),
                0.5,
                0.25,
                5
                );

                var warmup2 = new Training
                   (
                   "Before main training",
                   types[2],
                   null,
                   warmupExercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(5, 5),
                   0.75,
                   0.15,
                   3
                   );

                var warmup3 = new Training
                    (
                   "Before power trainig",
                   types[2],
                   null,
                   warmupExercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(10, 5),
                   0.5,
                   0.5,
                   5
                   );

                var warmup4 = new Training
                    (
                    "Before cardio training",
                    types[2],
                    false,
                    warmupExercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(15, 5),
                    0.75,
                    0.25,
                    5
                    );

                var warmup5 = new Training
                   (
                   "Universal warm-up",
                   types[2],
                   false,
                   warmupExercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(20, 5),
                   0.1,
                   0.25,
                   3
                   );

                var warmup6 = new Training
                    (
                   "Try me",
                   types[2],
                   true,
                   warmupExercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(25, 5),
                   1.25,
                   0.25,
                   3
                   );
                _storage.AddTraining(warmup1);
                _storage.AddTraining(warmup2);
                _storage.AddTraining(warmup3);
                _storage.AddTraining(warmup4);
                _storage.AddTraining(warmup5);
                _storage.AddTraining(warmup6);
            }
            if (type == "cardio")
            {
                var cardio1 = new Training
                    (
                    "Full body HIIT",
                    types[0],
                    null,
                    cardioExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(0, 3),
                    1,
                    0.25,
                    3
                    );

                var cardio2 = new Training
                    (
                    "Burn calories HIIT",
                    types[0],
                    null,
                    cardioExcercises.Where(e => easyExercises.Contains(e)).ToList().GetRange(5, 5),
                    0.75,
                    0.15,
                    3
                    );

                var cardio3 = new Training
                    (
                    "Best full body burn",
                    types[0],
                    false,
                    cardioExcercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(0, 5),
                    1.5,
                    0.5,
                    4
                    );

                var cardio4 = new Training
                    (
                    "Total burn",
                    types[0],
                    false,
                    warmupExercises.Where(e => middleExercises.Contains(e)).ToList().GetRange(5, 5),
                    2,
                    0.5,
                    4
                    );

                var cardio5 = new Training
                    (
                    "Intense full body",
                    types[0],
                    true,
                    cardioExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(0, 5),
                    3,
                    0.5,
                    5
                    );

                //var cardio6 = new Training
                //    (
                //    "Get shredded",
                //    types[0],
                //    true,
                //    cardioExcercises.Where(e => hardExercises.Contains(e)).ToList().GetRange(5, 5),
                //    3,
                //    0.5,
                //    5
                //    );

                _storage.AddTraining(cardio1);
                _storage.AddTraining(cardio2);
               _storage.AddTraining(cardio3);
                _storage.AddTraining(cardio4);
                _storage.AddTraining(cardio5);
               // _storage.AddTraining(cardio6);
            }


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

    