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

    public WeatherRepository(IConfiguration configuration)
    {
        _connectionstring =
            configuration.GetConnectionString("DefaultConnection");
    }

    // GET ALL DATA
    public async Task<IEnumerable<Weather>> GetAllAsync()
    {
        var list = new List<Weather>();

        using SqlConnection conn =
            new SqlConnection(_connectionstring);

        SqlCommand cmd =
            new SqlCommand("GetAllWeather", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        await conn.OpenAsync();

        using SqlDataReader reader =
            await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            list.Add(new Weather
            {
                Id = Convert.ToInt32(reader["Id"]),
                City = reader["City"].ToString(),
                Date = Convert.ToDateTime(reader["Date"]),
                Temp = Convert.ToSingle(reader["Temp"])
            });
        }

        return list;
    }

    // INSERT DATA
    public async Task<bool> AddAsync(Weather weather)
    {
        using SqlConnection conn =
            new SqlConnection(_connectionstring);

        SqlCommand cmd =
            new SqlCommand("InsertWeather", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@City", weather.City);
        cmd.Parameters.AddWithValue("@Date", weather.Date);
        cmd.Parameters.AddWithValue("@Temp", weather.Temp);

        await conn.OpenAsync();

        int rows =
            await cmd.ExecuteNonQueryAsync();

        return rows > 0;
    }

    // DELETE DATA
    public async Task<bool> DeleteAsync(int id)
    {
        using SqlConnection conn =
            new SqlConnection(_connectionstring);

        SqlCommand cmd =
            new SqlCommand("DeleteWeather", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Id", id);

        await conn.OpenAsync();

        int rows =
            await cmd.ExecuteNonQueryAsync();

        return rows > 0;
    }

    // UPDATE DATA
    public async Task<bool> UpdateAsync(
        int id,
        Weather weather)
    {
        using SqlConnection conn =
            new SqlConnection(_connectionstring);

        SqlCommand cmd =
            new SqlCommand("UpdateWeather", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Id", id);
        cmd.Parameters.AddWithValue("@City", weather.City);
        cmd.Parameters.AddWithValue("@Date", weather.Date);
        cmd.Parameters.AddWithValue("@Temp", weather.Temp);

        await conn.OpenAsync();

        int rows =
            await cmd.ExecuteNonQueryAsync();

        return rows > 0;
    }

    // GET BY ID
    public async Task<int> GetByIdAsync(int id)
    {
        using SqlConnection conn =
            new SqlConnection(_connectionstring);

        SqlCommand cmd =
            new SqlCommand("GetWeatherById", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Id", id);

        await conn.OpenAsync();

        object result =
            await cmd.ExecuteScalarAsync();

        return result != null
            ? Convert.ToInt32(result)
            : -1;
    }
}