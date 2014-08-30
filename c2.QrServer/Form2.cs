using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace c2.QrServer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnGetQr_Click(object sender, EventArgs e)
        {
            this.btnGetQr.Enabled = false;
            try
            {
                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(this.txtServerAddr.Text),

                };
                //httpClient.DefaultRequestHeaders.Accept.Add(
                //   new MediaTypeWithQualityHeaderValue("application/json"));
                var url =  "qrcode/create" ;

                var param = Newtonsoft.Json.JsonConvert.SerializeObject(new { content = this.txtContent.Text });
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");



                var httpResult = httpClient.PostAsync(url, contentPost).Result;


                httpResult.EnsureSuccessStatusCode();
                var stream = httpResult.Content.ReadAsStreamAsync().Result;

                var img = Image.FromStream(stream);
                this.pictureBox1.Image = img;
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show(  ex.Message);
                throw;
            }
            finally
            {
                this.btnGetQr.Enabled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.txtServerAddr.Text = Properties.Settings.Default.BaseAddress
                .Replace("0.0.0.0","localhost");
        }
    }
}
