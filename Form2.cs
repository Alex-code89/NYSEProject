using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NYSEProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\main;Initial Catalog=NYSE;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
                                                      FROM [dbo].[Login]
                                                      WHERE [UserName] = '"+textBox1.Text+"' and [Password] ='"+textBox2.Text+"'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                
                Form1 mainForm = new Form1();
                ClientForm clientForm = new ClientForm();
                if (dt.Rows[0]["Role"].ToString() == "Admin") { mainForm.Show(); }
                else if (dt.Rows[0]["Role"].ToString() == "Client")
                {
                    clientForm.Show();
                }
                else
                {
                    MessageBox.Show("This user's role is not specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Invalid username or password...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
