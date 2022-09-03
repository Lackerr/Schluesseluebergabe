using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schluesseluebergabe.Models
{
    public class Key
    {
        private readonly string _id = string.Empty;
        public string Id { get => _id; }

        public Key(string id)
        {
            _id = id;
        }
    }
}
