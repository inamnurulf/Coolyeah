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
    public partial class ActivityTab : Form
    {
        public ActivityTab()
        {
            InitializeComponent();
        }

        private void ActivityTab_Load(object sender, EventArgs e)
        {

        }

        private void HomeInActivity_Click(object sender, EventArgs e)
        {
            Homepage toHome = new Homepage();
            toHome.Show();
            this.Hide();
        }

        private void BtnDrinkInActivity_Click(object sender, EventArgs e)
        {
            DrinkTab toDrink = new DrinkTab();
            toDrink.Show();
            this.Hide();
        }

        private void BtnDietInActivity_Click(object sender, EventArgs e)
        {
            DietTab toDiet = new DietTab();
            toDiet.Show();
            this.Hide();
        }

        private void BtnSleepInActivity_Click(object sender, EventArgs e)
        {
            SleepTab toSleep = new SleepTab();
            toSleep.Show();
            this.Hide();
        }

        private void BtnActivityInActivity_Click(object sender, EventArgs e)
        {
            
        }
    }
}
