using Schluesseluebergabe.Models;
using Schluesseluebergabe.Services;
using System.Collections.Generic;
using System.Linq;

namespace Schluesseluebergabe.Commands
{
    class DeleteEntryCommand : CommandBase
    {
        private readonly List<PrintData> _printDataList;
        private readonly int _entryId;
        readonly IDataManager _dataManager;

        public DeleteEntryCommand(IEnumerable<PrintData> printData, int entryId)
        {
            _printDataList = printData.ToList();
            _entryId = entryId;

            //DI
            _dataManager = new DataManagerCSV();

        }
        public override async void Execute(object? parameter)
        {
            await _dataManager.DeleteDataAtAsync(_entryId);
        }
    }
}
