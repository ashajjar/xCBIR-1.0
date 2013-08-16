using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XCBIR.Classes;
using System.IO;

namespace XCBIR
{
    public partial class frmMain : Form
    {
        private databaseController DBC;
        private systemController SC;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                SC = new systemController(Application.StartupPath);
                int status = SC.Initialize();

                if (status == -1)
                {
                    Exception ex = new Exception("System failed to load some or all of its components !");
                }

                //Filling the lists of history and DB connections :
                fillHistoryList(SC.HistoryList);
                fillDBConnList(SC.DBConnectionList);

                //Connect to default connection
                DBC = new databaseController(
                    new System.Data.SqlClient.SqlConnection(SC.DefaultConnectionString));

                if (!DBC.Connect())
                {
                    Exception ex = new Exception("The default database connection is not valid !\nPlease select or add another connection string");
                }
                if (DBC.IsConnected)
                {
                    rbnMain.StatusBar.Text = rbnMain.StatusBar.Text + "connected.";
                    picLstResults.Items.Clear();
                    viewAllImages();
                }
                else
                {
                    rbnMain.StatusBar.Text = rbnMain.StatusBar.Text + "disconnected.";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading The System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (DBC.IsConnected)
                {
                    rbnMain.StatusBar.Text = rbnMain.StatusBar.Text + "connected.";
                    picLstResults.Items.Clear();
                    viewAllImages();
                }
                else
                {
                    rbnMain.StatusBar.Text = rbnMain.StatusBar.Text + "disconnected.";
                }
            }
        }

