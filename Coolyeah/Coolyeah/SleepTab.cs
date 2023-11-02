﻿using System;
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
    public partial class SleepTab : Form
    {
        public SleepTab()
        {
            InitializeComponent();
        }

        private void SleepTab_Load(object sender, EventArgs e)
        {

        }

        private void BtnDrinkInSleep_Click(object sender, EventArgs e)
        {
            DrinkTab toDrink = new DrinkTab();
            toDrink.Show();
            this.Hide();
        }

        private void BtnDietInSleep_Click(object sender, EventArgs e)
        {
            DietTab toDiet = new DietTab();
            toDiet.Show();
            this.Hide();
        }

        private void HomeInSleep_Click(object sender, EventArgs e)
        {
            Homepage toHome = new Homepage();
            toHome.Show();
            this.Hide();
        }

        private void BtnSleepInSleep_Click(object sender, EventArgs e)
        {

        }

        private void BtnActivityInSleep_Click(object sender, EventArgs e)
        {
            ActivityTab toActivity = new ActivityTab();
            toActivity.Show();
            this.Hide();
        }
    }
}