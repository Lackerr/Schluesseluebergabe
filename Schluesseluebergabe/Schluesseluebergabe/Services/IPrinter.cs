using Schluesseluebergabe.Models;
using System.Threading.Tasks;

namespace Schluesseluebergabe.Services
{
    public interface IPrinter
    {
        public Task<string> PrintDocumentAsync(PrintData data);
    }
}
