using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace YoutubePlayer
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This function is called when the form loads
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // This function is called when the label is clicked
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string videoUrl = Videolink.Text;
            string videoId = ExtractYouTubeId(videoUrl);
            await SendVideoIdToServer(videoId);
            LoadYouTubeVideo(videoId);
        }

        private string ExtractYouTubeId(string url)
        {
            var uri = new Uri(url);
            var query = uri.Query.TrimStart('?');
            var queryParams = query.Split('&');

            foreach (var param in queryParams)
            {
                var keyValue = param.Split('=');
                if (keyValue.Length == 2 && keyValue[0] == "v")
                {
                    return keyValue[1];
                }
            }

            return "";
        }

        private void LoadYouTubeVideo(string videoId)
        {
            string html = $@"
                <html>
                <head>
                    <meta content='IE=Edge' http-equiv='X-UA-Compatible'/>
                </head>
                <body>
                    <iframe id='video' src='https://www.youtube.com/embed/{videoId}' width='600' height='300' frameborder='0' allowfullscreen></iframe>
                </body>
                </html>";

            video.DocumentText = html;
        }

        private async Task SendVideoIdToServer(string videoId)
        {
            try
            {
                var json = JsonConvert.SerializeObject(new { videoId = videoId });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://localhost:5000/videos", content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Server error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending video ID: {ex.Message}");
            }
        }
    }
}
