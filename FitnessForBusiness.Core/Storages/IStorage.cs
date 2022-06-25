using FitnessForBusiness.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Storages
{
    public interface IStorage
    {
        void Save();

        void AddTraining(Training training);

        void Registration(User user);
        List<User> GetUsers { get; }
        List<Excercise> GetExcercises { get; }
        List<Training> GetTrainings { get; }
    }
}
