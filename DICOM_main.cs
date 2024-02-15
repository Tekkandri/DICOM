using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DICOM
{
    public partial class DICOM_main : Form
    {
        private Elements_list element_list;
        DICOM_elements dicom_elements_form;
        public DICOM_main()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            element_list = new Elements_list();
            element_list.LoadXML("dicom-elements.xml");
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "DICOM file (.DCM)|*.DCM";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dicom_elements_form = new DICOM_elements(openFileDialog.FileName, element_list);
                    dicom_elements_form.MdiParent = this;
                    dicom_elements_form.Show();
                    ToolStripMenuItem item = new ToolStripMenuItem(dicom_elements_form.Text);
                    tsmiWindow.DropDownItems.Add(item);
                    item.Click += new EventHandler(ItemClick);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsmiExportToXML_Click(object sender, EventArgs e)
        {
            DICOM_elements tmpform = this.ActiveMdiChild as DICOM_elements;
            saveFileDialog.Filter = "XML files(*.xml) | *.xml | All files(*.*) | *.* ";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tmpform.dicom_file.SaveXML(saveFileDialog.FileName);
            }
        }

        private void tsmiExportImage_Click(object sender, EventArgs e)
        {
            DICOM_elements tmpform = this.ActiveMdiChild as DICOM_elements;
            saveFileDialog.Filter = "PNG files(*.png) | *.png |JPEG files(*.jpeg) | *.jpeg |BMP files(*.bmp) | *.bmp | All files(*.*) | *.* ";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filter = System.IO.Path.GetExtension(saveFileDialog.FileName);
                switch (filter)
                {
                    case ".bmp": tmpform.dicom_file.bmp.Save(saveFileDialog.FileName, ImageFormat.Bmp); break;
                    case ".jpeg": tmpform.dicom_file.bmp.Save(saveFileDialog.FileName, ImageFormat.Jpeg); break;
                    case ".png": tmpform.dicom_file.bmp.Save(saveFileDialog.FileName, ImageFormat.Png); break;
                }
            }
        }

        private void tsbZoomIp_Click(object sender, EventArgs e)
        {
            DICOM_elements tmpform = this.ActiveMdiChild as DICOM_elements;
            tmpform.Zoom(ZoomVar.ZoomIn);
            tsslZoom.Text = "Zoom: " + (tmpform.zoom * 100).ToString() +"%";
        }

        private void tsbZoomOut_Click(object sender, EventArgs e)
        {
            DICOM_elements tmpform = this.ActiveMdiChild as DICOM_elements;
            tmpform.Zoom(ZoomVar.ZoomOut);
            tsslZoom.Text = "Zoom: " + (tmpform.zoom * 100).ToString() + "%";
        }

        private void tsbZoomToWidth_Click(object sender, EventArgs e)
        {
            DICOM_elements tmpform = this.ActiveMdiChild as DICOM_elements;
            tmpform.Zoom(ZoomVar.ZoomToWidth);
            tsslZoom.Text = "Zoom: " + (tmpform.zoom * 100).ToString() + "%";
        }

        private void tsbZoomOrig_Click(object sender, EventArgs e)
        {
            DICOM_elements tmpform = this.ActiveMdiChild as DICOM_elements;
            tmpform.Zoom(ZoomVar.Zoom100);
            tsslZoom.Text = "Zoom: " + (tmpform.zoom * 100).ToString() + "%";
        }

        private void DICOM_main_Load(object sender, EventArgs e)
        {
            tsbSaveImage.Enabled = false;
            tsbSaveXML.Enabled = false;

            tsbZoomIp.Enabled = false;
            tsbZoomOrig.Enabled = false;
            tsbZoomOut.Enabled = false;
            tsbZoomToWidth.Enabled = false;

            tsmiExportImage.Enabled = false;
            tsmiExportToXML.Enabled = false;

            tsmiVertical.Enabled = false;
            tsmiHorizont.Enabled = false;
            tsmiCascade.Enabled = false;
            tsmiCloseAll.Enabled = false;

            tsmiFileToolbar.Checked = true;
            tsmiImageToolbar.Checked = true;
        }

        private void DICOM_main_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                tsbSaveImage.Enabled = true;
                tsbSaveXML.Enabled = true;

                tsbZoomIp.Enabled = true;
                tsbZoomOrig.Enabled = true;
                tsbZoomOut.Enabled = true;
                tsbZoomToWidth.Enabled = true;

                tsmiExportImage.Enabled = true;
                tsmiExportToXML.Enabled = true;

                tsmiVertical.Enabled = true;
                tsmiHorizont.Enabled = true;
                tsmiCascade.Enabled = true;
                tsmiCloseAll.Enabled = true;

                tsslResolution.Text = ((DICOM_elements)this.ActiveMdiChild).dicom_file.img_size.Width.ToString() + " x " + ((DICOM_elements)this.ActiveMdiChild).dicom_file.img_size.Height.ToString();
                tsslZoom.Text = "Zoom: " + (((DICOM_elements)this.ActiveMdiChild).zoom * 100).ToString() + "%";
                tsslSize.Text = "Size: " + (((DICOM_elements)this.ActiveMdiChild).dicom_file.info.Length/1024).ToString()+" kb.";
                tsslCreateTime.Text = ((DICOM_elements)this.ActiveMdiChild).dicom_file.info.CreationTimeUtc.ToString();
                if (((DICOM_elements)this.ActiveMdiChild).dicom_file.implicit_vr)
                    tsslVR.Text = "Implicit VR";
                else
                    tsslVR.Text = "Explicit VR";
            }
            else
            {
                tsbSaveImage.Enabled = false;
                tsbSaveXML.Enabled = false;

                tsbZoomIp.Enabled = false;
                tsbZoomOrig.Enabled = false;
                tsbZoomOut.Enabled = false;
                tsbZoomToWidth.Enabled = false;

                tsmiExportImage.Enabled = false;
                tsmiExportToXML.Enabled = false;

                tsmiVertical.Enabled = false;
                tsmiHorizont.Enabled = false;
                tsmiCascade.Enabled = false;
                tsmiCloseAll.Enabled = false;
            }

        }

        public void Check_ChildForms()
        {
            if (this.ActiveMdiChild != null)
            {
                tsbSaveImage.Enabled = true;
                tsbSaveXML.Enabled = true;

                tsbZoomIp.Enabled = true;
                tsbZoomOrig.Enabled = true;
                tsbZoomOut.Enabled = true;
                tsbZoomToWidth.Enabled = true;

                tsmiExportImage.Enabled = true;
                tsmiExportToXML.Enabled = true;

                tsmiVertical.Enabled = true;
                tsmiHorizont.Enabled = true;
                tsmiCascade.Enabled = true;
                tsmiCloseAll.Enabled = true;
            }
            else
            {
                tsbSaveImage.Enabled = false;
                tsbSaveXML.Enabled = false;

                tsbZoomIp.Enabled = false;
                tsbZoomOrig.Enabled = false;
                tsbZoomOut.Enabled = false;
                tsbZoomToWidth.Enabled = false;

                tsmiExportImage.Enabled = false;
                tsmiExportToXML.Enabled = false;

                tsmiVertical.Enabled = false;
                tsmiHorizont.Enabled = false;
                tsmiCascade.Enabled = false;
                tsmiCloseAll.Enabled = false;

            }
        }

        private void tsmiVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void tsmiHorizont_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tsmiCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tsmiCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
        }
        private void ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            foreach (Form form in MdiChildren)
                if (form.Text == item.Text)
                    form.BringToFront();
                    
        }
        public void DelItem(string name)
        {
            for(int i = 0; i< tsmiWindow.DropDownItems.Count;i++)
                if(tsmiWindow.DropDownItems[i].Text == name)
                    tsmiWindow.DropDownItems.RemoveAt(i);

            tsslResolution.Text = "";
            tsslZoom.Text = "";
            tsslSize.Text = "";
            tsslCreateTime.Text = "";
            tsslVR.Text = "";
        }

        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We're no strangers to love\r\nYou know the rules and so do I\r\nA full commitment's what I'm thinking of\r\nYou wouldn't get this from any other guy\r\nI just wanna tell you how I'm feeling\r\nGotta make you understand\r\nNever gonna give you up\r\nNever gonna let you down\r\nNever gonna run around and desert you\r\nNever gonna make you cry\r\nNever gonna say goodbye\r\nNever gonna tell a lie and hurt you", "You're RICK ROLLED !!111!!11!!11!1!1");
        }

        private void tsmiFileToolbar_Click(object sender, EventArgs e)
        {
            if(tsmiFileToolbar.Checked == true)
            {
                tsmiFileToolbar.Checked = false;
                tsFileCommands.Visible = false;
            }
            else
            {
                tsmiFileToolbar.Checked = true;
                tsFileCommands.Visible = true;
            }
        }

        private void tsmiImageToolbar_Click(object sender, EventArgs e)
        {
            if (tsmiImageToolbar.Checked == true)
            {
                tsmiImageToolbar.Checked = false;
                tsZoom.Visible = false;
            }
            else
            {
                tsmiImageToolbar.Checked = true;
                tsZoom.Visible = true;
            }
        }
    }
}
