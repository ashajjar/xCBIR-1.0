namespace XCBIR
{
    partial class frmPatiantControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatiantControl));
            PureComponents.ActionSet.Controls.ActionScreenTip actionScreenTip1 = new PureComponents.ActionSet.Controls.ActionScreenTip();
            PureComponents.ActionSet.Controls.ActionScreenTip actionScreenTip2 = new PureComponents.ActionSet.Controls.ActionScreenTip();
            PureComponents.EntrySet.Controls.LabelStyle labelStyle2 = new PureComponents.EntrySet.Controls.LabelStyle();
            PureComponents.EntrySet.Controls.LabelStyle labelStyle3 = new PureComponents.EntrySet.Controls.LabelStyle();
            PureComponents.EntrySet.Controls.LabelStyle labelStyle4 = new PureComponents.EntrySet.Controls.LabelStyle();
            PureComponents.EntrySet.Controls.ScreenTip screenTip1 = new PureComponents.EntrySet.Controls.ScreenTip();
            PureComponents.EntrySet.Controls.StickyLabel stickyLabel1 = new PureComponents.EntrySet.Controls.StickyLabel();
            PureComponents.EntrySet.Controls.RichEditBoxStyle richEditBoxStyle1 = new PureComponents.EntrySet.Controls.RichEditBoxStyle();
            this.rbnfrmPatiantControl = new PureComponents.ActionSet.RibbonUI.RibbonForm();
            this.rbnSblPan = new PureComponents.ActionSet.RibbonUI.RibbonScrollablePanel();
            this.rbnPanPatControl = new PureComponents.ActionSet.RibbonUI.RibbonPanel();
            this.rbnTxtPatAge = new PureComponents.ActionSet.RibbonUI.RibbonTextBox();
            this.lblPatInfo = new PureComponents.EntrySet.Controls.Label();
            this.rbnBtnCancel = new PureComponents.ActionSet.RibbonUI.RibbonButton();
            this.rbnBtnDone = new PureComponents.ActionSet.RibbonUI.RibbonButton();
            this.rbnTxtPID = new PureComponents.ActionSet.RibbonUI.RibbonTextBox();
            this.rbnTxtPatName = new PureComponents.ActionSet.RibbonUI.RibbonTextBox();
            this.lblPatAge = new PureComponents.EntrySet.Controls.Label();
            this.lblPID = new PureComponents.EntrySet.Controls.Label();
            this.lblPatName = new PureComponents.EntrySet.Controls.Label();
            this.rbnTxtPatInfo = new PureComponents.EntrySet.Controls.RichEditBox();
            this.rbnCboPatName = new PureComponents.ActionSet.RibbonUI.RibbonComboBox();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.rbnfrmPatiantControl)).BeginInit();
            this.rbnfrmPatiantControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbnSblPan)).BeginInit();
            this.rbnPanPatControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblPatInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPatAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPatName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbnTxtPatInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnfrmPatiantControl
            // 
            this.rbnfrmPatiantControl.ClientContainer = this.rbnSblPan;
            this.rbnfrmPatiantControl.Controls.Add(this.rbnSblPan);
            this.rbnfrmPatiantControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnfrmPatiantControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbnfrmPatiantControl.Icon = ((System.Drawing.Image)(resources.GetObject("rbnfrmPatiantControl.Icon")));
            this.rbnfrmPatiantControl.Location = new System.Drawing.Point(0, 0);
            this.rbnfrmPatiantControl.Name = "rbnfrmPatiantControl";
            this.rbnfrmPatiantControl.ShowButtonBar = false;
            this.rbnfrmPatiantControl.ShowMaximizeButton = false;
            this.rbnfrmPatiantControl.ShowMinimizeButton = false;
            this.rbnfrmPatiantControl.ShowResizeHandler = false;
            this.rbnfrmPatiantControl.Size = new System.Drawing.Size(371, 261);
            this.rbnfrmPatiantControl.TabIndex = 0;
            this.rbnfrmPatiantControl.Text = "[Operation] Patiant";
            // 
            // rbnSblPan
            // 
            this.rbnSblPan.BackColor = System.Drawing.Color.Transparent;
            this.rbnSblPan.FormBackground = PureComponents.ActionSet.RibbonUI.RibbonBackground.Curvature1;
            this.rbnSblPan.InnerControl = this.rbnPanPatControl;
            this.rbnSblPan.Location = new System.Drawing.Point(1, 28);
            this.rbnSblPan.Name = "rbnSblPan";
            this.rbnSblPan.Size = new System.Drawing.Size(368, 230);
            this.rbnSblPan.TabIndex = 1;
            // 
            // rbnPanPatControl
            // 
            this.rbnPanPatControl.BackColor = System.Drawing.Color.Transparent;
            this.rbnPanPatControl.Controls.Add(this.rbnTxtPatAge);
            this.rbnPanPatControl.Controls.Add(this.lblPatInfo);
            this.rbnPanPatControl.Controls.Add(this.rbnBtnCancel);
            this.rbnPanPatControl.Controls.Add(this.rbnBtnDone);
            this.rbnPanPatControl.Controls.Add(this.rbnTxtPID);
            this.rbnPanPatControl.Controls.Add(this.rbnTxtPatName);
            this.rbnPanPatControl.Controls.Add(this.lblPatAge);
            this.rbnPanPatControl.Controls.Add(this.lblPID);
            this.rbnPanPatControl.Controls.Add(this.lblPatName);
            this.rbnPanPatControl.Controls.Add(this.rbnTxtPatInfo);
            this.rbnPanPatControl.Controls.Add(this.rbnCboPatName);
            this.rbnPanPatControl.FormBackground = PureComponents.ActionSet.RibbonUI.RibbonBackground.Curvature1;
            this.rbnPanPatControl.Location = new System.Drawing.Point(0, 0);
            this.rbnPanPatControl.Name = "rbnPanPatControl";
            this.rbnPanPatControl.Size = new System.Drawing.Size(359, 223);
            this.rbnPanPatControl.TabIndex = 0;
            // 
            // rbnTxtPatAge
            // 
            this.rbnTxtPatAge.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnTxtPatAge.Location = new System.Drawing.Point(94, 200);
            this.rbnTxtPatAge.Name = "rbnTxtPatAge";
            this.rbnTxtPatAge.Size = new System.Drawing.Size(112, 22);
            this.rbnTxtPatAge.TabIndex = 3;
            this.rbnTxtPatAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rbnTxtPatAge_KeyPress);
            this.rbnTxtPatAge.TextChanged += new System.EventHandler(this.rbnTxtPatAge_TextChanged);
            // 
            // lblPatInfo
            // 
            this.lblPatInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPatInfo.ForeColor = System.Drawing.Color.Black;
            this.lblPatInfo.Location = new System.Drawing.Point(11, 72);
            this.lblPatInfo.Name = "lblPatInfo";
            this.lblPatInfo.Size = new System.Drawing.Size(77, 22);
            labelStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblPatInfo.Style = labelStyle1;
            this.lblPatInfo.TabIndex = 0;
            this.lblPatInfo.TabStop = false;
            this.lblPatInfo.Text = "Patiant Info";
            // 
            // rbnBtnCancel
            // 
            this.rbnBtnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnBtnCancel.DrawBorder = true;
            this.rbnBtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("rbnBtnCancel.Image")));
            this.rbnBtnCancel.ImageAlign = PureComponents.ActionSet.Common.ImageAlignment.Left;
            this.rbnBtnCancel.Location = new System.Drawing.Point(273, 200);
            this.rbnBtnCancel.Name = "rbnBtnCancel";
            actionScreenTip1.Active = true;
            actionScreenTip1.Description = "Cancel the whole operation";
            actionScreenTip1.Image = null;
            actionScreenTip1.Text = "Cancel";
            this.rbnBtnCancel.ScreenTip = actionScreenTip1;
            this.rbnBtnCancel.Size = new System.Drawing.Size(86, 23);
            this.rbnBtnCancel.TabIndex = 4;
            this.rbnBtnCancel.Text = "Close";
            this.rbnBtnCancel.Click += new System.EventHandler(this.rbnBtnCancel_Click);
            // 
            // rbnBtnDone
            // 
            this.rbnBtnDone.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnBtnDone.DrawBorder = true;
            this.rbnBtnDone.Image = ((System.Drawing.Image)(resources.GetObject("rbnBtnDone.Image")));
            this.rbnBtnDone.ImageAlign = PureComponents.ActionSet.Common.ImageAlignment.Left;
            this.rbnBtnDone.Location = new System.Drawing.Point(273, 171);
            this.rbnBtnDone.Name = "rbnBtnDone";
            actionScreenTip2.Active = true;
            actionScreenTip2.Description = "Complete the operation";
            actionScreenTip2.Image = null;
            actionScreenTip2.Text = "Done";
            this.rbnBtnDone.ScreenTip = actionScreenTip2;
            this.rbnBtnDone.Size = new System.Drawing.Size(86, 23);
            this.rbnBtnDone.TabIndex = 4;
            this.rbnBtnDone.Text = "[Operation]";
            this.rbnBtnDone.Click += new System.EventHandler(this.rbnBtnDone_Click);
            // 
            // rbnTxtPID
            // 
            this.rbnTxtPID.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnTxtPID.Enabled = false;
            this.rbnTxtPID.Location = new System.Drawing.Point(94, 16);
            this.rbnTxtPID.Name = "rbnTxtPID";
            this.rbnTxtPID.Size = new System.Drawing.Size(112, 22);
            this.rbnTxtPID.TabIndex = 1;
            // 
            // rbnTxtPatName
            // 
            this.rbnTxtPatName.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnTxtPatName.Location = new System.Drawing.Point(94, 44);
            this.rbnTxtPatName.Name = "rbnTxtPatName";
            this.rbnTxtPatName.Size = new System.Drawing.Size(112, 22);
            this.rbnTxtPatName.TabIndex = 1;
            this.rbnTxtPatName.TextChanged += new System.EventHandler(this.rbnTxtPatName_TextChanged);
            // 
            // lblPatAge
            // 
            this.lblPatAge.BackColor = System.Drawing.Color.Transparent;
            this.lblPatAge.ForeColor = System.Drawing.Color.Black;
            this.lblPatAge.Location = new System.Drawing.Point(11, 203);
            this.lblPatAge.Name = "lblPatAge";
            this.lblPatAge.Size = new System.Drawing.Size(77, 19);
            labelStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblPatAge.Style = labelStyle2;
            this.lblPatAge.TabIndex = 0;
            this.lblPatAge.TabStop = false;
            this.lblPatAge.Text = "Patiant Age";
            // 
            // lblPID
            // 
            this.lblPID.BackColor = System.Drawing.Color.Transparent;
            this.lblPID.ForeColor = System.Drawing.Color.Black;
            this.lblPID.Location = new System.Drawing.Point(11, 16);
            this.lblPID.Name = "lblPID";
            this.lblPID.Size = new System.Drawing.Size(77, 22);
            labelStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblPID.Style = labelStyle3;
            this.lblPID.TabIndex = 0;
            this.lblPID.TabStop = false;
            this.lblPID.Text = "Patiant ID";
            // 
            // lblPatName
            // 
            this.lblPatName.BackColor = System.Drawing.Color.Transparent;
            this.lblPatName.ForeColor = System.Drawing.Color.Black;
            this.lblPatName.Location = new System.Drawing.Point(11, 44);
            this.lblPatName.Name = "lblPatName";
            this.lblPatName.Size = new System.Drawing.Size(77, 22);
            labelStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblPatName.Style = labelStyle4;
            this.lblPatName.TabIndex = 0;
            this.lblPatName.TabStop = false;
            this.lblPatName.Text = "Patiant Name";
            // 
            // rbnTxtPatInfo
            // 
            this.rbnTxtPatInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rbnTxtPatInfo.Description = null;
            this.rbnTxtPatInfo.Location = new System.Drawing.Point(94, 72);
            this.rbnTxtPatInfo.Name = "rbnTxtPatInfo";
            screenTip1.BackColor = System.Drawing.Color.WhiteSmoke;
            screenTip1.BorderColor = System.Drawing.Color.DarkGray;
            screenTip1.FadeColor = System.Drawing.Color.White;
            screenTip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            screenTip1.ForeColor = System.Drawing.Color.Black;
            this.rbnTxtPatInfo.ScreenTip = screenTip1;
            this.rbnTxtPatInfo.Size = new System.Drawing.Size(173, 122);
            this.rbnTxtPatInfo.StickyLabel = stickyLabel1;
            richEditBoxStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.rbnTxtPatInfo.Style = richEditBoxStyle1;
            this.rbnTxtPatInfo.TabIndex = 2;
            this.rbnTxtPatInfo.TextFormatted = "";
            // 
            // rbnCboPatName
            // 
            this.rbnCboPatName.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnCboPatName.Location = new System.Drawing.Point(94, 44);
            this.rbnCboPatName.Name = "rbnCboPatName";
            this.rbnCboPatName.SelectedIndex = -1;
            this.rbnCboPatName.SelectedItem = null;
            this.rbnCboPatName.Size = new System.Drawing.Size(112, 22);
            this.rbnCboPatName.TabIndex = 5;
            this.rbnCboPatName.Text = "Select Patiant";
            this.rbnCboPatName.SelectedIndexChanged += new System.EventHandler(this.rbnCboPatName_SelectedIndexChanged);
            // 
            // frmPatiantControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 261);
            this.Controls.Add(this.rbnfrmPatiantControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPatiantControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Operation] Image";
            this.Load += new System.EventHandler(this.frmPatiantControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rbnfrmPatiantControl)).EndInit();
            this.rbnfrmPatiantControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbnSblPan)).EndInit();
            this.rbnPanPatControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblPatInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPatAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPatName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbnTxtPatInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PureComponents.ActionSet.RibbonUI.RibbonForm rbnfrmPatiantControl;
        private PureComponents.ActionSet.RibbonUI.RibbonScrollablePanel rbnSblPan;
        private PureComponents.ActionSet.RibbonUI.RibbonPanel rbnPanPatControl;
        private PureComponents.EntrySet.Controls.Label lblPatInfo;
        private PureComponents.EntrySet.Controls.Label lblPatName;
        private PureComponents.ActionSet.RibbonUI.RibbonTextBox rbnTxtPatName;
        private PureComponents.EntrySet.Controls.RichEditBox rbnTxtPatInfo;
        private PureComponents.ActionSet.RibbonUI.RibbonButton rbnBtnCancel;
        private PureComponents.ActionSet.RibbonUI.RibbonButton rbnBtnDone;
        private System.Windows.Forms.OpenFileDialog OFD;
        private PureComponents.EntrySet.Controls.Label lblPatAge;
        private PureComponents.ActionSet.RibbonUI.RibbonTextBox rbnTxtPID;
        private PureComponents.EntrySet.Controls.Label lblPID;
        private PureComponents.ActionSet.RibbonUI.RibbonTextBox rbnTxtPatAge;
        private PureComponents.ActionSet.RibbonUI.RibbonComboBox rbnCboPatName;
    }
}