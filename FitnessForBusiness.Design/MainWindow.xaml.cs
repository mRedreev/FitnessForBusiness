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
        }

        private void InitialUsers()
        {
            using (Context context = new Context()) //Создание подключения (локальной копии БД)
            {
                User user1 = new User(
                    "Mikhail",
                    "Redreev",
                   ".. / .. / Users /user1.jpg",
                    DateTime.Parse("30.09.2002"),
                    true,
                    true,
                    "MRedreev",
                    "Misha2002"
                    );
                context.Users.Add(user1);
                context.SaveChanges();
                MessageBox.Show("Saved user1");
            }
        }

        private void Initial
    }
}
