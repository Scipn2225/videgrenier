using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

public class DataAccessLayer
{
    private readonly string _conString;
    public DataAccessLayer()
    {
        _conString =
        WebConfigurationManager.ConnectionStrings["vigrenier"].ConnectionString;
    }
    public SqlDataReader GetMovies()
    {
        SqlConnection con = new SqlConnection(_conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        // Call the stored procedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "ProductSelect";
        con.Open();
        return cmd.ExecuteReader();

    }


    public SqlDataReader GetUsers()
    {
        SqlConnection con = new SqlConnection(_conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        // Call the stored procedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "userSelect";
        con.Open();
        return cmd.ExecuteReader();

    }



    public SqlDataReader GetEntries()
    {
        SqlConnection con = new SqlConnection(_conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        // Call the ViewReview stored procedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "ViewReview";
        con.Open();
        return cmd.ExecuteReader(CommandBehavior.CloseConnection);
    }
    public void AddEntry(string IPAddress, int user_id, string comment)
    {
        SqlConnection con = new SqlConnection(_conString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        // Call the AddReview stored procedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "AddReview";
        DateTime thisDay = DateTime.Now;
        cmd.Parameters.AddWithValue("@ip", IPAddress);
        cmd.Parameters.AddWithValue("@uid", user_id);
        cmd.Parameters.AddWithValue("@com", comment);
        cmd.Parameters.AddWithValue("@dt", thisDay);
        using (con)
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }


}