        private void pictureList1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (picLstResults.SelectedItem == null)
                {
                    return;
                }
                picQView.Image.Dispose();
                picQView.Image = null;
                picLstResults.SelectedItem.Image.Dispose();
                picLstResults.SelectedItem.Image = null;
                frmViewImage frmView = new frmViewImage(
                    picLstResults.SelectedItem.Tag.ToString(),
                    (imageRecord)picLstResults.SelectedItem.Value,
                    this.DBC,"modify");
                if (frmView.ShowDialog() == DialogResult.OK)
                {
                    picLstResults.SelectedItem.Image = new Bitmap(picLstResults.SelectedItem.Tag.ToString());
                }
                else
                {
                    picLstResults.SelectedItem.Image = new Bitmap(picLstResults.SelectedItem.Tag.ToString());
                }
                picQView.Load(picLstResults.SelectedItem.Tag.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error in Viewing Image", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnBtnOpenEx_Click(object sender, EventArgs e)
        {
            try
            {
                //Preparing to show open file dialog :
                OFD.FileName = "";
                OFD.Title = "Open an image file";
                OFD.Filter = "JPEG Images (*.jpg)|*.jpg|Bitmap Images (*.bmp)|*.bmp";
                OFD.ShowDialog();
                if (OFD.FileName != "")
                {
                    picExample.Load(OFD.FileName);
                }
                else
                {
                    picExample.ImageLocation = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Open Dialog Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnBtnInsertImg_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeriesControl frmsc = new frmSeriesControl(DBC, SC, "Insert");
                if (frmsc.ShowDialog() == DialogResult.OK)
                {
                    picLstResults.Items.Clear();
                    viewAllImages();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error Starting Insertion Process", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnBtnModifyImg_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeriesControl frmsc = new frmSeriesControl(DBC, SC, "Modify");
                if (frmsc.ShowDialog() == DialogResult.OK)
                {
                    picLstResults.Items.Clear();
                    viewAllImages();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error Starting Modification Process", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

        }

        private void rbnBtnDeleteImg_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeriesControl frmsc = new frmSeriesControl(DBC, SC, "Delete");
                if (frmsc.ShowDialog() == DialogResult.OK)
                {
                    picLstResults.Items.Clear();
                    viewAllImages();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error Starting Deletion Process", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

        }

        private void rbnBtnClrHist_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr =
                    MessageBox.Show("Are you sure you want to clear history?", "Clear History"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (!SC.ClearSearchHistory())
                    {
                        MessageBox.Show("System faild to clear history !", "Clear History"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("History cleared successfully!", "Clear History"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rbnCboTxtSemantic.Items.Clear();
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Clearing History Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void rbnBtnAddDB_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddDBConnection frmAddDB = new frmAddDBConnection(SC, this);
                frmAddDB.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error Adding DB connection", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

        }

        private void rbnBtnDBConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbnCboDBs.Text != "Select or Add Database")
                {
                    if (DBC.IsConnected)
                    {
                        if (!DBC.Disconnect())
                        {
                            MessageBox.Show(
                            "Cannot disconnect current connection.\nPlease try again later !",
                            "Can not disconnect", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            rbnMain.StatusBar.Text = rbnMain.StatusBar.Text.Replace("connected", "disconnected");
                        }
                    }
                    DBC.ConnectionString =
                        new System.Data.SqlClient.SqlConnection(rbnCboDBs.Text.Trim('*'));
                    if (!DBC.Connect())
                    {
                        MessageBox.Show(
                        "Cannot connect to DB.\nPlease try again later !",
                        "Can not connect", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        rbnMain.StatusBar.Text = rbnMain.StatusBar.Text.Replace("disconnected", "connected");
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Please select a connection to connect to !",
                        "No connection specified", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        ex.Message,
                        "Connecting to DB Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void rbnBtnDBDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DBC.IsConnected)
                {
                    MessageBox.Show(
                            "The database is already disconnected!",
                            "Already Disconnected", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                }
                else
                {
                    if (!DBC.Disconnect())
                    {
                        MessageBox.Show(
                            "The database can not be disconnected!\nPlease try again later.",
                            "Disconnecting Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        rbnMain.StatusBar.Text = rbnMain.StatusBar.Text.Replace("connected", "disconnected");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Disconnecting Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void rbnBtnManEx_Click(object sender, EventArgs e)
        {
            try
            {
                throw new NotImplementedException("Image manipulation not implemented yet");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Implementation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbnBtnUndoMan_Click(object sender, EventArgs e)
        {
            try
            {
                throw new NotImplementedException("Image manipulation not implemented yet");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Implementation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbnDDBtnSearch_MenuItemClick(object sender, PureComponents.ActionSet.RibbonUI.RibbonMenuItemEventArgs e)
        {
            try
            {
                if (e.MenuItem.Text == "Search by Example")
                {
                    this.Cursor = Cursors.WaitCursor;
                    if ((picExample.ImageLocation == null)||(picExample.ImageLocation == ""))
                    {
                        throw new Exception("Please open an example image to find similar images !");
                    }
                    picLstResults.Items.Clear();
                    search srch = new search();
                    //long ll = DateTime.Now.Ticks;
                    List<string[]> res = srch.SearchByExample(picExample.ImageLocation, DBC,
                        double.Parse(rbnTxtMaxArea.Text), double.Parse(rbnTxtMinArea.Text));
                    if (res == null)
                    {
                        throw new Exception("An error occured !\nThe database is empty or there are no matches !");
                    }
                    for (int i = 0; i < res.Count; i++)
                    {
                        string name = res[i][0];

                        string imgpath = SC.SettingsList[0].Trim('\\') + "\\" + res[i][1] + "\\" + res[i][0];

                        Bitmap bmp = new Bitmap(imgpath);
                        PureComponents.EntrySet.Lists.PictureListItem pItem =
                            new PureComponents.EntrySet.Lists.PictureListItem(name+res[i][2],
                            bmp, true, null);
                        pItem.Tag = imgpath;
                        pItem.Value = res[i][3];
                        picLstResults.Items.Add(pItem);
                    }
                    rbnMain.StatusBar.Text =
                        rbnMain.StatusBar.Text.Remove(rbnMain.StatusBar.Text.IndexOf("."));
                    rbnMain.StatusBar.Text = rbnMain.StatusBar.Text + ". Number of results is " + res.Count;
                    //ll = DateTime.Now.Ticks - ll;
                    //ll = ll / 1000;
                    //ll = ll / 3600;
                    //MessageBox.Show(ll.ToString());
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Search by semantic is not activated !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Searching Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
            }
        }

        private void rbnBtnInsertCat_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatCtl CatCtl = new frmCatCtl(this.DBC,"A");
                CatCtl.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnBtnDelCat_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatCtl CatCtl = new frmCatCtl(this.DBC, "D");
                CatCtl.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void picLstResults_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (picLstResults.SelectedItem==null)
                {
                    return;
                }
                if ((picLstResults.SelectedItem.Image.Width > picQView.Width) ||
                    (picLstResults.SelectedItem.Image.Height > picQView.Height))
                {
                    picQView.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    picQView.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                lblImageInfo.Text = picLstResults.SelectedItem.Tag.ToString() + " - Series ID : " + picLstResults.SelectedItem.Value;
                picQView.Load(lblImageInfo.Text);
                //frmQuickView frmQView = new frmQuickView(img);
                //frmQView.Show(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Quick View Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void picExample_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if ((picExample.ImageLocation == null) || (picExample.ImageLocation == ""))
                {
                    return;
                }
                if ((picExample.Image.Width > picQView.Width) || (picExample.Image.Height > picQView.Height))
                {
                    picQView.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    picQView.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                picQView.Load(picExample.ImageLocation);
                lblImageInfo.Text = "Example Image : " + picExample.ImageLocation;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Example Image Viewing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbnSblPan_Resize(object sender, EventArgs e)
        {
            picLstResults.Height = rbnSblPan.Height;
        }

        private void picLstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (picLstResults.SelectedItem == null)
                {
                    return;
                }
                if ((picLstResults.SelectedItem.Image.Width > picQView.Width) ||
                    (picLstResults.SelectedItem.Image.Height > picQView.Height))
                {
                    picQView.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    picQView.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                lblImageInfo.Text = picLstResults.SelectedItem.Tag.ToString();
                picQView.Load(lblImageInfo.Text);
                //frmQuickView frmQView = new frmQuickView(img);
                //frmQView.Show(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Quick View Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnBtnAddPat_Click(object sender, EventArgs e)
        {
            try
            {
                frmPatiantControl frmPat = new frmPatiantControl(DBC, "Insert");
                frmPat.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error Starting Insertion Process", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnBtnModPat_Click(object sender, EventArgs e)
        {
            try
            {
                frmPatiantControl frmPat = new frmPatiantControl(DBC, "Modify");
                frmPat.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error Starting Modification Process", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void rbnBtnDelPat_Click(object sender, EventArgs e)
        {
            try
            {
                frmPatiantControl frmPat = new frmPatiantControl(DBC, "Delete");
                frmPat.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error Starting Deletion Process", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want exit ?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                SC.Exit();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void rbnMain_RibbonApplicationMenuExitButtonClick(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want exit ?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                SC.Exit();
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void rbnMain_RibbonApplicationMenuItemClick(object sender, PureComponents.ActionSet.RibbonUI.RibbonMenuItemEventArgs e)
        {
            if (e.MenuItem == rbnMnuItmBrowse)
            {
                if (DBC.IsConnected)
                {
                    picLstResults.Items.Clear();
                    viewAllImages();
                }
            }
            else if (e.MenuItem == rbnMnuItmHelp)
            {
                System.Diagnostics.Process.Start("XCBIR Help.chm");
            }
            else if (e.MenuItem == rbnMnuItmAbout)
            {
                MessageBox.Show(
                    "University of Kalamoon\nInformation Technology\nGraduation Project\nX-CBIR 2009\nAhmad Hajjar - Osama Al-Khatib",
                    "About",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void rbnTabCP_Click(object sender, EventArgs e)
        {

        }

        #region Auxiliary Functions
        private void viewAllImages()
        {
            try
            {
                DBC.CommandText = "SELECT * FROM IMAGE";
                DataSet ds = DBC.ExecuteQuery();
                DataSet sds;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string fname = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    string imgID = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                    double sid = Math.Floor((double.Parse(imgID) / 100));

                    DBC.CommandText = "SELECT FolderPath FROM Series WHERE SID = " + sid.ToString() + " ;";
                    sds = DBC.ExecuteQuery();
                    if (sds.Tables[0].Rows.Count < 1)
                    {
                        return;
                    }

                    string imgFld = sds.Tables[0].Rows[0].ItemArray[0].ToString();

                    imgFld = (imgFld.EndsWith("\\")) ? imgFld : imgFld + "\\";
                    imgFld = (imgFld.StartsWith("\\")) ? imgFld : "\\" + imgFld;

                    string imgpath = this.SC.SettingsList[0].TrimEnd('\\') + imgFld + fname;
                    Bitmap bmp = new Bitmap(imgpath);
                    PureComponents.EntrySet.Lists.PictureListItem pItem =
                        new PureComponents.EntrySet.Lists.PictureListItem(fname,
                        bmp, true, null);
                    pItem.Tag = imgpath;
                    imageRecord imgRecord = new imageRecord(imgID, null, fname, null);
                    pItem.Value = imgRecord;
                    picLstResults.Items.Add(pItem);
                }
                rbnMain.StatusBar.Text = "Database is connected.";
                rbnMain.StatusBar.Text = rbnMain.StatusBar.Text + " - - - - You have "
                    + picLstResults.Items.Count + " images in the database";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error viewing all images", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fillHistoryList(List<string> histList)
        {
            try
            {
                rbnCboTxtSemantic.Items.Clear();
                for (int i = 0; i < histList.Count; i++)
                {
                    rbnCboTxtSemantic.Items.Add(histList[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Filling History List Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        public void fillDBConnList(List<string> dbConnList)
        {
            try
            {
                rbnCboDBs.Items.Clear();
                for (int i = 0; i < dbConnList.Count; i++)
                {
                    rbnCboDBs.Items.Add(dbConnList[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Filling DB connections List Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        #endregion

        private void browseAllImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DBC.IsConnected)
            {
                picLstResults.Items.Clear();
                viewAllImages();
            }
        }

        private void openContainingSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeriesControl frmsc = new frmSeriesControl(DBC, SC, "Delete");
                if (frmsc.ShowDialog() == DialogResult.OK)
                {
                    picLstResults.Items.Clear();
                    viewAllImages();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error Starting Deletion Process", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

    }
}