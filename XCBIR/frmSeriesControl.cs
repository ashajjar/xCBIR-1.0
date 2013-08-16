using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XCBIR.Classes;
using PureComponents.EntrySet.Lists;

namespace XCBIR
{
    public partial class frmSeriesControl : Form
    {
        static System.Drawing.Image x;
        private string opr;
        private databaseController DBC;
        private imageRecord ImageRecord;
        private featureExtractor fe;
        private List<Feature> fv;
        private systemController SC;
        private Series SeriesRecord;

        #region Modification Flags
        private bool allowPatiantChange = false;
        private bool pat_changed = false;
        private bool images_changed = false;
        private bool cats_changed = false;
        private bool notes_changed = false;
        #endregion

        public frmSeriesControl(databaseController dbc,systemController sc, string opr)
        {
            this.opr = opr;
            this.DBC = dbc;
            this.SC = sc;
            InitializeComponent();
        }

        private void rbnBtnNotes_Click(object sender, EventArgs e)
        {
            if (rbnBtnNotes.Tag.ToString() == "N")
            {
                x = rbnBtnTemp.Image;
                rbnBtnTemp.Image = rbnBtnNotes.Image;
                rbnBtnNotes.Image = x;
                this.Height = 670;
                rbnBtnNotes.Tag = "Y";
                rbnTxtNotes.Visible = true;
                rbnTxtNotes.Location = new Point(11, 562);
            }
            else
            {
                rbnTxtNotes.Location = new Point(11, 493);
                rbnTxtNotes.Visible = false;
                this.Height = 610;
                rbnBtnNotes.Tag = "N";
                x = rbnBtnTemp.Image;
                rbnBtnTemp.Image = rbnBtnNotes.Image;
                rbnBtnNotes.Image = x;
            }
        }

        private void frmSeriesControl_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[Opr]", opr);
            rbnFrmSerControl.Text = rbnFrmSerControl.Text.Replace("[Opr]", opr);
            rbnBtnDone.Text = rbnBtnDone.Text.Replace("[Opr]", opr);

            if (opr.ToLower() == "delete")
            {
                rbnCboSeriesID.Visible = true;
                rbnBtnNotes.Visible = false;
                rbnBtnAddImage.Visible = false;
                rbnBtnRemoveImage.Visible = false;
                rbnBtnDelAll.Visible = false;
                rbnBtnManipulate.Visible = false;
                mListCats.ShowCheck = false;
                rbnBtnNotes_Click(sender, e);
            }

            if (opr.ToLower() == "insert")
            {
                rbnTxtSeriesID.Text = getLastID().ToString();
            }

            if (opr.ToLower() == "modify")
            {
                rbnCboSeriesID.Visible = true;
                rbnBtnNotes.Visible = false;
                rbnBtnAddImage.Visible = false;
                rbnBtnRemoveImage.Visible = false;
                rbnBtnDelAll.Visible = false;
                rbnBtnManipulate.Visible = false;
            }
            picLstSerImage.Items.Clear();
            rbnCboPatiant.Items.Clear();
            mListCats.Items.Clear();
            fillPatList();
            fillCatList();
            if (mListCats.Items.Count < 1)
            {
                MessageBox.Show("There are no categories in the database .\nPlease insert one categoy at least !",
                    "No Categories in The Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
                this.Close();
            }
            picQView.ImageLocation = "";
        }

        private void picLstSerImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (picLstSerImage.SelectedIndex < 0)
                {
                    return;
                }
                if (picLstSerImage.SelectedItem == null)//If no image is selected
                {
                    return;
                }

