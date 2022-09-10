using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SolrNet.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace VietLacSo2022
{
    public partial class Screen : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Screen()
        {
            InitializeComponent();
        }
        public PanelControl Pan
        {
            get { return panelControl2; }
            set { panelControl2 = value; }
        }
        public Color ColorTop
        {
            get;
            set;
        }
        public Color ColorBottom
        {
            get;
            set;
        }


        public string thing = "chiTietPhanMem1";

        public T GetAttribute<T>(string _name)
        {
            return (T)GetType().GetField(_name).GetValue(this);
        }
        

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linearGradientBrush =
            new LinearGradientBrush(panelControl1.ClientRectangle, Color.FromArgb(98,255, 116, 57), Color.FromArgb(99,161, 137, 151), 180);

            ColorBlend cblend = new ColorBlend(3);
            cblend.Colors = new Color[3] { Color.FromArgb(98, 255, 116, 57), Color.FromArgb(99, 161, 137, 151), Color.FromArgb(98, 255, 116, 57) };
            cblend.Positions = new float[3] { 0f, 0.5f, 1f };

            linearGradientBrush.InterpolationColors = cblend;
            ;
            e.Graphics.FillRectangle(linearGradientBrush, panelControl1.ClientRectangle);
            // tablePanel1.Controls.Add(Danh)


        }

        private void fluentDesignFormContainer1_Click(object sender, EventArgs e)
        {

        }

        internal static Rectangle GetWorkingArea(HoTro hoTro)
        {
            throw new NotImplementedException();
        }

        private void fluentDesignFormContainer1_Paint(object sender, PaintEventArgs e)
        {
           
           
        }

        private void tablePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void danhsachphanmem_Click(object sender, EventArgs e)
        {
            // danhSachPhanMem_2cs1.Visible = true;
            //danhSachPhanMem_2cs1.BringToFront();
            dspm1.Visible = true;
            dspm1.BringToFront();
           // dspm1.Show();


        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {
            //panelControl2.BackColor = Color.White;
           // panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            //panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
           // this.textEdit1.AutoSize = false;
           // this.textEdit1.Size = new System.Drawing.Size(295, 31);
        }

        private void tablePanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Screen_Load(object sender, EventArgs e)
        {
            accordionControl1.AllowItemSelection = Enabled;
            accordionControl1.Appearance.Item.Pressed.BackColor = Color.FromArgb(57, 160, 255);
            accordionControl1.Appearance.Group.Normal.FontSizeDelta = 4;
            accordionControl1.Appearance.Group.Hovered.FontSizeDelta = 4;
            accordionControl1.Appearance.Group.Pressed.FontSizeDelta = 4;
            accordionControl1.Appearance.Group.Normal.ForeColor = Color.Black;
            accordionControl1.Appearance.Group.Hovered.ForeColor = Color.Black;
            accordionControl1.Appearance.Group.Pressed.ForeColor = Color.Black;
            accordionControl1.Appearance.Item.Normal.FontSizeDelta = 4;
            accordionControl1.Appearance.Item.Hovered.FontSizeDelta = 4;
            accordionControl1.Appearance.Item.Pressed.FontSizeDelta = 4;
            accordionControl1.Appearance.Item.Normal.ForeColor = Color.Black;
            accordionControl1.Appearance.Item.Hovered.ForeColor = Color.Black;
            accordionControl1.Appearance.Item.Pressed.ForeColor = Color.White;
            // danhSachPhanMem_2cs1.Visible = true;
            // danhSachPhanMem_2cs1.BringToFront();
            dspm1.Visible = true;
            dspm1.BringToFront();


        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void banquyen_Click(object sender, EventArgs e)
        {
            banQuyen1.Visible = true;
            banQuyen1.BringToFront();
        }

        private void taikhoancanhan_Click(object sender, EventArgs e)
        {
            taiKhoanCaNhan1.Visible = true;
            taiKhoanCaNhan1.BringToFront();
        }

        private void tailieu_Click(object sender, EventArgs e)
        {
            taiLieu1.Visible = true;
            taiLieu1.BringToFront();
        }

        private void congdong_Click(object sender, EventArgs e)
        {
            congDong1.Visible = true;
            congDong1.BringToFront();
        }

        private void dieukhoan_Click(object sender, EventArgs e)
        {
            dieuKhoan1.Visible = true;
            dieuKhoan1.BringToFront();
        }

        private void hotro_Click(object sender, EventArgs e)
        {
            hoTro1.Visible = true;
            hoTro1.BringToFront();
            
        }
    }
}
