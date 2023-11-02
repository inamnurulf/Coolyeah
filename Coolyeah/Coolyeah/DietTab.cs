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
    public partial class DietTab : Form
    {
        public DietTab()
        {
            InitializeComponent();
        }

        private void DietTab_Load(object sender, EventArgs e)
        {

        }

        private void BtnDrinkInDiet_Click(object sender, EventArgs e)
        {
            DrinkTab toDrink = new DrinkTab();
            toDrink.Show();
            this.Hide();
        }

        private void BtnDietInDiet_Click(object sender, EventArgs e)
        {

        }

        private void HomeInDiet_Click(object sender, EventArgs e)
        {
            Homepage toHome = new Homepage();
            toHome.Show();
            this.Hide();
        }

        private void BtnSleepInDiet_Click(object sender, EventArgs e)
        {
            SleepTab toSleep = new SleepTab();
            toSleep.Show();
            this.Hide();
        }

        private void BtnActivityInDiet_Click(object sender, EventArgs e)
        {
            ActivityTab toActivity = new ActivityTab();
            toActivity.Show();
            this.Hide();
        }
    }
}
