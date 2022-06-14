using FitnessForBusiness.Core;
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
           // InitialTrainings();
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

        private void InitialTrainings()
        {
            using (Context context = new Context()) //Создание подключения (локальной копии БД)
            {
                Excercise excercise1 = new Excercise
                (
                    "Air bike",
                    "http://d205bpvrqc9yn1.cloudfront.net/0003.gif",
                    null,
                    new List<string>() { "waist", "abs" },
                    "mat"
                );

                Excercise excercise2 = new Excercise
                (
                    "All fours squad stretch",
                    "http://d205bpvrqc9yn1.cloudfront.net/1512.gif",
                    null,
                    new List<string>() { "quads" },
                    "mat"
                );

                Excercise excercise3 = new Excercise
                (
                    "ankle circles",
                    "http://d205bpvrqc9yn1.cloudfront.net/1368.gif",
                    null,
                    new List<string>() { "calves" },
                    "mat"
                );

                Excercise excercise4 = new Excercise
                (
                    "astride jumps",
                    "http://d205bpvrqc9yn1.cloudfront.net/3220.gif",
                    null,
                    new List<string>() { "cardiovascular system" },
                    "mat"
                );

                Training training1 = new Training(
                    "Short warm-up",
                    "warm-up",
                    null,
                    new List<Excercise> { excercise1, excercise2, excercise3, excercise4 },
                    0.5,
                    0.25,
                    2
                    );
                context.Trainings.Add(training1);
                context.SaveChanges();
                MessageBox.Show("training1 saved");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
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
        
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}

    