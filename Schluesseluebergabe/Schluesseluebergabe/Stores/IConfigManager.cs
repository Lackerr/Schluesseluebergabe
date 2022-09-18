namespace Schluesseluebergabe.Stores
{
    interface IConfigManager
    {
        public Config GetConfig();
        public void SaveConfig(Config config);
    }
}
