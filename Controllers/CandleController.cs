using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CandleStore.Models;

namespace CandleStore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CandleController : ControllerBase
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();

    [HttpGet]
    public List<Candle> GetAllCandles(int LocationId)
    {
      var getAllCandles = db.Candles.OrderBy(m => m.Name);
      return getAllCandles.ToList();

    }

    [HttpGet("{id}")]
    public Candle GetOneCandle(int id, int LocationId)
    {
      var oneCandle = db.Candles.FirstOrDefault(i => i.Id == id);
      return oneCandle;
    }

    [HttpPost]
    public Candle CreateNewCandle(Candle item)
    {
      db.Candles.Add(item);
      db.SaveChanges();
      return item;
    }

    [HttpPut("{id}/stock")]
    public Candle UpdateStock(int id, Candle data)
    {
      var item = db.Candles.FirstOrDefault(i => i.Id == id);
      item.NumberInStock -= 1;
      db.SaveChanges();
      return item;
    }

    [HttpPut("{id}/location")]
    public Candle UpdateLocationid(int id, Candle data, int LocationId)
    {
      data.Id = id;
      db.Entry(data).State = EntityState.Modified;
      db.SaveChanges();
      return data;
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteOne(int id)
    {
      var item = db.Candles.FirstOrDefault(f => f.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      db.Candles.Remove(item);
      db.SaveChanges();
      return Ok();
    }

    [HttpDelete("{LocationId}/DeleteCandleFromLocation")]
    public ActionResult DeleteOneFromLocation(int id)
    {
      var item = db.Candles.FirstOrDefault(f => f.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      db.Candles.Remove(item);
      db.SaveChanges();
      return Ok();
    }

    [HttpGet("sku/{SKU}")]
    public List<Candle> GetAllCandlesSKU()
    {
      var getAllCandlesSKU = db.Candles.OrderBy(m => m.SKU);
      foreach (var Candle in getAllCandlesSKU)
      {
        Console.WriteLine($"{Candle.Name} : {Candle.LocationId}");

      }
      return getAllCandlesSKU.ToList();
    }


    [HttpGet("OutOfStock")]
    public List<Candle> GetAllCandlesOutOfStock(int NumberInStock)
    {
      var noStock = db.Candles.Where(i => i.NumberInStock == 0);
      foreach (var candle in noStock)
      {
        Console.WriteLine($"{candle.Name}");

      }
      return noStock.ToList();

    }
  }
}