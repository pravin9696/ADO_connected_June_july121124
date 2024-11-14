using System.Data;
using System.Data.SqlClient;

namespace ADO_connected_June_july121124
{
    class CRUD_operation
    {
        public void InsertOperation()
        {
            int id;
            string name;
            string div;
            int totalMarks;
            Console.WriteLine("Enter id,name ,Total Marks and div of Student");
            id = int.Parse(Console.ReadLine());
            name = Console.ReadLine();
            totalMarks = int.Parse(Console.ReadLine());
            div = Console.ReadLine();

            string insertQry = $"insert into tblStudent(id,name,totalMarks,div)values({id},'{name}',{totalMarks},'{div}')";


            //ADO.NET logic

            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=StudDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(insertQry, con);
            cmd.CommandType = CommandType.Text;
            int n=0;
            try
            {
                n = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Id must be unique!!!!!");
            }

            if (n > 0)
            {
                Console.WriteLine("Record inserted Successfully...");
            }
            else
            {
                Console.WriteLine("record not inserted!!!!");
            }
            con.Close();







        }
        public void selectOperation()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-ABKHEEV;Initial Catalog=EmpDB;Integrated Security=True;TrustServerCertificate=True";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from tblEmployee";
            // cmd.CommandText = "ProSelect";
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0].ToString() + " " + rdr[1].ToString() + " " + rdr[2].ToString());
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
            // cr1.selectOperation();
            cr1.InsertOperation();
        }
    }
}
