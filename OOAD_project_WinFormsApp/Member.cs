using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAD_project_WinFormsApp
{
    public interface IMember
    {
        public string addMember();
        public string deleteMember(int id);
        public string updateMember(int id);
    }
    public class Abstraction
    {
        private IMember impMember;

        public Abstraction(IMember implementation)
        {
            impMember = implementation;
        }
        public string addMember()
        {
            Console.WriteLine("testing add member in abstract");
            return impMember.addMember();
        }
        public string deleteMember(int id)
        {
            Console.WriteLine("Testing delete member id :  ", id);
            return impMember.deleteMember(id);
        }
        public string updateMember(int id)
        {
            Console.WriteLine("Testing update member id : ", id);
            return impMember.updateMember(id);
        }
    }
    class Member : Person, IMember
    {
        // varaible for store amount
        private double amount;
        // varaible for store timing
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
        public string addMember()
        {
            string query = "INSERT INTO tbl_member VALUES('" + name + "','" + phone + "','" + gender + "'," + age + "," + MAmount + ",'" + MTiming + "')";
            conDB.connectionDatabase(query);
            MessageBox.Show("Member Added Sucessfully");
            return "Status : 200";
        }

        public string deleteMember(int id)
        {
            string query = "DELETE FROM tbl_member WHERE Mid= " + id + "";
            conDB.connectionDatabase(query);
            MessageBox.Show("Member Deleted Successfully");
            return "Status 200";
        }

        public string updateMember(int id)
        {
            string query = "UPDATE tbl_member SET MName = '" + name + "',MPhone = '" + phone + "',MGen = '" + gender + "',MAge = " + age + ",MAmount = " + MAmount + ",MTiming = '" + MTiming + "' WHERE Mid = " + id + "";
            conDB.connectionDatabase(query);
            MessageBox.Show("Member Updated Sucessfully");
            return "Status 200";
        }
    }

}
