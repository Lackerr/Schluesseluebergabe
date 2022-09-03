using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schluesseluebergabe.Models
{
    public class Sender
    {
        public string Name { get => _name; }
        public string LastName { get => _lastName; }

        private readonly string _name = string.Empty;
        private readonly string _lastName = string.Empty;

        public Sender(string name, string lastName)
        {
            _name = name;
            _lastName = lastName;
        }
    }
}
