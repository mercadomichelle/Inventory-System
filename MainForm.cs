﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Inventory_System
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        { 
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void customerButton2_Click(object sender, EventArgs e)
        {
            openChildForm(new MedicineForm());
        }

        private void btnVita_Click(object sender, EventArgs e)
        {
            openChildForm(new VitaminsForm());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            openChildForm(new StocksOnHandForm());
        }

        private void btnReco_Click(object sender, EventArgs e)
        {
            openChildForm(new RecommendationForm());
        }

        private void customerButton1_Click(object sender, EventArgs e)
        {
            openChildForm(new UserForm());
        }

        private int imageNumber = 1;

        private void LoadNextImage()
        {
            if (imageNumber == 6)
            {
                imageNumber = 1;
            }
            SlidePic.ImageLocation = string.Format(@"Images\{0}.png", imageNumber);
            imageNumber++;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }
    }
}
