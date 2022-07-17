using NewsScout.Models;
using System.IO;
using System.Text.Json;

namespace NewsScout.Services
{
    internal static class ConfigurationService
    {

        #region Methods

        // Load settings.json into Settings class
        internal static Settings LoadSettings()
        {
            string _fileName = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\Configuration\settings.json");
            string? _fileContents = File.ReadAllText(_fileName);

            return JsonSerializer.Deserialize<Settings>(_fileContents);
        }

        #endregion
    }
}