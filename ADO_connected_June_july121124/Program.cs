using System.Data.SqlClient;
using System.Data;

namespace ADO_connected_June_july121124
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string constring = "Data Source=DESKTOP-ABKHEEV;Initial Catalog=EmpDB;Integrated Security=True;TrustServerCertificate=True";

            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-ABKHEEV;Initial Catalog=EmpDB;Integrated Security=True;TrustServerCertificate=True");
            //step1
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            //step2 
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "select * from tblEmployee";
            cmd.CommandType = CommandType.Text;

            //select Query  user ExecuteReader() method of SqlCommand
            //other than select Query use ExecuteNonQuery()method()

            //step3

           SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int id = (int)rdr[0];
                string name = rdr.GetString(1);
                //decimal salary=rdr.GetDecimal(2);
                int salary = int.Parse(rdr[2].ToString());
                string add = rdr.GetString(3);
                Console.WriteLine(id+" "+name+" "+salary+" "+add);
            }

            con.Close();
        }
    }
}
