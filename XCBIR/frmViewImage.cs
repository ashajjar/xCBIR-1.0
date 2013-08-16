using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XCBIR.Classes;

namespace XCBIR
{
    public partial class frmViewImage : Form
    {
        private imageRecord ImageRecord;
        private imageProcessor ImgPro;
        private databaseController DBC;
        private string opr;
        private string ImgPath;
        private int ContrastVal = 0;
        private int BrightnessVal = 0;
        private bool bright_clicked = false;
        private bool contrast_clicked = false;
        const double ZoomOut = 0.90909090909090909090909090909091;
        const double ZoomIn = 1.1;

        public frmViewImage(string imagePath, imageRecord IR, databaseController DBC, string opr)
        {
            this.opr = opr;
            this.DBC = DBC;
            ImageRecord = IR;
            ContrastVal = 0;
            BrightnessVal = 0;
            bright_clicked = false;
            contrast_clicked = false;
            ImgPro = new imageProcessor(imagePath);
            ImgPath = imagePath;
            InitializeComponent();
        }

        private void rbnFrmViewImage_Click(object sender, EventArgs e)
        {

        }

        private void frmViewImage_Load(object sender, EventArgs e)
        {
            picViewImage.Load(ImgPath);
            picViewImage.Height = picViewImage.Image.Height;
            picViewImage.Width = picViewImage.Image.Width;
            //picViewImage.Refresh();
            //int px, py;
            //int pw = picViewImage.Width;
            //int ph = picViewImage.Height;

            //px = (this.Width / 2) - (pw / 2);
            //py = (this.Height / 2) - (ph / 2);
            //picViewImage.Location = new Point(px, py);
        }

        private void tlStrpBright_Click(object sender, EventArgs e)
        {
            lblBCValue.Visible = !lblBCValue.Visible;
            trkBar.Visible = !trkBar.Visible;
            trkBar.Value = BrightnessVal;
            trkBar.Left = 8;
            lblBCValue.Left = 8;
            bright_clicked = true;
            contrast_clicked = false;
            trackBarHider.Enabled = trkBar.Visible;
            //trkBar.Maximum = 100;
            //trkBar.Minimum = -100;
            //trkBar.Value = 0;
            //trkBar.SmallChange = 1;
            //trkBar.LargeChange = 5;
        }

        private void tlStrpContrast_Click(object sender, EventArgs e)
        {
            lblBCValue.Visible = !lblBCValue.Visible;
            trkBar.Visible = !trkBar.Visible;
            trkBar.Value = ContrastVal;
            trkBar.Left = 29;
            lblBCValue.Left = 29;
            bright_clicked = false;
            contrast_clicked = true;
            trackBarHider.Enabled = trkBar.Visible;
            //trkBar.Maximum = 1;
            //trkBar.Minimum = -1;
            //trkBar.Value = 0;
            //trkBar.SmallChange = 0.01;
            //trkBar.LargeChange = 0.05;
        }

        private void trkBar_Scroll(object sender, EventArgs e)
        {
            lblBCValue.Text = trkBar.Value.ToString();
            if (contrast_clicked)
            {
                ContrastVal = trkBar.Value;
                double beta = (double)ContrastVal / 100;
                ImgPro.EnhanceContrast(beta);
            }
            else if (bright_clicked)
            {
                BrightnessVal = trkBar.Value;
                double beta = (double)BrightnessVal / 100;
                ImgPro.BrightenImage(beta);
            }
            picViewImage.ImageLocation = ImgPro.NewImagePath;
        }

        private void tlStrpUndo_Click(object sender, EventArgs e)
        {
            ImgPro.Undo();
            picViewImage.ImageLocation = ImgPro.NewImagePath;
        }

        private void tlStrpRedo_Click(object sender, EventArgs e)
        {
            ImgPro.Redo();
            picViewImage.ImageLocation = ImgPro.NewImagePath;
        }

