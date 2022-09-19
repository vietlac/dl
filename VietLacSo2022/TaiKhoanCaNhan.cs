using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietLacSo2022
{
    public partial class TaiKhoanCaNhan : DevExpress.XtraEditors.XtraUserControl
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
        public static string thetext2 = string.Empty;
        public static string thetext3 = string.Empty;
        public static string thetext4= string.Empty;
        public static string thetext5 = string.Empty;
        public static string thetext6 = string.Empty;
        public static string thetext7 = string.Empty;
        public string TheText2
        {
            get => thetext2;
            set => thetext2 = value;

        }
        public string TheText3
        {
            get => thetext3;
            set => thetext3 = value;


        }
        public string TheText4
        {
            get => thetext4;
            set => thetext4 = value;

        }
        public string TheText5
        {
            get => thetext5;
            set => thetext5 = value;

        }
        public string TheText6
        {
            get => thetext6;
            set => thetext6 = value;

        }
        public string TheText7
        {
            get => thetext7;
            set => thetext7 = value;

        }
        public TaiKhoanCaNhan()
        {
            InitializeComponent();
            textEdit2.Visible = false;
            textEdit3.Visible = false;
            textEdit4.Visible = false;
            textEdit5.Visible = false;
            textEdit6.Visible = false;
            textEdit7.Visible = false;
        }
       
        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void TaiKhoanCaNhan_Load(object sender, EventArgs e)
        {
            simpleButton1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            simpleButton1.Appearance.BorderColor = Color.FromArgb(57, 160, 255);
            simpleButton1.AllowFocus = false;
            simpleButton2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            simpleButton2.Appearance.BorderColor = Color.FromArgb(57, 160, 255);
            simpleButton2.AllowFocus = false;
            panelControl3.BackColor = Color.White;
            panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl4.BackColor = Color.FromArgb(241, 243, 250);
            panelControl4.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl4.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl5.BackColor = Color.White;
            panelControl5.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl5.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            //textEdit2.Visible = false;
           // Form1 f = new Form1();
            string var = Form1.sodienthoai2;
            string var2 = Form1.matkhau2;
            bool accept = true;
            string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string query = @"select * from nguoidung where sodienthoai = '" + var + "' and matkhau = '" + var2 + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                accept = true;
            }
            if (accept == true)
            {
                labelControl2.Text = r["hoten"].ToString();
                textEdit2.Text = r["hoten"].ToString();
                labelControl4.Text = ((DateTime)r["ngaysinh"]).ToString("dd'/'MM'/'yyyy");
                textEdit3.Text = ((DateTime)r["ngaysinh"]).ToString("dd'/'MM'/'yyyy");
                labelControl6.Text= r["sodienthoai"].ToString();
                textEdit4.Text = r["sodienthoai"].ToString();
                labelControl9.Text = r["email"].ToString();
                textEdit5.Text = r["email"].ToString();

                if (r["gioitinh"].ToString()== radioButton1.Text|| System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(r["gioitinh"].ToString().ToLower())== radioButton1.Text)
                {
                    //radioButton1.CheckState = CheckState.Checked;
                    radioButton1.Checked = true;

                }
                if(r["gioitinh"].ToString() == radioButton2.Text || System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(r["gioitinh"].ToString().ToLower()) == radioButton2.Text)
                {
                    //checkEdit2.CheckState = CheckState.Checked;
                    radioButton2.Checked = true;
                }
                labelControl11.Text = r["diachi"].ToString();
                textEdit6.Text = r["diachi"].ToString(); ;
                labelControl13.Text = r["id"].ToString();
                labelControl15.Text = r["matkhau"].ToString();
                textEdit7.Text = r["matkhau"].ToString(); ;

            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MyMessageBox2 newms2 = new MyMessageBox2();
            newms2.Show();
               
            
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

            MyMessageBox2 newms2 = new MyMessageBox2();
            newms2.Show();
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }
        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            simpleButton2.Text = "Lưu";
            textEdit2.Visible = true;
            textEdit3.Visible = true;
            textEdit4.Visible = true;
            textEdit5.Visible = true;
            textEdit6.Visible = true;
            textEdit7.Visible = true;
            simpleButton2.Click += myButton_Click;
        }
        private void textEdit2_TextChanged(object sender, EventArgs e)
        {
           
           
           
        }
        void myButton_Click(object sender, EventArgs e)
        {

            string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            if (radioButton1.Checked == true)
            {
                string query = @"UPDATE nguoidung 
                             SET hoten = @hoten, ngaysinh = @ngaysinh, sodienthoai = @sodienthoai, email = @email, gioitinh= @gioitinh,  diachi= @diachi, matkhau= @matkhau Where id =@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                var date = DateTime.ParseExact(thetext3, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@hoten", thetext2);
                cmd.Parameters.AddWithValue("@ngaysinh", date);
                cmd.Parameters.AddWithValue("@sodienthoai", thetext4);
                cmd.Parameters.AddWithValue("@email", thetext5);
                cmd.Parameters.AddWithValue("@gioitinh", radioButton1.Text);
                cmd.Parameters.AddWithValue("@diachi", thetext6);
                cmd.Parameters.AddWithValue("@matkhau", thetext7);
                cmd.Parameters.AddWithValue("@id", labelControl13.Text);
                SqlDataReader r = cmd.ExecuteReader();
                textEdit2.Visible = false;
                textEdit3.Visible = false;
                textEdit4.Visible = false;
                textEdit5.Visible = false;
                textEdit6.Visible = false;
                textEdit7.Visible = false;
                r.Close();
                conn.Close();
                labelControl2.Text = thetext2;
                labelControl4.Text = thetext3;
                labelControl6.Text = thetext4;
                labelControl9.Text = thetext5;
                labelControl11.Text = thetext6;
                labelControl15.Text = thetext7;
                radioButton2.Checked = false;
                simpleButton2.Text = "Sửa";
                simpleButton2.Click += simpleButton2_Click_1;
            }
            else if (radioButton2.Checked == true)
            {
                string query = @"UPDATE nguoidung 
                             SET hoten = @hoten, ngaysinh = @ngaysinh, sodienthoai = @sodienthoai, email = @email, gioitinh= @gioitinh,  diachi= @diachi, matkhau= @matkhau Where id =@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                var date = DateTime.ParseExact(thetext3, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@hoten", thetext2);
                cmd.Parameters.AddWithValue("@ngaysinh", date);
                cmd.Parameters.AddWithValue("@sodienthoai", thetext4);
                cmd.Parameters.AddWithValue("@email", thetext5);
                cmd.Parameters.AddWithValue("@gioitinh", radioButton2.Text);
                cmd.Parameters.AddWithValue("@diachi", thetext6);
                cmd.Parameters.AddWithValue("@matkhau", thetext7);
                cmd.Parameters.AddWithValue("@id", labelControl13.Text);
                SqlDataReader r = cmd.ExecuteReader();
                textEdit2.Visible = false;
                textEdit3.Visible = false;
                textEdit4.Visible = false;
                textEdit5.Visible = false;
                textEdit6.Visible = false;
                textEdit7.Visible = false;
                r.Close();
                conn.Close();
                labelControl2.Text = thetext2;
                labelControl4.Text = thetext3;
                labelControl6.Text = thetext4;
                labelControl9.Text = thetext5;
                labelControl11.Text = thetext6;
                labelControl15.Text = thetext7;
                radioButton1.Checked = false;
                simpleButton2.Text = "Sửa";
                simpleButton2.Click += simpleButton2_Click_1;
            }
        }

        private void textEdit3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textEdit4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textEdit5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textEdit6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textEdit7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

            MyMessageBox newms = new MyMessageBox();            
            newms.StartPosition = FormStartPosition.CenterScreen;
            newms.Show();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            MyMessageBox2 newms2 = new MyMessageBox2();
            newms2.Show();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit2_TextChanged_1(object sender, EventArgs e)
        {
            thetext2 = textEdit2.Text;
        }

        private void textEdit3_TextChanged_1(object sender, EventArgs e)
        {
            thetext3 = textEdit3.Text;
        }

        private void textEdit4_TextChanged_1(object sender, EventArgs e)
        {
            thetext4 = textEdit4.Text;
        }

        private void textEdit5_TextChanged_1(object sender, EventArgs e)
        {
            thetext5 = textEdit5.Text;
        }

        private void textEdit6_TextChanged_1(object sender, EventArgs e)
        {
            thetext6 = textEdit6.Text;
        }

        private void textEdit7_TextChanged_1(object sender, EventArgs e)
        {
            thetext7 = textEdit7.Text;
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

        private void panelControl5_Paint(object sender, PaintEventArgs e)
        {
           
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(57, 160, 255), 2, ButtonBorderStyle.Solid, Color.FromArgb(57, 160, 255), 2, ButtonBorderStyle.Solid, Color.FromArgb(57, 160, 255), 2, ButtonBorderStyle.Solid, Color.FromArgb(57, 160, 255), 2, ButtonBorderStyle.Solid);
        }
    }
}
