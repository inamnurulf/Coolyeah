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
    class DietViewModel : INotifyPropertyChanged
    {
        public ICommand AddNewItemCommand { get; set; }

        public ObservableCollection<Food> MyDataCollection { get; set; }

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



        public DietViewModel()
        {

            _sqliteHelper = new DataBase("\\db\\coolyeah.db");
            _sqliteHelper.CreateTable(); 
            AddNewItemCommand = new RelayCommand(AddNewItem);
            MyDataCollection = new ObservableCollection<Food>();
            FetchData();

        }

        private IEnumerable<Food> FetchDataFromApi()
        {
            return new List<Food>
            {
                new Food { id = 1, Notes = "Value1", Value=2 },
                new Food { id = 2, Notes = "Value2", Value=5 },
                new Food { id = 3, Notes = "Value3", Value=4 },
                new Food { id = 4, Notes = "Value4", Value=2 },
            };
        }
        private void AddNewItem(object parameter)
        {
            if (int.TryParse(ValueText, out int value))
            {
                Food newFood = new Food
                {
                    id = MyDataCollection.Count + 1, // You might want to use a more robust method to generate IDs
                    Notes = NotesText,
                    Value = value
                };
                _sqliteHelper.InsertFood(newFood);

                MyDataCollection.Clear();
                NotesText = string.Empty;
                ValueText = string.Empty;
                FetchData();

            }

        }

        private void FetchData()
        {
            var dbData = _sqliteHelper.ReadAllFood();

            foreach (var item in dbData)
            {
                MyDataCollection.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
