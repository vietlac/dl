using DevExpress.Pdf;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietLacSo2022
{
    public partial class TaiLieu : DevExpress.XtraEditors.XtraUserControl
    {
        public static string newac = string.Empty;
        public string NEWAC
        {
            get { return newac; }
            set { newac = value; }
        }
        public static string _url= string.Empty;
        public string VideoID
        {
            get
            {
                var yMatch = new Regex(@"http(?:s?)://(?:www\.)?youtu(?:be\.com/watch\?v=|\.be/)([\w\-]+)(&(amp;)?[\w\?=]*)?").Match(_url);
                return yMatch.Success ? yMatch.Groups[1].Value : String.Empty;
            }
        }
        public TaiLieu()
        {
            InitializeComponent();
            labelControl3.Visible = false;
        }

        private void accordionControl1_Click(object sender, EventArgs e)
        {

        }

        private void TaiLieu_Load(object sender, EventArgs e)
        {
            panelControl1.BackColor = Color.White;
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl3.BackColor = Color.FromArgb(241, 243, 250);
            panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl4.BackColor = Color.FromArgb(241, 243, 250);
            panelControl4.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl4.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl5.BackColor = Color.White;
            panelControl5.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl5.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl6.BackColor = Color.FromArgb(241, 243, 250);
            panelControl6.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl6.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl7.BackColor = Color.FromArgb(241, 243, 250);
            panelControl7.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl7.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            panelControl8.BackColor = Color.FromArgb(241, 243, 250);
            panelControl8.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl8.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            accordionControl1.AllowItemSelection = Enabled;
            accordionControl1.Appearance.Item.Pressed.BackColor = Color.Red;
            accordionControl1.Appearance.Group.Normal.FontSizeDelta = 4;
            accordionControl1.Appearance.Group.Hovered.FontSizeDelta = 4;
            accordionControl1.Appearance.Group.Pressed.FontSizeDelta = 4;
            accordionControl1.Appearance.Item.Normal.FontSizeDelta = 4;
            accordionControl1.Appearance.Item.Hovered.FontSizeDelta = 4;
            accordionControl1.Appearance.Item.Pressed.FontSizeDelta = 4;
            string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string query = @"select * from phanmem";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader r = cmd.ExecuteReader();
           // LabelControl lb = new LabelControl();
            while (r.Read())
            {
                AccordionControlElement group = accordionControl1.Elements.OfType<AccordionControlElement>().Where(el => el.Style == ElementStyle.Group).First();
                AccordionControlElement ac = new AccordionControlElement();
                ac.Text = r["tenphanmem"].ToString();
                newac = ac.Text;
                group.Elements.Add(ac);
                ac.Click += newitemclick;
               
            }
            

        }
        private void newitemclick(object sender, EventArgs e)
        {
            //this.Appearance.BackColor = Color.Red;
            // MessageBox.Show(newac);
            string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string query = @"select * from phanmem where tenphanmem=N'" + newac + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader r = cmd.ExecuteReader();
            
            while (r.Read())
            {
                labelControl3.Visible = true;
                labelControl3.Text = r["tenpdf"].ToString();
                FileStream stream = System.IO.File.Open(r["huongdanpdf"].ToString(), FileMode.Open, FileAccess.Read, FileShare.Read);
                pdfViewer1.LoadDocument(stream);
                //string filename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().FullName), r["huongdanvideo"].ToString());
                int x = 0, y = 0;
                TaiLieu2 obj = new TaiLieu2();
                tableLayoutPanel1.Controls.Add(obj, y, x);
                y++;
                if (y >= 3)
                {
                    y = 0;
                    x++;
                }
            }
            
        }
            private void accordionControl1_MouseEnter(object sender, EventArgs e)
        {

            accordionControl1.AllowItemSelection = Enabled;
            accordionControl1.Appearance.Item.Pressed.BackColor = Color.FromArgb(57, 160, 255);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pdfViewer1.Visible = !pdfViewer1.Visible;
            panelControl6.Visible = !panelControl6.Visible;

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
            //axWindowsMediaPlayer1.Visible = !axWindowsMediaPlayer1.Visible;
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = !tableLayoutPanel1.Visible;
            panelControl8.Visible = !panelControl8.Visible;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            MyMessageBox2 newms2 = new MyMessageBox2();
            newms2.Show();
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            MyMessageBox2 newms2 = new MyMessageBox2();
            newms2.Show();
        }
    }
}
