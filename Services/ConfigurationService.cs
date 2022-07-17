using NewsScout.Models;
using System.IO;
using System.Text.Json;

namespace NewsScout.Services
{
    public static class ConfigurationService
    {

        #region Methods

        // Load settings.json into Settings class
        public static Settings LoadSettings()
        {
            string _fileName = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\Configuration\settings.json");

            try
            {
                string? _fileContents = File.ReadAllText(_fileName);
                return JsonSerializer.Deserialize<Settings>(_fileContents);
            }
            catch (Exception e)
            {
                WriteLine($"Error reading from {_fileName}. Message:\n\n{e.Message}");
                throw;
            }            
        }

        #endregion
    }
}