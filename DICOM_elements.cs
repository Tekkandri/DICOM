using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DICOM
{
    public enum ZoomVar { ZoomIn, ZoomOut, Zoom100, ZoomToWidth};
    public partial class DICOM_elements : Form
    {
        private const int max_coeff = 2;
        private const double min_coeff = 0.1;
        private const double delta = 0.1;

        public DICOM_file dicom_file;
        private string filename;
        private Elements_list list;
        public double zoom;
        private Point mouse_point;
        private Point scrollbar_point;
        private Bitmap bmp;
        private Point move;
        public DICOM_elements(string filename, Elements_list list)
        {
            InitializeComponent();
            this.list = list;
            this.filename = filename;
            this.zoom = 1;
        }
        private void getTable()
        {
            gvDicomElements.Columns.Add("Group", "Группа");
            gvDicomElements.Columns.Add("Element", "Элемент");
            gvDicomElements.Columns.Add("VR", "VR");
            gvDicomElements.Columns.Add("Length", "Длина");
            gvDicomElements.Columns.Add("Name", "Имя");
            gvDicomElements.Columns.Add("Value", "Значение");

            gvDicomElements.Columns[0].Width = 100;
            gvDicomElements.Columns[1].Width = 100;
            gvDicomElements.Columns[2].Width = 50;
            gvDicomElements.Columns[3].Width = 100;
            gvDicomElements.Columns[4].Width = 200;
            gvDicomElements.Columns[5].Width = 200;

            foreach (Dicom_dataset dataset in dicom_file)
                gvDicomElements.Rows.Add(dataset.get_header().get_groupid(), dataset.get_header().get_elementid(), dataset.get_header().get_vr(), dataset.get_length(), dataset.get_header().get_name(), dataset.value_to_str(dicom_file.char_set));
        }

        private void DICOM_elements_Load(object sender, EventArgs e)
        {
            dicom_file = new DICOM_file(this.filename, this.list);
            getTable();
            pbImage.Size = dicom_file.img_size;
            pbImage.Image = dicom_file.bmp;
            this.Text = dicom_file.info.Name;
        }
        public double Zoom(ZoomVar coeff)
        {
            switch (coeff)
            {
                case ZoomVar.ZoomIn:
                    this.zoom += delta;
                    if (this.zoom > max_coeff)
                        this.zoom = max_coeff;
                    break;
                case ZoomVar.ZoomOut:
                    this.zoom -= delta;
                    if(this.zoom < min_coeff)
                        this.zoom = min_coeff; 
                    break;
               case ZoomVar.ZoomToWidth:
                    pbImage.Width = dicom_file.bmp.Width;
                    this.zoom = Math.Round((double)this.panel.ClientSize.Width / (double)this.pbImage.ClientSize.Width,4);
                    break;
                case ZoomVar.Zoom100:
                    this.zoom = 1;
                    break;
            }

            pbImage.Width = Convert.ToInt32(this.dicom_file.bmp.Width * this.zoom);
            pbImage.Height = Convert.ToInt32(this.dicom_file.bmp.Height * this.zoom);

            return this.zoom;
        }

        private void pbImage_MouseDown(object sender, MouseEventArgs e)
        {
            this.bmp = new Bitmap(pbImage.Width, pbImage.Height);
            this.mouse_point = new Point(e.Location.X, e.Location.Y);
            this.scrollbar_point.X = panel.HorizontalScroll.Value;
            this.scrollbar_point.Y = panel.VerticalScroll.Value;
            this.Cursor = Cursors.Hand;
            this.move.X = 0;
            this.move.Y = 0;
        }

        private void pbImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Cursor == Cursors.Hand)
            {

                int new_vscroll = this.scrollbar_point.Y + (this.mouse_point.Y - e.Location.Y);
                int new_hscroll = this.scrollbar_point.X + (this.mouse_point.X - e.Location.X);

                if (new_hscroll >= 0 && new_hscroll <= panel.HorizontalScroll.Maximum - panel.ClientSize.Width && panel.HorizontalScroll.Visible)
                    new_hscroll = this.scrollbar_point.X + (this.mouse_point.X - e.Location.X);
                if (new_vscroll >= 0 && new_vscroll <= panel.VerticalScroll.Maximum - panel.ClientSize.Height && panel.VerticalScroll.Visible)
                    new_vscroll = this.scrollbar_point.Y + (this.mouse_point.Y - e.Location.Y);

                panel.AutoScrollPosition = new Point(new_hscroll, new_vscroll);
                
                this.Cursor = Cursors.Default;
                pbImage.Invalidate();
                bmp.Dispose();
            }
        }

        private void pbImage_MouseMove(object sender, MouseEventArgs e)
        {
            if(this.Cursor == Cursors.Hand)
            {
                int HScroll = panel.HorizontalScroll.Value - (e.Location.X - this.mouse_point.X);
                int VScroll = panel.VerticalScroll.Value - (e.Location.Y - this.mouse_point.Y);

                if (HScroll >= 0 && HScroll <= panel.HorizontalScroll.Maximum - panel.ClientSize.Width && panel.HorizontalScroll.Visible)
                    this.move.X = e.Location.X - this.mouse_point.X;
                if (VScroll >= 0 && VScroll <= panel.VerticalScroll.Maximum - panel.ClientSize.Height && panel.VerticalScroll.Visible)
                    this.move.Y = e.Location.Y - this.mouse_point.Y;

                pbImage.CreateGraphics().DrawImage(pbImage.Image, this.move.X, this.move.Y);
            }
        }

        public void DICOM_elements_FormClosed(object sender, FormClosedEventArgs e)
        {
            DICOM_main mainform = this.MdiParent as DICOM_main;

            mainform.Check_ChildForms();
            mainform.DelItem(this.Text);
        }

        private void tsmiPatient_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dicom_file.Get_Info(), "Информация о пациенте");
        }
    }
}
