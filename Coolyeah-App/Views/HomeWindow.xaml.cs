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
using System.Windows.Shapes;

namespace Coolyeah_App.Views
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton1.Background = new SolidColorBrush(Colors.Transparent);
            RadioButton2.Background = new SolidColorBrush(Colors.Transparent);
            RadioButton3.Background = new SolidColorBrush(Colors.Transparent);

            RadioButton radioButton = (RadioButton)sender;
            radioButton.Background = new SolidColorBrush(Color.FromRgb(50, 50, 150));
        }
    }
}
