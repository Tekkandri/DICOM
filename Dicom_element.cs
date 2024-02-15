using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Runtime.InteropServices;
using System.Globalization;

namespace DICOM
{
    public class Dicom_element
    {
        private string groupid;
        private string elementid;
        private string vr;
        private string name;
        
        public Dicom_element()
        {
            this.groupid = "";
            this.elementid = "";
            this.vr = "";
            this.name = "";
        }

        public Dicom_element(string groupid, string elementid, string vr)
        {
            this.groupid = groupid;
            this.elementid = elementid;
            this.vr = vr;
        }
        public Dicom_element(string groupid, string elementid, string vr, string name)
        {
            this.groupid = groupid;
            this.elementid = elementid;
            this.vr = vr;
            this.name = name;
        }
        public Dicom_element(XmlNode node)
        {
            ReadXML(node);
        }
        private void ReadXML(XmlNode node)
        {
            this.groupid = node.Attributes.GetNamedItem("GroupID").Value;
            this.elementid = node.Attributes.GetNamedItem("ElementID").Value;

            foreach (XmlNode childnode in node.ChildNodes)
            {
                if (childnode.Name == "VR")
                    this.vr = childnode.InnerText;

                if (childnode.Name == "Name")
                    this.name = childnode.InnerText;
            }
        }
        public string get_vr()
        {
            return this.vr;
        }
        public string get_name()
        {
            return this.name;
        }
        public string get_groupid()
        {
            return this.groupid;
        }
        public string get_elementid()
        {
            return this.elementid;
        }
        public void set_vr(string vr)
        {
            this.vr = vr;
        }
        public void set_name(string name)
        {
            this.name = name;
        }
        public void set_groupid(string groupid)
        {
            this.groupid = groupid;
        }
        public void set_elementid(string elementid)
        {
            this.elementid = elementid;
        }
    }
    public class Elements_list: List<Dicom_element>
    {
        public void addElement(XmlNode node)
        {
            Dicom_element elem = new Dicom_element(node);
            if(elem != null)
                Add(elem);
        }
        public void LoadXML(string filename)
        {
            Clear();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(filename);

            foreach (XmlNode node in xmldoc.DocumentElement)
            {
                addElement(node);
            }
        }
        public Dicom_element get_element_by_groupid_and_elementid(string groupid, string elementid)
        {
            Dicom_element result;
            if (elementid == "0000")
                result = new Dicom_element(groupid, elementid, "UL", "Group Length");
            else
            {
                int i = 0;
                while ((i < Count) && ((this[i].get_groupid() != groupid) || (this[i].get_elementid() != elementid)))
                    i++;
                if (i == Count)
                    result = new Dicom_element(groupid, elementid, "UN", "User's tag");
                else
                    result = this[i];
            }
            return result;
        }
        public string get_vr_by_groupid_and_elementid(string groupid, string elementid)
        {
            Dicom_element result = null;
            foreach (Dicom_element element in this)
            {
                if (element.get_groupid() == groupid && element.get_elementid() == elementid)
                    result = element;
            }
            return result.get_vr();
        }
    }
    public class Dicom_dataset
    {
        private Dicom_element header;
        private uint length;
        private byte[] value;

