using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schluesseluebergabe.Models
{
    public class GeoData
    {
        public string City { get => _city; }
        public DateTime Date { get => _date; }

        private readonly string _city = string.Empty;
        private readonly DateTime _date;

        public GeoData(string city)
        {
            _city = city;
            _date = DateTime.Now;
        }

    }
}
