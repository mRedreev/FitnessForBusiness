using FitnessForBusiness.Core.Models;
using FitnessForBusiness.Core.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Design.MVVM.ViewModel
{
    internal class ProfileViewModel
    {
        IStorage _storage;
        User _user;
        public ProfileViewModel(IStorage storage, User user)
        {
            _storage = storage;
            _user = user;
        }
    }
}
