using Schluesseluebergabe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schluesseluebergabe.Services
{
    public interface IDataManager
    {
        public Task<List<PrintData>> GetDataAsync();
        public Task SaveDataAsync(PrintData data);
    }
}
