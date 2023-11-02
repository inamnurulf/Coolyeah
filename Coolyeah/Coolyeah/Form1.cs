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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }

        private void HomeInHome_Click(object sender, EventArgs e)
        {

        }

        private void BtnDietInHome_Click(object sender, EventArgs e)
        {
            DietTab toDiet = new DietTab();
            toDiet.Show();
            this.Hide();
        }

        private void BtnDrinkInHome_Click(object sender, EventArgs e)
        {
            DrinkTab toDrink = new DrinkTab();
            toDrink.Show();
            this.Hide();
        }

        private void BtnSleepInHome_Click(object sender, EventArgs e)
        {
            SleepTab toSleep = new SleepTab();
            toSleep.Show();
            this.Hide();
        }

        private void BtnActivityInHome_Click(object sender, EventArgs e)
        {
            ActivityTab toActivity= new ActivityTab();
            toActivity.Show();
            this.Hide();
        }
    }
}
