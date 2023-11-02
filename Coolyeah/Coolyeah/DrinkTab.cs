using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coolyeah
{
    public partial class DrinkTab : Form
    {
        public DrinkTab()
        {
            InitializeComponent();
        }

        private void BtnDrinkInDrink_Click(object sender, EventArgs e)
        {

        }

        private void BtnActivityInDrink_Click(object sender, EventArgs e)
        {
            ActivityTab toActivity = new ActivityTab();
            toActivity.Show();
            this.Hide();
        }

        private void BtnSleepInDrink_Click(object sender, EventArgs e)
        {
            SleepTab toSleep = new SleepTab();
            toSleep.Show();
            this.Hide();
        }

        private void HomeInDrink_Click(object sender, EventArgs e)
        {
            Homepage toHome = new Homepage();
            toHome.Show();
            this.Hide();
        }

        private void BtnDietInDrink_Click(object sender, EventArgs e)
        {
            DietTab toDiet = new DietTab();
            toDiet.Show();
            this.Hide();
        }

        private void BtnDrinkInHome_Click(object sender, EventArgs e)
        {

        }
    }
}
