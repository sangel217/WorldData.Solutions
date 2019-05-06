using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;


namespace WorldData.Controllers
{
  public class CitiesController : Controller
  {
    [HttpGet("/cities")]
    public ActionResult Index()
    {
      List<City> allCities = City.GetAll();
      return View(allCities);
    }
  }
}
