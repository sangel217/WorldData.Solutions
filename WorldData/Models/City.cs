using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace WorldData.Models
{
  public class City
  {
    private string _name;
    private string _countryCode;
    private string _district;
    private int _population;
    private int _id;
    //private static List<City> _instances = new List<City> {};

    public City(string name, string countryCode, string district, int population, int id)
    {
      _name = name;
      _countryCode = countryCode;
      _district = district;
      _population = population;
      _id = id;
      //_instances.Add(this);
      //_id = _instances.Count;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetCountryCode()
    {
      return _countryCode;
    }

    public string GetDistrict()
    {
      return _district;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<City> GetAll()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityCountryCode = rdr.GetString(2);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetInt32(4);
        City newCity = new City(cityName, cityCountryCode, cityDistrict, cityPopulation, cityId);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }
  }
}
