using DevExpress.XtraEditors;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietLacSo2022
{
    public partial class DSPM : DevExpress.XtraEditors.XtraUserControl
    {
        public DSPM()
        {
            InitializeComponent();
            //this.Visible = true;
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // X-coordinate of upper-left corner or padding at start
            int nTopRect,// Y-coordinate of upper-left corner or padding at the top of the textbox
            int nRightRect, // X-coordinate of lower-right corner or Width of the object
            int nBottomRect,// Y-coordinate of lower-right corner or Height of the object
                            //RADIUS, how round do you want it to be?
            int nheightRect, //height of ellipse 
            int nweightRect //width of ellipse
        );
        int _radius = 20;
        int _opacity = 125;
        Color _backColor = Color.Black;
        public DSPM(TableLayoutPanel tableLayoutPanel1)
        {
            TableLayoutPanelControl = tableLayoutPanel1;
        }
        public  TableLayoutPanel TableLayoutPanelControl
        {
            get { return tableLayoutPanel1; }
            set { tableLayoutPanel1 = value; }
        }

        private void DSPM_Load(object sender, EventArgs e)
        {
          
            
            try
            {
                string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionstring);
                conn.Open();
                string query = @"select id, tenphanmem, anhphanmem from phanmem";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();
                int x = 0, y = 0;
                while (r.Read())
                {
                    int id = Convert.ToInt32(r["id"]); ;
                    string tenphanmem = r["tenphanmem"].ToString();
                    Image anhphanmem = Image.FromFile(r["anhphanmem"].ToString());
                    DanhSachPhanMem_2cs obj = new DanhSachPhanMem_2cs(id, tenphanmem, anhphanmem);

                    tableLayoutPanel1.Controls.Add(obj, y, x);

                    y++;
                    if (y >= 5)
                    {
                        y = 0;
                        x++;
                    }

                }
                r.Close();
                //cmd.Clone();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            this.textEdit1.AutoSize = false;
            this.textEdit1.Size = new System.Drawing.Size(295, 31);
            Label imgLabel = new Label();
            imgLabel.Image = imageCollection1.Images[0];
            imgLabel.AutoSize = false;
            imgLabel.Size = imgLabel.Image.Size;
            imgLabel.ImageAlign = ContentAlignment.MiddleCenter;
            imgLabel.Text = "";
            imgLabel.BackColor = Color.Transparent;
            imgLabel.Parent = textEdit1;
            // pick a location where it won't get in the way too much
            imgLabel.Location = Point.Empty;
            panelControl2.BackColor = Color.White;
            panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl3.BackColor = Color.FromArgb(241, 243, 250);
            panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
        }

        private void TextEdit1_Resize(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            while (tableLayoutPanel1.Controls.Count > 0)
            {
                tableLayoutPanel1.Controls[0].Dispose();
            }
            if (e.KeyChar == (char)13 && textEdit1.Text != null )
            {
                try
                {
                    string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(connectionstring);
                    conn.Open();
                    string query = @"select id, tenphanmem, anhphanmem from phanmem where id = @id or tenphanmem like N'@tenphanmem'  ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", textEdit1.Text);
                    cmd.Parameters.AddWithValue("@tenphanmem", string.Format("%{0}%", textEdit1.Text));
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    SqlDataReader r = cmd.ExecuteReader();
                    int x = 0, y = 0;
                    while (r.Read())
                    {
                        int id = Convert.ToInt32(r["id"]); ;
                        string tenphanmem = r["tenphanmem"].ToString();
                        Image anhphanmem = Image.FromFile(r["anhphanmem"].ToString());
                        DanhSachPhanMem_2cs obj = new DanhSachPhanMem_2cs(id, tenphanmem, anhphanmem);

                        tableLayoutPanel1.Controls.Add(obj, y, x);
                        //tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        y++;
                        if (y >= 5)
                        {
                            y = 0;
                            x++;
                        }

                    }
                    r.Close();

                    //cmd.Clone();
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
               
            }
            
            else
            {
                string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionstring);
                conn.Open();
                string query = @"select id, tenphanmem, anhphanmem from phanmem";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();
                int x = 0, y = 0;
                while (r.Read())
                {
                    int id = Convert.ToInt32(r["id"]); ;
                    string tenphanmem = r["tenphanmem"].ToString();
                    Image anhphanmem = Image.FromFile(r["anhphanmem"].ToString());
                    DanhSachPhanMem_2cs obj = new DanhSachPhanMem_2cs(id, tenphanmem, anhphanmem);

                    tableLayoutPanel1.Controls.Add(obj, y, x);

                    y++;
                    if (y >= 5)
                    {
                        y = 0;
                        x++;
                    }

                }
                r.Close();
            }
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MyMessageBox2 newms2 = new MyMessageBox2();
            newms2.Show();
        }

        private void textEdit1_Paint(object sender, PaintEventArgs e)
        {
           
        }
       
        private void textEdit1_Resize(object sender, EventArgs e)
        {
            base.OnResize(e);
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(2, 3, this.Width, this.Height, 15, 15));
        }
    }
}
