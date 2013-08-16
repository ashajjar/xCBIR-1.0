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
    public partial class frmPatiantControl : Form
    {
        private databaseController DBC;
        private Patiant PatiantRecord;
        public Patiant insertedPatiant;
        private string opr;

        public frmPatiantControl(databaseController dbc, string opr)
        {
            this.opr = opr;
            this.DBC = dbc;
            InitializeComponent();
        }

        private void frmPatiantControl_Load(object sender, EventArgs e)
        {
            try
            {
                rbnBtnDone.Text = rbnBtnDone.Text.Replace("[Operation]", opr);
                rbnfrmPatiantControl.Text = rbnfrmPatiantControl.Text.Replace("[Operation]", opr);
                this.Text = this.Text.Replace("[Operation]", opr);

                if (opr.ToLower() == "insert")
                {
                    rbnTxtPID.Text = getLastID().ToString();
                    rbnCboPatName.SendToBack();
                }
                else if (opr.ToLower() == "modify")
                {
                    rbnCboPatName.BringToFront();
                    fillPatList();
                }
                else if (opr.ToLower() == "delete")
                {
                    rbnCboPatName.BringToFront();
                    rbnTxtPatAge.Enabled = false;
                    rbnTxtPatInfo.Enabled = false;
                    fillPatList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void rbnTxtPatName_TextChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void rbnBtnDone_Click(object sender, EventArgs e)
        {
            try
            {
                #region Insert Patiant Record
                if (opr.ToUpper() == "INSERT")
                {
                    if (rbnTxtPatName.Text.Trim() != "")//Check fields
                    {
                        PatiantRecord = new Patiant(rbnTxtPID.Text,
                                                    rbnTxtPatName.Text,
                                                    null, null);

                        if (rbnTxtPatInfo.Text.Trim() != "")
                        {
                            PatiantRecord.Information = rbnTxtPatInfo.Text;
                        }
                        if (rbnTxtPatAge.Text.Trim() != "")
                        {
                            PatiantRecord.Age = rbnTxtPatAge.Text;
                        }

                        if (!PatiantRecord.InsertPatiant(DBC))//If insertion is not done
                        {
                            throw new Exception("Failed to insert the patiant record!");//Throw an exception
                        }
                        insertedPatiant = PatiantRecord;
                        this.DialogResult = DialogResult.OK;
                        this.Close();//Close when done
                    }
                    else
                    {
                        MessageBox.Show(
                        "Name field is required!",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                #endregion
                #region Modify Patiant Record
                else if (opr.ToUpper() == "MODIFY")
                {
                    if (rbnCboPatName.Text.ToLower() != "select patiant")
                    {
                        if (rbnCboPatName.Text.Trim() != "")//Check fields
                        {
                            PatiantRecord = new Patiant(rbnTxtPID.Text,
                                                        rbnCboPatName.Text,
                                                        null, null);

                            if (rbnTxtPatInfo.Text.Trim() != "")
                            {
                                PatiantRecord.Information = rbnTxtPatInfo.Text;
                            }
                            if (rbnTxtPatAge.Text.Trim() != "")
                            {
                                PatiantRecord.Age = rbnTxtPatAge.Text;
                            }

                            if (!PatiantRecord.UpdatePatiant(DBC))//If modification is not done
                            {
                                throw new Exception("Failed to modify the patiant record!");//Throw an exception
                            }
                            this.DialogResult = DialogResult.OK;
                            this.Close();//Close when done

                        }
                        else
                        {
                            MessageBox.Show(
                            "Name field is required!",
                            "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Please select a patiant first!",
                            "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                #endregion
                #region Delete Patiant Record
                else if (opr.ToUpper() == "DELETE")
                {
                    if (rbnCboPatName.Text.ToLower() != "select patiant")
                    {
                        PatiantRecord = new Patiant(rbnTxtPID.Text, null, null, null);
                        if (!PatiantRecord.DeletePatiant(DBC))//If deletion is not done
                        {
                            throw new Exception("Failed to delete the patiant record!");//Throw an exception
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();//Close when done
                    }
                    else
                    {
                        MessageBox.Show(
                            "Please select a patiant first!",
                            "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
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
            }
        }

        private void rbnBtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void rbnCboPatName_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Select category to delete :
            try
            {
                string name = rbnCboPatName.SelectedItem;
                DBC.CommandText = "SELECT * FROM Patiant WHERE Name='" + name + "';";
                DataSet ds = DBC.ExecuteQuery();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rbnTxtPID.Text =
                        ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    rbnTxtPatAge.Text =
                        ds.Tables[0].Rows[0].ItemArray[2].ToString();
                    rbnTxtPatInfo.Text =
                        ds.Tables[0].Rows[0].ItemArray[3].ToString();
                }
                if (opr.ToLower() == "modify")
                {
                    rbnCboPatName.ReadOnly = false;
                }
                else
                {
                    rbnCboPatName.ReadOnly = true;
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

        private void rbnTxtPatAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0') || (e.KeyChar > '9'))
            {
                e.KeyChar = (char)0;
            }
        }

        private void rbnTxtPatAge_TextChanged(object sender, EventArgs e)
        {
            //Patiant age must be numeric
            try
            {
                if ((!rbnTxtPatAge.Text.EndsWith("0")) && (!rbnTxtPatAge.Text.EndsWith("1")) &&
                    (!rbnTxtPatAge.Text.EndsWith("2")) && (!rbnTxtPatAge.Text.EndsWith("3")) &&
                    (!rbnTxtPatAge.Text.EndsWith("4")) && (!rbnTxtPatAge.Text.EndsWith("5")) &&
                    (!rbnTxtPatAge.Text.EndsWith("6")) && (!rbnTxtPatAge.Text.EndsWith("7")) &&
                    (!rbnTxtPatAge.Text.EndsWith("8")) && (!rbnTxtPatAge.Text.EndsWith("9")))
                {
                    if (rbnTxtPatAge.Text.Length > 0)
                    {
                        //rbnTxtPatAge.Text = rbnTxtPatAge.Text.Remove(rbnTxtPatAge.Text.Length - 1, 1);
                        int L = rbnTxtPatAge.Text.Length;
                        rbnTxtPatAge.Text = rbnTxtPatAge.Text.Trim(rbnTxtPatAge.Text[L - 1]);
                        rbnTxtPatAge.Text = rbnTxtPatAge.Text.Trim();
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

        #region Auxiliary Functions
        /// <summary>
        /// Fill patiants list to select one to be modify
        /// </summary>
        private void fillPatList()
        {
            try
            {
                if (DBC.IsConnected)
                {
                    //DBC.CommandText = "SELECT DISTINCT P.PID AS Patiant, P.Name FROM Patiant AS P INNER JOIN Series AS S ON P.PID = S.PID;";
                    DBC.CommandText = "SELECT Name FROM Patiant;";
                    DataSet ds = DBC.ExecuteQuery();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rbnCboPatName.Items.Clear();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            rbnCboPatName.Items.Add(
                                ds.Tables[0].Rows[i].ItemArray[0].ToString());
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
        /// Gets an ID for patiant
        /// </summary>
        /// <returns>ID for the patiant to be inserted</returns>
        private int getLastID()
        {
            //Get last image id to insert after it
            try
            {
                if (DBC.IsConnected)
                {
                    DBC.CommandText = "SELECT MAX(PID) FROM Patiant;";
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
        #endregion
    }
}