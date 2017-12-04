using System;
using System.Data.SqlClient;


public class Class1
{
    public Class1()
    {

        SqlConnection myConnection = new SqlConnection("user id=root;" +
                                                       "password=team7;" +
                                                       "server=localhost;" +
                                                       "Trusted_Connection=yes;" +
                                                       "database=omeka1; " +
                                                       "connection timeout=30");


        try
        {
            myConnection.Open();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        try
        {
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from omeka_element_texts", myConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                Console.WriteLine(myReader["Column1"].ToString());
                Console.WriteLine(myReader["Column2"].ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }


        try
        {
            myConnection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}