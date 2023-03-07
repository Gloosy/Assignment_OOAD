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

        Connection conDB = Connection.Instance;
       
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
            string query = "INSERT INTO tbl_coach VALUES('" + name + "','" + phone + "','" + gender + "'," + age + ",'" + Description + "'," + CPrice + ")";
            conDB.connectionDatabase(query);
            MessageBox.Show("Coach Added Sucessfully");
        }
        public void UpdateMember(int id)
        {       
            String query = "UPDATE tbl_coach SET CName = '" + name + "',CPhone = '" + phone + "',CGen = '" + gender + "',CAge = " + age + ",CDesciption = '"+Description+"',CPrice = "+CPrice+" WHERE Cid = " + id + "";               
            conDB.connectionDatabase(query);
            MessageBox.Show("Coach Updated Sucessfully");
        }
        public void DeleteMember(int id)
        {
            String query = "DELETE FROM tbl_coach WHERE Cid= " + id + "";
            conDB.connectionDatabase(query);
            MessageBox.Show("Coach Deleted successfully");
        }
    }
}
