using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAD_project_WinFormsApp
{
    public class Connection
    {
        private static Connection instance ;

        private Connection() { }

        public static Connection Instance
        {
            get 
            {   if(instance == null)
                {
                    instance = new Connection();
                }
                return instance; 
            }
        }
        public void connectionDatabase(String query)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=CHHAY\SQL;Initial Catalog=OOAD;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
