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
        public ICommand DeleteItemCommand { get; set; }

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
            _sqliteHelper.CreateTableFood(); 
            AddNewItemCommand = new RelayCommand(AddNewItem);
            DeleteItemCommand = new RelayCommand(DeleteItem);
            MyDataCollection = new ObservableCollection<Food>();
            FetchData();

        }

        private void AddNewItem(object parameter)
        {
            if (int.TryParse(ValueText, out int value))
            {
                Food newFood = new Food
                {
                    id = MyDataCollection.Count + 1, 
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

        private void DeleteItem(object parameter)
        {
            if (parameter is Food foodToDelete)
            {
                _sqliteHelper.DeleteFood(foodToDelete.id);
                MyDataCollection.Remove(foodToDelete);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
