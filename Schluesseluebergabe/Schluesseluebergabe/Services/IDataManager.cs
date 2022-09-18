using Schluesseluebergabe.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schluesseluebergabe.Services
{
    public interface IDataManager
    {
        public Task<List<PrintData>> GetDataAsync();
        public Task SaveDataAsync(List<PrintData> data, bool overrideData);
        public Task DeleteDataAtAsync(int i);
    }
}
