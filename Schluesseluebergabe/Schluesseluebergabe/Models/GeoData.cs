﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schluesseluebergabe.Models
{
    public class GeoData
    {
        public string? City { get; set; }
        public DateTime Date { get; set; }

        public GeoData()
        {
            Date = DateTime.Now;
        }
    }
}