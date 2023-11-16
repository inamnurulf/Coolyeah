using Coolyeah_App.Helper;
using Coolyeah_App.Models;
using Coolyeah_App.Views;
using System.Windows;
using System.Windows.Controls;


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
            if (_sqliteHelper.HasUser())
            {
                homeWindow.Show();
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(txtAge.Text, out int age))
            {
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

                homeWindow.Show();
                Close();

            }
            else
            {
                MessageBox.Show("Please enter a valid age (numeric value).");
            }
        }

    }
}
