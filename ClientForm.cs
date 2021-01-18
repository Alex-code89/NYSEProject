using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Formatting;


namespace NYSEProject
{
    public partial class ClientForm : Form
    {
        HttpClient client = new HttpClient();

        public ClientForm()
        {
            InitializeComponent();
        }

        private void WebServicesSetting()
        {
            client.BaseAddress = new Uri("https://localhost:44385/clientAPI.asmx/");
        }
        private DataTable splitString (string jsonString)
        {
            string[] json = jsonString.Split('>');
            string[] finalJson = json[2].Split('<');
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(finalJson[0]);
            return dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            HttpResponseMessage message = client.GetAsync("usersDT?symbol=" + textBox1.Text + "").Result;
            string messageJson = message.Content.ReadAsStringAsync().Result;
            dataGridView1.DataSource = splitString(messageJson);
            

        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            WebServicesSetting();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Alex put help instructions. This is the second line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
