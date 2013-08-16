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
    public partial class frmCatCtl : Form
    {
        private databaseController DBC;
        private category Category;
        public category insertedCategory;
        private string opr;

        public frmCatCtl(databaseController dbc,string opr)
        {
            this.DBC = dbc;
            this.opr = opr;
            InitializeComponent();
        }

        private void rbnFrmCatCtl_Click(object sender, EventArgs e)
        {

        }

        private void frmCatCtl_Load(object sender, EventArgs e)
        {
            if (opr == "A")//Prepare for insertion operation
            {
                int ID = getLastID();
                rbnTxtCatID.Text = ID.ToString();
                fillParentList();
            }
            else//Prepare for deletion operation
            {
                rbnCboCatName.BringToFront();
                fillCategoryList();
                rbnTxtCatID.Enabled = false;
                rbnTxtCatName.Enabled = false;
                rbnCboCatParent.Enabled = false;
            }
        }

        private void rbnBtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (opr.ToUpper() == "A")//If this is an insertion operation
                {
                    if (rbnTxtCatName.Text.Trim() != "")//Check fields
                    {
                        if (rbnCboCatParent.Text == "Select Parent")//If this category is a root
                        {
                            Category = new category(rbnTxtCatID.Text,
                                rbnTxtCatName.Text, null);
                        }
                        else//If this category is not a root
                        {
                            Category = new category(rbnTxtCatID.Text,
                                rbnTxtCatName.Text,
                                rbnCboCatParent.Text.Split('\t')[0]);
                        }
                        if (!Category.InsertCategory(DBC))//If insertion is not done
                        {
                            throw new Exception("Failed to insert the category!");//Throw an exception
                        }
                        insertedCategory = Category;
                        DialogResult = DialogResult.OK;
                        this.Close();//Close when done
                    }
                    else
                    {
                        MessageBox.Show(
                        "All fields are required!",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                else//If this is a deletion operation
                {
                    if (rbnCboCatName.Text != "Select Category")
                    {
                        if (rbnCboCatParent.Text.Length == 0)//If this category is a root
                        {
                            Category = new category(rbnTxtCatID.Text,
                                rbnCboCatName.Text, null);
                        }
                        else//If this category is not a root
                        {
                            Category = new category(rbnTxtCatID.Text,
                                rbnCboCatName.Text,
                                rbnCboCatParent.Text.Split('\t')[0]);
                        }
                        if (!Category.DeleteCategory(DBC))//If deletion is not done
                        {
                            throw new Exception("Failed to delete the category!");//Throw an exception
                        }
                    }
                    else
                    {
                        throw new Exception("Please select a category to delete!");//Throw an exception
                    }
                    DialogResult = DialogResult.OK;
                    this.Close();
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

        private void rbnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbnCboCatName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select category to delete :
            try
            {
                string name = rbnCboCatName.SelectedItem;
                DBC.CommandText = "SELECT CatID,CatParentID FROM Category WHERE CatName='" + name + "';";
                DataSet ds = DBC.ExecuteQuery();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rbnTxtCatID.Text =
                        ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    rbnCboCatParent.Text =
                        ds.Tables[0].Rows[0].ItemArray[1].ToString();
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

        private int getLastID()
        {
            //Get last category id to insert after it
            try
            {
                if (DBC.IsConnected)
                {
                    DBC.CommandText = "SELECT MAX(CatID) FROM Category;";
                    DataSet ds = DBC.ExecuteQuery();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if ((ds.Tables[0].Rows[0].ItemArray[0] != null) 
                            &&(ds.Tables[0].Rows[0].ItemArray[0].ToString() != ""))
                        {
                            return int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString()) + 1;
                        }
                        else
                        {
                            return 1;
                        }
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

        private void fillCategoryList()
        {
            //Fill category name list to select one to delete
            try
            {
                if (DBC.IsConnected)
                {
                    DBC.CommandText = "SELECT CatName FROM Category;";
                    DataSet ds = DBC.ExecuteQuery();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            rbnCboCatName.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
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

        private void fillParentList()
        {
            /*
             * Fill category parent list to select one to be 
             * the parent of the category to be inserted
             */
            try
            {
                if (DBC.IsConnected)
                {
                    DBC.CommandText = "SELECT CatID,CatName FROM Category;";
                    DataSet ds = DBC.ExecuteQuery();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            rbnCboCatParent.Items.Add(
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
    }
}