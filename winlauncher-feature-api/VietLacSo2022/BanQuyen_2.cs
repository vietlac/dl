using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietLacSo2022
{
    public partial class BanQuyen_2 : DevExpress.XtraEditors.XtraUserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public BanQuyen_2()
        {
            InitializeComponent();
        }

        public BanQuyen_2(int id, string tenphanmem, Image anhphanmem, string tinhtrang, string key_khoa)
        {
            InitializeComponent();
            //chiTietPhanMem1.Visible = false;
            ID = id;
            Pname = tenphanmem;
            Pic = anhphanmem;
            Tinhtrang = tinhtrang;
            Key2 = key_khoa;


        }
        public int ID
        {
            get;
            set;

        }
        public string Pname
        {
            get => labelControl1.Text;
            set => labelControl1.Text = value;

        }
        public Image Pic
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }
        public string Tinhtrang
        {
            get => labelControl2.Text;
            set => labelControl2.Text = value;

        }
        public string Key2
        {
            get => labelControl3.Text;
            set => labelControl3.Text = value;

        }
        private void BanQuyen_2_Load(object sender, EventArgs e)
        {
            // pictureBox1.Width = 66;
            //  pictureBox1.Height = 45;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            panelControl1.BackColor = Color.White;
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            if (labelControl1.Text.Length > 45)
            {
                string label1 = labelControl1.Text.Substring(0, 45);
                string label2 = labelControl1.Text.Substring(45, labelControl1.Text.Length - label1.Length);
                labelControl1.Text = label1 + Environment.NewLine + label2;
            }
            
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 5, 5));
        }

        private void BanQuyen_2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(57, 160, 255), 2, ButtonBorderStyle.Solid, Color.FromArgb(57, 160, 255), 2, ButtonBorderStyle.Solid, Color.FromArgb(57, 160, 255), 2, ButtonBorderStyle.Solid, Color.FromArgb(57, 160, 255), 2, ButtonBorderStyle.Solid);
           
        }
    }
}
