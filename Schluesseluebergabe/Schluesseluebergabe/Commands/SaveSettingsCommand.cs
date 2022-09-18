using Schluesseluebergabe.Stores;

namespace Schluesseluebergabe.Commands
{
    class SaveSettingsCommand : CommandBase
    {
        private readonly ConfigManager _cfgManager;
        private readonly Config _config;

        public SaveSettingsCommand(Config config)
        {
            _cfgManager = ConfigManager.Instance;
            _config = config;
        }

        public override void Execute(object? parameter)
        {
            _cfgManager.SaveConfig(_config);
        }
    }
}
