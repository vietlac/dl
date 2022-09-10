using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace VietLacSo2022
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
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
        public Form1()
        {
            InitializeComponent();
            dangKy1.Visible = false;
           
           
        }

        public static string sodienthoai2 = "";
        public static string matkhau2 = "";
        public string SoDienThoai
        {
            get => sodienthoai2;
            set => sodienthoai2 = value;

        }
        public string Matkhau
        {
            get => matkhau2;
            set => matkhau2 = value;

        }
        public static string userName = string.Empty;
        public static string User
        {
            get { return userName; }
            set { userName = value; }
        }
        public static string passUser = string.Empty;
        public static string Pass
        {
            get { return passUser; }
            set { passUser = value; }
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
           

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textEdit2.Properties.PasswordChar = '*';
            if (userName != string.Empty)
            {
                textEdit1.Text = userName;
                textEdit2.Text = passUser; ;
            }
            this.panelControl3.Paint += PanelControl3_Paint;

        }
        private void PanelControl3_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            ColorTop = Color.FromArgb(20, 217, 217, 217);
            ColorBottom = Color.FromArgb(2, 217, 217, 217);
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, this.ColorTop, this.ColorBottom, 90F);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, ClientRectangle);

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {
           // dangKy1.Visible = true;
           // dangKy1.BringToFront();
        }

        private void dangKy1_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
           
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void dangKy1_Validating(object sender, CancelEventArgs e)
        {

        }
        
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
           // sodienthoai2 = textEdit1.Text;
        }

        private void textEdit2_TextChanged(object sender, EventArgs e)
        {
          //  matkhau2 = textEdit2.Text;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
           // if (checkEdit1.Checked)
           // {
           //      userName = textEdit1.Text;
           //      passUser = textEdit2.Text;
            //    Properties.Settings.Default.Save();
           // }
        }

        private void checkEdit1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                userName = textEdit1.Text;
                passUser = textEdit2.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void textEdit1_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textEdit1_TextChanged_1(object sender, EventArgs e)
        {
            sodienthoai2 = textEdit1.Text;
        }

        private void textEdit2_TextChanged_1(object sender, EventArgs e)
        {
            matkhau2 = textEdit2.Text;
        }

        private void dangKy1_Load_1(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void vbButton1_Click(object sender, EventArgs e)
        {
            bool accept = true;
            string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string query = @"select * from nguoidung";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                if (textEdit1.Text == r["sodienthoai"].ToString() && textEdit2.Text == r["matkhau"].ToString())
                {
                    accept = true;
                }


            }
            if (accept == true)
            {
                Screen sc = new Screen();
                sc.Show();
                this.Opacity = 0;
                this.ShowInTaskbar = false;
            }
        }

        private void vbButton2_Click(object sender, EventArgs e)
        {
            dangKy1.Visible = true;
            dangKy1.BringToFront();
        }

        private void panelControl3_Paint_1(object sender, PaintEventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