        private void tlStrpReset_Click(object sender, EventArgs e)
        {
            ImgPro.ResetImage();
            picViewImage.Load(ImgPro.OriginalImagePath);
            picViewImage.Height = picViewImage.Image.Height;
            picViewImage.Width = picViewImage.Image.Width;
        }

        private void picViewImage_Paint(object sender, PaintEventArgs e)
        {
            int px, py;

            //picViewImage.Width = picViewImage.Image.Width;
            //picViewImage.Height = picViewImage.Image.Height;

            int pw = picViewImage.Width;
            int ph = picViewImage.Height;

            px = (this.Width / 2) - (pw / 2);
            py = (this.Height / 2) - (ph / 2);
            picViewImage.Location = new Point(px, py);
        }

        private void trkBarZoom_Scroll(object sender, EventArgs e)
        {
            picViewImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picViewImage.Width = picViewImage.Width * trkBarZoom.Value / 10;
            picViewImage.Height = picViewImage.Height * trkBarZoom.Value / 10;
        }

        private void rbnBtnZoomIN_Click(object sender, EventArgs e)
        {
            picViewImage.Width = (int)Math.Round(picViewImage.Width * 1.1);
            picViewImage.Height = (int)Math.Round(picViewImage.Height * 1.1);
        }

        private void rbnBtnZoomOUT_Click(object sender, EventArgs e)
        {
            picViewImage.Width = (int)Math.Round(picViewImage.Width * ZoomOut);
            picViewImage.Height = (int)Math.Round(picViewImage.Height * ZoomOut);
        }

        private void trkBar_MouseEnter(object sender, EventArgs e)
        {
            trackBarHider.Enabled = false;
        }

        private void trkBar_MouseLeave(object sender, EventArgs e)
        {
            trackBarHider.Enabled = true;
        }

        private void trackBarHider_Tick(object sender, EventArgs e)
        {
            trkBar.Visible = false;
            lblBCValue.Visible = false;
            trackBarHider.Enabled = false;
        }

        private void tlStrpCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tlStrpSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (opr.ToLower() == "insert")
                {
                    //picViewImage.Image.Save(ImgPro.OriginalImagePath);
                    System.IO.File.Copy(ImgPro.NewImagePath, ImgPro.OriginalImagePath, true);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else //If operation is modify image . . .
                {

                    featureExtractor fe = new featureExtractor(ImgPro.NewImagePath);
                    List<Feature> fv = new List<Feature>();
                    fv = fe.AllFeatures();
                    //Get all image information :
                    string[] info = fe.GetImageInfo().Split('\n');
                    for (int i = 0; i < info.Length; i++)
                    {
                        info[i] = info[i].Trim();
                    }
                    //Get image size and Dimensions
                    string size = "", h = "", w = "";
                    for (int i = 0; i < info.Length; i++)
                    {
                        if (info[i].StartsWith("FileSize"))
                        {
                            size = info[i];
                        }
                        else if (info[i].StartsWith("Width"))
                        {
                            w = info[i];
                        }
                        else if (info[i].StartsWith("Height"))
                        {
                            h = info[i];
                        }
                    }
                    info = new string[2];
                    info[0] = size.Split(':')[1].Trim();        //Image size . . .

                    info[1] = h.Split(':')[1].Trim() + "X"
                            + w.Split(':')[1].Trim();           //Image Dimensions . . .

                    ImageRecord.ImageInfo = info;
                    ImageRecord.FeatureVector = fv;
                    // . . . and modify that record in the opened database
                    if (!ImageRecord.ModifyImage(DBC))//If insertion is not done
                    {
                        throw new Exception("Failed to save changes to image record with ID: " + ImageRecord.ID + "!");//Throw an exception
                    }
                    //picViewImage.Image.Save(ImgPro.OriginalImagePath);
                    System.IO.File.Copy(ImgPro.NewImagePath, ImgPro.OriginalImagePath, true);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Changes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}