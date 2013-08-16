namespace XCBIR
{
    partial class frmAddDBConnection
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
            PureComponents.EntrySet.Controls.CheckBoxStyle checkBoxStyle1 = new PureComponents.EntrySet.Controls.CheckBoxStyle();
            PureComponents.EntrySet.Controls.CheckSignStyle checkSignStyle1 = new PureComponents.EntrySet.Controls.CheckSignStyle();
            PureComponents.EntrySet.Controls.CheckBoxLabelStyle checkBoxLabelStyle1 = new PureComponents.EntrySet.Controls.CheckBoxLabelStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddDBConnection));
            PureComponents.EntrySet.Controls.ScreenTip screenTip1 = new PureComponents.EntrySet.Controls.ScreenTip();
            PureComponents.EntrySet.Controls.StickyLabel stickyLabel1 = new PureComponents.EntrySet.Controls.StickyLabel();
            PureComponents.EntrySet.Controls.RichEditBoxStyle richEditBoxStyle1 = new PureComponents.EntrySet.Controls.RichEditBoxStyle();
            PureComponents.EntrySet.Controls.LabelStyle labelStyle1 = new PureComponents.EntrySet.Controls.LabelStyle();
            this.rbnFrmAddDBConn = new PureComponents.ActionSet.RibbonUI.RibbonForm();
            this.ribbonScrollablePanel1 = new PureComponents.ActionSet.RibbonUI.RibbonScrollablePanel();
            this.ribbonPanel1 = new PureComponents.ActionSet.RibbonUI.RibbonPanel();
            this.chkDefualt = new PureComponents.EntrySet.Controls.CheckBox();
            this.ribbonButton1 = new PureComponents.ActionSet.RibbonUI.RibbonButton();
            this.rbnBtnAdd = new PureComponents.ActionSet.RibbonUI.RibbonButton();
            this.rbnTxtConnStr = new PureComponents.EntrySet.Controls.RichEditBox();
            this.lblConn = new PureComponents.EntrySet.Controls.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rbnFrmAddDBConn)).BeginInit();
            this.rbnFrmAddDBConn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonScrollablePanel1)).BeginInit();
            this.ribbonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbnTxtConnStr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblConn)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnFrmAddDBConn
            // 
            this.rbnFrmAddDBConn.ClientContainer = this.ribbonScrollablePanel1;
            this.rbnFrmAddDBConn.Controls.Add(this.ribbonScrollablePanel1);
            this.rbnFrmAddDBConn.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnFrmAddDBConn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbnFrmAddDBConn.Icon = ((System.Drawing.Image)(resources.GetObject("rbnFrmAddDBConn.Icon")));
            this.rbnFrmAddDBConn.Location = new System.Drawing.Point(0, 0);
            this.rbnFrmAddDBConn.Name = "rbnFrmAddDBConn";
            this.rbnFrmAddDBConn.ShowButtonBar = false;
            this.rbnFrmAddDBConn.ShowMaximizeButton = false;
            this.rbnFrmAddDBConn.ShowMinimizeButton = false;
            this.rbnFrmAddDBConn.ShowResizeHandler = false;
            this.rbnFrmAddDBConn.Size = new System.Drawing.Size(529, 205);
            this.rbnFrmAddDBConn.TabIndex = 0;
            this.rbnFrmAddDBConn.Text = "Add DB Connection";
            // 
            // ribbonScrollablePanel1
            // 
            this.ribbonScrollablePanel1.BackColor = System.Drawing.Color.Transparent;
            this.ribbonScrollablePanel1.FormBackground = PureComponents.ActionSet.RibbonUI.RibbonBackground.Curvature1;
            this.ribbonScrollablePanel1.InnerControl = this.ribbonPanel1;
            this.ribbonScrollablePanel1.Location = new System.Drawing.Point(1, 28);
            this.ribbonScrollablePanel1.Name = "ribbonScrollablePanel1";
            this.ribbonScrollablePanel1.Size = new System.Drawing.Size(526, 174);
            this.ribbonScrollablePanel1.TabIndex = 1;
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.BackColor = System.Drawing.Color.Transparent;
            this.ribbonPanel1.Controls.Add(this.chkDefualt);
            this.ribbonPanel1.Controls.Add(this.ribbonButton1);
            this.ribbonPanel1.Controls.Add(this.rbnBtnAdd);
            this.ribbonPanel1.Controls.Add(this.rbnTxtConnStr);
            this.ribbonPanel1.Controls.Add(this.lblConn);
            this.ribbonPanel1.FormBackground = PureComponents.ActionSet.RibbonUI.RibbonBackground.Curvature1;
            this.ribbonPanel1.Location = new System.Drawing.Point(10, 0);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Size = new System.Drawing.Size(526, 159);
            this.ribbonPanel1.TabIndex = 0;
            // 
            // chkDefualt
            // 
            this.chkDefualt.Description = null;
            this.chkDefualt.Location = new System.Drawing.Point(11, 136);
            this.chkDefualt.Name = "chkDefualt";
            this.chkDefualt.Size = new System.Drawing.Size(100, 20);
            checkSignStyle1.BackColor = System.Drawing.Color.White;
            checkSignStyle1.ForeColor = System.Drawing.Color.DodgerBlue;
            checkBoxStyle1.CheckStyle = checkSignStyle1;
            checkBoxStyle1.LabelStyle = checkBoxLabelStyle1;
            checkBoxStyle1.Theme = PureComponents.EntrySet.Controls.CheckBoxTheme.Flat;
            this.chkDefualt.Style = checkBoxStyle1;
            this.chkDefualt.TabIndex = 1;
            this.chkDefualt.Text = "Default";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ribbonButton1.DrawBorder = true;
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.ImageAlign = PureComponents.ActionSet.Common.ImageAlignment.Left;
            this.ribbonButton1.Location = new System.Drawing.Point(338, 136);
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.Size = new System.Drawing.Size(86, 23);
            this.ribbonButton1.TabIndex = 3;
            this.ribbonButton1.Text = "Cancel";
            this.ribbonButton1.Click += new System.EventHandler(this.ribbonButton1_Click);
            // 
            // rbnBtnAdd
            // 
            this.rbnBtnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnBtnAdd.DrawBorder = true;
            this.rbnBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("rbnBtnAdd.Image")));
            this.rbnBtnAdd.ImageAlign = PureComponents.ActionSet.Common.ImageAlignment.Left;
            this.rbnBtnAdd.Location = new System.Drawing.Point(430, 136);
            this.rbnBtnAdd.Name = "rbnBtnAdd";
            this.rbnBtnAdd.Size = new System.Drawing.Size(86, 23);
            this.rbnBtnAdd.TabIndex = 2;
            this.rbnBtnAdd.Text = "Add";
            this.rbnBtnAdd.Click += new System.EventHandler(this.rbnBtnAdd_Click);
            // 
            // rbnTxtConnStr
            // 
            this.rbnTxtConnStr.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rbnTxtConnStr.Description = null;
            this.rbnTxtConnStr.Location = new System.Drawing.Point(11, 42);
            this.rbnTxtConnStr.Name = "rbnTxtConnStr";
            screenTip1.BackColor = System.Drawing.Color.WhiteSmoke;
            screenTip1.BorderColor = System.Drawing.Color.DarkGray;
            screenTip1.FadeColor = System.Drawing.Color.White;
            screenTip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            screenTip1.ForeColor = System.Drawing.Color.Black;
            this.rbnTxtConnStr.ScreenTip = screenTip1;
            this.rbnTxtConnStr.Size = new System.Drawing.Size(505, 88);
            this.rbnTxtConnStr.StickyLabel = stickyLabel1;
            richEditBoxStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.rbnTxtConnStr.Style = richEditBoxStyle1;
            this.rbnTxtConnStr.TabIndex = 0;
            this.rbnTxtConnStr.TextFormatted = "";
            // 
            // lblConn
            // 
            this.lblConn.BackColor = System.Drawing.Color.Transparent;
            this.lblConn.ForeColor = System.Drawing.Color.Black;
            this.lblConn.Location = new System.Drawing.Point(11, 14);
            this.lblConn.Name = "lblConn";
            this.lblConn.Size = new System.Drawing.Size(105, 22);
            labelStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblConn.Style = labelStyle1;
            this.lblConn.TabIndex = 1;
            this.lblConn.TabStop = false;
            this.lblConn.Text = "Connection String";
            // 
            // frmAddDBConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 205);
            this.Controls.Add(this.rbnFrmAddDBConn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddDBConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add DB Connection";
            ((System.ComponentModel.ISupportInitialize)(this.rbnFrmAddDBConn)).EndInit();
            this.rbnFrmAddDBConn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonScrollablePanel1)).EndInit();
            this.ribbonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbnTxtConnStr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblConn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PureComponents.ActionSet.RibbonUI.RibbonForm rbnFrmAddDBConn;
        private PureComponents.ActionSet.RibbonUI.RibbonScrollablePanel ribbonScrollablePanel1;
        private PureComponents.ActionSet.RibbonUI.RibbonPanel ribbonPanel1;
        private PureComponents.EntrySet.Controls.Label lblConn;
        private PureComponents.EntrySet.Controls.RichEditBox rbnTxtConnStr;
        private PureComponents.ActionSet.RibbonUI.RibbonButton rbnBtnAdd;
        private PureComponents.ActionSet.RibbonUI.RibbonButton ribbonButton1;
        private PureComponents.EntrySet.Controls.CheckBox chkDefualt;
    }
}