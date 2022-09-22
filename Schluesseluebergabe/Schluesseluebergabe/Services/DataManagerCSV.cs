using Schluesseluebergabe.Models;
using Schluesseluebergabe.Stores;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Schluesseluebergabe.Services
{
    public class DataManagerCSV : IDataManager
    {
        private List<PrintData> _printData;
        private DataTable _dataTable;
        private readonly string _csvFileName;
        private readonly string _filePath;

        private readonly ConfigManager _cfgManager;

        public DataManagerCSV()
        {
            _cfgManager = ConfigManager.Instance;

            _printData = new List<PrintData>();
            _dataTable = new DataTable();

            _filePath = _cfgManager.GetConfig().DataDirectory;
            _csvFileName = Path.Combine(_filePath, "data.csv");

            InitDataTable();
        }

        public async Task<List<PrintData>> GetDataAsync()
        {
            DataTable table;
            if (!File.Exists(_csvFileName))
            {
                return null;
            }
            try
            {
                table = CSVLibraryAK.CSVLibraryAK.Import(_csvFileName, true);
            }
            catch
            {
                throw new IOException($"Fehler beim Zugriff auf {_csvFileName}");
            }

            return await DataTableToList(table);


        }

        public async Task SaveDataAsync(List<PrintData> data, bool overrideData)
        {
            await LoadData();
            if (overrideData)
            {
                _printData.Clear();
                _dataTable.Clear();
                //while(_dataTable.Rows.Count > 1)
                //{
                //    _dataTable.Rows.RemoveAt(1);
                //}

            }
            else
            {
            }

            _printData.AddRange(data);

            if (!Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(_filePath);
            }

            await AddToDatatable(data);
            CSVLibraryAK.CSVLibraryAK.Export(_csvFileName, _dataTable);
        }

        public async Task DeleteDataAtAsync(int i)
        {
            await LoadData();
            if (!Directory.Exists(_csvFileName))
            {
                Directory.CreateDirectory(_filePath);
            }

            _printData.RemoveAt(i);
            CSVLibraryAK.CSVLibraryAK.Export(_csvFileName, _dataTable);

        }


        private Task AddToDatatable(List<PrintData> dataList)
        {
            foreach (var data in dataList)
            {
                _dataTable.Rows.Add(
               data.Recipient.Name,
               data.Recipient.ForeName,
               data.Recipient.Id,
               data.Sender.Name,
               data.Sender.ForeName,
               data.Key.Id,
               data.GeoData.City,
               data.GeoData.Date);
            }

            return Task.CompletedTask;
        }

        private void InitDataTable()
        {
            if (File.Exists(_csvFileName))
            {
                return;
            }

            _dataTable = new DataTable();
            _dataTable.Columns.Add("Recipient_Name");
            _dataTable.Columns.Add("Recipient_ForeName");
            _dataTable.Columns.Add("Recipient_Id");
            _dataTable.Columns.Add("Sender_Name");
            _dataTable.Columns.Add("Sender_ForeName");
            _dataTable.Columns.Add("Key_Id");
            _dataTable.Columns.Add("GeoData_City");
            _dataTable.Columns.Add("GeoData_Date");
        }

        private async Task LoadData()
        {
            if (!File.Exists(_csvFileName))
            {
                return;
            }

            _dataTable = CSVLibraryAK.CSVLibraryAK.Import(_csvFileName, true);
            _printData = await DataTableToList(_dataTable);

        }

        private static async Task<List<PrintData>> DataTableToList(DataTable table)
        {
            List<PrintData> list = new();

            foreach (var row in table.AsEnumerable().ToList())
            {
                var items = row.ItemArray.ToList();
                list.Add(
                    new PrintData()
                    {
                        Recipient = new Recipient()
                        {
                            Name = items[0]?.ToString(),
                            ForeName = items[1]?.ToString(),
                            Id = items[2]?.ToString()
                        },
                        Sender = new Sender()
                        {
                            Name = items[3]?.ToString(),
                            ForeName = items[4]?.ToString()
                        },
                        Key = new KeyInformation()
                        {
                            Id = items[5]?.ToString()
                        },
                        GeoData = new GeoData()
                        {
                            City = items[6]?.ToString(),
                            Date = DateTime.Parse(items[7].ToString()[..10])
                        }
                    });
            }
            return list;
        }
    }
}
