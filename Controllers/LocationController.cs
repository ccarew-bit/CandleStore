using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandleStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandleStore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LocationController : ControllerBase
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();

    [HttpGet("location")]
    public List<Location> GetAllLocations()
    {
      var getAllLocations = db.Locations.OrderBy(m => m.Address);
      return getAllLocations.ToList();
    }

    [HttpPost]
    public Location CreateNewLocation(Location item)
    {
      db.Locations.Add(item);
      db.SaveChanges();
      return item;
    }

    [HttpGet("numberInStock/{NumberInStock}/LocationId/{LocationId}")]
    public List<Candle> GetAllCandlesOutOfStock(int NumberInStock, int LocationId)
    {
      var noStock = db.Candles.Where(i => i.NumberInStock == 0).Where(j => j.LocationId == LocationId);
      foreach (var candle in noStock)
      {
        Console.WriteLine($"{candle.Name}");

      }
      return noStock.ToList();

    }
  }
}