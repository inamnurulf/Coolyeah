using Coolyeah_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Coolyeah_App.ViewModels
{
    class DietViewModel
    {
        public ICommand AddNewItemCommand { get; set; }

        public ObservableCollection<Food> MyDataCollection { get; set; }


        public DietViewModel()
        {
            AddNewItemCommand = new RelayCommand(AddNewItem);
            MyDataCollection = new ObservableCollection<Food>();
            FetchData();
        }
        private void FetchData()
        {
            var apiData = FetchDataFromApi();

            foreach (var item in apiData)
            {
                MyDataCollection.Add(item);
            }
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
            MessageBox.Show("Adding new item");
        }
    }
}
