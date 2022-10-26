using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAD_project_WinFormsApp
{
    class Member : Person
    {
        private double amount;
        private String timing;
       

        public double MAmount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }
        public String MTiming
        {
            get { return this.timing; }
            set { this.timing = value; }
        }
        public void AddMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=CHHAY\SQL;Initial Catalog=OOAD;Integrated Security=True");
                con.Open();
                String query = "INSERT INTO tbl_member VALUES('" +name+ "','" + phone + "','" + gender + "'," + age + "," + MAmount + ",'" + MTiming + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added successfully");
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        public void UpdateMember(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=CHHAY\SQL;Initial Catalog=OOAD;Integrated Security=True");
                con.Open();
                String query = "UPDATE tbl_member SET MName = '" + name + "',MPhone = '" + phone + "',MGen = '" + gender + "',MAge = " + age + ",MAmount = " + MAmount + ",MTiming = '" + MTiming + "' WHERE Mid = " + id + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Member Updated Sucessfully");
                con.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DeleteMember(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CHHAY\SQL;Initial Catalog=OOAD;Integrated Security=True");
            con.Open();
            String query = "DELETE FROM tbl_member WHERE Mid= " + id + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Member Deleted successfully");
            con.Close();
        }
    }
}
