using System;
using System.IO;

namespace Schluesseluebergabe.Stores
{
    public class Config
    {
        public string PrintPath { get; set; }
        public string DataDirectory { get; set; }
        public string SenderName { get; set; }
        public string SenderForeName { get; set; }
        public string City { get; set; }



        public Config()
        {
            InitializeData();  
        }

        private void InitializeData()
        {
            PrintPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DataDirectory = Path.Combine(Environment.CurrentDirectory, "data");
            SenderName = string.Empty;
            SenderForeName = string.Empty;
            City = string.Empty;
        }
    }
}
