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
        // Sigleton Class
        Connection conDB = Connection.Instance;

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
            string query = "INSERT INTO tbl_member VALUES('" + name + "','" + phone + "','" + gender + "'," + age + "," + MAmount + ",'" + MTiming + "')";
            conDB.connectionDatabase(query);
            MessageBox.Show("Member Added Sucessfully");
          
        }
        public void UpdateMember(int id)
        {
            string query = "UPDATE tbl_member SET MName = '" + name + "',MPhone = '" + phone + "',MGen = '" + gender + "',MAge = " + age + ",MAmount = " + MAmount + ",MTiming = '" + MTiming + "' WHERE Mid = " + id + "";
            conDB.connectionDatabase(query);
            MessageBox.Show("Member Updated Sucessfully");
        }
        public void DeleteMember(int id)
        {
            string query = "DELETE FROM tbl_member WHERE Mid= " + id + "";
            conDB.connectionDatabase(query);
            MessageBox.Show("Member Deleted Successfully");
        }
    }
}