                if (picLstSerImage.Items[picLstSerImage.SelectedIndex].Text.ToLower().Contains("removed"))
                {
                    //If the image is already removed then undo button will be visible and remove button will be disabled
                    rbnBtnUnremove.Visible = true;
                    rbnBtnRemoveImage.Enabled = false;
                }
                else
                {
                    //If the image is not removed then undo button will be invisible and remove button will be enabled
                    rbnBtnUnremove.Visible = false;
                    rbnBtnRemoveImage.Enabled = true;
                }
                //Scale the image to fit on viewing board
                if ((picLstSerImage.SelectedItem.Image.Width > picQView.Width) ||
                    (picLstSerImage.SelectedItem.Image.Height > picQView.Height))
                {
                    picQView.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    picQView.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                
                picQView.Image = picLstSerImage.SelectedItem.Image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Quick View Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnBtnAddImage_Click(object sender, EventArgs e)
        {
            if (picLstSerImage.Items.Count > 98)
            {
                MessageBox.Show("The series can contain 99 images at most"
                                , "Adding Image Error"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Error);
                return;
            }
            OFD.FileName = "";
            OFD.InitialDirectory = "D:\\Brain Images";
            OFD.Title = "Open an image file";
            OFD.Filter = "JPEG Images (*.jpg)|*.jpg|Bitmap Images (*.bmp)|*.bmp";
            OFD.ShowDialog();

            Bitmap bmp;
            PictureListItem pItem;

            if (opr.ToLower() == "insert")      //Insertion
            {
                string fname = "";
                if (OFD.FileName != "")
                {
                    foreach (string fileName in OFD.FileNames)
                    {
                        bmp = new Bitmap(fileName);
                        fname = fileName.Substring(fileName.LastIndexOf('\\')).TrimStart('\\');
                        pItem = new PureComponents.EntrySet.Lists.PictureListItem(
                            fname, bmp, true, fileName);
                        picLstSerImage.Items.Add(pItem);
                    }
                }
            }
            else        //Modification
            {
                images_changed = true;
                string fname = "";
                if (OFD.FileName != "")
                {
                    foreach (string fileName in OFD.FileNames)
                    {
                        bmp = new Bitmap(fileName);
                        fname = fileName.Substring(fileName.LastIndexOf('\\')).TrimStart('\\');
                        pItem = new PureComponents.EntrySet.Lists.PictureListItem(
                            fname + " New", bmp, true, fileName);
                        ImageRecord = new imageRecord(
                            getUnusedImageID(int.Parse(rbnCboSeriesID.SelectedItem)).ToString(), null, fname, null);
                        pItem.Value = ImageRecord;
                        picLstSerImage.Items.Add(pItem);
                    }
                }
            }
        }

        private void rbnBtnRemoveImage_Click(object sender, EventArgs e)
        {
            if (picLstSerImage.SelectedItem == null)
            {
                return;
            }
            else
            {
                if (opr.ToLower() == "insert")      //Insertion
                {
                    picLstSerImage.Items.RemoveAt(picLstSerImage.SelectedIndex);
                }
                else        //Modification
                {
                    images_changed = true;
                    string status = picLstSerImage.Items[picLstSerImage.SelectedIndex].Text;
                    if (!status.ToLower().Contains("removed"))
                    {
                        if (status.ToLower().Contains("new"))
                        {
                            picLstSerImage.Items[picLstSerImage.SelectedIndex].Text =
                                picLstSerImage.Items[picLstSerImage.SelectedIndex].Text.ToLower().Replace(
                                "new", "Removed New");
                            picLstSerImage_SelectedIndexChanged(sender, e);
                        }
                        else        //i.e. is NULL in other words it is Old
                        {
                            picLstSerImage.Items[picLstSerImage.SelectedIndex].Text += " Removed";
                            picLstSerImage_SelectedIndexChanged(sender, e);
                        }
                    }
                }
            }
        }

        private void rbnBtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void rbnBtnDone_Click(object sender, EventArgs e)
        {
            try
            {
                #region Insert Series
                if (opr.ToUpper() == "INSERT")
                {
                    //Check if the series information are filled well . . .
                    if ((rbnCboPatiant.SelectedItem != "Select Patiant") &&
                        (picLstSerImage.Items.Count > 0) && (rbnCboPatiant.SelectedItem != null))
                    {
                        //Preparing the progress bar . . .
                        int xx = picLstSerImage.Items.Count;
                        xx = 100 / xx;
                        proBarOpr.Visible = true;
                        proBarOpr.BringToFront();
                        proBarOpr.Value = 0;

                        //Create the physical path where the image and the series is contained 
                        int sid = int.Parse(rbnTxtSeriesID.Text);
                        string serFolder = SC.SettingsList[0].TrimEnd('\\') + "\\" + sid.ToString();
                        Directory.CreateDirectory(serFolder);
                        sid = sid * 100;
                        int imgID = 0;
                        //Extract image features for each image in the series :
                        foreach (PictureListItem P in picLstSerImage.Items)
                        {
                            Application.DoEvents();
                            fe = new featureExtractor(P.Tag.ToString());
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

                            imgID++;                                    //Image ID in the series . . .
                            int ID = sid + imgID;                       //Image ID in the database . . .
                            //Create image record . . . 
                            ImageRecord = new imageRecord(ID.ToString(), info, P.Text, fv);
                            // . . . and insert that record in the opened database
                            if (!ImageRecord.InsertImage(DBC))//If insertion is not done
                            {
                                throw new Exception("Failed to insert the image record with ID: " + ID.ToString() + "!");//Throw an exception
                            }
                            //Copy image file from its location to where each image in the database is stored
                            File.Copy(P.Tag.ToString(), serFolder + "\\" + P.Text, true);
                            Application.DoEvents();
                            proBarOpr.Value += xx;
                        }
                        sid = sid / 100;
                        //Determine series categories . . .
                        List<category> catList = new List<category>();
                        for (int i = 0;
                            i < mListCats.Items.Count; i++)
                        {
                            if (mListCats.Items[i].CheckState == CheckState.Checked)
                            {
                                catList.Add(new category(mListCats.Items[i].Description, null, null));
                            }
                        }
                        //Create series record . . .
                        SeriesRecord = new Series(sid.ToString()
                                                , rbnCboPatiant.SelectedItem.Split('\t')[0]
                                                , sid.ToString()
                                                , this.rbnTxtNotes.Text, catList);
                        //Try to insert the series . . .
                        if (!SeriesRecord.InsertSeries(DBC))    //In insertion is not done
                        {
                            throw new Exception("Failed to insert this series !");  //Throw an exception
                        }
                        proBarOpr.Value = 100;
                        proBarOpr.SendToBack();
                        proBarOpr.Visible = false;
                        this.DialogResult = DialogResult.OK;
                        this.Close();//Close when done
                    }
                    else
                    {
                        throw new Exception("Please fill all the fields !");
                    }
                }
                #endregion
                #region Modify Series
                else if (opr.ToUpper() == "MODIFY")
                {
                    //Check if the fields are filled well . . .
                    if ((rbnCboPatiant.SelectedItem != "Select Patiant") &&
                        (rbnCboSeriesID.SelectedItem != "Select Series"))
                    {
                        if (!(pat_changed || cats_changed
                            || images_changed || notes_changed))
                        {
                            this.DialogResult = DialogResult.None;
                            MessageBox.Show("No change done to this series !",
                                            "Closing",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            this.Close();
                        }
                        //Preparing the progress bar . . .
                        int xx = picLstSerImage.Items.Count;
                        xx = 100 / xx;
                        proBarOpr.Visible = true;
                        proBarOpr.BringToFront();
                        proBarOpr.Value = 0;

                        //Get the physical path where the image and the series is contained 
                        int sid = int.Parse(rbnCboSeriesID.SelectedItem);
                        string serFolder = SC.SettingsList[0].TrimEnd('\\') + "\\" + sid.ToString();
                        sid = sid * 100;
                        int imgID = 0;

                        //Extract image features for each changed or new image in the series :
                        foreach (PictureListItem P in picLstSerImage.Items)
                        {
                            Application.DoEvents();
                            string txt = P.Text.ToLower();
                            #region If image is removed
                            if (txt.Contains("removed"))
                            {
                                if (txt.Contains("new"))
                                {
                                    picLstSerImage.Items.Remove(P);
                                }
                                else
                                {
                                    ImageRecord = (imageRecord)P.Value;
                                    if (ImageRecord.DeleteImage(DBC))
                                    {
                                        P.Text = P.Text.ToLower();
                                        P.Text = P.Text.Replace(" removed", "");
                                        //File.Delete(serFolder + "\\" + P.Text);
                                    }
                                    else
                                    {
                                        throw new Exception("The image with ImageID : " + ImageRecord.ID + "\nCannot be deleted");
                                    }
                                }
                            }
                            #endregion
                            #region If image is new and not removed
                            else
                            {
                                if (!txt.Contains("removed") && (txt.Contains("new")))
                                {
                                    fe = new featureExtractor(P.Tag.ToString());
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

                                    imgID = getUnusedImageID(sid / 100);        //Image ID in the series . . .
                                    int ID = imgID+1;                       //Image ID in the database . . .
                                    //Create image record . . . 
                                    P.Text = P.Text.ToLower();
                                    P.Text = P.Text.Replace(" new", "");
                                    ImageRecord = new imageRecord(ID.ToString(), info, P.Text, fv);
                                    // . . . and insert that record in the opened database
                                    if (!ImageRecord.InsertImage(DBC))//If insertion is not done
                                    {
                                        throw new Exception("Failed to insert the new image record with ID: " + ID.ToString() + "!");//Throw an exception
                                    }
                                    //Copy image file from its location to where each image in the database is stored
                                    File.Copy(P.Tag.ToString(), serFolder + "\\" + P.Text, true);
                                }
                            }
                            #endregion
                            #region If image is not new nor removed but changed
                            if (txt.Contains("changed"))    //Manipulated (Edited) image 
                            {
                                //Do not do any thing to this image why?!!! . . . 
                                //simply because it was added by the manipulation process
                            }
                            #endregion
                            Application.DoEvents();
                            proBarOpr.Value += xx;
                        }
                        sid = sid / 100;
                        //Determine series categories . . .
                        List<category> catList = new List<category>();
                        for (int i = 0; i < mListCats.Items.Count; i++)
                        {
                            if (mListCats.Items[i].CheckState == CheckState.Checked)
                            {
                                catList.Add(new category(mListCats.Items[i].Description, null, null));
                            }
                        }
                        //Create series record . . .
                        SeriesRecord = new Series(sid.ToString()
                                                , rbnCboPatiant.SelectedItem.Split('\t')[0]
                                                , sid.ToString()
                                                , this.rbnTxtNotes.Text, catList);
                        //Try to update the series . . .
                        if (!SeriesRecord.UpdateSeries(DBC))    //If modification not done . . .
                        {
                            throw new Exception("Failed to update this series !");  //Throw an exception
                        }
                        proBarOpr.Value = 100;
                        proBarOpr.SendToBack();
                        proBarOpr.Visible = false;
                        this.DialogResult = DialogResult.OK;
                        this.Close();//Close when done
                    }
                    else
                    {
                        throw new Exception("Please fill all the fields !");
                    }
                }
                #endregion
                #region Delete Series
                else if (opr.ToUpper() == "DELETE")
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to delete this series and all its images ?", "Deletion", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        //Check if the fields are filled well . . .
                        if ((rbnCboPatiant.SelectedItem != "Select Patiant") &&
                            (rbnCboSeriesID.SelectedItem != "Select Series"))
                        {
                            //Preparing the progress bar . . .
                            int xx = picLstSerImage.Items.Count;
                            xx = 100 / xx;
                            proBarOpr.Visible = true;
                            proBarOpr.BringToFront();
                            proBarOpr.Value = 0;

                            //Get the physical path where the image and the series is contained 
                            int sid = int.Parse(rbnCboSeriesID.SelectedItem);
                            string serFolder = SC.SettingsList[0].TrimEnd('\\') + "\\" + sid.ToString();
                            sid = sid * 100;
                            int imgID = 0;

                            //Delete each image in the series :
                            foreach (PictureListItem P in picLstSerImage.Items)
                            {
                                Application.DoEvents();
                                string txt = P.Text.ToLower();
                                ImageRecord = (imageRecord)P.Value;
                                if (!P.Text.ToLower().Contains("new")) 
                                {
                                    if (!ImageRecord.DeleteImage(DBC))
                                    {
                                        throw new Exception("The image with ImageID : " + ImageRecord.ID + "\nCannot be deleted");
                                    }
                                }
                                Application.DoEvents();
                                proBarOpr.Value += xx;
                            }
                            sid = sid / 100;
                            //Determine series categories . . .
                            List<category> catList = new List<category>();
                            for (int i = 0; i < mListCats.Items.Count; i++)
                            {
                                catList.Add(new category(mListCats.Items[i].Description, null, null));
                            }
                            //Create series record . . .
                            SeriesRecord = new Series(sid.ToString()
                                                    , rbnCboPatiant.SelectedItem.Split('\t')[0]
                                                    , sid.ToString()
                                                    , this.rbnTxtNotes.Text, catList);
                            //Try to delete the series . . .
                            if (!SeriesRecord.DeleteSeries(DBC))    //If deletion not done . . .
                            {
                                throw new Exception("Failed to delete this series !");  //Throw an exception
                            }
                            proBarOpr.Value = 100;
                            proBarOpr.SendToBack();
                            proBarOpr.Visible = false;
                            this.DialogResult = DialogResult.OK;
                            this.Close();//Close when done
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                if (proBarOpr.Visible)
                {
                    proBarOpr.Visible = false;
                }
            }
        }

        private void rbnBtnDelAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (opr.ToLower() == "modify")          //Modification
                {
                    DialogResult dr = MessageBox.Show(
                                    "Are you sure you want to delete this series from the DATABASE ?"
                                    , "Warning"
                                    , MessageBoxButtons.YesNo
                                    , MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.Yes)
                    {
                        opr = "delete";
                        rbnBtnDone_Click(sender, e);
                    }
                }
                else        //Inserion
                {
                    DialogResult dr = MessageBox.Show(
                                    "Are you sure you want to clear all the images you have added up to now?"
                                    , "Warning"
                                    , MessageBoxButtons.YesNo
                                    , MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.Yes)
                    {
                        picLstSerImage.Items.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnCboPatiant_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((opr.ToLower() == "delete") || opr.ToLower() == "modify")
                {
                    if (!allowPatiantChange)
                    {
                        fillSeriesList(int.Parse(rbnCboPatiant.SelectedItem.Split('\t')[0]));
                    }
                    else
                    {
                        pat_changed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnCboSeriesID_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                int SID = int.Parse(rbnCboSeriesID.SelectedItem);
                if (DBC.IsConnected)
                {
                    //Firstly check all categories of this series with ID : SID
                    #region Check Categories
                    DBC.CommandText = "SELECT CatID FROM Series_Cats where SID= " + SID.ToString() + " ;";
                    DataSet ds = DBC.ExecuteQuery();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < mListCats.Items.Count; i++)
                        {
                            mListCats.Items[i].CheckState = CheckState.Unchecked;
                        }
                        for (int i = 0; i < mListCats.Items.Count; i++)
                        {
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                if (mListCats.Items[i].Description ==
                                    ds.Tables[0].Rows[j].ItemArray[0].ToString())
                                {
                                    mListCats.Items[i].CheckState = CheckState.Checked;
                                }
                            }
                        }
                    }
                    #endregion
                    //Secondly fill the images of this series with ID (SID) in the picture list :
                    #region Fill Picture List
                    //Bring all images in the series
                    DBC.CommandText = "SELECT ImageID,FileName FROM Image where FLOOR(ImageID/100)= " + SID.ToString() + " ;";
                    ds = DBC.ExecuteQuery();
                    //Bring the folder where images of series are copied
                    DBC.CommandText = "SELECT FolderPath FROM Series WHERE SID = " + SID.ToString() + " ;";
                    DataSet sds = DBC.ExecuteQuery();
                    //Images folder is . . . 
                    string imgFld = sds.Tables[0].Rows[0].ItemArray[0].ToString();

                    //Now put all images in the series in the picture list (picLstSerImage)
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string fname = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                        string ImageID = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                        imgFld = (imgFld.EndsWith("\\")) ? imgFld : imgFld + "\\";
                        imgFld = (imgFld.StartsWith("\\")) ? imgFld : "\\" + imgFld;

                        string imgpath = this.SC.SettingsList[0].TrimEnd('\\') + imgFld + fname;
                        Bitmap bmp = new Bitmap(imgpath);
                        PictureListItem pItem = new PictureListItem(fname, bmp, true, null);
                        ImageRecord = new imageRecord(ImageID, null, fname, null);
                        pItem.Value = ImageRecord;
                        pItem.Tag = imgpath;
                        picLstSerImage.Items.Add(pItem);
                    }
                    #endregion
                    //And finally fill the notes about the series
                    #region Fill Series Notes
                    DBC.CommandText = "SELECT Notes FROM Series_Notes where SID= " + SID.ToString() + " ;";
                    ds = DBC.ExecuteQuery();
                    if(ds.Tables[0].Rows.Count>0)
                        rbnTxtNotes.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    #endregion
                }
                else
                {
                    throw new Exception("The database is not connected");
                }
                #region Operations related to specific kind of data manipulation
                if (opr.ToLower() == "modify")          //Modification
                {
                    rbnBtnNotes.Visible = true;
                    rbnBtnAddImage.Visible = true;
                    rbnBtnRemoveImage.Visible = true;
                    rbnBtnDelAll.Visible = true;
                    rbnBtnManipulate.Visible = true;
                    allowPatiantChange = true;
                }
                else        //Deletion
                {
                    int[] to_delete = new int[mListCats.Items.Count];
                    int j = 0;
                    for (int i = 0; i < mListCats.Items.Count; i++)
                    {
                        if (mListCats.Items[i].CheckState == CheckState.Unchecked)
                        {
                            to_delete[j] = i;
                            j++;
                        }
                    }
                    for (int i = j; i >= 0; i--)
                    {
                        mListCats.Items.RemoveAt(i);
                    }
                    mListCats.ShowCheck = false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnBtnUnremove_Click(object sender, EventArgs e)
        {
            picLstSerImage.Items[picLstSerImage.SelectedIndex].Text =
                picLstSerImage.Items[picLstSerImage.SelectedIndex].Text.Replace(" Removed", "");
        }

        private void mListCats_ItemChecked(object sender, MultiList.CheckedItemEventArgs e)
        {
            try
            {
                if (opr.ToLower() == "modify")
                {
                    cats_changed = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void rbnTxtNotes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (opr.ToLower() == "modify")
                {
                    notes_changed = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void rbnBtnAddPat_Click(object sender, EventArgs e)
        {
            try
            {
                frmPatiantControl frmPat = new frmPatiantControl(DBC, "Insert");
                if (frmPat.ShowDialog() == DialogResult.OK)
                {
                    int sel = rbnCboPatiant.Items.Add(frmPat.insertedPatiant.ID +
                        '\t' + frmPat.insertedPatiant.Name);
                    rbnCboPatiant.SelectedIndex = sel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error Starting Patiant Insertion Process", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnBtnAddCat_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatCtl frmCat = new frmCatCtl(DBC, "A");
                if (frmCat.ShowDialog() == DialogResult.OK)
                {
                    MultiListItem mli = new PureComponents.EntrySet.Lists.MultiListItem(
                        frmCat.insertedCategory.Name, frmCat.insertedCategory.ID);
                    mli.CheckState = CheckState.Checked;
                    mListCats.Items.Add(mli);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error Starting Category Insertion Process", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnBtnManipulate_Click(object sender, EventArgs e)
        {
            try
            {
                picQView.Image.Dispose();
                picQView.Image = null;
                picLstSerImage.SelectedItem.Image.Dispose();
                picLstSerImage.SelectedItem.Image = null;
                frmViewImage frmView = new frmViewImage(
                    picLstSerImage.SelectedItem.Tag.ToString(),
                    (imageRecord)picLstSerImage.SelectedItem.Value,
                    this.DBC, opr);
                if (frmView.ShowDialog() == DialogResult.OK)
                {
                    picLstSerImage.SelectedItem.Image = new Bitmap(picLstSerImage.SelectedItem.Tag.ToString());
                }
                else
                {
                    picLstSerImage.SelectedItem.Image = new Bitmap(picLstSerImage.SelectedItem.Tag.ToString());
                }
                picQView.Load(picLstSerImage.SelectedItem.Tag.ToString());
                if (opr.ToLower() == "modify")
                {
                    picLstSerImage.SelectedItem.Text += " changed";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error in Viewing Image", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        #region Auxiliary Functions

        /// <summary>
        /// Fill patiants list to select one to be the patiant to which this series belongs
        /// </summary>
        private void fillPatList()
        {
            try
            {
                if (DBC.IsConnected)
                {
                    //DBC.CommandText = "SELECT DISTINCT P.PID AS Patiant, P.Name FROM Patiant AS P INNER JOIN Series AS S ON P.PID = S.PID;";
                    DBC.CommandText = "SELECT PID,Name FROM Patiant;";
                    DataSet ds = DBC.ExecuteQuery();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rbnCboPatiant.Items.Clear();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            rbnCboPatiant.Items.Add(
                                ds.Tables[0].Rows[i].ItemArray[0].ToString() +
                                '\t'.ToString() +
                                ds.Tables[0].Rows[i].ItemArray[1].ToString());
                        }
                    }
                }
                else
                {
                    throw new Exception("The database is not connected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Get last series id to insert after it
        /// </summary>
        /// <returns>The ID of the series</returns>
        private int getLastID()
        {
            try
            {
                if (DBC.IsConnected)
                {
                    DBC.CommandText = "SELECT MAX(SID) FROM Series;";
                    DataSet ds = DBC.ExecuteQuery();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string t = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                        if (t != "")
                            return int.Parse(t) + 1;
                        else
                            return 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    throw new Exception("The database is not connected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return -1;
            }
        }

        /// <summary>
        /// Gets the last unused image ID for the current series.
        /// </summary>
        /// <param name="SID">The current series ID</param>
        /// <returns>Last image ID</returns>
        private int getUnusedImageID(int SID)
        {
            try
            {
                if (DBC.IsConnected)
                {
                    int imgID = 0;
                    DBC.CommandText = "SELECT ImageID FROM Image WHERE (FLOOR(ImageID / 100) = " + SID.ToString() + " );";
                    DataSet ds = DBC.ExecuteQuery();
                    int iSID = SID * 100;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string t;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            t = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                            if (int.Parse(t) != iSID + i+1)
                            {
                                imgID = iSID + i+1;
                                break;
                            }
                        }
                        if (imgID == 0)
                        {
                            imgID = iSID + ds.Tables[0].Rows.Count;
                        }
                        return imgID;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    throw new Exception("The database is not connected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return -1;
            }
        }

        /// <summary>
        /// Fill categories list to select from to be the categories of this series
        /// </summary>
        private void fillCatList()
        {
            try
            {
                if (DBC.IsConnected)
                {
                    DBC.CommandText = "SELECT CatID,CatName FROM Category;";
                    DataSet ds = DBC.ExecuteQuery();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        mListCats.Items.Clear();
                        PureComponents.EntrySet.Lists.MultiListItem mli;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            mli = new PureComponents.EntrySet.Lists.MultiListItem(
                                ds.Tables[0].Rows[i].ItemArray[1].ToString(), 
                                ds.Tables[0].Rows[i].ItemArray[0].ToString());
                            mListCats.Items.Add(mli);
                        }
                    }
                }
                else
                {
                    throw new Exception("The database is not connected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Fill seires list to select from to be modified or deleted
        /// </summary>
        /// <param name="PID">The patiant to which the series belong</param>
        private void fillSeriesList(int PID)
        {
            try
            {
                if (DBC.IsConnected)
                {
                    DBC.CommandText = "SELECT SID FROM Series WHERE PID= " + PID.ToString() + ";";
                    DataSet ds = DBC.ExecuteQuery();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rbnCboSeriesID.Items.Clear();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            rbnCboSeriesID.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
                        }
                    }
                    else
                    {
                        throw new Exception("There is no series related to this patiant!");
                    }
                }
                else
                {
                    throw new Exception("The database is not connected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}