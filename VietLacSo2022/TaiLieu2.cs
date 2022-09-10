using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace VietLacSo2022
{
    public partial class TaiLieu2 : DevExpress.XtraEditors.XtraUserControl
    {
        public TaiLieu2()
        {
            InitializeComponent();
            string connectionstring = "Data Source=ADMIN;Initial Catalog=LacVietSo;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string query = @"select * from videophanmem, phanmem where phanmem.tenphanmem=N'" + TaiLieu.newac + "'" + "and phanmem.idphanmem = videophanmem.idphanmem";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                labelControl1.Text = r["tenvideo"].ToString();
                // webView21.Source = new Uri(@"https://youtube.com");
                // await webView21.EnsureCoreWebView2Async();
                var embed = "<html><head>" +
              "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
              "</head><body>" +
              "<iframe width=\"300\" src=\"{0}\"" +
              "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" +
              "</body></html>";
                var url = r["huongdanvideo"].ToString().Replace("watch?v=","embed/");
                this.webBrowser1.DocumentText = string.Format(embed, url);

            }
          
        }
        

        private async  void TaiLieu2_Load(object sender, EventArgs e)
        {
            
          
        }
    }
}
