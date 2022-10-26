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
    public partial class AddMember : Form
    {
        Member member = new Member();
        public AddMember()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=CHHAY\SQL;Initial Catalog=OOAD;Integrated Security=True");
        private void AddMember_Load(object sender, EventArgs e)
        {
          

        }
        
 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text == "" || txtAge.Text == "" || txtMAount.Text == "" || cboGender.Text == ""|| cboTiming.Text == "")
            {
                MessageBox.Show("Missing informations.");
            }
            else
            {
                member.name = txtName.Text;
                member.phone = txtPhone.Text;
                member.gender = cboGender.Text;
                member.age = Convert.ToInt32(txtAge.Text);
                member.MAmount =Convert.ToDouble(txtMAount.Text);
                member.MTiming = cboTiming.Text;
                member.AddMember();
                txtName.Text = "";
                txtPhone.Text = "";
                txtAge.Text = "";
                cboGender.Text = "";
                cboTiming.Text = "";
                txtMAount.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtAge.Text = "";
            cboGender.Text = "";
            cboTiming.Text = "";
            txtMAount.Text = "";
        }








        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult res;
            res = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void btnCoach_Click(object sender, EventArgs e)
        {
            FormCoach frm = new FormCoach();
            frm.Show();
            this.Hide();
        }

        private void cboCoachName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
