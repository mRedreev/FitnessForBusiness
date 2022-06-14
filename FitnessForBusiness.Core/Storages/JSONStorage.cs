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

        public JSONStorage()
        {
            _users = new Repository<User>("user.json");
            _trainings = new Repository<Training>("training.json");
        }


        public List<User> GetUsers => _users.GetCollection;

        public List<Training> GetTrainings => _trainings.GetCollection;

        public void Save()
        {
            _users.Save();
            _trainings.Save();
        }
    }
}
