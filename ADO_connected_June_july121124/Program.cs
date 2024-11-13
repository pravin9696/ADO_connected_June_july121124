using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace ADO_connected_June_july121124
{
    class CRUD_operation
    {
        public void selectOperation()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString= @"Data Source=DESKTOP-ABKHEEV;Initial Catalog=EmpDB;Integrated Security=True;TrustServerCertificate=True";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from tblEmployee";
           // cmd.CommandText = "ProSelect";
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr= cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0].ToString()+" " + rdr[1].ToString()+" " + rdr[2].ToString());
            }
            con.Close();
        }   
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // string constring = "Data Source=DESKTOP-ABKHEEV;Initial Catalog=EmpDB;Integrated Security=True;TrustServerCertificate=True";


            // //SqlConnection con = new SqlConnection("Data Source=DESKTOP-ABKHEEV;Initial Catalog=EmpDB;Integrated Security=True;TrustServerCertificate=True");
            // //step1
            // SqlConnection con = new SqlConnection(constring);
            // con.Open();

            // //step2 
            // SqlCommand cmd = new SqlCommand();

            // cmd.Connection = con;
            // cmd.CommandText = "select * from tblEmployee";
            // cmd.CommandType = CommandType.Text;

            // //select Query  user ExecuteReader() method of SqlCommand
            // //other than select Query use ExecuteNonQuery()method()

            // //step3

            //SqlDataReader rdr = cmd.ExecuteReader();

            // while(rdr.Read())
            // {
            //     int id = (int)rdr[0];
            //     string name = rdr.GetString(1);
            //     //decimal salary=rdr.GetDecimal(2);
            //     int salary = int.Parse(rdr[2].ToString());
            //     string add = rdr.GetString(3);
            //     Console.WriteLine(id+" "+name+" "+salary+" "+add);
            // }

            // con.Close();

            CRUD_operation cr1 = new CRUD_operation();
            cr1.selectOperation();
        }
    }
}
