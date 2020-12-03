using Newtonsoft.Json;
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
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetCompanyPolicy();
        }

        private void GetCompanyPolicy()
        {
            string BaseUri = "http://localhost:4558/api/";
            try
            {
               
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUri);
                    string path = BaseUri + "Student/GetStudentName";
                    client.DefaultRequestHeaders.Add("APIKey", "ABCD123");
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = response.Content.ReadAsStringAsync().Result;
                        var CompanyPolicy = JsonConvert.DeserializeObject<string>(jsonString);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-7NPAUSD\SQLEXPRESS;Initial Catalog=nibm;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter adp = new SqlDataAdapter("SELECT Name from student",con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> Names = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var temp = dataGridView1.Rows[i].Cells[0].Value;

                if (temp == null)
                    continue;

                bool isChecked = (bool)dataGridView1.Rows[i].Cells[0].Value;
                if(isChecked == true)
                {
                    Names.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                }
                else
                {
                    MessageBox.Show("No");
                }
            }
        }
    }
}
