using System;
using System.Collections.Generic;

namespace CandleStore.Models
{
  public class Candle
  {
    public int Id { get; set; }
    public string SKU { get; set; }

    public string Name { get; set; }

    public string ScentDescription { get; set; }

    public int NumberInStock { get; set; }

    public double Price { get; set; }

    public DateTime DateOrdered { get; set; } = DateTime.Now;

    public int? LocationId { get; set; }
    public Location Location { get; set; }
  }
}