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
    class SleepViewModel : INotifyPropertyChanged
    {
        public ICommand AddNewItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }


        public ObservableCollection<Sleep> MyDataCollection { get; set; }

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

        public SleepViewModel()
        {
            _sqliteHelper = new DataBase("\\db\\coolyeah.db");
            _sqliteHelper.CreateTableSleep();
            AddNewItemCommand = new RelayCommand(AddNewItem);
            DeleteItemCommand = new RelayCommand(DeleteItem);
            MyDataCollection = new ObservableCollection<Sleep>();
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
            CurrentValue = MyDataCollection.Sum(sleep => sleep.Value);
        }

        private void AddNewItem(object parameter)
        {
            if (int.TryParse(ValueText, out int value))
            {
                Sleep newSleep = new Sleep
                {
                    id = MyDataCollection.Count + 1,
                    Notes = NotesText,
                    Value = value
                };
                _sqliteHelper.InsertSleep(newSleep);

                MyDataCollection.Clear();
                NotesText = string.Empty;
                ValueText = string.Empty;
                FetchData();
            }
        }

        private void FetchData()
        {
            var dbData = _sqliteHelper.ReadAllSleep();

            foreach (var item in dbData)
            {
                MyDataCollection.Add(item);
            }

            UpdateCurrentValue();
        }

        private void DeleteItem(object parameter)
        {
            MessageBox.Show("");
            if (parameter is Sleep SleepToDelete)
            {
                _sqliteHelper.DeleteSleep(SleepToDelete.id);
                MyDataCollection.Remove(SleepToDelete);
                UpdateCurrentValue();

            }
;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
