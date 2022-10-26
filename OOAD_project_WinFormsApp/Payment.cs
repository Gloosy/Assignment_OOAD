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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            txtAmount.Text = "";
        }
        SqlConnection con = new SqlConnection(@"Data Source=CHHAY\SQL;Initial Catalog=OOAD;Integrated Security=True");
        private void  FillName()
        {
            if(comboBox1.Text == "Coach")
            {
                cboName.Hide();
                comboBox2.Show();
                con.Open();
                String query = "SELECT CName FROM tbl_coach";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("CName", typeof(String));
                dt.Load(sdr);
                comboBox2.ValueMember = "CName";
                comboBox2.DataSource = dt;
                con.Close();
            }else
            {
                comboBox2.Hide();
                cboName.Show();
                con.Open();
                String query = "SELECT MName FROM tbl_member";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("MName", typeof(String));
                dt.Load(sdr);
                cboName.ValueMember = "MName";
                cboName.DataSource = dt;
                con.Close();
            }
            

        }
        private void loadData()
        {
            
                con.Open();
                String query = "SELECT * FROM tbl_payment";
                SqlDataAdapter s = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder();
                var data = new DataSet();
                s.Fill(data);
                dgvPayment.DataSource = data.Tables[0];
                con.Close();
               

        }
        private void FilterByName()
        {

            con.Open();
            String query = "SELECT * FROM tbl_payment WHERE PMember = '"+txtSearch.Text+"'";
            SqlDataAdapter s = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var data = new DataSet();
            s.Fill(data);
            dgvPayment.DataSource = data.Tables[0];
            con.Close();

        }
        private void Payment_Load(object sender, EventArgs e)
        {
            FillName();
            loadData();  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int key = 1;
        private void btnPay_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Coach")
            {
                if (comboBox2.Text == "" || txtAmount.Text == "")
                {
                    MessageBox.Show("Mssing informations");

                }
                else
                {
                    try
                    {
                        String payperiode = dateTimePicker1.Value.Day.ToString() + dateTimePicker1.Value.Month.ToString() + dateTimePicker1.Value.Year.ToString();
                        con.Open();
                        String sql = "SELECT COUNT(*) FROM tbl_payment WHERE PMember = '" + comboBox2.SelectedValue.ToString() + "' AND PMonth = '" + payperiode + "';";
                        SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            MessageBox.Show("Already Paid for this month");
                        }
                        else
                        {
                            String query = "INSERT INTO tbl_payment VALUES('" + payperiode + "','" + comboBox2.SelectedValue.ToString() + "'," + txtAmount.Text + ")";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Paid Successfully");
                        }
                        con.Close();
                        loadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                if (cboName.Text == "" || txtAmount.Text == "")
                {
                    MessageBox.Show("Mssing informations");

                }
                else
                {
                    try
                    {
                        String payperiode = dateTimePicker1.Value.Day.ToString() + dateTimePicker1.Value.Month.ToString() + dateTimePicker1.Value.Year.ToString();
                        con.Open();
                        String sql = "SELECT COUNT(*) FROM tbl_payment WHERE PMember = '" + cboName.SelectedValue.ToString() + "' AND PMonth = '" + payperiode + "';";
                        SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            MessageBox.Show("Already Paid for this month");
                        }
                        else
                        {
                            String query = "INSERT INTO tbl_payment VALUES('" + payperiode + "','" + cboName.SelectedValue.ToString() + "'," + txtAmount.Text + ")";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Paid Successfully");
                        }
                        con.Close();
                        loadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }






            
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

        private void button2_Click(object sender, EventArgs e)
        {
            FillName();
           
        }
    }
}
