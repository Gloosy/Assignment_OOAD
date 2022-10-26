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
    public partial class UpdateDelete : Form
    {
        Member member = new Member();
        Coach coach = new Coach();
        public UpdateDelete()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=CHHAY\SQL;Initial Catalog=OOAD;Integrated Security=True");
        private void loadData()
        {
            try
            {
                if (comboBox1.Text == "Coach")
                {
                    con.Open();
                    String query = "SELECT * FROM tbl_coach";
                    SqlDataAdapter s = new SqlDataAdapter(query, con);
                    SqlCommandBuilder builder = new SqlCommandBuilder();
                    var data = new DataSet();
                    s.Fill(data);
                    dgvUpdateData.DataSource = data.Tables[0];
                    con.Close();
                    label7.Text = "Description:";
                    label8.Visible = false;
                    label10.Show();
                    txtPrice.Show();
                    cboTiming.Hide();
                    txtMAmount.Hide();
                    txtDes.Show();
                    
                }
                else
                {
                    con.Open();
                    String query = "SELECT * FROM tbl_member";
                    SqlDataAdapter s = new SqlDataAdapter(query, con);
                    SqlCommandBuilder builder = new SqlCommandBuilder();
                    var data = new DataSet();
                    s.Fill(data);
                    dgvUpdateData.DataSource = data.Tables[0];
                    con.Close();
                    label7.Name = "Monthly Amount :";
                    label8.Visible = true;
                    label10.Hide();
                    txtPrice.Hide();
                    cboTiming.Show();
                    txtDes.Hide();
                    txtMAmount.Show();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            loadData();
        }



        int id = 0;
        private void dgvViewData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                if (comboBox1.Text == "Coach")
                {
                    id = Convert.ToInt32(dgvUpdateData.SelectedRows[0].Cells[0].Value.ToString());
                    txtName.Text = dgvUpdateData.SelectedRows[0].Cells[1].Value.ToString();
                    txtPhone.Text = dgvUpdateData.SelectedRows[0].Cells[2].Value.ToString();
                    cboGender.Text = dgvUpdateData.SelectedRows[0].Cells[3].Value.ToString();
                    txtAge.Text = dgvUpdateData.SelectedRows[0].Cells[4].Value.ToString();
                    txtDes.Text = dgvUpdateData.SelectedRows[0].Cells[5].Value.ToString();
                    txtPrice.Text = dgvUpdateData.SelectedRows[0].Cells[6].Value.ToString();
                }
                else
                {

                    id = Convert.ToInt32(dgvUpdateData.SelectedRows[0].Cells[0].Value.ToString());
                    txtName.Text = dgvUpdateData.SelectedRows[0].Cells[1].Value.ToString();
                    txtPhone.Text = dgvUpdateData.SelectedRows[0].Cells[2].Value.ToString();
                    cboGender.Text = dgvUpdateData.SelectedRows[0].Cells[3].Value.ToString();
                    txtAge.Text = dgvUpdateData.SelectedRows[0].Cells[4].Value.ToString();
                    txtMAmount.Text = dgvUpdateData.SelectedRows[0].Cells[5].Value.ToString();
                    cboTiming.Text = dgvUpdateData.SelectedRows[0].Cells[6].Value.ToString();
                }
                   
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void dgvUpdateData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUpdateData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateDelete_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void clear()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtAge.Text = "";
            cboGender.Text = "";
            cboTiming.Text = "";
            txtMAmount.Text = "";
            txtPrice.Text = "";
            txtDes.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Coach")
            {
                label8.Visible = false;
                cboTiming.Hide();
                txtMAmount.Hide();
                label7.Name = "Description";
                txtPrice.Show();
                txtDes.Show();
                
                if (id == 0 || txtName.Text == "" || txtPhone.Text == "" || txtAge.Text == "" || txtDes.Text == "" || txtPrice.Text == "")
                {
                    MessageBox.Show("Missing informations");
                }
                else
                {
                    DialogResult res;
                    res = MessageBox.Show("Do you want to update?", "Update Member", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        coach.name = txtName.Text;
                        coach.phone = txtPhone.Text;
                        coach.gender = cboGender.Text;
                        coach.age = Convert.ToInt32(txtAge.Text);
                        coach.CPrice = Convert.ToDouble(txtPrice.Text);
                        coach.Description = txtDes.Text;                          
                        coach.UpdateMember(id);
                        loadData();
                    }
                    else
                    {
                        this.Show();
                    }
                }
            }
            else
            {

                if (id == 0 || txtName.Text == "" || txtPhone.Text == "" || txtAge.Text == "" || txtMAmount.Text == "" || cboGender.Text == "" || cboTiming.Text == "")
                {
                    MessageBox.Show("Missing informations");
                }
                else
                {
                    DialogResult res;
                    res = MessageBox.Show("Do you want to update?", "Update Member", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        member.name = txtName.Text;
                        member.phone = txtPhone.Text;
                        member.gender = cboGender.Text;
                        member.age = Convert.ToInt32(txtAge.Text);
                        member.MAmount = Convert.ToDouble(txtMAmount.Text);
                        member.MTiming = cboTiming.Text;
                        member.UpdateMember(id);
                        loadData();
                    }
                    else
                    {
                        this.Show();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if(comboBox1.Text == "Coach")
            {
                if (id == 0)
                {
                    MessageBox.Show("Select row to delete.");
                }
                else
                {
                    DialogResult res;
                    res = MessageBox.Show("Do you want to delete?", "Delete Coach", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            coach.DeleteMember(id);    
                            loadData();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        this.Show();
                    }
                }
            }
            else
            {
                if (id == 0)
                {
                    MessageBox.Show("Select row to delete.");
                }
                else
                {
                    DialogResult res;
                    res = MessageBox.Show("Do you want to delete?", "Delete Member", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            member.DeleteMember(id);
                            loadData();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        this.Show();
                    }
                }
            }
            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtMAmount_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
