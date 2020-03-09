using System;
using System.Collections.Generic;

namespace CandleStore.Models
{
  public class Location
  {
    public int Id { get; set; }

    public string Address { get; set; }

    public string ManagerName { get; set; }

    public string PhoneNumber { get; set; }

    public List<Candle> Candles { get; set; } = new List<Candle>();


  }
}