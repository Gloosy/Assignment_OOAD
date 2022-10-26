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

namespace OOAD_project_WinFormsApp
{
    public partial class ViewMember : Form
    {
        public ViewMember()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=CHHAY\SQL;Initial Catalog=OOAD;Integrated Security=True");
        private void loadData()
        {

            try
            {
                if(comboBox1.Text == "Coach")
                {
                    con.Open();
                    String query = "SELECT * FROM tbl_coach";
                    SqlDataAdapter s = new SqlDataAdapter(query, con);
                    SqlCommandBuilder builder = new SqlCommandBuilder();
                    var data = new DataSet();
                    s.Fill(data);
                    dgvViewData.DataSource = data.Tables[0];
                    con.Close();
                    


                }
                else
                {
                    con.Open();
                    String query = "SELECT * FROM tbl_member";
                    SqlDataAdapter s = new SqlDataAdapter(query, con);
                    SqlCommandBuilder builder = new SqlCommandBuilder();
                    var data = new DataSet();
                    s.Fill(data);
                    dgvViewData.DataSource = data.Tables[0];
                    con.Close();
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        private void FilterByName()
        {
            con.Open();
            String query = "SELECT * FROM tbl_member WHERE MName = '" + txtSearch.Text + "'";
            SqlDataAdapter s = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var data = new DataSet();
            s.Fill(data);
            dgvViewData.DataSource = data.Tables[0];
            con.Close();

        }
        private void ViewMember_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterByName();
            txtSearch.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
