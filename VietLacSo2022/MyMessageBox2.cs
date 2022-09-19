using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietLacSo2022
{
    public partial class MyMessageBox2 : DevExpress.XtraEditors.XtraForm
    {
        public MyMessageBox2()
        {
            InitializeComponent();
         
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.ShowInTaskbar = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            Application.OpenForms["Screen"].Close();
            Form1 f1 = new Form1();
            f1.Show();
           
        }

        private void simpleButton1_MouseHover(object sender, EventArgs e)
        {
            simpleButton1.Appearance.BackColor = Color.FromArgb(57, 160, 255);
            simpleButton1.Appearance.ForeColor = Color.White;
        }

        private void simpleButton1_MouseLeave(object sender, EventArgs e)
        {
            simpleButton1.Appearance.BackColor = Color.White;
            simpleButton1.Appearance.ForeColor = Color.FromArgb(57, 160, 255);
        }

        private void simpleButton2_MouseHover(object sender, EventArgs e)
        {
            simpleButton2.Appearance.BackColor = Color.FromArgb(57, 160, 255);
            simpleButton2.Appearance.ForeColor = Color.White;
        }

        private void simpleButton2_MouseLeave(object sender, EventArgs e)
        {
            simpleButton2.Appearance.BackColor = Color.White;
            simpleButton2.Appearance.ForeColor = Color.FromArgb(57, 160, 255);
        }

        private void MyMessageBox2_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.ActiveForm.Width- this.Width, 130);
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
    }
}