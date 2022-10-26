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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text == "" || txtAge.Text == "" || txtDes.Text== "" || cboGender.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Missing informations.");
            }
            else
            {
                coach.name = txtName.Text;
                coach.phone = txtPhone.Text;
                coach.gender = cboGender.Text;
                coach.age = Convert.ToInt32(txtAge.Text);
                coach.Description = txtDes.Text;
                coach.CPrice = Convert.ToDouble(txtPrice.Text);            
                coach.AddMember();
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
