using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Models
{
    public class User
    {
        public int Id { get; set;}

        public string Name { get; set; }

        public string Surname { get; set;}

        public string ImageSource { get; set; }

        public int Age { get; set;}

        public bool? Level { get; set;}

        public bool? Goal { get; set;}

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime Born { get; set; }
        public List<Training> CompletedTrainings { get; set; }

        public string ShowGoal()
        {
            return functions.NameOfGoal(Goal);
        }

        public int CountAge(DateTime born)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - born.Year;
            if (born > now.AddYears(-age)) age--;
            return age;
        }

        public User(string name, string surname, string imageSource, DateTime born, bool? level, bool? goal, string login, string password)
        {
            Name = name;
            Surname = surname;
            ImageSource = imageSource;
            Level = level;
            Goal = goal;
            Login = login;
            Password = password;
            Age = CountAge(born);
            CompletedTrainings = new List<Training>();
            Born = born;
        }

        public User()
        {

        }
    }

    
}
