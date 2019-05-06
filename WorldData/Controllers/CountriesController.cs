using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;


namespace WorldData.Controllers
{
  public class CountriesController : Controller
  {
    [HttpGet("/countries")]
    public ActionResult Index()
    {
      List<Country> allCountries = Country.GetAll();
      return View(allCountries);
    }
  }
}
