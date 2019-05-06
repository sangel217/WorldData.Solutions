using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace WorldData.Models
{
  public class Country
  {
    private string _code;
    private string _name;
    private string _continent;
    private string _region;
    private float _surfaceArea;
    private short _indepYear;
    private int _population;
    private float _lifeExpectancy;
    private float _gnp;
    private float _gnpOld;
    private string _localName;
    private string _govtForm;
    private string _headOfState;
    private int _capital;
    private string _code2;

    public Country(string code, string name, string continent, string region, float surfaceArea, short indepYear, int population, float lifeExpectancy, float gnp, float gnpOld, string localName, string govtForm, string headOfState, int capital, string code2)
    {
      _code = code;
      _name = name;
     _continent = continent;
     _region = region;
     _surfaceArea = surfaceArea;
     _indepYear = indepYear;
     _population = population;
     _lifeExpectancy = lifeExpectancy;
     _gnp = gnp;
     _gnpOld = gnpOld;
     _localName = localName;
     _govtForm = govtForm;
     _headOfState = headOfState;
     _capital = capital;
     _code2 = code2;
    }

    public string GetCode()
    {
      return _code;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetContinent()
    {
      return _continent;
    }

    public string GetRegion()
    {
      return _region;
    }

    public float GetSurfaceArea()
    {
      return _surfaceArea;
    }

    public short GetIndepYear()
    {
      return _indepYear;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public float GetLifeExpectancy()
    {
      return _lifeExpectancy;
    }

    public float GetGnp()
    {
      return _gnp;
    }
    public float GetGnpOld()
    {
      return _gnpOld;
    }
    public string GetLocalName()
    {
      return _localName;
    }
    public string GetGovtForm()
    {
      return _govtForm;
    }
    public string GetHeadOfState()
    {
      return _headOfState;
    }
    public int GetCapital()
    {
        return _capital;
    }
    public string GetCode2()
    {
      return _code2;
    }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        string countryCode = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        string countryContinent = rdr.GetString(2);
        string countryRegion = rdr.GetString(3);
        float countrySurfaceArea = rdr.GetFloat(4);
        short countryIndepYear = rdr.GetInt16(5);
        int countryPopulation = rdr.GetInt32(6);
        float countryLifeExpectancy = rdr.GetFloat(7);
        float countryGnp = rdr.GetFloat(8);
        float countryGnpOld = rdr.GetFloat(9);
        string countryLocalName = rdr.GetString(10);
        string countryGovtForm = rdr.GetString(11);
        string countryHeadOfState = rdr.GetString(12);
        int countryCapital = 0;
        if(countryCapital != null)
        {
          countryCapital = rdr.GetInt32(13);
        }
        string countryCode2 = rdr.GetString(14);
        Country newCountry = new Country (countryCode, countryName, countryContinent, countryRegion, countrySurfaceArea, countryIndepYear, countryPopulation, countryLifeExpectancy, countryGnp, countryGnpOld, countryLocalName, countryGovtForm, countryHeadOfState, countryCapital, countryCode2);
        allCountries.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountries;

    }

  }
}
