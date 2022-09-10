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
    public partial class Outgoing : DevExpress.XtraEditors.XtraUserControl
    {
        public Outgoing()
        {
            InitializeComponent();
        }
        public string Message { get
            {
                return labelControl1.Text;
            } set
            {
                labelControl1.Text = value;
                AdJustHeight();
            } 
        }
        void AdJustHeight()
        {

            labelControl1.Height = Utils.GetTextHeight(labelControl1) + 10;
            panelControl1.Height = labelControl1.Height + panelControl1.Top + labelControl1.Height;
            this.Height = panelControl1.Bottom + 10;
        }
        

        private void Outgoing_Resize(object sender, EventArgs e)
        {
            AdJustHeight();

        }

        private void Outgoing_DockChanged(object sender, EventArgs e)
        {
            AdJustHeight();
        }

        private void Outgoing_Load(object sender, EventArgs e)
        {
            panelControl1.BackColor = Color.FromArgb(26, 67, 131);
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
        }
    }
}
