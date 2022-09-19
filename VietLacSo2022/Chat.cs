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
    public partial class Chat : DevExpress.XtraEditors.XtraForm
    {
        public Chat()
        {
            InitializeComponent();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.ActiveForm.Width - this.Width, Screen.ActiveForm.Height- this.Height -20); ;
            panelControl1.BackColor = Color.FromArgb(57, 160, 255);
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.AutoScroll = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Send();
        }
        void Send()
        {
            if (textEdit1.Text.Trim().Length == 0) return;
            AddOutgoing(textEdit1.Text);
            textEdit1.Text = String.Empty;
            timer1.Start();
        }
        int curtop = 10;
        void AddIncoming(string mesage)
        {
            var bubble = new Incoming();
            panelControl3.Controls.Add(bubble);
            bubble.Top= curtop;
            bubble.Width = panelControl3.Width;
            bubble.Message = mesage;
            curtop +=bubble.Height;
        }
        void AddOutgoing(string mesage)
        {
            var bubble = new Outgoing();
            panelControl3.Controls.Add(bubble);
            bubble.Top = curtop;
            bubble.Width = panelControl3.Width;
            bubble.Message = mesage;
            curtop += bubble.Height;
        }

        private void simpleButton1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Send();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            AddIncoming("Xin lỗi chúng tôi chưa trả lời được câu hỏi này");
        }

        private void Chat_Shown(object sender, EventArgs e)
        {
            AddIncoming("Chào mừng quý khách đến với trung tâm hỗ trợ Việt Lạc! Chúng tôi có thể giúp gì cho quý khách?");
        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}