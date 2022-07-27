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

        // Convert country to two-letter code
        public static string[] ConvertToTwoLetter(string[] _input, Enum _type)
        {
            List<string> _twoLetterList = new List<string>();

            switch (_type)
            {
                case MenuService.SettingsKeys.Country:
                    foreach (string _country in _input)
                    {
                        _twoLetterList.Add(OptionsService.Country[_country]);
                    }
                    break;

                case MenuService.SettingsKeys.Language:
                    foreach (string _language in _input)
                    {
                        _twoLetterList.Add(OptionsService.Language[_language]);
                    }
                    break;

                default:
                    break;
            }

            return _twoLetterList.ToArray();
        }

        // Check input against dictionaries // Error Checking
        public static bool CheckAgainstDictionary(string[] _input, Enum _type)
        {
            bool _isInDictionary = true;

            switch (_type)
            {
                case MenuService.SettingsKeys.Country:
                    foreach (string _country in _input)
                    {
                        if (!OptionsService.Country.Any(x => x.Key == _country))
                        {
                            _isInDictionary = false;
                            Write($"\n{_country} is not an option. Press any key to continue...");
                            break;
                        }
                    }
                    break;

                case MenuService.SettingsKeys.Language:
                    foreach (string _language in _input)
                    {
                        if (!OptionsService.Language.Any(x => x.Key == _language))
                        {
                            _isInDictionary = false;
                            Write($"\n{_language} is not an option. Press any key to continue...");
                            break;
                        }
                    }
                    break;

                default:
                    break;
            }

            return _isInDictionary;
        }

        #endregion

    }
}