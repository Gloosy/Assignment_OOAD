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
    public partial class FormCoach : Form
    {
        Coach coach = new Coach();
        public FormCoach()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AddMember frm = new AddMember();
            frm.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=CHHAY\SQL;Initial Catalog=OOAD;Integrated Security=True");
        public Coach Coach { get => coach; set => coach = value; }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text == "" || txtAge.Text == "" || txtDes.Text== "" || cboGender.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Missing informations.");
            }
            else
            {
                Coach.name = txtName.Text;
                Coach.phone = txtPhone.Text;
                Coach.gender = cboGender.Text;
                Coach.age = Convert.ToInt32(txtAge.Text);
                Coach.Description = txtDes.Text;
                Coach.CPrice = Convert.ToDouble(txtPrice.Text);
                coach.addCoach();
                txtName.Text = "";
                txtPhone.Text = "";
                txtAge.Text = "";
                txtDes.Text = "";
                cboGender.Text = "";
                txtPrice.Text = "";
               
            }
        }

        private void FormCoach_Load(object sender, EventArgs e)
        {

        }
    }
}
