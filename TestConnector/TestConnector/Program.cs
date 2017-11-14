using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Odbc;
using MySql.Data.MySqlClient;


namespace TestConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*
                string driver = "DRIVER={MySQL ODBC 5.2 UNICODE Driver};";
                string server = "Location=147.222.163.1;";
                string database = "Data Source=criley2_DB;";
                string user = "User ID=criley2;";
                string password = "Password=password;";
                string option = "OPTION=3";
                */

                MySql.Data.MySqlClient.MySqlConnection connect;


                //Connection string for Connector/ODBC 3.51
                // Driver={MariaDB ODBC 3.0 Driver};
                string MyConString = "Server=localhost;UID=root;Database=omeka1;PWD=team7;Port=3306";

                connect = new MySql.Data.MySqlClient.MySqlConnection();

                connect.ConnectionString = MyConString;

                connect.Open();

                if (connect.State == ConnectionState.Open)
                {
                    Console.WriteLine("It worked.");

                }


                Console.WriteLine("Connection Information:");
                Console.WriteLine("\tConnection String:" +
                                  connect.ConnectionString);
                Console.WriteLine("\tConnection Timeout:" +
                                  connect.ConnectionTimeout);
                Console.WriteLine("\tDatabase:" +
                                  connect.Database);
                Console.WriteLine("\tDataSource:" +
                                  connect.DataSource);

                Console.WriteLine("\tServerVersion:" +
                                  connect.ServerVersion);






                connect.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }



        }
    }
}
