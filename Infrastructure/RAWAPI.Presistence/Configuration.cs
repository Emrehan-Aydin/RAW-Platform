using Microsoft.Extensions.Configuration;

namespace RAWAPI.Presistence {
    public static class Configuration {
        public static string getConnectionString() {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/RAWAPI.Api"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString("connection");

        }
    }
}
