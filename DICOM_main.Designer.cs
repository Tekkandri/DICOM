namespace DICOM
{
    partial class DICOM_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DICOM_main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExportImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportToXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImageToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHorizont = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tsFileCommands = new System.Windows.Forms.ToolStrip();
            this.tsbOpenFIle = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveXML = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveImage = new System.Windows.Forms.ToolStripButton();
            this.tsZoom = new System.Windows.Forms.ToolStrip();
            this.tsbZoomIp = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomToWidth = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOrig = new System.Windows.Forms.ToolStripButton();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslResolution = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslVR = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCreateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip.SuspendLayout();
            this.tsFileCommands.SuspendLayout();
            this.tsZoom.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.видToolStripMenuItem,
            this.tsmiWindow,
            this.tsmiHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1050, 36);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.toolStripSeparator1,
            this.tsmiExportImage,
            this.tsmiExportToXML,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(69, 32);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(363, 34);
            this.tsmiOpen.Text = "Открыть";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(360, 6);
            // 
            // tsmiExportImage
            // 
            this.tsmiExportImage.Name = "tsmiExportImage";
            this.tsmiExportImage.Size = new System.Drawing.Size(363, 34);
            this.tsmiExportImage.Text = "Экспортировать изображение";
            this.tsmiExportImage.Click += new System.EventHandler(this.tsmiExportImage_Click);
            // 
            // tsmiExportToXML
            // 
            this.tsmiExportToXML.Name = "tsmiExportToXML";
            this.tsmiExportToXML.Size = new System.Drawing.Size(363, 34);
            this.tsmiExportToXML.Text = "Экспорт в XML";
            this.tsmiExportToXML.Click += new System.EventHandler(this.tsmiExportToXML_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(360, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(363, 34);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileToolbar,
            this.tsmiImageToolbar});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(58, 32);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // tsmiFileToolbar
            // 
            this.tsmiFileToolbar.Name = "tsmiFileToolbar";
            this.tsmiFileToolbar.Size = new System.Drawing.Size(421, 34);
            this.tsmiFileToolbar.Text = "Панель инструментов (Файл)";
            this.tsmiFileToolbar.Click += new System.EventHandler(this.tsmiFileToolbar_Click);
            // 
            // tsmiImageToolbar
            // 
            this.tsmiImageToolbar.Name = "tsmiImageToolbar";
            this.tsmiImageToolbar.Size = new System.Drawing.Size(421, 34);
            this.tsmiImageToolbar.Text = "Панель инструментов (Изображение)";
            this.tsmiImageToolbar.Click += new System.EventHandler(this.tsmiImageToolbar_Click);
            // 
            // tsmiWindow
            // 
            this.tsmiWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVertical,
            this.tsmiHorizont,
            this.tsmiCascade,
            this.toolStripSeparator3,
            this.tsmiCloseAll,
            this.toolStripSeparator4});
            this.tsmiWindow.Name = "tsmiWindow";
            this.tsmiWindow.Size = new System.Drawing.Size(72, 32);
            this.tsmiWindow.Text = "Окно";
            // 
            // tsmiVertical
            // 
            this.tsmiVertical.Name = "tsmiVertical";
            this.tsmiVertical.Size = new System.Drawing.Size(238, 34);
            this.tsmiVertical.Text = "Вертикально";
            this.tsmiVertical.Click += new System.EventHandler(this.tsmiVertical_Click);
            // 
            // tsmiHorizont
            // 
            this.tsmiHorizont.Name = "tsmiHorizont";
            this.tsmiHorizont.Size = new System.Drawing.Size(238, 34);
            this.tsmiHorizont.Text = "Горизонтально";
            this.tsmiHorizont.Click += new System.EventHandler(this.tsmiHorizont_Click);
            // 
            // tsmiCascade
            // 
            this.tsmiCascade.Name = "tsmiCascade";
            this.tsmiCascade.Size = new System.Drawing.Size(238, 34);
            this.tsmiCascade.Text = "Каскад";
            this.tsmiCascade.Click += new System.EventHandler(this.tsmiCascade_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(235, 6);
            // 
            // tsmiCloseAll
            // 
            this.tsmiCloseAll.Name = "tsmiCloseAll";
            this.tsmiCloseAll.Size = new System.Drawing.Size(238, 34);
            this.tsmiCloseAll.Text = "Закрыть все";
            this.tsmiCloseAll.Click += new System.EventHandler(this.tsmiCloseAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(235, 6);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(97, 32);
            this.tsmiHelp.Text = "Справка";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmiHelp_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tsFileCommands
            // 
            this.tsFileCommands.Dock = System.Windows.Forms.DockStyle.None;
            this.tsFileCommands.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsFileCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpenFIle,
            this.tsbSaveXML,
            this.tsbSaveImage});
            this.tsFileCommands.Location = new System.Drawing.Point(9, 22);
            this.tsFileCommands.Name = "tsFileCommands";
            this.tsFileCommands.Size = new System.Drawing.Size(120, 38);
            this.tsFileCommands.TabIndex = 1;
            this.tsFileCommands.Text = "toolStrip1";
            // 
            // tsbOpenFIle
            // 
            this.tsbOpenFIle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenFIle.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenFIle.Image")));
            this.tsbOpenFIle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenFIle.Name = "tsbOpenFIle";
            this.tsbOpenFIle.Size = new System.Drawing.Size(34, 33);
            this.tsbOpenFIle.Text = "tsbOpenFile";
            this.tsbOpenFIle.ToolTipText = "Открыть файл\r\n";
            this.tsbOpenFIle.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsbSaveXML
            // 
            this.tsbSaveXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveXML.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveXML.Image")));
            this.tsbSaveXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveXML.Name = "tsbSaveXML";
            this.tsbSaveXML.Size = new System.Drawing.Size(34, 33);
            this.tsbSaveXML.Text = "tsmiSaveXML";
            this.tsbSaveXML.ToolTipText = "Сохранить XML\r\n";
            this.tsbSaveXML.Click += new System.EventHandler(this.tsmiExportToXML_Click);
            // 
            // tsbSaveImage
            // 
            this.tsbSaveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveImage.Image")));
            this.tsbSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveImage.Name = "tsbSaveImage";
            this.tsbSaveImage.Size = new System.Drawing.Size(34, 33);
            this.tsbSaveImage.Text = "tsbSaveImage";
            this.tsbSaveImage.ToolTipText = "Сохранить изображение\r\n";
            this.tsbSaveImage.Click += new System.EventHandler(this.tsmiExportImage_Click);
            // 
            // tsZoom
            // 
            this.tsZoom.Dock = System.Windows.Forms.DockStyle.None;
            this.tsZoom.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsZoom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbZoomIp,
            this.tsbZoomOut,
            this.tsbZoomToWidth,
            this.tsbZoomOrig});
            this.tsZoom.Location = new System.Drawing.Point(144, 22);
            this.tsZoom.Name = "tsZoom";
            this.tsZoom.Size = new System.Drawing.Size(154, 33);
            this.tsZoom.TabIndex = 2;
            this.tsZoom.Text = "tsZoom";
            // 
            // tsbZoomIp
            // 
            this.tsbZoomIp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomIp.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomIp.Image")));
            this.tsbZoomIp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomIp.Name = "tsbZoomIp";
            this.tsbZoomIp.Size = new System.Drawing.Size(34, 28);
            this.tsbZoomIp.Text = "tsbZoomIp";
            this.tsbZoomIp.ToolTipText = "Увеличить зум\r\n";
            this.tsbZoomIp.Click += new System.EventHandler(this.tsbZoomIp_Click);
            // 
            // tsbZoomOut
            // 
            this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomOut.Image")));
            this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomOut.Name = "tsbZoomOut";
            this.tsbZoomOut.Size = new System.Drawing.Size(34, 28);
            this.tsbZoomOut.Text = "tsbZoomOut";
            this.tsbZoomOut.ToolTipText = "Уменьшить зум";
            this.tsbZoomOut.Click += new System.EventHandler(this.tsbZoomOut_Click);
            // 
            // tsbZoomToWidth
            // 
            this.tsbZoomToWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomToWidth.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomToWidth.Image")));
            this.tsbZoomToWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomToWidth.Name = "tsbZoomToWidth";
            this.tsbZoomToWidth.Size = new System.Drawing.Size(34, 28);
            this.tsbZoomToWidth.Text = "tsbZoomToWidth";
            this.tsbZoomToWidth.ToolTipText = "По ширине";
            this.tsbZoomToWidth.Click += new System.EventHandler(this.tsbZoomToWidth_Click);
            // 
            // tsbZoomOrig
            // 
            this.tsbZoomOrig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomOrig.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomOrig.Image")));
            this.tsbZoomOrig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomOrig.Name = "tsbZoomOrig";
            this.tsbZoomOrig.Size = new System.Drawing.Size(34, 28);
            this.tsbZoomOrig.Text = "tsbZoomOrig";
            this.tsbZoomOrig.ToolTipText = "Оригинальный размер";
            this.tsbZoomOrig.Click += new System.EventHandler(this.tsbZoomOrig_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslZoom,
            this.tsslResolution,
            this.tsslSize,
            this.tsslVR,
            this.tsslCreateTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 541);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1050, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tsslZoom
            // 
            this.tsslZoom.Name = "tsslZoom";
            this.tsslZoom.Size = new System.Drawing.Size(0, 15);
            // 
            // tsslResolution
            // 
            this.tsslResolution.Name = "tsslResolution";
            this.tsslResolution.Size = new System.Drawing.Size(0, 15);
            // 
            // tsslSize
            // 
            this.tsslSize.Name = "tsslSize";
            this.tsslSize.Size = new System.Drawing.Size(0, 15);
            // 
            // tsslVR
            // 
            this.tsslVR.Name = "tsslVR";
            this.tsslVR.Size = new System.Drawing.Size(0, 15);
            // 
            // tsslCreateTime
            // 
            this.tsslCreateTime.Name = "tsslCreateTime";
            this.tsslCreateTime.Size = new System.Drawing.Size(0, 15);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tsFileCommands);
            this.groupBox1.Controls.Add(this.tsZoom);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1050, 64);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // DICOM_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1050, 563);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "DICOM_main";
            this.Text = "DICOM";
            this.Load += new System.EventHandler(this.DICOM_main_Load);
            this.MdiChildActivate += new System.EventHandler(this.DICOM_main_MdiChildActivate);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tsFileCommands.ResumeLayout(false);
            this.tsFileCommands.PerformLayout();
            this.tsZoom.ResumeLayout(false);
            this.tsZoom.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportToXML;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiVertical;
        private System.Windows.Forms.ToolStripMenuItem tsmiHorizont;
        private System.Windows.Forms.ToolStripMenuItem tsmiCascade;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseAll;
        private System.Windows.Forms.ToolStrip tsFileCommands;
        private System.Windows.Forms.ToolStripButton tsbOpenFIle;
        private System.Windows.Forms.ToolStripButton tsbSaveXML;
        private System.Windows.Forms.ToolStripButton tsbSaveImage;
        private System.Windows.Forms.ToolStrip tsZoom;
        private System.Windows.Forms.ToolStripButton tsbZoomIp;
        private System.Windows.Forms.ToolStripButton tsbZoomOut;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbZoomToWidth;
        private System.Windows.Forms.ToolStripButton tsbZoomOrig;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslZoom;
        private System.Windows.Forms.ToolStripStatusLabel tsslResolution;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripStatusLabel tsslSize;
        private System.Windows.Forms.ToolStripStatusLabel tsslCreateTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslVR;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileToolbar;
        private System.Windows.Forms.ToolStripMenuItem tsmiImageToolbar;
    }
}

