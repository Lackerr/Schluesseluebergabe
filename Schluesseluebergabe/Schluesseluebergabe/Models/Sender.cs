using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schluesseluebergabe.Models
{
    public class Sender
    {
        public string? Name { get; set; }
        public string? ForeName { get; set; }

        public Sender()
        {
            try
            {
                var name = ConfigurationManager.AppSettings.Get("Sender_Name");
                var foreName = ConfigurationManager.AppSettings.Get("Sender_ForeName");

                Name = name ?? "";
                ForeName = foreName ?? "";
            }
            catch { }
        }
    }
}
