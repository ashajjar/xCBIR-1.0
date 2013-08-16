using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FeatureExtractor;
using ImageManipulation;

namespace XCBIR
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmQuickView_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Loading moduls . . .";
            proBarLoad.Value = 10;
            //tmrLoad.Enabled = true;
        }

        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            tmrLoad.Enabled = false;
        }

        private void frmSplash_Activated(object sender, EventArgs e)
        {
            this.Refresh();
            proBarLoad.Value = 60;
            lblStatus.Text = "Features Extractor Module . . .";
            this.Refresh();
            FeatureExtractorclass FEC = new FeatureExtractorclass();

            proBarLoad.Value = 90;
            lblStatus.Text = "Image Processing Tools . . .";
            this.Refresh();
            ImageManipulationclass IMC = new ImageManipulationclass();
            proBarLoad.Value = 100;
            frmMain mainScreen = new frmMain();
            mainScreen.Show();
            this.Hide();
        }
    }
}