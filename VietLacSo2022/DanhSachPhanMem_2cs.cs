using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietLacSo2022
{
    public partial class DanhSachPhanMem_2cs : DevExpress.XtraEditors.XtraUserControl
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
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public DanhSachPhanMem_2cs()
        {
            InitializeComponent();
            //chiTietPhanMem1.Visible = false;

        }
        public static decimal giaphanmem;
        public static decimal Giaca
        {
            get { return giaphanmem; }
            set { giaphanmem = value; }
        }
        public DanhSachPhanMem_2cs(int id, string tenphanmem, Image anhphanmem)
        {
            InitializeComponent();
            //chiTietPhanMem1.Visible = false;
            ID = id;
            Pname = tenphanmem;
            Pic = anhphanmem;


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
        private void DanhSachPhanMem_2cs_Load(object sender, EventArgs e)
        {


            
           // pictureBox1.Width = 140;
           // pictureBox1.Height = 123;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //labelControl1.Left = (this.ClientSize.Width - labelControl1.Width) / 2;
           
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            panelControl1.BackColor = Color.White;
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            if (labelControl1.Text.Length > 20)
            {
                LabelControl label1 = new LabelControl();
                LabelControl label2 = new LabelControl();
                LabelControl label3 = new LabelControl();
                label1.Text = labelControl1.Text.Substring(0, 20);
                label2.Text = labelControl1.Text.Substring(20, 20);
                label3.Text = labelControl1.Text.Substring(40, labelControl1.Text.Length- label1.Text.Length - label2.Text.Length);
                
                label1.Left = (this.ClientSize.Width - label1.Width) / 2;
                label2.Left = (this.ClientSize.Width - label2.Width) / 2;
                label3.Left = (this.ClientSize.Width - label3.Width) / 2;
                
                labelControl1.Text = label1.Text + Environment.NewLine + label2.Text + Environment.NewLine+ label3.Text;
                labelControl1.Left = (this.ClientSize.Width - labelControl1.Width) / 2;
               
            }

            



        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string query = @"select * from phanmem where id = " + ID;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader r = cmd.ExecuteReader();
           // int x = 0, y = 0;
            while (r.Read())
            {
                string tenphanmem = r["tenphanmem"].ToString();

                Image anhphanmem = Image.FromFile(r["anhphanmem"].ToString());
                Image anhphanmem2 = Image.FromFile(r["anhphanmem2"].ToString());
                Image anhphanmem3 = Image.FromFile(r["anhphanmem3"].ToString());
                Image anhphanmem4 = Image.FromFile(r["anhphanmem4"].ToString());
                Image anhphanmem5 = Image.FromFile(r["anhphanmem5"].ToString());
                string maphanmem = r["maphanmem"].ToString();
                giaphanmem = decimal.Parse(r["giaphanmem"].ToString());
              //  var a = Chi_Tiet_Phan_Mem.sotien;
                //MessageBox.Show(a.ToString());
               var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
               // decimal giacaphanmem = giaphanmem * a;
                    string gioithieuphanmem = r["gioithieuphanmem"].ToString();
                    string tinhtrangconlai = r["tinhtrangconlai"].ToString();
                    string huongdanmuahang = r["huongdanmuahang"].ToString();

                    Chi_Tiet_Phan_Mem ct = new Chi_Tiet_Phan_Mem(ID, tenphanmem, anhphanmem, anhphanmem2, anhphanmem3, anhphanmem4, anhphanmem5, maphanmem, String.Format(info, "{0:c}", giaphanmem), gioithieuphanmem, tinhtrangconlai, huongdanmuahang);
                    ct.TopLevel = false;
                    // ct.TopMost = true;
                    ct.Dock = DockStyle.Fill;
                    Screen sc = (Screen)Application.OpenForms["Screen"];
                    // PanelControl panel1 = (PanelControl)sc.Controls["panelControl2"];
                    sc.Controls.Add(ct);
                    ct.BringToFront();
                    // sc.Controls.Add(ct);
                    // sc.Show();
                    ct.Show();
                

            }

        }

        private void vbButton1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string query = @"select * from phanmem where id = " + ID;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader r = cmd.ExecuteReader();
            // int x = 0, y = 0;
            while (r.Read())
            {
                string tenphanmem = r["tenphanmem"].ToString();

                Image anhphanmem = Image.FromFile(r["anhphanmem"].ToString());
                Image anhphanmem2 = Image.FromFile(r["anhphanmem2"].ToString());
                Image anhphanmem3 = Image.FromFile(r["anhphanmem3"].ToString());
                Image anhphanmem4 = Image.FromFile(r["anhphanmem4"].ToString());
                Image anhphanmem5 = Image.FromFile(r["anhphanmem5"].ToString());
                string maphanmem = r["maphanmem"].ToString();
                giaphanmem = decimal.Parse(r["giaphanmem"].ToString());
                //  var a = Chi_Tiet_Phan_Mem.sotien;
                //MessageBox.Show(a.ToString());
                var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
                // decimal giacaphanmem = giaphanmem * a;
                string gioithieuphanmem = r["gioithieuphanmem"].ToString();
                string tinhtrangconlai = r["tinhtrangconlai"].ToString();
                string huongdanmuahang = r["huongdanmuahang"].ToString();

                Chi_Tiet_Phan_Mem ct = new Chi_Tiet_Phan_Mem(ID, tenphanmem, anhphanmem, anhphanmem2, anhphanmem3, anhphanmem4, anhphanmem5, maphanmem, String.Format(info, "{0:c}", giaphanmem), gioithieuphanmem, tinhtrangconlai, huongdanmuahang);
                ct.TopLevel = false;
                // ct.TopMost = true;
                ct.Dock = DockStyle.Fill;
                Screen sc = (Screen)Application.OpenForms["Screen"];
                // PanelControl panel1 = (PanelControl)sc.Controls["panelControl2"];
                sc.Controls.Add(ct);
                ct.BringToFront();
                // sc.Controls.Add(ct);
                // sc.Show();
                ct.Show();

            }

        }

        private void vbButton1_MouseHover(object sender, EventArgs e)
        {
            vbButton1.BackColor = Color.FromArgb(57, 160, 255);
            vbButton1.ForeColor = Color.White;
        }

        private void vbButton1_MouseLeave(object sender, EventArgs e)
        {
           vbButton1.BackColor = Color.White;
            vbButton1.ForeColor = Color.FromArgb(57, 160, 255);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
