using Schluesseluebergabe.Stores;
using System;

namespace Schluesseluebergabe.Models
{
    public class GeoData
    {
        public string? City { get; set; }
        public DateTime Date { get; set; }
        private readonly ConfigManager _cfgManager;

        public GeoData()
        {
            _cfgManager = ConfigManager.Instance;


            Date = DateTime.Now.Date;
            City = _cfgManager.GetConfig().City;
        }
    }
}
