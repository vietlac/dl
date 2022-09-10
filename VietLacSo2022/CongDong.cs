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
    public partial class CongDong : DevExpress.XtraEditors.XtraUserControl
    {
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
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public CongDong()
        {
            InitializeComponent();
            panelControl12.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panelControl12.Width +100 , panelControl12.Height, 10, 10));
            panelControl11.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panelControl4.Width +100 , panelControl11.Height, 10, 10));
         
        }

        private void CongDong_Load(object sender, EventArgs e)
        {
            panelControl1.BackColor = Color.White;
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl2.BackColor = Color.White;
            panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl3.BackColor = Color.FromArgb(241, 243, 250);
            panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl4.BackColor = Color.FromArgb(241, 243, 250);
            panelControl4.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl4.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl6.BackColor = Color.FromArgb(241, 243, 250);
            panelControl6.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl6.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl7.BackColor = Color.White;
            panelControl7.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl7.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl8.BackColor = Color.White;
            panelControl8.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl8.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl9.BackColor = Color.White;
            panelControl9.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl9.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl10.BackColor = Color.White;
            panelControl10.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl10.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl15.BackColor = Color.White;
            panelControl15.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl15.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl4.LookAndFeel.SkinName = "Glass Oceans";
            panelControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl2_Paint);
            panelControl7.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl7_Paint);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            MyMessageBox2 newms2 = new MyMessageBox2();
            newms2.Show();
        }

        private void panelControl11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {
           
            
        }

        private void panelControl11_RegionChanged(object sender, EventArgs e)
        {
           
        }

        private void panelControl13_Paint(object sender, PaintEventArgs e)
        {

            LinearGradientBrush linearGradientBrush =
         new LinearGradientBrush(panelControl13.ClientRectangle, Color.FromArgb(24, 57, 160, 255), Color.FromArgb(21, 255, 116, 57), 180);

            ColorBlend cblend = new ColorBlend(3);
            cblend.Colors = new Color[3] { Color.FromArgb(24, 57, 160, 255), Color.FromArgb(21, 255, 116, 57), Color.FromArgb(22, 57, 160, 255) };
            cblend.Positions = new float[3] { 0f, 0.5f, 1f };

            linearGradientBrush.InterpolationColors = cblend;
            
            e.Graphics.FillRectangle(linearGradientBrush, panelControl13.ClientRectangle);

        }

        private void panelControl12_Paint(object sender, PaintEventArgs e)
        {


            
        }

        private void panelControl11_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panelControl4_Paint_1(object sender, PaintEventArgs e)
        {

            LinearGradientBrush linearGradientBrush =
          new LinearGradientBrush(panelControl4.ClientRectangle, Color.FromArgb(24, 57, 160, 255), Color.FromArgb(21, 255, 116, 57), 180);

            ColorBlend cblend = new ColorBlend(3);
            cblend.Colors = new Color[3] { Color.FromArgb(24, 57, 160, 255), Color.FromArgb(21, 255, 116, 57), Color.FromArgb(22, 57, 160, 255) };
            cblend.Positions = new float[3] { 0f, 0.5f, 1f };

            linearGradientBrush.InterpolationColors = cblend;
            
            e.Graphics.FillRectangle(linearGradientBrush, panelControl4.ClientRectangle);
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {
            Color color = Color.FromArgb(255, 116, 57);
            Color backColor = Color.FromArgb(57, 160, 255);
            var amount = 0.5;
            byte r = (byte)(color.R);
            byte g = (byte)(color.G * amount + backColor.G * (1 - amount));
            byte b = (byte)(backColor.B);
            Color lastcolor = Color.FromArgb(r, g, b);
            ControlPaint.DrawBorder(e.Graphics, ((Control)sender).ClientRectangle, lastcolor, 1, ButtonBorderStyle.Solid, Color.FromArgb(255, 116, 57), 1, ButtonBorderStyle.Solid, lastcolor, 1, ButtonBorderStyle.Solid, Color.FromArgb(57, 160, 255), 1, ButtonBorderStyle.Solid);
        }
        private void panelControl7_Paint(object sender, PaintEventArgs e)
        {
            Color color = Color.FromArgb(255, 116, 57);
            Color backColor = Color.FromArgb(57, 160, 255);
            var amount = 0.5;
            byte r = (byte)(color.R);
            byte g = (byte)(color.G * amount + backColor.G * (1 - amount));
            byte b = (byte)(backColor.B);
            Color lastcolor = Color.FromArgb(r, g, b);
            ControlPaint.DrawBorder(e.Graphics, ((Control)sender).ClientRectangle, lastcolor, 1, ButtonBorderStyle.Solid, Color.FromArgb(255, 116, 57), 1, ButtonBorderStyle.Solid, lastcolor, 1, ButtonBorderStyle.Solid, Color.FromArgb(57, 160, 255), 1, ButtonBorderStyle.Solid);

        }

        private void panelControl8_Paint(object sender, PaintEventArgs e)
        {
            Color color = new Color();
            color = Color.FromArgb(217, 217, 217);
            Color backColor = new Color();
            backColor = Color.FromArgb(57, 160, 255);
            var amount= 0.5;
            byte r = (byte)(color.R * amount + backColor.R * (1 - amount));
            byte g = (byte)(color.G * amount + backColor.G * (1 - amount));
            byte b = (byte)(color.B * amount + backColor.B * (1 - amount));
            ControlPaint.DrawBorder(e.Graphics, panelControl8.ClientRectangle,
                     Color.FromArgb(r, g, b), 1, ButtonBorderStyle.Dotted, // left
                     Color.FromArgb(r, g, b), 1, ButtonBorderStyle.Dotted, // top
                     Color.FromArgb(r, g, b), 1, ButtonBorderStyle.Dotted, // right
                     Color.FromArgb(r, g, b), 1, ButtonBorderStyle.Dotted);// bottom
        }

        private void panelControl9_Paint(object sender, PaintEventArgs e)
        {

            Color color = new Color();
            color = Color.FromArgb(217, 217, 217);
            Color backColor = new Color();
            backColor = Color.FromArgb(57, 160, 255);
            var amount = 0.5;
            byte r = (byte)(color.R * amount + backColor.R * (1 - amount));
            byte g = (byte)(color.G * amount + backColor.G * (1 - amount));
            byte b = (byte)(color.B * amount + backColor.B * (1 - amount));
            ControlPaint.DrawBorder(e.Graphics, panelControl8.ClientRectangle,
                     Color.FromArgb(r, g, b), 1, ButtonBorderStyle.Dotted, // left
                     Color.FromArgb(r, g, b), 1, ButtonBorderStyle.Dotted, // top
                     Color.FromArgb(r, g, b), 1, ButtonBorderStyle.Dotted, // right
                     Color.FromArgb(r, g, b), 1, ButtonBorderStyle.Dotted);// bottom
        }

        private void panelControl10_Paint(object sender, PaintEventArgs e)
        {
            Color color = new Color();
            color = Color.FromArgb(217, 217, 217);
            Color backColor = new Color();
            backColor = Color.FromArgb(57, 160, 255);
            var amount = 0.5;
            byte r = (byte)(color.R * amount + backColor.R * (1 - amount));
            byte g = (byte)(color.G * amount + backColor.G * (1 - amount));
            byte b = (byte)(color.B * amount + backColor.B * (1 - amount));
            ControlPaint.DrawBorder(e.Graphics, panelControl8.ClientRectangle,
                     Color.FromArgb(r, g, b), 1, ButtonBorderStyle.Dotted, // left
                     Color.FromArgb(r, g, b), 1, ButtonBorderStyle.Dotted, // top
                     Color.FromArgb(r, g, b), 1, ButtonBorderStyle.Dotted, // right
                     Color.FromArgb(r, g, b), 1, ButtonBorderStyle.Dotted);// bottom
        }
    }
}
