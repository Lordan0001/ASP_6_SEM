using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("X", x));
            data.Add(new KeyValuePair<string, string>("Y", y));

            var url = "https://localhost:44331/BVD/sum";
            using (var client = new HttpClient())
            {
                var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(data) };
                var res = await client.SendAsync(req);
                ResultNum.Text = res.Content.ReadAsStringAsync().Result; 
            }

        }
      
    }
}
