using System.Collection.Generic;

namespace WorldData.Models
{
  public class City
  {
    private string _name;
    private string _countryCode;
    private string _district;
    private int _population;
    private int _id;
    private static List<City> _instances = new List<City> {};

    public City(string name, string countryCode, string district, int population)
    {
      _name = name;
      _countryCode = countryCode;
      _district = district;
      _population = population;
      _instances.Add(this);
      _id = _instances.Count;
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
      return _instances;
    }
  }
}
