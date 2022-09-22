using Schluesseluebergabe.Stores;
using System;

namespace Schluesseluebergabe.Models
{
    public class GeoData
    {
        public string? City { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get => Date.ToShortDateString(); }

        private readonly ConfigManager _cfgManager;


        public GeoData()
        {
            _cfgManager = ConfigManager.Instance;


            Date = DateTime.Now;
            City = _cfgManager.GetConfig().City;
        }
    }
}