        public Dicom_dataset(Dicom_element header)
        {
            this.header = header;
        }
        public Dicom_dataset(Dicom_element header, uint length, byte[] value)
        {
            this.header = header;
            this.length = length;
            this.value = value;
        }
        public Dicom_element get_header()
        {
            return this.header;
        }
        public uint get_length()
        {
            return this.length;
        }
        public byte[] get_value()
        {
            return this.value;
        }
        public void set_length(uint length)
        {
            this.length = length;
        }
        public void set_value(byte[] value)
        {
            this.value = value;
        }
        public void set_header(Dicom_element header)
        {
            this.header = header;
        }
        public string value_to_str(Encoding encode)
        {
            string result = "";
            if (this.header.get_vr() == "SQ")
                result = "(Sequence)";
            else 
                if (this.length == 0)
                result = "";
            else 
                switch(this.header.get_vr())
                {
                    case "SS": result = BitConverter.ToInt16(this.value, 0).ToString(); break;//Signed Short
                    case "US": result = BitConverter.ToUInt16(this.value, 0).ToString(); break;//Unsigned Short
                    case "SL": result = BitConverter.ToInt32(this.value, 0).ToString(); break;//Signed Long
                    case "UL": result = BitConverter.ToUInt32(this.value, 0).ToString(); break;//Unsigned Long длина результирующего массива недостаточна!!!!
                    case "SV": result = BitConverter.ToInt64(this.value, 0).ToString(); break;//Signed 64-bit Very Long
                    case "UV": result = BitConverter.ToUInt64(this.value, 0).ToString(); break;//Unsigned 64-bit Very Long
                    case "DA":
                        //FL OF 13
                        char[] str = encode.GetString(this.value).ToCharArray();
                        result = str[6].ToString() + str[7].ToString() + "/" + str[4].ToString() + str[5].ToString() + "/" + str[0].ToString() + str[1].ToString() + str[2].ToString() + str[3].ToString();
                        break;
                    case "OB": //Other Byte
                        int v = 0;
                        for (int i = 0; i < this.value.Length; i++)
                            v += (this.value[i] << (i * 8));
                        result = v.ToString(); break;
                    default: result = encode.GetString(this.value).ToString(); break;
                }
            return result.Trim(new char[] { (char)0 });
        }
        public XmlNode GetXML(XmlDocument xmldoc)
        {
            XmlNode element_node = xmldoc.CreateElement("Element");

            XmlAttribute attr = xmldoc.CreateAttribute("GroupID");
            attr.Value = this.get_header().get_groupid();
            element_node.Attributes.Append(attr);

            attr = xmldoc.CreateAttribute("ElementID");
            attr.Value = this.get_header().get_elementid();
            element_node.Attributes.Append(attr);

            XmlNode vr_node = xmldoc.CreateElement("VR");
            vr_node.InnerText = this.get_header().get_vr();
            element_node.AppendChild(vr_node);

            XmlNode length_node = xmldoc.CreateElement("Length");
            length_node.InnerText = this.get_length().ToString();
            element_node.AppendChild(length_node);

            XmlNode name_node = xmldoc.CreateElement("Name");
            name_node.InnerText = this.get_header().get_name();
            element_node.AppendChild(name_node);

            XmlNode value_node = xmldoc.CreateElement("Value");
            value_node.InnerText = this.value_to_str(Encoding.ASCII);
            element_node.AppendChild(value_node);

            return element_node;
        }
    }
    public class DICOM_file : List<Dicom_dataset>
    {
        private Elements_list dicom_elements;
        private string filename;
        private BinaryReader file_reader;
        public bool implicit_vr;
        public int bits_allocated;
        public int bits_stored;
        public Size img_size;
        public double WL;
        public double WW;
        public Encoding char_set;
        public Bitmap bmp;
        private IntPtr pointer;
        public FileInfo info;
        public DICOM_file(string filename, Elements_list dicom_elements)
        {
            this.char_set = Encoding.ASCII;
            this.dicom_elements = dicom_elements;
            this.file_reader = new BinaryReader(File.OpenRead(filename));
            this.filename = filename;
            this.info = new FileInfo(filename);

            NumberFormatInfo nfi = new CultureInfo("ru-RU", false).NumberFormat;
            nfi.NumberDecimalSeparator = ".";

            if (isDicom(filename))
            {

                Dicom_dataset ds = new Dicom_dataset(dicom_elements.get_element_by_groupid_and_elementid("0002", "0000"));
                ds.set_length(4);

                file_reader.ReadBytes(8);

                uint group_0002_length = file_reader.ReadUInt32();
                ds.set_value(BitConverter.GetBytes(group_0002_length));

                Add(ds);

                long group_0002_end = file_reader.BaseStream.Position + group_0002_length;

                while (file_reader.BaseStream.Position < group_0002_end)
                {
                    Dicom_element header = dicom_elements.get_element_by_groupid_and_elementid(file_reader.ReadUInt16().ToString("X4"), file_reader.ReadUInt16().ToString("X4"));
                    ds = new Dicom_dataset(header);

                    ds.get_header().set_vr(Encoding.ASCII.GetString(file_reader.ReadBytes(2)));

                    ds.set_length(ReadLength(ds.get_header().get_vr()));

                    ds.set_value(file_reader.ReadBytes((int)ds.get_length()));

                    Add(ds);

                    if (ds.get_header().get_elementid() == "0010")
                    {
                        string tmp = ds.value_to_str(Encoding.ASCII);
                        this.implicit_vr = (tmp == "1.2.840.10008.1.2");
                    }
                }
                bool is_img;
                do
                {
                    ds = new Dicom_dataset(dicom_elements.get_element_by_groupid_and_elementid(file_reader.ReadUInt16().ToString("X4"), file_reader.ReadUInt16().ToString("X4")));
                    if (!this.implicit_vr)
                        ds.get_header().set_vr(Encoding.ASCII.GetString(file_reader.ReadBytes(2)));

                    ds.set_length(ReadLength(ds.get_header().get_vr(), this.implicit_vr));
                    is_img = (ds.get_header().get_groupid() == "7FE0" && ds.get_header().get_elementid() == "0010");
                    if (!is_img)
                    {
                        ds.set_value(file_reader.ReadBytes((int)ds.get_length()));
                        if (ds.get_header().get_elementid() == "0005" && ds.get_header().get_groupid() == "0008")
                        {
                            if (ds.value_to_str(Encoding.ASCII) == "ISO_IR 144")
                                this.char_set = Encoding.GetEncoding(28595);
                            else
                                if (ds.value_to_str(Encoding.ASCII) == "ISO 2022 IR 6\\IS")
                                this.char_set = Encoding.GetEncoding(1251);
                        }
                        else
                        if (ds.get_header().get_groupid() == "0028" && ds.get_header().get_elementid() == "0010")
                            this.img_size.Height = BitConverter.ToUInt16(ds.get_value(), 0);
                        else
                        if (ds.get_header().get_groupid() == "0028" && ds.get_header().get_elementid() == "0011")
                            this.img_size.Width = BitConverter.ToUInt16(ds.get_value(), 0);
                        else
                        if (ds.get_header().get_groupid() == "0028" && ds.get_header().get_elementid() == "0100")
                            this.bits_allocated = BitConverter.ToUInt16(ds.get_value(), 0);
                        else
                        if (ds.get_header().get_groupid() == "0028" && ds.get_header().get_elementid() == "0101")
                            this.bits_stored = BitConverter.ToUInt16(ds.get_value(), 0);
                        else
                        if (ds.get_header().get_groupid() == "0028" && ds.get_header().get_elementid() == "1050")
                            this.WL = Convert.ToDouble(ds.value_to_str(Encoding.ASCII), nfi);
                        else
                        if (ds.get_header().get_groupid() == "0028" && ds.get_header().get_elementid() == "1051")
                            this.WW = Convert.ToDouble(ds.value_to_str(Encoding.ASCII), nfi);

                    }
                    else
                    {
                        char[] symb = { 'I', 'm', 'a', 'g', 'e' };
                        ds.set_value(Encoding.ASCII.GetBytes(symb));
                        CreateImage();
                    }
                    Add(ds);
                }
                while (!is_img && file_reader.BaseStream.Position < file_reader.BaseStream.Length);
                file_reader.Close();
            }
            else
            {
                file_reader.Close();
                throw new FormatException("Not DICOM file");
            }
        }
        ~DICOM_file()
        {
            Marshal.FreeHGlobal(this.pointer);
        }
        private bool isDicom(string filename)
        {
            this.file_reader.ReadBytes(128);
            byte[] header = file_reader.ReadBytes(4);
            return (Encoding.ASCII.GetString(header) == "DICM");
        }
        private uint ReadLength(string vr, bool implicit_vr=false)
        {
            uint value_length = 0;

            if (implicit_vr)
                value_length = file_reader.ReadUInt32();
            else
            {
                if (vr == "OB" || vr == "OW" || vr == "OT" || vr == "UN" || vr == "UT" || vr == "SQ")
                {
                    file_reader.ReadBytes(2);
                    value_length = file_reader.ReadUInt32();
                }
                else
                {
                    value_length = file_reader.ReadUInt16();
                }
            }

            if (vr == "SQ")
                value_length = ReadSequence(value_length);

            return value_length;
        }
        private uint ReadSequence(uint sqlength)
        {
            uint result = sqlength;
            if(sqlength == 0xffffffff)
            {
                bool stop = false;
                do
                {
                    ushort tmp = file_reader.ReadUInt16();
                    if (tmp == 0xfffe)
                    {
                        tmp = file_reader.ReadUInt16();
                        stop = (tmp == 0xe0dd);
                    }
                }
                while (!stop);
                file_reader.ReadBytes(4);
                result = 0;
            }
            return result;
        }
        public void SaveXML(string filename)
        {
            XmlDocument xmldoc = new XmlDocument();

            XmlDeclaration xmldec = xmldoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmldoc.AppendChild(xmldec);

            XmlElement xmlRoot = xmldoc.CreateElement("Elements");
            xmldoc.AppendChild(xmlRoot);

            foreach (Dicom_dataset f in this)
                xmlRoot.AppendChild(f.GetXML(xmldoc));

            xmldoc.Save(filename);
        }
        private void CreateImage()
        {
            int bytes_per_pixel = this.bits_allocated / 8;
            byte[] original_values = file_reader.ReadBytes(this.img_size.Width * this.img_size.Height * bytes_per_pixel);
            byte[] pixels = new byte[this.img_size.Width * this.img_size.Height*3];
            int j = 0;
            for(int i=0;i<original_values.Length;i+=bytes_per_pixel)
            {
                int gray = original_values[i] + (original_values[i + 1] << 8);
                int gray8bit;
                if (gray <= (this.WL - 0.5 - (this.WW - 1) / 2))
                    gray8bit = 0;
                else
                    if (gray > (this.WL - 0.5 + (this.WW - 1) / 2))
                        gray8bit = 255;
                    else
                        gray8bit = (int)(((gray - (WL - 0.5)) / (WW - 1) + 0.5) * 255);
                pixels[j] = (byte)gray8bit;
                pixels[j + 1] = (byte)gray8bit;
                pixels[j+2] = (byte)gray8bit;
                j += 3;
            }
            int size = Marshal.SizeOf(pixels[0]) * pixels.Length;
            this.pointer = Marshal.AllocHGlobal(size);
            Marshal.Copy(pixels, 0, this.pointer, pixels.Length);
            this.bmp = new Bitmap(this.img_size.Width, this.img_size.Height, this.img_size.Width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, pointer);

        }
        public string Get_Info()
        {
            string result = "";
            foreach(Dicom_dataset ds in this)
            {
                if (ds.get_header().get_groupid() == "0010" && ds.get_header().get_elementid() == "0010")
                    result += "Имя пациента: " + ds.value_to_str(this.char_set) +"\n";
                if (ds.get_header().get_groupid() == "0010" && ds.get_header().get_elementid() == "0040")
                    result += "Пол: " + ds.value_to_str(this.char_set) + "\n";
                if (ds.get_header().get_groupid() == "0008" && ds.get_header().get_elementid() == "0020")
                    result += "Дата посещения: " + ds.value_to_str(this.char_set) + "\n";
                if (ds.get_header().get_groupid() == "0010" && ds.get_header().get_elementid() == "0030")
                    result += "Дата рождения: " + ds.value_to_str(this.char_set) + "\n";
            }
            return result;
        }
    }

}
