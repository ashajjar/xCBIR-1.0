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
    public partial class frmAddDBConnection : Form
    {
        private systemController SC;
        private frmMain F;
        public frmAddDBConnection(systemController sc,frmMain frm)
        {
            SC = sc;
            F = frm;
            InitializeComponent();
        }

        private void rbnBtnAdd_Click(object sender, EventArgs e)
        {
            if (rbnTxtConnStr.Text != "")
            {
                if (SC.AddDBConnection(rbnTxtConnStr.Text, chkDefualt.Checked))
                {
                    MessageBox.Show("Connection string added successfully!", "Connection Added"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    F.fillDBConnList(SC.DBConnectionList);
                }
                else
                {
                    MessageBox.Show("Failed to add connection string", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please insert a connection string first", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Close();
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}