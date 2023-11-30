using Coolyeah_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Coolyeah_App.Helper;
using System.IO;
using System.ComponentModel;

namespace Coolyeah_App.ViewModels
{
    class ActivityViewModel : INotifyPropertyChanged
    {
        public ICommand AddNewItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }


        public ObservableCollection<Activity> MyDataCollection { get; set; }

        private DataBase _sqliteHelper;

        private string _notesText;
        public string NotesText
        {
            get { return _notesText; }
            set
            {
                if (_notesText != value)
                {
                    _notesText = value;
                    OnPropertyChanged(nameof(NotesText));
                }
            }
        }

        private string _valueText;
        public string ValueText
        {
            get { return _valueText; }
            set
            {
                if (_valueText != value)
                {
                    _valueText = value;
                    OnPropertyChanged(nameof(ValueText));
                }
            }
        }

        public ActivityViewModel()
        {
            _sqliteHelper = new DataBase("\\db\\coolyeah.db");
            _sqliteHelper.CreateTableActivity(); 
            AddNewItemCommand = new RelayCommand(AddNewItem);
            DeleteItemCommand = new RelayCommand(DeleteItem);
            MyDataCollection = new ObservableCollection<Activity>();
            SetIdealValue();
            UpdateCurrentValue();
            FetchData();
        }

        private int _currentValue;

        public int CurrentValue
        {
            get { return _currentValue; }
            set
            {
                if (_currentValue != value)
                {
                    _currentValue = value;
                    OnPropertyChanged(nameof(CurrentValue));
                }
            }
        }

        private int _idealValue;

        public int IdealValue
        {
            get { return _idealValue; }
            set
            {
                if (_idealValue != value)
                {
                    _idealValue = value;
                    OnPropertyChanged(nameof(IdealValue));
                }
            }
        }

        private void SetIdealValue()
        {
            User user = _sqliteHelper.GetUser();
            if (user == null) { return; }
            if (user.Sex == "Male")
            {
                IdealValue = 8;
            }
            else
            {
                IdealValue = 8;
            }

        }

        private void UpdateCurrentValue()
        {
            CurrentValue = MyDataCollection.Sum(activy => activy.Value);
        }

        private void AddNewItem(object parameter)
        {

            if (int.TryParse(ValueText, out int value))
            {
                Activity newActivity = new Activity
                {
                    id = MyDataCollection.Count + 1,
                    Notes = NotesText,
                    Value = value
                };
                _sqliteHelper.InsertActivity(newActivity); 

                MyDataCollection.Clear();
                NotesText = string.Empty;
                ValueText = string.Empty;
                FetchData();
            }

            UpdateCurrentValue();
        }

        private void FetchData()
        {
            var dbData = _sqliteHelper.ReadAllActivity();

            foreach (var item in dbData)
            {
                MyDataCollection.Add(item);
            }
            UpdateCurrentValue();

        }
        private void DeleteItem(object parameter)
        {
            if (parameter is Activity ActivitToDelete)
            {
                _sqliteHelper.DeleteActivity(ActivitToDelete.id);
                MyDataCollection.Remove(ActivitToDelete);

                UpdateCurrentValue();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
