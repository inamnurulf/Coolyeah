using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coolyeah_App.ViewModels
{
    class HomeViewModel : ObservableObject
    {
        public RelayCommand HomePageViewCommand { get; set; }
        public RelayCommand DrinkViewCommand { get; set; }
        public RelayCommand SleepViewCommand { get; set; }
        public RelayCommand DietViewCommand { get; set; }
        public RelayCommand ActivityViewCommand { get; set; }

        public HomePageViewModel HomeVM { get; set; }
        public DrinkViewModel DrinkVM { get; set; }
        public SleepViewModel SleepVM { get; set; }
        public DietViewModel DietVM { get; set; }
        public ActivityViewModel ActivityVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            HomeVM = new HomePageViewModel();
            DrinkVM = new DrinkViewModel();
            SleepVM = new SleepViewModel();
            DietVM = new DietViewModel();
            ActivityVM = new ActivityViewModel();

            CurrentView = HomeVM;

            HomePageViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            DrinkViewCommand = new RelayCommand(o =>
            {
                CurrentView = DrinkVM;
            });

            SleepViewCommand = new RelayCommand(o =>
            {
                CurrentView = SleepVM;
            });

            DietViewCommand = new RelayCommand(o =>
            {
                CurrentView = DietVM;
            });
            ActivityViewCommand = new RelayCommand(o =>
            {
                CurrentView = ActivityVM;
            });
        }
    }
}
