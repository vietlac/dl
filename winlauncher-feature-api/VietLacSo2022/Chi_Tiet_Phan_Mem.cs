using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietLacSo2022
{
    public partial class Chi_Tiet_Phan_Mem : DevExpress.XtraEditors.XtraForm
    {
        public static int sotien ;
        public static int Sotien
        {
            get { return sotien; }
            set { sotien = value; }
        }
        int i;
        public Chi_Tiet_Phan_Mem()
        {
            InitializeComponent();
            i = 0;
        }
        
        
        public Chi_Tiet_Phan_Mem(int id, string tenphanmem, Image anhphanmem, Image anhphanmem2, Image anhphanmem3, Image anhphanmem4, Image anhphanmem5, string maphanmem, string giaphanmem,string gioithieuphanmem, string tinhtrangconlai,string huongdanmuahang)
        {
            InitializeComponent();
            //chiTietPhanMem1.Visible = false;
            ID = id;
            Name = tenphanmem;
            Ma = maphanmem;
            Tinhtrangconlai = tinhtrangconlai;
            Gia = giaphanmem;
            Gioithieu = gioithieuphanmem;
            Huongdanmua = huongdanmuahang;
            Pic = anhphanmem;
            Pic2 = anhphanmem2;
            Pic3 = anhphanmem3;
            Pic4 = anhphanmem4;
            Pic5 = anhphanmem5;


        }
        public int ID
        {
            get;
            set;

        }
        public  string Name
        {
            get => labelControl1.Text;
            set => labelControl1.Text = value;

        }
        public string Ma
        {
            get => labelControl3.Text;
            set => labelControl3.Text = value;

        }
        public string Tinhtrangconlai
        {
            get => labelControl5.Text;
            set => labelControl5.Text = value;

        }
        public string Gia
        {
            get => labelControl6.Text;
            set => labelControl6.Text = value;

        }
        public string Gioithieu
        {
            get => textBox2.Text;
            set => textBox2.Text = value;

        }
        public string Huongdanmua
        {
            get => textBox1.Text;
            set => textBox1.Text = value;

        }
        public Image Pic
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }
        public Image Pic2
        {
            get => pictureBox2.Image;
            set => pictureBox2.Image = value;
        }
        public Image Pic3
        {
            get => pictureBox3.Image;
            set => pictureBox3.Image = value;
        }
        public Image Pic4
        {
            get => pictureBox4.Image;
            set => pictureBox4.Image = value;
        }
        public Image Pic5
        {
            get => pictureBox5.Image;
            set => pictureBox5.Image = value;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            //textEdit2.Text = "1";
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.ScrollToCaret();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void textEdit2_TextChanged(object sender, EventArgs e)
        {
            //sotien = "1";
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            labelControl6.Text = String.Format(info, "{0:c}",(int.Parse(textEdit2.Text) * DanhSachPhanMem_2cs.giaphanmem));

        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            
            textEdit2.Text = (++i).ToString();
            //sotien = textEdit2.Text;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (i < 0) return;
            else if (i > 0)
            {
                textEdit2.Text = (--i).ToString();
            }
        }

        private void textEdit2_EditValueChanged_1(object sender, EventArgs e)
        {
            //textEdit2.Text = "1";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            MyMessageBox2 newms2 = new MyMessageBox2();
            newms2.Show();
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linearGradientBrush =
           new LinearGradientBrush(panelControl1.ClientRectangle, Color.FromArgb(98, 255, 116, 57), Color.FromArgb(99, 161, 137, 151), 180);

            ColorBlend cblend = new ColorBlend(3);
            cblend.Colors = new Color[3] { Color.FromArgb(98, 255, 116, 57), Color.FromArgb(99, 161, 137, 151), Color.FromArgb(98, 255, 116, 57) };
            cblend.Positions = new float[3] { 0f, 0.5f, 1f };

            linearGradientBrush.InterpolationColors = cblend;
            ;
            e.Graphics.FillRectangle(linearGradientBrush, panelControl1.ClientRectangle);
            // tablePanel1.Controls.Add(Danh)
        }

        private void Chi_Tiet_Phan_Mem_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            simpleButton6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            simpleButton6.Appearance.BorderColor = Color.FromArgb(57, 160, 255);
            simpleButton6.AllowFocus = false;
            simpleButton7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            simpleButton7.Appearance.BorderColor = Color.FromArgb(57, 160, 255);
            simpleButton7.AllowFocus = false;
            panelControl1.BackColor = Color.FromArgb(241, 243, 250);
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl3.BackColor = Color.White;
            panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl4.BackColor = Color.White;
            panelControl4.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl4.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl6.BackColor = Color.FromArgb(241, 243, 250);
            panelControl6.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl6.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
        }

        private void simpleButton6_MouseHover(object sender, EventArgs e)
        {
            simpleButton6.Appearance.BackColor = Color.FromArgb(57, 160, 255);
            simpleButton6.Appearance.ForeColor = Color.White;
        }

        private void simpleButton6_MouseLeave(object sender, EventArgs e)
        {
            simpleButton6.Appearance.BackColor = Color.White;
            simpleButton6.Appearance.ForeColor = Color.FromArgb(57, 160, 255);
        }

        private void simpleButton7_MouseHover(object sender, EventArgs e)
        {
            simpleButton7.Appearance.BackColor = Color.FromArgb(57, 160, 255);
            simpleButton7.Appearance.ForeColor = Color.White;
        }

        private void simpleButton7_MouseLeave(object sender, EventArgs e)
        {

            simpleButton7.Appearance.BackColor = Color.White;
            simpleButton7.Appearance.ForeColor = Color.FromArgb(57, 160, 255);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }
    }
}