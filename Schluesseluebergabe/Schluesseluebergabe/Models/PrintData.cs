using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schluesseluebergabe.Models
{
    public class PrintData
    {
        public Recipient Recipient { get; set; } = new Recipient();
        public Sender Sender { get; set; } = new Sender();
        public KeyInformation Key { get; set; } = new KeyInformation();
        public GeoData GeoData { get; set; } = new GeoData();

        public PrintData() { }

        public PrintData(Recipient recipient, Sender sender, KeyInformation key, GeoData geoData)
        {
            Recipient = recipient;
            Sender = sender;
            Key = key;
            GeoData = geoData;
        }
    }
}
