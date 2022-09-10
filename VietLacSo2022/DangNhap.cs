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
    public partial class DangNhap : DevExpress.XtraEditors.XtraUserControl
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        
        private void DangNhap_Load(object sender, EventArgs e)
        {
           
        }
        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            //dangKy1.Visible = true;
            //dangKy1.BringToFront();
            this.Hide();
            this.Parent.Controls.Add(dk);
            dk.BringToFront();
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textEdit2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
