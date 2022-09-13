using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietLacSo2022
{
    public partial class BanQuyen : DevExpress.XtraEditors.XtraUserControl
    {
        public BanQuyen()
        {
            InitializeComponent();
        }
        public static string key_khoa = String.Empty;
        public static string Key_khoa
        {
            get { return key_khoa; }
            set { key_khoa = value; }
        }
        public static string key_k = String.Empty;
        public static string Key_k
        {
            get { return key_k; }
            set { key_k = value; }
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
        private void BanQuyen_Load(object sender, EventArgs e)
        {

            panelControl1.BackColor = Color.FromArgb(241, 243, 250);
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl2.BackColor = Color.White;
            panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;

            string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionstring);
                conn.Open();
                string query = @"select id, tenphanmem, anhphanmem, tinhtrang, key_khoa from phanmem";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();
                int x = 0, y = 0;
                while (r.Read())
                {
                    int id = Convert.ToInt32(r["id"]); ;
                    string tenphanmem = r["tenphanmem"].ToString();
                    Image anhphanmem = Image.FromFile(r["anhphanmem"].ToString());
                    string tinhtrang = r["tinhtrang"].ToString();
                    key_khoa = r["key_khoa"].ToString();
                    BanQuyen_2 obj = new BanQuyen_2(id, tenphanmem, anhphanmem, tinhtrang, key_khoa);
                    tableLayoutPanel1.Controls.Add(obj, y, x);
                    y++;
                    if (y >0)
                    {
                        y = 0;
                        x++;
                    }
                    key_k += key_khoa + Environment.NewLine;

                }
                
                r.Close();
                //cmd.Clone();
            

         
            
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
           
               
        }

        private void simpleButton1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            MyMessageBox2 newms2 = new MyMessageBox2();
            newms2.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
           
        }

        private void simpleButton1_Paint_1(object sender, PaintEventArgs e)
        {
            ColorTop = Color.FromArgb(57, 160, 255);
            ColorBottom = Color.FromArgb(255, 116, 57);
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, this.ColorTop, this.ColorBottom, 180F);
            Graphics g = e.Graphics;
            // LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height + 5), Color.FromArgb(57, 160, 255), Color.FromArgb(255, 116, 57), 180F);
            e.Graphics.DrawString("SAO CHÉP TOÀN BỘ KEY", simpleButton1.Font, lgb, 10, 10);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(key_k);
        }
    }
}
