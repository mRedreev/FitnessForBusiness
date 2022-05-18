using FitnessForBusiness.Core;
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
            //InitialUsers();
            //InitialTrainings();
        }

       /* private void InitialUsers()
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
                {
                    Name = "Air bike",
                    VideoSource = "http://d205bpvrqc9yn1.cloudfront.net/0003.gif",
                    Level = null,
                    BodyParts = new List<string>() { "waist", "abs" },
                    Equipment = "mat",
                };

                Excercise excercise2 = new Excercise
                {
                    Name = "All fours squad stretch",
                    VideoSource = "http://d205bpvrqc9yn1.cloudfront.net/1512.gif",
                    Level = null,
                    BodyParts = new List<string>() { "quads" },
                    Equipment = "mat",
                };

                Excercise excercise3 = new Excercise
                {
                    Name = "ankle circles",
                    VideoSource = "http://d205bpvrqc9yn1.cloudfront.net/1368.gif",
                    Level = null,
                    BodyParts = new List<string>() { "calves" },
                    Equipment = "mat",
                };

                Excercise excercise4 = new Excercise
                {
                    Name = "astride jumps",
                    VideoSource = "http://d205bpvrqc9yn1.cloudfront.net/3220.gif",
                    Level = null,
                    BodyParts = new List<string>() { "cardiovascular system" },
                    Equipment = "mat",
                };

                Training training1 = new Training(
                    "Short warm-up",
                    "warm-up",
                    null,
                    new List<Excercise> { excercise1, excercise2, excercise3, excercise4 },
                    0.5,
                    0.25,
                    2,
                    ""
                    );
                context.Trainings.Add(training1);
                context.SaveChanges();
                MessageBox.Show("training1 saved");
            }
        }*/
    }
}
