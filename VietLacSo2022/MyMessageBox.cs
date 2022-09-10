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
    public partial class MyMessageBox : DevExpress.XtraEditors.XtraForm
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public MyMessageBox()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
           
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.ShowInTaskbar = false;

        }

        private void MyMessageBox_Load(object sender, EventArgs e)
        {

            panelControl1.BackColor = Color.White;
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            simpleButton1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            simpleButton1.Appearance.BorderColor = Color.FromArgb(57, 160, 255);
            simpleButton1.AllowFocus = false;
            simpleButton2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            simpleButton2.Appearance.BorderColor = Color.FromArgb(57, 160, 255);
            simpleButton2.AllowFocus = false;
        }

        private void MyMessageBox_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(57, 160, 255), ButtonBorderStyle.Solid);
        }

        private void simpleButton1_MouseHover(object sender, EventArgs e)
        {
            simpleButton1.Appearance.BackColor = Color.FromArgb(57, 160, 255);
            simpleButton1.Appearance.ForeColor = Color.White;
        }
        
        private void simpleButton2_MouseHover(object sender, EventArgs e)
        {
            simpleButton2.Appearance.BackColor = Color.FromArgb(57, 160, 255);
            simpleButton2.Appearance.ForeColor = Color.White;
        }

        private void simpleButton1_MouseLeave(object sender, EventArgs e)
        {
            simpleButton1.Appearance.BackColor = Color.White;
            simpleButton1.Appearance.ForeColor = Color.FromArgb(57, 160, 255);
        }

        private void simpleButton2_MouseLeave(object sender, EventArgs e)
        {
            simpleButton2.Appearance.BackColor = Color.White;
            simpleButton2.Appearance.ForeColor = Color.FromArgb(57, 160, 255);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
          
        }
    }
}