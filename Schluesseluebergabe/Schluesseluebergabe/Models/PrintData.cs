using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schluesseluebergabe.Models
{
    public class PrintData
    {
        public Recipient Recipient { get; set; }
        public Sender Sender { get; set; }
        public KeyInformation Key { get; set; }
        public GeoData GeoData { get; set; }
        public PrintData(Recipient recipient, Sender sender, KeyInformation key, GeoData geoData)
        {
            Recipient = recipient;
            Sender = sender;
            Key = key;
            GeoData = geoData;
        }
    }
}
