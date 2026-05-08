using Test.Models;
using System.Data;

namespace Test.Repositories;

public class WeatherRepository : IWeather
{
    private readonly IDbConnection _db;

    public WeatherRepository(IDbConnection db)
    {
        _db = db;
    }

    // GET ALL DATA
    public IEnumerable<Weather> GetAll()
    {
        var result = new List<Weather>();

        using var cmd = _db.CreateCommand();

        cmd.CommandText =
            "SELECT Date, Temp, Summary FROM Weather";

        if (_db.State != ConnectionState.Open)
            _db.Open();

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            result.Add(new Weather
            {
                Date = reader["Date"].ToString(),
                Temp = Convert.ToDouble(reader["Temp"]),
                Summary = reader["Summary"].ToString()
            });
        }

        return result;
    }

    // INSERT DATA
    public bool Add(Weather weather)
    {
        using var cmd = _db.CreateCommand();

        cmd.CommandText =
            "INSERT INTO Weather (Date, Temp, Summary) VALUES (@Date, @Temp, @Summary)";

        if (_db.State != ConnectionState.Open)
            _db.Open();

        // Date parameter
        var dateParam = cmd.CreateParameter();
        dateParam.ParameterName = "@Date";
        dateParam.Value = weather.Date;
        cmd.Parameters.Add(dateParam);

        // Temp parameter
        var tempParam = cmd.CreateParameter();
        tempParam.ParameterName = "@Temp";
        tempParam.Value = weather.Temp;
        cmd.Parameters.Add(tempParam);

        // Summary parameter
        var summaryParam = cmd.CreateParameter();
        summaryParam.ParameterName = "@Summary";
        summaryParam.Value = weather.Summary;
        cmd.Parameters.Add(summaryParam);

        // Execute query
        int rowsAffected = cmd.ExecuteNonQuery();

        return rowsAffected > 0;
    }
}