namespace XCBIR
{
    partial class frmCatCtl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PureComponents.EntrySet.Controls.LabelStyle labelStyle1 = new PureComponents.EntrySet.Controls.LabelStyle();
            PureComponents.EntrySet.Controls.LabelStyle labelStyle2 = new PureComponents.EntrySet.Controls.LabelStyle();
            PureComponents.EntrySet.Controls.LabelStyle labelStyle3 = new PureComponents.EntrySet.Controls.LabelStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatCtl));
            PureComponents.ActionSet.Controls.ActionScreenTip actionScreenTip1 = new PureComponents.ActionSet.Controls.ActionScreenTip();
            PureComponents.ActionSet.Controls.ActionScreenTip actionScreenTip2 = new PureComponents.ActionSet.Controls.ActionScreenTip();
            PureComponents.ActionSet.Controls.ActionScreenTip actionScreenTip3 = new PureComponents.ActionSet.Controls.ActionScreenTip();
            this.rbnFrmCatCtl = new PureComponents.ActionSet.RibbonUI.RibbonForm();
            this.ribbonScrollablePanel1 = new PureComponents.ActionSet.RibbonUI.RibbonScrollablePanel();
            this.ribbonPanel1 = new PureComponents.ActionSet.RibbonUI.RibbonPanel();
            this.rbnCboCatParent = new PureComponents.ActionSet.RibbonUI.RibbonComboBox();
            this.lblCatParent = new PureComponents.EntrySet.Controls.Label();
            this.lblCatID = new PureComponents.EntrySet.Controls.Label();
            this.lblCatName = new PureComponents.EntrySet.Controls.Label();
            this.rbnBtnOK = new PureComponents.ActionSet.RibbonUI.RibbonButton();
            this.rbnCancel = new PureComponents.ActionSet.RibbonUI.RibbonButton();
            this.rbnTxtCatID = new PureComponents.ActionSet.RibbonUI.RibbonTextBox();
            this.rbnTxtCatName = new PureComponents.ActionSet.RibbonUI.RibbonTextBox();
            this.rbnCboCatName = new PureComponents.ActionSet.RibbonUI.RibbonComboBox();
            this.rbnDone = new PureComponents.ActionSet.RibbonUI.RibbonButton();
            ((System.ComponentModel.ISupportInitialize)(this.rbnFrmCatCtl)).BeginInit();
            this.rbnFrmCatCtl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonScrollablePanel1)).BeginInit();
            this.ribbonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblCatParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCatID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCatName)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnFrmCatCtl
            // 
            this.rbnFrmCatCtl.ClientContainer = this.ribbonScrollablePanel1;
            this.rbnFrmCatCtl.Controls.Add(this.ribbonScrollablePanel1);
            this.rbnFrmCatCtl.Controls.Add(this.rbnDone);
            this.rbnFrmCatCtl.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnFrmCatCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbnFrmCatCtl.Icon = ((System.Drawing.Image)(resources.GetObject("rbnFrmCatCtl.Icon")));
            this.rbnFrmCatCtl.Location = new System.Drawing.Point(0, 0);
            this.rbnFrmCatCtl.Name = "rbnFrmCatCtl";
            this.rbnFrmCatCtl.ShowButtonBar = false;
            this.rbnFrmCatCtl.ShowMaximizeButton = false;
            this.rbnFrmCatCtl.ShowMinimizeButton = false;
            this.rbnFrmCatCtl.ShowResizeHandler = false;
            this.rbnFrmCatCtl.Size = new System.Drawing.Size(330, 126);
            this.rbnFrmCatCtl.TabIndex = 0;
            this.rbnFrmCatCtl.Text = "Category Control";
            this.rbnFrmCatCtl.Click += new System.EventHandler(this.rbnFrmCatCtl_Click);
            // 
            // ribbonScrollablePanel1
            // 
            this.ribbonScrollablePanel1.BackColor = System.Drawing.Color.Transparent;
            this.ribbonScrollablePanel1.FormBackground = PureComponents.ActionSet.RibbonUI.RibbonBackground.Curvature1;
            this.ribbonScrollablePanel1.InnerControl = this.ribbonPanel1;
            this.ribbonScrollablePanel1.Location = new System.Drawing.Point(1, 28);
            this.ribbonScrollablePanel1.Name = "ribbonScrollablePanel1";
            this.ribbonScrollablePanel1.Size = new System.Drawing.Size(327, 95);
            this.ribbonScrollablePanel1.TabIndex = 1;
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.BackColor = System.Drawing.Color.Transparent;
            this.ribbonPanel1.Controls.Add(this.rbnCboCatParent);
            this.ribbonPanel1.Controls.Add(this.lblCatParent);
            this.ribbonPanel1.Controls.Add(this.lblCatID);
            this.ribbonPanel1.Controls.Add(this.lblCatName);
            this.ribbonPanel1.Controls.Add(this.rbnBtnOK);
            this.ribbonPanel1.Controls.Add(this.rbnCancel);
            this.ribbonPanel1.Controls.Add(this.rbnTxtCatID);
            this.ribbonPanel1.Controls.Add(this.rbnTxtCatName);
            this.ribbonPanel1.Controls.Add(this.rbnCboCatName);
            this.ribbonPanel1.FormBackground = PureComponents.ActionSet.RibbonUI.RibbonBackground.Curvature1;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Size = new System.Drawing.Size(317, 88);
            this.ribbonPanel1.TabIndex = 0;
            // 
            // rbnCboCatParent
            // 
            this.rbnCboCatParent.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnCboCatParent.Location = new System.Drawing.Point(103, 66);
            this.rbnCboCatParent.Name = "rbnCboCatParent";
            this.rbnCboCatParent.SelectedIndex = -1;
            this.rbnCboCatParent.SelectedItem = null;
            this.rbnCboCatParent.Size = new System.Drawing.Size(122, 22);
            this.rbnCboCatParent.TabIndex = 2;
            this.rbnCboCatParent.Text = "Select Parent";
            // 
            // lblCatParent
            // 
            this.lblCatParent.BackColor = System.Drawing.Color.Transparent;
            this.lblCatParent.ForeColor = System.Drawing.Color.Black;
            this.lblCatParent.Location = new System.Drawing.Point(11, 65);
            this.lblCatParent.Name = "lblCatParent";
            this.lblCatParent.Size = new System.Drawing.Size(86, 23);
            labelStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblCatParent.Style = labelStyle1;
            this.lblCatParent.TabIndex = 3;
            this.lblCatParent.TabStop = false;
            this.lblCatParent.Text = "Parent";
            // 
            // lblCatID
            // 
            this.lblCatID.BackColor = System.Drawing.Color.Transparent;
            this.lblCatID.ForeColor = System.Drawing.Color.Black;
            this.lblCatID.Location = new System.Drawing.Point(11, 7);
            this.lblCatID.Name = "lblCatID";
            this.lblCatID.Size = new System.Drawing.Size(86, 23);
            labelStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblCatID.Style = labelStyle2;
            this.lblCatID.TabIndex = 3;
            this.lblCatID.TabStop = false;
            this.lblCatID.Text = "Category ID";
            // 
            // lblCatName
            // 
            this.lblCatName.BackColor = System.Drawing.Color.Transparent;
            this.lblCatName.ForeColor = System.Drawing.Color.Black;
            this.lblCatName.Location = new System.Drawing.Point(11, 36);
            this.lblCatName.Name = "lblCatName";
            this.lblCatName.Size = new System.Drawing.Size(86, 23);
            labelStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblCatName.Style = labelStyle3;
            this.lblCatName.TabIndex = 3;
            this.lblCatName.TabStop = false;
            this.lblCatName.Text = "Category Name";
            // 
            // rbnBtnOK
            // 
            this.rbnBtnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnBtnOK.DrawBorder = true;
            this.rbnBtnOK.Image = ((System.Drawing.Image)(resources.GetObject("rbnBtnOK.Image")));
            this.rbnBtnOK.ImageAlign = PureComponents.ActionSet.Common.ImageAlignment.Left;
            this.rbnBtnOK.Location = new System.Drawing.Point(231, 8);
            this.rbnBtnOK.Name = "rbnBtnOK";
            actionScreenTip1.Active = true;
            actionScreenTip1.Description = "Cancel the whole operation";
            actionScreenTip1.Image = null;
            actionScreenTip1.Text = "Cancel";
            this.rbnBtnOK.ScreenTip = actionScreenTip1;
            this.rbnBtnOK.Size = new System.Drawing.Size(86, 23);
            this.rbnBtnOK.TabIndex = 3;
            this.rbnBtnOK.Text = "Done";
            this.rbnBtnOK.Click += new System.EventHandler(this.rbnBtnOK_Click);
            // 
            // rbnCancel
            // 
            this.rbnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnCancel.DrawBorder = true;
            this.rbnCancel.Image = ((System.Drawing.Image)(resources.GetObject("rbnCancel.Image")));
            this.rbnCancel.ImageAlign = PureComponents.ActionSet.Common.ImageAlignment.Left;
            this.rbnCancel.Location = new System.Drawing.Point(231, 37);
            this.rbnCancel.Name = "rbnCancel";
            actionScreenTip2.Active = true;
            actionScreenTip2.Description = "Cancel the whole operation";
            actionScreenTip2.Image = null;
            actionScreenTip2.Text = "Cancel";
            this.rbnCancel.ScreenTip = actionScreenTip2;
            this.rbnCancel.Size = new System.Drawing.Size(86, 23);
            this.rbnCancel.TabIndex = 4;
            this.rbnCancel.Text = "Cancel";
            this.rbnCancel.Click += new System.EventHandler(this.rbnCancel_Click);
            // 
            // rbnTxtCatID
            // 
            this.rbnTxtCatID.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnTxtCatID.Location = new System.Drawing.Point(103, 8);
            this.rbnTxtCatID.Name = "rbnTxtCatID";
            this.rbnTxtCatID.Size = new System.Drawing.Size(122, 22);
            this.rbnTxtCatID.TabIndex = 0;
            // 
            // rbnTxtCatName
            // 
            this.rbnTxtCatName.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnTxtCatName.Location = new System.Drawing.Point(103, 37);
            this.rbnTxtCatName.Name = "rbnTxtCatName";
            this.rbnTxtCatName.Size = new System.Drawing.Size(122, 22);
            this.rbnTxtCatName.TabIndex = 1;
            // 
            // rbnCboCatName
            // 
            this.rbnCboCatName.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnCboCatName.Location = new System.Drawing.Point(103, 38);
            this.rbnCboCatName.Name = "rbnCboCatName";
            this.rbnCboCatName.SelectedIndex = -1;
            this.rbnCboCatName.SelectedItem = null;
            this.rbnCboCatName.Size = new System.Drawing.Size(122, 22);
            this.rbnCboCatName.TabIndex = 5;
            this.rbnCboCatName.Text = "Select Category";
            this.rbnCboCatName.SelectedIndexChanged += new System.EventHandler(this.rbnCboCatName_SelectedIndexChanged);
            // 
            // rbnDone
            // 
            this.rbnDone.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnDone.DrawBorder = true;
            this.rbnDone.Image = ((System.Drawing.Image)(resources.GetObject("rbnDone.Image")));
            this.rbnDone.ImageAlign = PureComponents.ActionSet.Common.ImageAlignment.Left;
            this.rbnDone.Location = new System.Drawing.Point(123, 54);
            this.rbnDone.Name = "rbnDone";
            actionScreenTip3.Active = true;
            actionScreenTip3.Description = "Complete the operation";
            actionScreenTip3.Image = null;
            actionScreenTip3.Text = "Done";
            this.rbnDone.ScreenTip = actionScreenTip3;
            this.rbnDone.Size = new System.Drawing.Size(86, 23);
            this.rbnDone.TabIndex = 1;
            this.rbnDone.Text = "[Operation]";
            // 
            // frmCatCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 126);
            this.Controls.Add(this.rbnFrmCatCtl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCatCtl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCatCtl";
            this.Load += new System.EventHandler(this.frmCatCtl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rbnFrmCatCtl)).EndInit();
            this.rbnFrmCatCtl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonScrollablePanel1)).EndInit();
            this.ribbonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblCatParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCatID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCatName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PureComponents.ActionSet.RibbonUI.RibbonForm rbnFrmCatCtl;
        private PureComponents.ActionSet.RibbonUI.RibbonScrollablePanel ribbonScrollablePanel1;
        private PureComponents.ActionSet.RibbonUI.RibbonButton rbnDone;
        private PureComponents.ActionSet.RibbonUI.RibbonPanel ribbonPanel1;
        private PureComponents.ActionSet.RibbonUI.RibbonComboBox rbnCboCatParent;
        private PureComponents.ActionSet.RibbonUI.RibbonTextBox rbnTxtCatName;
        private PureComponents.ActionSet.RibbonUI.RibbonTextBox rbnTxtCatID;
        private PureComponents.EntrySet.Controls.Label lblCatParent;
        private PureComponents.EntrySet.Controls.Label lblCatID;
        private PureComponents.EntrySet.Controls.Label lblCatName;
        private PureComponents.ActionSet.RibbonUI.RibbonButton rbnCancel;
        private PureComponents.ActionSet.RibbonUI.RibbonButton rbnBtnOK;
        private PureComponents.ActionSet.RibbonUI.RibbonComboBox rbnCboCatName;

    }
}