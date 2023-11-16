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

namespace Coolyeah_App.ViewModels
{
    class DietViewModel
    {
        public ICommand AddNewItemCommand { get; set; }

        public ObservableCollection<Food> MyDataCollection { get; set; }

        private DataBase _sqliteHelper;





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
            Food newFood = new Food { Notes = "New Food", Value = 10 };
            _sqliteHelper.InsertFood(newFood);

            MyDataCollection.Clear();
            FetchData();
        }

        private void FetchData()
        {
            var dbData = _sqliteHelper.ReadAllFood();

            foreach (var item in dbData)
            {
                MyDataCollection.Add(item);
            }
        }
    }
}
