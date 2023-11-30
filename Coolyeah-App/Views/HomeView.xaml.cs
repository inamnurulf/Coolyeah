using Coolyeah_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coolyeah_App.Views
{
    public partial class HomeView : UserControl
    {
        private HomePageViewModel _viewModel;

        public HomeView()
        {
            InitializeComponent();
            _viewModel = new HomePageViewModel();
            DataContext = _viewModel;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.FetchQuote();
        }
    }
}
