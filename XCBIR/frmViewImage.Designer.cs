namespace XCBIR
{
    partial class frmViewImage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewImage));
            this.rbnFrmViewImage = new PureComponents.ActionSet.RibbonUI.RibbonForm();
            this.rbnSblPan = new PureComponents.ActionSet.RibbonUI.RibbonScrollablePanel();
            this.rbnPanMain = new PureComponents.ActionSet.RibbonUI.RibbonPanel();
            this.trkBarZoom = new System.Windows.Forms.TrackBar();
            this.lblBCValue = new System.Windows.Forms.Label();
            this.trkBar = new System.Windows.Forms.TrackBar();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tlStrpBright = new System.Windows.Forms.ToolStripButton();
            this.tlStrpContrast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlStrpUndo = new System.Windows.Forms.ToolStripButton();
            this.tlStrpRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.rbnBtnZoomOUT = new System.Windows.Forms.ToolStripButton();
            this.rbnBtnZoomIN = new System.Windows.Forms.ToolStripButton();
            this.tlStrpReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlStrpCancel = new System.Windows.Forms.ToolStripButton();
            this.tlStrpSave = new System.Windows.Forms.ToolStripButton();
            this.picViewImage = new System.Windows.Forms.PictureBox();
            this.trackBarHider = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rbnFrmViewImage)).BeginInit();
            this.rbnFrmViewImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbnSblPan)).BeginInit();
            this.rbnPanMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkBarZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBar)).BeginInit();
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picViewImage)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnFrmViewImage
            // 
            this.rbnFrmViewImage.ClientContainer = this.rbnSblPan;
            this.rbnFrmViewImage.Controls.Add(this.rbnSblPan);
            this.rbnFrmViewImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnFrmViewImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbnFrmViewImage.Icon = ((System.Drawing.Image)(resources.GetObject("rbnFrmViewImage.Icon")));
            this.rbnFrmViewImage.Location = new System.Drawing.Point(0, 0);
            this.rbnFrmViewImage.Name = "rbnFrmViewImage";
            this.rbnFrmViewImage.ShowButtonBar = false;
            this.rbnFrmViewImage.Size = new System.Drawing.Size(1036, 780);
            this.rbnFrmViewImage.TabIndex = 0;
            this.rbnFrmViewImage.Text = "View Image";
            this.rbnFrmViewImage.Click += new System.EventHandler(this.rbnFrmViewImage_Click);
            // 
            // rbnSblPan
            // 
            this.rbnSblPan.BackColor = System.Drawing.Color.Transparent;
            this.rbnSblPan.FormBackground = PureComponents.ActionSet.RibbonUI.RibbonBackground.Curvature1;
            this.rbnSblPan.InnerControl = this.rbnPanMain;
            this.rbnSblPan.Location = new System.Drawing.Point(1, 28);
            this.rbnSblPan.Name = "rbnSblPan";
            this.rbnSblPan.Size = new System.Drawing.Size(1033, 749);
            this.rbnSblPan.TabIndex = 1;
            // 
            // rbnPanMain
            // 
            this.rbnPanMain.BackColor = System.Drawing.Color.Transparent;
            this.rbnPanMain.Controls.Add(this.trkBarZoom);
            this.rbnPanMain.Controls.Add(this.lblBCValue);
            this.rbnPanMain.Controls.Add(this.trkBar);
            this.rbnPanMain.Controls.Add(this.toolStripMain);
            this.rbnPanMain.Controls.Add(this.picViewImage);
            this.rbnPanMain.FormBackground = PureComponents.ActionSet.RibbonUI.RibbonBackground.Curvature1;
            this.rbnPanMain.Location = new System.Drawing.Point(0, 0);
            this.rbnPanMain.Name = "rbnPanMain";
            this.rbnPanMain.Size = new System.Drawing.Size(1033, 749);
            this.rbnPanMain.TabIndex = 0;
            // 
            // trkBarZoom
            // 
            this.trkBarZoom.AutoSize = false;
            this.trkBarZoom.BackColor = System.Drawing.Color.LightSteelBlue;
            this.trkBarZoom.Location = new System.Drawing.Point(897, 103);
            this.trkBarZoom.Maximum = 20;
            this.trkBarZoom.Minimum = 5;
            this.trkBarZoom.Name = "trkBarZoom";
            this.trkBarZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkBarZoom.Size = new System.Drawing.Size(26, 422);
            this.trkBarZoom.TabIndex = 5;
            this.trkBarZoom.Value = 10;
            this.trkBarZoom.Visible = false;
            this.trkBarZoom.Scroll += new System.EventHandler(this.trkBarZoom_Scroll);
            // 
            // lblBCValue
            // 
            this.lblBCValue.AutoSize = true;
            this.lblBCValue.Location = new System.Drawing.Point(8, 200);
            this.lblBCValue.Name = "lblBCValue";
            this.lblBCValue.Size = new System.Drawing.Size(13, 13);
            this.lblBCValue.TabIndex = 4;
            this.lblBCValue.Text = "0";
            this.lblBCValue.Visible = false;
            // 
            // trkBar
            // 
            this.trkBar.AutoSize = false;
            this.trkBar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.trkBar.Location = new System.Drawing.Point(8, 25);
            this.trkBar.Maximum = 100;
            this.trkBar.Minimum = -100;
            this.trkBar.Name = "trkBar";
            this.trkBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkBar.Size = new System.Drawing.Size(26, 173);
            this.trkBar.TabIndex = 3;
            this.trkBar.Visible = false;
            this.trkBar.MouseLeave += new System.EventHandler(this.trkBar_MouseLeave);
            this.trkBar.Scroll += new System.EventHandler(this.trkBar_Scroll);
            this.trkBar.MouseEnter += new System.EventHandler(this.trkBar_MouseEnter);
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlStrpBright,
            this.tlStrpContrast,
            this.toolStripSeparator1,
            this.tlStrpUndo,
            this.tlStrpRedo,
            this.toolStripSeparator3,
            this.rbnBtnZoomOUT,
            this.rbnBtnZoomIN,
            this.tlStrpReset,
            this.toolStripSeparator4,
            this.tlStrpCancel,
            this.tlStrpSave});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1033, 25);
            this.toolStripMain.TabIndex = 2;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // tlStrpBright
            // 
            this.tlStrpBright.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlStrpBright.Image = ((System.Drawing.Image)(resources.GetObject("tlStrpBright.Image")));
            this.tlStrpBright.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlStrpBright.Name = "tlStrpBright";
            this.tlStrpBright.Size = new System.Drawing.Size(23, 22);
            this.tlStrpBright.Text = "Brightness";
            this.tlStrpBright.Click += new System.EventHandler(this.tlStrpBright_Click);
            // 
            // tlStrpContrast
            // 
            this.tlStrpContrast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlStrpContrast.Image = ((System.Drawing.Image)(resources.GetObject("tlStrpContrast.Image")));
            this.tlStrpContrast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlStrpContrast.Name = "tlStrpContrast";
            this.tlStrpContrast.Size = new System.Drawing.Size(23, 22);
            this.tlStrpContrast.Text = "Contrast";
            this.tlStrpContrast.Click += new System.EventHandler(this.tlStrpContrast_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlStrpUndo
            // 
            this.tlStrpUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlStrpUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlStrpUndo.Image")));
            this.tlStrpUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlStrpUndo.Name = "tlStrpUndo";
            this.tlStrpUndo.Size = new System.Drawing.Size(23, 22);
            this.tlStrpUndo.Text = "Undo";
            this.tlStrpUndo.Click += new System.EventHandler(this.tlStrpUndo_Click);
            // 
            // tlStrpRedo
            // 
            this.tlStrpRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlStrpRedo.Image = ((System.Drawing.Image)(resources.GetObject("tlStrpRedo.Image")));
            this.tlStrpRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlStrpRedo.Name = "tlStrpRedo";
            this.tlStrpRedo.Size = new System.Drawing.Size(23, 22);
            this.tlStrpRedo.Text = "Redo";
            this.tlStrpRedo.Click += new System.EventHandler(this.tlStrpRedo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // rbnBtnZoomOUT
            // 
            this.rbnBtnZoomOUT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rbnBtnZoomOUT.Image = ((System.Drawing.Image)(resources.GetObject("rbnBtnZoomOUT.Image")));
            this.rbnBtnZoomOUT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rbnBtnZoomOUT.Name = "rbnBtnZoomOUT";
            this.rbnBtnZoomOUT.Size = new System.Drawing.Size(23, 22);
            this.rbnBtnZoomOUT.Text = "Zoom out";
            this.rbnBtnZoomOUT.Click += new System.EventHandler(this.rbnBtnZoomOUT_Click);
            // 
            // rbnBtnZoomIN
            // 
            this.rbnBtnZoomIN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rbnBtnZoomIN.Image = ((System.Drawing.Image)(resources.GetObject("rbnBtnZoomIN.Image")));
            this.rbnBtnZoomIN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rbnBtnZoomIN.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            this.rbnBtnZoomIN.Name = "rbnBtnZoomIN";
            this.rbnBtnZoomIN.Size = new System.Drawing.Size(23, 22);
            this.rbnBtnZoomIN.Text = "Zoom in";
            this.rbnBtnZoomIN.Click += new System.EventHandler(this.rbnBtnZoomIN_Click);
            // 
            // tlStrpReset
            // 
            this.tlStrpReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlStrpReset.Image = ((System.Drawing.Image)(resources.GetObject("tlStrpReset.Image")));
            this.tlStrpReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlStrpReset.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.tlStrpReset.Name = "tlStrpReset";
            this.tlStrpReset.Size = new System.Drawing.Size(23, 22);
            this.tlStrpReset.Text = "Reset the original imag";
            this.tlStrpReset.Click += new System.EventHandler(this.tlStrpReset_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tlStrpCancel
            // 
            this.tlStrpCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlStrpCancel.Image = ((System.Drawing.Image)(resources.GetObject("tlStrpCancel.Image")));
            this.tlStrpCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlStrpCancel.Name = "tlStrpCancel";
            this.tlStrpCancel.Size = new System.Drawing.Size(23, 22);
            this.tlStrpCancel.Text = "Cancel";
            this.tlStrpCancel.Click += new System.EventHandler(this.tlStrpCancel_Click);
            // 
            // tlStrpSave
            // 
            this.tlStrpSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlStrpSave.Image = ((System.Drawing.Image)(resources.GetObject("tlStrpSave.Image")));
            this.tlStrpSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlStrpSave.Name = "tlStrpSave";
            this.tlStrpSave.Size = new System.Drawing.Size(23, 22);
            this.tlStrpSave.Text = "Save";
            this.tlStrpSave.Click += new System.EventHandler(this.tlStrpSave_Click);
            // 
            // picViewImage
            // 
            this.picViewImage.Location = new System.Drawing.Point(390, 300);
            this.picViewImage.Name = "picViewImage";
            this.picViewImage.Size = new System.Drawing.Size(50, 50);
            this.picViewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picViewImage.TabIndex = 0;
            this.picViewImage.TabStop = false;
            this.picViewImage.Paint += new System.Windows.Forms.PaintEventHandler(this.picViewImage_Paint);
            // 
            // trackBarHider
            // 
            this.trackBarHider.Enabled = true;
            this.trackBarHider.Interval = 3000;
            this.trackBarHider.Tick += new System.EventHandler(this.trackBarHider_Tick);
            // 
            // frmViewImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 780);
            this.Controls.Add(this.rbnFrmViewImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Image";
            this.Load += new System.EventHandler(this.frmViewImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rbnFrmViewImage)).EndInit();
            this.rbnFrmViewImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbnSblPan)).EndInit();
            this.rbnPanMain.ResumeLayout(false);
            this.rbnPanMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkBarZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBar)).EndInit();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picViewImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PureComponents.ActionSet.RibbonUI.RibbonForm rbnFrmViewImage;
        private PureComponents.ActionSet.RibbonUI.RibbonScrollablePanel rbnSblPan;
        private PureComponents.ActionSet.RibbonUI.RibbonPanel rbnPanMain;
        private System.Windows.Forms.PictureBox picViewImage;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton tlStrpBright;
        private System.Windows.Forms.ToolStripButton tlStrpContrast;
        private System.Windows.Forms.TrackBar trkBar;
        private System.Windows.Forms.Label lblBCValue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlStrpUndo;
        private System.Windows.Forms.ToolStripButton tlStrpRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton rbnBtnZoomOUT;
        private System.Windows.Forms.TrackBar trkBarZoom;
        private System.Windows.Forms.ToolStripButton rbnBtnZoomIN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlStrpCancel;
        private System.Windows.Forms.ToolStripButton tlStrpReset;
        private System.Windows.Forms.ToolStripButton tlStrpSave;
        private System.Windows.Forms.Timer trackBarHider;
    }
}