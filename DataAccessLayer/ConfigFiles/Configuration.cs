using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DataAccessLayer
{
	public static class Configuration
    {
        private static string _connectionString;

        public static string GetConnectionString()
        {
            if (_connectionString != null)
            {
                return _connectionString;
            }

            if (!File.Exists("appsettings.json"))
            {
                return null;
            }

            try
            {
                var json = File.ReadAllText("appsettings.json");
				var appSettings = JsonConvert.DeserializeObject<AppSettings>(json);
				_connectionString = appSettings.FirstTaskDbConnectionString;
			}
			catch
            {
				return null;
            }
            
            return _connectionString;
        }

        public static void ChangeDataBaseInConnectionString()
        {
            var parts = _connectionString.Split(';');
            var dataBasePart = parts.FirstOrDefault(p => p.Contains("Database="));

            if (!dataBasePart.Contains("FirstTask"))
            {
                string substringForReplace = dataBasePart.Substring(dataBasePart.IndexOf('=') + 1);

                _connectionString = _connectionString.Replace(substringForReplace, "FirstTask");
                //var appSettings = new AppSettings { FirstTaskDbConnectionString = _connectionString };
                //var json = JsonConvert.SerializeObject(appSettings);
                //File.WriteAllText("appsettings.json", json);
            }
        }
    }
}
