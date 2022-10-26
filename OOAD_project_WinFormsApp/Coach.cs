using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAD_project_WinFormsApp
{
    class Coach:Person
    {
        private double price;
        private String des;
        
       
        public double CPrice
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public String Description
        {
            get { return this.des; }
            set { this.des = value; }
        }
        public void AddMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=CHHAY\SQL;Initial Catalog=OOAD;Integrated Security=True");
                con.Open();
                String query = "INSERT INTO tbl_coach VALUES('" + name + "','" + phone + "','" + gender + "'," + age + ",'" + Description + "'," + CPrice + ")";
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
                String query = "UPDATE tbl_coach SET CName = '" + name + "',CPhone = '" + phone + "',CGen = '" + gender + "',CAge = " + age + ",CDesciption = '"+Description+"',CPrice = "+CPrice+" WHERE Cid = " + id + "";                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Coach Updated Sucessfully");
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
            String query = "DELETE FROM tbl_coach WHERE Cid= " + id + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Coach Deleted successfully");
            con.Close();
        }
    }
}
