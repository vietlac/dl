using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietLacSo2022
{
    public partial class HoTro : DevExpress.XtraEditors.XtraUserControl
    {
        public HoTro()
        {
            InitializeComponent();
           
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MyMessageBox2 newms2 = new MyMessageBox2();
            newms2.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Chat c = new Chat();
            // c.StartPosition = FormStartPosition.Manual;
       
            c.Show();

        }

        private void HoTro_Load(object sender, EventArgs e)
        {
            panelControl3.BackColor = Color.FromArgb(241, 243, 250);
            panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl3.BackColor = Color.White;
            panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
        }

        private void panelControl7_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linearGradientBrush =
        new LinearGradientBrush(panelControl7.ClientRectangle, Color.FromArgb(24, 57, 160, 255), Color.FromArgb(21, 255, 116, 57), 180);

            ColorBlend cblend = new ColorBlend(3);
            cblend.Colors = new Color[3] { Color.FromArgb(24, 57, 160, 255), Color.FromArgb(21, 255, 116, 57), Color.FromArgb(22, 57, 160, 255) };
            cblend.Positions = new float[3] { 0f, 0.5f, 1f };

            linearGradientBrush.InterpolationColors = cblend;

            e.Graphics.FillRectangle(linearGradientBrush, panelControl7.ClientRectangle);
        }

        private void panelControl9_Paint(object sender, PaintEventArgs e)
        {

            LinearGradientBrush linearGradientBrush =
        new LinearGradientBrush(panelControl9.ClientRectangle, Color.FromArgb(24, 57, 160, 255), Color.FromArgb(21, 255, 116, 57), 180);

            ColorBlend cblend = new ColorBlend(3);
            cblend.Colors = new Color[3] { Color.FromArgb(24, 57, 160, 255), Color.FromArgb(21, 255, 116, 57), Color.FromArgb(22, 57, 160, 255) };
            cblend.Positions = new float[3] { 0f, 0.5f, 1f };

            linearGradientBrush.InterpolationColors = cblend;

            e.Graphics.FillRectangle(linearGradientBrush, panelControl9.ClientRectangle);
        }

        private void panelControl8_Paint(object sender, PaintEventArgs e)
        {

            LinearGradientBrush linearGradientBrush =
        new LinearGradientBrush(panelControl8.ClientRectangle, Color.FromArgb(24, 57, 160, 255), Color.FromArgb(21, 255, 116, 57), 180);

            ColorBlend cblend = new ColorBlend(3);
            cblend.Colors = new Color[3] { Color.FromArgb(24, 57, 160, 255), Color.FromArgb(21, 255, 116, 57), Color.FromArgb(22, 57, 160, 255) };
            cblend.Positions = new float[3] { 0f, 0.5f, 1f };

            linearGradientBrush.InterpolationColors = cblend;

            e.Graphics.FillRectangle(linearGradientBrush, panelControl8.ClientRectangle);
        }

        private void panelControl10_Paint(object sender, PaintEventArgs e)
        {

            LinearGradientBrush linearGradientBrush =
        new LinearGradientBrush(panelControl10.ClientRectangle, Color.FromArgb(24, 57, 160, 255), Color.FromArgb(21, 255, 116, 57), 180);

            ColorBlend cblend = new ColorBlend(3);
            cblend.Colors = new Color[3] { Color.FromArgb(24, 57, 160, 255), Color.FromArgb(21, 255, 116, 57), Color.FromArgb(22, 57, 160, 255) };
            cblend.Positions = new float[3] { 0f, 0.5f, 1f };

            linearGradientBrush.InterpolationColors = cblend;

            e.Graphics.FillRectangle(linearGradientBrush, panelControl10.ClientRectangle);
        }
    }
}
