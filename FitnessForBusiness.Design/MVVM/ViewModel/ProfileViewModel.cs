using FitnessForBusiness.Core.Models;
using FitnessForBusiness.Core.Storages;
using FitnessForBusiness.Design.MVVM.View;
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
        public ProfileViewModel(User user)
        {
            
            _user = user;
            var pofileView = new ProfileView(_user);
        }
    }
}
