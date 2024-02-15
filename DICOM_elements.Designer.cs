namespace DICOM
{
    partial class DICOM_elements
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
            this.gvDicomElements = new System.Windows.Forms.DataGridView();
            this.tbcTable = new System.Windows.Forms.TabControl();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.menuStripPatient = new System.Windows.Forms.MenuStrip();
            this.tsmiPatient = new System.Windows.Forms.ToolStripMenuItem();
            this.tabImage = new System.Windows.Forms.TabPage();
            this.panel = new System.Windows.Forms.Panel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvDicomElements)).BeginInit();
            this.tbcTable.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.menuStripPatient.SuspendLayout();
            this.tabImage.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gvDicomElements
            // 
            this.gvDicomElements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvDicomElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDicomElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDicomElements.Location = new System.Drawing.Point(3, 36);
            this.gvDicomElements.Name = "gvDicomElements";
            this.gvDicomElements.RowHeadersWidth = 62;
            this.gvDicomElements.RowTemplate.Height = 28;
            this.gvDicomElements.Size = new System.Drawing.Size(1254, 872);
            this.gvDicomElements.TabIndex = 0;
            // 
            // tbcTable
            // 
            this.tbcTable.Controls.Add(this.tabTable);
            this.tbcTable.Controls.Add(this.tabImage);
            this.tbcTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcTable.Location = new System.Drawing.Point(0, 0);
            this.tbcTable.Name = "tbcTable";
            this.tbcTable.SelectedIndex = 0;
            this.tbcTable.Size = new System.Drawing.Size(1268, 944);
            this.tbcTable.TabIndex = 4;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.gvDicomElements);
            this.tabTable.Controls.Add(this.menuStripPatient);
            this.tabTable.Location = new System.Drawing.Point(4, 29);
            this.tabTable.Name = "tabTable";
            this.tabTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabTable.Size = new System.Drawing.Size(1260, 911);
            this.tabTable.TabIndex = 0;
            this.tabTable.Text = "Таблица";
            this.tabTable.UseVisualStyleBackColor = true;
            // 
            // menuStripPatient
            // 
            this.menuStripPatient.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripPatient.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripPatient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPatient});
            this.menuStripPatient.Location = new System.Drawing.Point(3, 3);
            this.menuStripPatient.Name = "menuStripPatient";
            this.menuStripPatient.Size = new System.Drawing.Size(1254, 33);
            this.menuStripPatient.TabIndex = 1;
            this.menuStripPatient.Text = "menuStrip1";
            // 
            // tsmiPatient
            // 
            this.tsmiPatient.Name = "tsmiPatient";
            this.tsmiPatient.Size = new System.Drawing.Size(122, 29);
            this.tsmiPatient.Text = "О пациенте";
            this.tsmiPatient.Click += new System.EventHandler(this.tsmiPatient_Click);
            // 
            // tabImage
            // 
            this.tabImage.Controls.Add(this.panel);
            this.tabImage.Location = new System.Drawing.Point(4, 29);
            this.tabImage.Name = "tabImage";
            this.tabImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabImage.Size = new System.Drawing.Size(1260, 911);
            this.tabImage.TabIndex = 1;
            this.tabImage.Text = "Снимок";
            this.tabImage.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.pbImage);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(3, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1254, 905);
            this.panel.TabIndex = 1;
            // 
            // pbImage
            // 
            this.pbImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbImage.Location = new System.Drawing.Point(5, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(100, 50);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            this.pbImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseDown);
            this.pbImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseMove);
            this.pbImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseUp);
            // 
            // DICOM_elements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 944);
            this.Controls.Add(this.tbcTable);
            this.MainMenuStrip = this.menuStripPatient;
            this.Name = "DICOM_elements";
            this.Text = "DICOM_elements";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DICOM_elements_FormClosed);
            this.Load += new System.EventHandler(this.DICOM_elements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDicomElements)).EndInit();
            this.tbcTable.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tabTable.PerformLayout();
            this.menuStripPatient.ResumeLayout(false);
            this.menuStripPatient.PerformLayout();
            this.tabImage.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvDicomElements;
        private System.Windows.Forms.TabControl tbcTable;
        private System.Windows.Forms.TabPage tabTable;
        private System.Windows.Forms.TabPage tabImage;
        public System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.MenuStrip menuStripPatient;
        private System.Windows.Forms.ToolStripMenuItem tsmiPatient;
        public System.Windows.Forms.Panel panel;
    }
}