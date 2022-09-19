using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Net.Http ;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace VietLacSo2022
{
    public partial class DangKy : DevExpress.XtraEditors.XtraUserControl
    {

        public static string URI = "https://vietlac.com/wp-json/wp/v2/users/";
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
        public DangKy()
        {
            InitializeComponent();
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
        private void DangKy_Load(object sender, EventArgs e)
        {
            panelControl1.BackColor = Color.Transparent;
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            textEdit4.Properties.PasswordChar = '*';
            this.panelControl1.Paint += PanelControl1_Paint;

        }
        private void PanelControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            ColorTop = Color.FromArgb(20, 217, 217, 217);
            ColorBottom = Color.FromArgb(2, 217, 217, 217);
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, this.ColorTop, this.ColorBottom, 90F);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, ClientRectangle);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {



        }

        private void textEdit1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void simpleButton1_Resize(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void vbButton1_Click(object sender, EventArgs e)
        {
            bool accept = true;
            // Regex phoneNumpattern = new Regex(@"\+[0-9]{3}\s+[0-9]{3}\s+[0-9]{5}\s+[0-9]{3}");
            if (string.IsNullOrWhiteSpace(textEdit1.Text))
            {

                MessageBox.Show("Tên không được để trống");
                accept = false;
            }
            else if (string.IsNullOrWhiteSpace(textEdit2.Text))
            {

                MessageBox.Show("Số điện thoại không được để trống");
                accept = false;
            }
            else if (string.IsNullOrWhiteSpace(textEdit3.Text))
            {

                MessageBox.Show("Địa chỉ không được để trống");
                accept = false;
            }
            else if (string.IsNullOrWhiteSpace(textEdit4.Text))
            {

                MessageBox.Show("Mật khẩu không được để trống");
                accept = false;
            }


            // else if (!phoneNumpattern.IsMatch(textEdit2.Text))


            else if (textEdit1.Text != null && textEdit2.Text != null && textEdit3.Text != null && textEdit4.Text != null)
            {
                IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("username",textEdit1.Text),
                    new KeyValuePair<string, string>("name", textEdit2.Text),
                    new KeyValuePair<string, string>("email",textEdit3.Text),
                    new KeyValuePair<string, string>("password", textEdit4.Text),

                };
                HttpContent q = new FormUrlEncodedContent(queries);
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.PostAsync(URI,q))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();
                            HttpContentHeaders headers = content.Headers;
                            MessageBox.Show(mycontent);
                        }
                    }
                }
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(URI))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();
                            HttpContentHeaders headers = content.Headers;
                            MessageBox.Show(mycontent);
                        }
                    }
                }




                //string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
                //SqlConnection conn = new SqlConnection(connectionstring);
                //conn.Open();
                //string query = @"insert into nguoidung(hoten,sodienthoai,diachi,matkhau) VALUES (@hoten,@sodienthoai, @diachi, @matkhau) ";
                //SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("@hoten", textEdit1.Text);
                //cmd.Parameters.AddWithValue("@sodienthoai", textEdit2.Text);
                //cmd.Parameters.AddWithValue("@diachi", textEdit3.Text);
                //cmd.Parameters.AddWithValue("@matkhau", textEdit4.Text);
                //cmd.ExecuteNonQuery();
                this.Hide();

            }

        }
        public void GetAll()
        {

            // List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            //MessageBox.Show(users.ToString());
        }
    }
}
