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

        List<User> GetUsers { get; }

        List<Training> GetTrainings { get; }
    }
}
