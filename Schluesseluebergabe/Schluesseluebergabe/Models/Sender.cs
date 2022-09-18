using Schluesseluebergabe.Stores;

namespace Schluesseluebergabe.Models
{
    public class Sender
    {
        public string? Name { get; set; }
        public string? ForeName { get; set; }

        private readonly ConfigManager _cfgManager;

        public Sender()
        {
            try
            {
                _cfgManager = ConfigManager.Instance;
                var cfg = _cfgManager.GetConfig();

                var name = cfg.SenderName;
                var foreName = cfg.SenderForeName;

                Name = name ?? "";
                ForeName = foreName ?? "";
            }
            catch { }
        }
    }
}
