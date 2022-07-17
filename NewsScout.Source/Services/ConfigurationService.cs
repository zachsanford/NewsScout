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

        // Save to settings.json from a Settings class object
        public static void SaveSettings(Settings? _settingsToSave)
        {
            string _fileName = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\Configuration\settings.json");

            try
            {
                string _jsonContent = JsonSerializer.Serialize<Settings>(_settingsToSave, new JsonSerializerOptions() { WriteIndented = true });
                File.WriteAllText(_fileName, _jsonContent);
            }
            catch (Exception e)
            {
                WriteLine($"Here is the error message:\n\n{e.Message}");
                throw;
            }
        }

        #endregion

    }
}