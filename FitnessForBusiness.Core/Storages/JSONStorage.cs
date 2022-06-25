using FitnessForBusiness.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Storages
{
    public class JSONStorage : IStorage
    {
        readonly Repository<User> _users;
        readonly Repository<Training> _trainings;
        readonly Repository<Excercise> _excercises;
        private const string filePath1 = "../../../FitnessForBusiness.Core/Data/users.json";
        private const string filePath2 = "../../../FitnessForBusiness.Core/Data/trainings.json";
        private const string filepath3 = "../../../FitnessForBusiness.Core/Data/fitness_exercises.json";
        public JSONStorage()
        {
            _users = new Repository<User>(filePath1);
            _trainings = new Repository<Training>(filePath2);
            _excercises = new Repository<Excercise>(filepath3);
        }


        public List<Excercise> GetExcercises => _excercises.GetCollection;
        public List<User> GetUsers => _users.GetCollection;
        public List<Training> GetTrainings => _trainings.GetCollection;

        public void Save()
        {
            _users.Save();
            _trainings.Save();
        }

        public void Registration(User user)
        {
            _users.AddNewElement(user);
            Save();
        }

        public void AddTraining(Training training)
        {
            _trainings.AddNewElement(training);
            Save();
        }
    }
}
