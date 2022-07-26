namespace NewsScout.Services
{
    public static class MenuService
    {

        #region Properties

        public static char MenuSelection { get; set; }
        public enum SettingsKeys { ApiKey, Country, Language }
        public enum MenuType { Main, Settings, ApiSettings }
        public static ReadOnlyCollection<char> MainMenuOptions { get; private set; } = new List<char>
        {
            '0', // Get results with current settings
            '1', // Get results with search query
            's', // Settings
            'q'  // Quit
        }.AsReadOnly();
        public static ReadOnlyCollection<string> MainMenuDescriptions { get; private set; } = new List<string>
        {
            "0) - Get News with the Current Settings -",
            "1) - Create News Search -",
            "s) - Access the Program Settings -",
            "q) - Quit the Program -"
        }.AsReadOnly();
        public static ReadOnlyCollection<char> SettingsMenuOptions { get; private set; } = new List<char>
        {
            '0', // Change API Key
            '1', // Change Countries of Origin
            '2', // Change Languages
            'b'  // Back one menu
        }.AsReadOnly();
        public static ReadOnlyCollection<string> SettingsMenuDescriptions { get; private set; } = new List<string>
        {
            "0) - Change API Key -",
            "1) - Change Countries of Origin - (Can have up to five!)",
            "2) - Change Languages - (Can have up to five!)",
            "b) - Back to Main Menu -"
        }.AsReadOnly();
        public static ReadOnlyCollection<char> APIKeyMenuOptions { get; private set; } = new List<char>
        {
            '0', // Enter New Value
            '1', // Save Changes
            'b'  // Discard Changes and go back

        }.AsReadOnly();
        public static ReadOnlyCollection<string> APIKeyMenuDescriptions { get; private set; } = new List<string>
        {
            "0) - Enter New Value -",
            "1) - Save Changes -",
            "b) - Discard Changes and Go Back -"
        }.AsReadOnly();

        #endregion

        #region Methods

        // Main menu header
        private static void ShowMainMenuHeader()
        {
            // Clear the console
            Clear();

            // Build Menu
            StringBuilder _stringBuilder = new StringBuilder();
            _stringBuilder.AppendLine();
            _stringBuilder.AppendLine("                _/      _/ _/_/_/_/ _/        _/  _/_/");
            _stringBuilder.AppendLine("               _/_/    _/ _/        _/       _/ _/   _/");
            _stringBuilder.AppendLine("              _/  _/  _/ _/_/_/     _/  _/  _/    _/");
            _stringBuilder.AppendLine("             _/    _/_/ _/          _/_/ _/_/ _/    _/");
            _stringBuilder.AppendLine("            _/      _/ _/_/_/_/     _/    _/   _/_/");
            _stringBuilder.AppendLine();
            _stringBuilder.AppendLine("           _/_/     _/_/_/   _/_/_/   _/   _/ _/_/_/_/");
            _stringBuilder.AppendLine("         _/   _/  _/       _/     _/ _/   _/    _/");
            _stringBuilder.AppendLine("           _/    _/       _/     _/ _/   _/    _/");
            _stringBuilder.AppendLine("       _/    _/ _/       _/     _/ _/   _/    _/");
            _stringBuilder.AppendLine("        _/_/     _/_/_/   _/_/_/    _/_/     _/");
            _stringBuilder.AppendLine();
            _stringBuilder.AppendLine("###########################################################");
            _stringBuilder.AppendLine();

            // Output
            Write(_stringBuilder.ToString());
        }

        // Display Settings
        private static void ShowCurrentSettings()
        {
            Settings _currentSettings = ConfigurationService.LoadSettings();
            WriteLine("     API Key:");
            WriteLine($"          {_currentSettings.ApiKey}");
            WriteLine("\n     Countries:");
            if (_currentSettings.Country != null)
            {
                foreach (string _country in _currentSettings.Country)
                {
                    WriteLine($"          {OptionsService.Country.FirstOrDefault(v => v.Value == _country).Key}");
                }
            }
            WriteLine("\n     Languages:");
            if (_currentSettings.Language != null)
            {
                foreach (string _language in _currentSettings.Language)
                {
                    WriteLine($"          {OptionsService.Language.FirstOrDefault(v => v.Value == _language).Key}");
                }
            }
            WriteLine();
            WriteLine("###########################################################\n");
        }

        // Generic method for showing settings.json values when editing
        private static void ShowEditValues(Enum _valueToSelect, string _newValue = null)
        {
            Settings _currentSettings = ConfigurationService.LoadSettings();

            switch (_valueToSelect)
            {
                case SettingsKeys.ApiKey:
                    WriteLine("     API Key:");
                    WriteLine($"          {_currentSettings.ApiKey}");
                    if (_newValue != null)
                    {
                        WriteLine("\n     New API Key:");
                        WriteLine($"          {_newValue}");
                    }
                    break;

                case SettingsKeys.Country:
                    WriteLine("     Countries:");
                    if (_currentSettings.Country != null)
                    {
                        foreach (string _country in _currentSettings.Country)
                        {
                            WriteLine($"          {OptionsService.Country.FirstOrDefault(v => v.Value == _country).Key}");
                        }
                    }
                    break;

                case SettingsKeys.Language:
                    WriteLine("+     Languages:");
                    if (_currentSettings.Language != null)
                    {
                        foreach (string _language in _currentSettings.Language)
                        {
                            WriteLine($"          {OptionsService.Language.FirstOrDefault(v => v.Value == _language).Key}");
                        }
                    }
                    break;

                default:
                    break;
            }

            WriteLine();
            WriteLine("###########################################################\n");
        }
        
        // Generic method for error checking the users input
        public static char CheckUserSelection(string _userInput, char[] _choicesToChooseFrom)
        {
            char _userChar;

            while (true)
            {
                // Try and convert to a char
                if (char.TryParse(_userInput.ToLower(), out _userChar))
                {
                    // Continue
                    if (_choicesToChooseFrom.Contains(_userChar))
                    {
                        // break the while loop
                        break;
                    }
                    else
                    {
                        // Not a correct selection - try again
                        Write($"{_userChar} is not in the selection list!! Please try again >> ");
                        _userInput = ReadLine();
                    }
                } 
                else
                {
                    // Too long - try again
                    Write($"{_userInput} is too long!! Please try again >> ");
                    _userInput = ReadLine();
                }
            }

            return _userChar;
        }

        // Generic display the Menu Options
        public static char ShowMenu(ReadOnlyCollection<char> _menuOptions, ReadOnlyCollection<string> _menuDescriptions, Enum _menuType)
        {
            ShowMainMenuHeader();

            switch (_menuType)
            {
                case MenuType.Settings:
                    ShowCurrentSettings();
                    break;

                case MenuType.ApiSettings:
                    ShowEditValues(SettingsKeys.ApiKey);
                    break;

                default:
                    break;
            }

            foreach (string _menuItemDescription in _menuDescriptions)
            {
                WriteLine(_menuItemDescription);
            }

            Write("\nPlease enter your selection >> ");
            return CheckUserSelection(ReadLine(), _menuOptions.ToArray());
        }

        // Quit the program
        public static void UserQuitTheProgram()
        {
            ShowMainMenuHeader();

            WriteLine("Goodbye...\n");
        }

        #endregion

    }
}