using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessForBusiness.Core.Core;
using FitnessForBusiness.Core.Models;

namespace FitnessForBusiness.Design.MVVM.ViewModel
{
    internal class CurrentViewModel : ObservableObject
    {
        public RelayCommand ProfileViewCommand { get; set; }

        public ProfileViewModel ProfileVM { get; set; }

        public RelayCommand AllWorkoutsViewCommand { get; set; }

        public AllWorkoutsViewModel AllWorkoutsVM { get; set; }

        public RelayCommand CompletedWorkoutsCommand { get; set; }

        public CompletedWorkoutsViewModel CompletedWorkoutsVM { get; set; }

        private object _currentView;

        public User _user;
        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public CurrentViewModel(User user)
        {
            _user = user;
            ProfileVM = new ProfileViewModel(_user);
            AllWorkoutsVM = new AllWorkoutsViewModel();
            CompletedWorkoutsVM = new CompletedWorkoutsViewModel();

            CurrentView = AllWorkoutsVM;

            ProfileViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProfileVM;
            });

            AllWorkoutsViewCommand = new RelayCommand(o =>
            {
                CurrentView = AllWorkoutsVM;
            });

            CompletedWorkoutsCommand = new RelayCommand(o =>
            {
                CurrentView = CompletedWorkoutsVM;
            });
        }
    }
}
