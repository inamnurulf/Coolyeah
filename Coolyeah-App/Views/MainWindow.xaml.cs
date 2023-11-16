using Coolyeah_App.Views;
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
using Coolyeah_App.Models;
using Coolyeah_App.Helper;


namespace Coolyeah_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HomeWindow homeWindow = new HomeWindow();

        private DataBase _sqliteHelper;

        public MainWindow()
        {
            _sqliteHelper = new DataBase("\\db\\coolyeah.db");
            _sqliteHelper.CreateTableUser();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_sqliteHelper.HasUser())
            {
                MessageBox.Show("A user already exists. You can only input once.");
            }
            else
            {

                if (int.TryParse(txtAge.Text, out int age))
                {
                    // Access user details from the ViewModel
                    double.TryParse(txtWeight.Text, out double weight);
                    double.TryParse(txtHeight.Text, out double height);

                    var user = new User
                    {
                        Name = txtName.Text,
                        Age = age,
                        Sex = (string)((ComboBoxItem)comboGender.SelectedItem)?.Content,
                        Weight = weight,
                        Height = height
                    };

                    _sqliteHelper.InsertUser(user);


                    
                }
                else
                {
                    MessageBox.Show("Please enter a valid age (numeric value).");
                }
            }
            homeWindow.Show();
            Close();
        }

    }
}
