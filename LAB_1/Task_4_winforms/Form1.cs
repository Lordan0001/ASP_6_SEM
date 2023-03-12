using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_4_winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void  button1_ClickAsync(object sender, EventArgs e)
        {
                string x = FirstNum.Text;
                string y = SecondNum.Text;
                var url = $"https://localhost:44331/BVD/sum?X={x}&Y={y}";
                using (var client = new HttpClient())
                {
                    var req = new HttpRequestMessage(HttpMethod.Post, url);
                    var res = await client.SendAsync(req);
                    this.ResultNum.Text = res.Content.ReadAsStringAsync().Result;
                }
            
        }
    }
}
