﻿using Coolyeah_App.Models;
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
            FetchData();
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
        }

        private void DeleteItem(object parameter)
        {
            if (parameter is Sleep SleepToDelete)
            {
                _sqliteHelper.DeleteFood(SleepToDelete.id);
                MyDataCollection.Remove(SleepToDelete);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
