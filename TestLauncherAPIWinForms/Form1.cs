using VietLacSo2022;
using WordPressPCL;
using Newtonsoft.Json;

namespace TestLauncherAPIWinForms
{
    public partial class Form1 : Form
    {
        private readonly VietLacWordPress vlwp;

        public Form1()
        {
            InitializeComponent();
            vlwp = new VietLacWordPress();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.button1.Text = "Please wait ...";
            var products = await vlwp.GetProducts();
            var dialog = MessageBox.Show(JsonConvert.SerializeObject(products));
            if (dialog == DialogResult.OK)
            {
                this.button1.Text = "Get Products";
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await vlwp.Login("vilapadev", "GUQE9JqsMKwftMnMZVKyZZ4K");
        }
    }
}