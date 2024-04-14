using Microsoft.Extensions.Configuration;

namespace Core.Configuration
{
    /// <summary>
    /// Provides access to the application configuration model.
    /// </summary>
    public static class Config
    {
        public static ConfigModel Model { get; }

        static Config()
        {
            Model = new ConfigModel();

            new ConfigurationBuilder()
                .AddJsonFile(@$"./Configuration/config.json")
                .Build()
                .Bind(Model);
        }
    }
}
