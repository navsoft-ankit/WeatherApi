using Test.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;



// {
//     public class WeatherRepository : IWeather
//     {
//         private readonly string _connectionString;

//         public WeatherRepository(string connectionString)
//         {
//             _connectionString = connectionString;
//         }

//         // GET ALL DATA
//         public IEnumerable<Weather> GetAll()
//         {
//             var result = new List<Weather>();
//             using SqlConnection conn = new SqlConnection(_connectionString);
//             SqlCommand cmd = new SqlCommand("SELECT Date, Temp, Summary FROM Weather", conn);
//             conn.Open();
//             using SqlDataReader reader = cmd.ExecuteReader();
//             while (reader.Read())
//             {
//                 result.Add(new Weather
//                 {
//                     Date = reader["Date"].ToString(),
//                     Temp = Convert.ToDouble(reader["Temp"]),
//                     Summary = reader["Summary"].ToString()
//                 });
//             }
//             return result;
//         }
//         // INSERT DATA
//         public bool Add(Weather weather)
//         {
//             using SqlConnection conn = new SqlConnection(_connectionString);

//             SqlCommand cmd = new SqlCommand(
//                 "INSERT INTO Weather (Date, Temp, Summary) VALUES (@Date, @Temp, @Summary)",
//                 conn
//             );

//             cmd.Parameters.AddWithValue("@Date", weather.Date);
//             cmd.Parameters.AddWithValue("@Temp", weather.Temp);
//             cmd.Parameters.AddWithValue("@Summary", weather.Summary);

//             conn.Open();

//             int rowsAffected = cmd.ExecuteNonQuery();

//             return rowsAffected > 0;
//         }

//         // CREATE TABLE
//         public bool Create_Table()
//         {
//             using SqlConnection conn = new SqlConnection(_connectionString);

//             SqlCommand cmd = new SqlCommand(
//                 @"CREATE TABLE Weather (
//                     Id INT PRIMARY KEY IDENTITY(1,1),
//                     Date NVARCHAR(50),
//                     Temp FLOAT,
//                     Summary NVARCHAR(255)
//                 )",
//                 conn
//             );

//             conn.Open();

//             cmd.ExecuteNonQuery();

//             return true;
//         }
//     }
// }

namespace Test.Repositories;
public class WeatherRepository : IWeather
{
    private readonly string _connectionstring;
    public WeatherRepository(string Connectionstring)
    {
        _connectionstring = Connectionstring;
    }
    public IEnumerable <Weather> GetAll()
    {
        var list = new List<Weather>();
        using SqlConnection conn  = new SqlConnection(_connectionstring);
        SqlCommand cmd = new SqlCommand ("GetAllWether",conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Weather
            {
                Date = reader["Date"].ToString(),
                Temp = Convert.ToDouble(reader["Temp"]),
                Summary = reader["Summary"].ToString()
            });
        }
        return list;
    }
//insert data
    public bool Add(Weather weather)
    {
        using SqlConnection conn = new SqlConnection(_connectionstring);

        SqlCommand cmd = new SqlCommand("InsertWeather", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Date", weather.Date);
        cmd.Parameters.AddWithValue("@Temp", weather.Temp);
        cmd.Parameters.AddWithValue("@Summary", weather.Summary);

        conn.Open();

        int rows = cmd.ExecuteNonQuery();

        return rows > 0;
    }
    public bool Delete(Weather weather)
    {
        using SqlConnection conn = new SqlConnection(_connectionstring);

        SqlCommand cmd = new SqlCommand("DeleteWeather", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Date", weather.Date);

        conn.Open();

        int rows = cmd.ExecuteNonQuery();

        return rows > 0;
    }
}