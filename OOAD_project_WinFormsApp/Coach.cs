using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAD_project_WinFormsApp
{
    // base interface 
    public abstract class IComponent
    {
        
        public abstract string addCoach();
        public abstract string updateCoach(int id);
        public abstract string deleteCoach(int id);
    }

    class Component : IComponent
    {
        
        public override string addCoach()
        {
            return "Status 200";
        }

      
        public override string deleteCoach(int id)
        {
            return "Status 200";
        }

      
        public override string updateCoach(int id)
        {
            return "Status 200";
        }
    }
    // Derived Decorator class
    public class Coach : IPerson
    {

        protected IPerson person = new Person();
        IComponent component = new Component();
        Connection conDB = Connection.Instance;
        private double price;
        private String des;

        public Coach(IComponent component)
        {
            this.component = component;
        }

        public Coach()
        {
        }

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


        public int id { get => person.id; set => person.id = value; }
        public string name { get => person.name; set => person.name = value; }
        public string phone { get => person.phone; set => person.phone = value; }
        public string gender { get => person.gender; set => person.gender = value; }
        public int age { get => person.age; set => person.age = value; }
        public string addCoach()
        {
            string message = component.addCoach();
            string query = "INSERT INTO tbl_coach VALUES('" + name + "','" + phone + "','" + gender + "'," + age + ",'" + Description + "'," + CPrice + ")";
            conDB.connectionDatabase(query);
            MessageBox.Show("Coach Added Sucessfully");
            return message;
        }
        

        public string updateCoach(int id)
        {
            string message = component.updateCoach(id);
            String query = "UPDATE tbl_coach SET CName = '" + name + "',CPhone = '" + phone + "',CGen = '" + gender + "',CAge = " + age + ",CDesciption = '" + Description + "',CPrice = " + CPrice + " WHERE Cid = " + id + "";
            conDB.connectionDatabase(query);
            MessageBox.Show("Coach Updated Sucessfully");
            return message;
        }
       
        public string deleteCoach(int id)
        {
            string message = component.deleteCoach(id);
            String query = "DELETE FROM tbl_coach WHERE Cid= " + id + "";
            conDB.connectionDatabase(query);
            MessageBox.Show("Coach Deleted successfully");
            return message;
        }
        
    }
    public interface IDoSomething
    {
        public void AddMember();
        public void DeleteMember(int id);
        public void UpdateMember(int id);
    }
}
