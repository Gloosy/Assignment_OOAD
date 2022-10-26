using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OOAD_project_WinFormsApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=CHHAY\SQL;Initial Catalog=OOAD;Integrated Security=True");
        
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            try
            {
                String query = "SELECT * FROM login WHERE admin ='"+txtUsername.Text+"' AND password = '"+txtPassword.Text+"' ";
                SqlDataAdapter exc = new SqlDataAdapter(query, con);

                DataTable dtable = new DataTable();
                exc.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txtUsername.Text;
                    password = txtPassword.Text;

                    MainForm form2 = new MainForm();
                    form2.ShowDialog();
                    this.Hide();
                }else
                {
                    MessageBox.Show("Invalid login","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsername.Clear();

                    txtUsername.Focus();
                    
                }
            }
            catch
            {
                MessageBox.Show("404");
            }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
