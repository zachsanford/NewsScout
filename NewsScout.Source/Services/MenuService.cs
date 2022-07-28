namespace NewsScout.Services
{
    public static class MenuService
    {

        #region Properties

        public static char MenuSelection { get; set; }
        public enum SettingsKeys { ApiKey, Country, Language }
        public enum MenuType { Main, Settings, ApiSettings, CountrySettings, LanguageSettings, CustomSearch }
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
        public static ReadOnlyCollection<char> SettingsEditMenuOptions { get; private set; } = new List<char>
        {
            '0', // Enter New Value
            '1', // Save Changes
            'b'  // Discard Changes and go back

        }.AsReadOnly();
        public static ReadOnlyCollection<string> SettingsEditMenuDescriptions { get; private set; } = new List<string>
        {
            "0) - Enter New Value -",
            "1) - Save Changes -",
            "b) - Discard Changes and Go Back -"
        }.AsReadOnly();
        public static ReadOnlyCollection<char> ArticleListOptions { get; private set; } = new List<char>
        {
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            'b'  // Go back
        }.AsReadOnly();
        public static ReadOnlyCollection<char> SearchQueryMenuOptions { get; private set; } = new List<char>
        {
            '0', // Create/Edit Query
            '1', // Run Query
            'b'  // Go back
        }.AsReadOnly();
        public static ReadOnlyCollection<string> SearchQueryMenuDescriptions { get; private set; } = new List<string>
        {
            "0) - Create/Edit Search Query -",
            "1) - Run Query -",
            "b) - Go Back -"
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
        private static void ShowEditValues(Enum _valueToSelect, string[]? _newValues = null)
        {
            Settings _currentSettings = ConfigurationService.LoadSettings();

            switch (_valueToSelect)
            {
                case SettingsKeys.ApiKey:
                    WriteLine("     API Key:");
                    WriteLine($"          {_currentSettings.ApiKey}");
                    if (_newValues != null && _newValues.Length <= 1)
                    {
                        WriteLine("\n     New API Key:");
                        WriteLine($"          {_newValues[0]}");
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
                    if (_newValues != null && _newValues.Length <= 5)
                    {
                        WriteLine("\n     New Countries:");
                        foreach (string _newCountry in _newValues)
                        {
                            WriteLine($"          {_newCountry}");
                        }
                    }
                    break;

                case SettingsKeys.Language:
                    WriteLine("     Languages:");
                    if (_currentSettings.Language != null)
                    {
                        foreach (string _language in _currentSettings.Language)
                        {
                            WriteLine($"          {OptionsService.Language.FirstOrDefault(v => v.Value == _language).Key}");
                        }
                    }
                    if (_newValues != null && _newValues.Length <= 5)
                    {
                        WriteLine("\n     New Languages:");
                        foreach (string _newLanguage in _newValues)
                        {
                            WriteLine($"          {_newLanguage}");
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
        public static char ShowMenu(ReadOnlyCollection<char> _menuOptions, ReadOnlyCollection<string> _menuDescriptions, Enum _menuType, string[]? _extraOptions = null, string? _extraOption = null)
        {
            ShowMainMenuHeader();

            switch (_menuType)
            {
                case MenuType.Settings:
                    ShowCurrentSettings();
                    break;

                case MenuType.ApiSettings:
                    ShowEditValues(SettingsKeys.ApiKey, _extraOptions);
                    break;

                case MenuType.CountrySettings:
                    ShowEditValues(SettingsKeys.Country, _extraOptions);
                    break;

                case MenuType.LanguageSettings:
                    ShowEditValues(SettingsKeys.Language, _extraOptions);
                    break;

                case MenuType.CustomSearch:
                    ShowCustomSearchMenu(_extraOption);
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

        // Input parsing for settings, To Lower
        public static string[] ParseSettingsInput(string _userInput, Enum _inputType)
        {
            // Split on comma (,)
            string[] _splitUserInput = _userInput.Split(',');

            switch (_inputType)
            {
                case SettingsKeys.ApiKey:
                    // Clear leading and trailing whitespace.
                    for (int i = 0; i < _splitUserInput.Length; i++)
                    {
                        _splitUserInput[i] = _splitUserInput[i].Trim();
                    }
                    break;

                default:

                    // Clear leading and trailing whitespace. To Lower
                    for (int i = 0; i < _splitUserInput.Length; i++)
                    {
                        _splitUserInput[i] = _splitUserInput[i].Trim().ToLower();
                    }

                    break;
            }

            return _splitUserInput;
        }

        // Show list of articles
        public static char ListArticles(ApiResponse _articles, ReadOnlyCollection<char> _menuOptions)
        {
            ShowMainMenuHeader();

            for (int i = 0; i < 10; i++)
            {
                if (!string.IsNullOrEmpty(_articles.Results[i].Title))
                {
                    WriteLine($"{i}) - {_articles.Results[i].Title}");
                }
                else
                {
                    WriteLine($"{i}) - NO TITLE");
                }

                if (!string.IsNullOrEmpty(_articles.Results[i].Description))
                {
                    WriteLine($"{_articles.Results[i].Description}");
                }
                else
                {
                    WriteLine("NO DESCRIPTION");
                }
                WriteLine();
            }

            WriteLine("b) - Go back -");
            Write("\nPlease enter your selection >> ");
            return CheckUserSelection(ReadLine(), _menuOptions.ToArray());
        }

        // Show specific article
        public static void ShowArticle(Result _individualResult)
        {
            ShowMainMenuHeader();

            if (!string.IsNullOrEmpty(_individualResult.Title))
            {
                WriteLine("TITLE:");
                WriteLine($"\n{_individualResult.Title}");
            }
            else
            {
                WriteLine("TITLE:");
                WriteLine($"\nNOT AVAILABLE");
            }

            if (!string.IsNullOrEmpty(_individualResult.Description))
            {
                WriteLine("\nDESCRIPTION:");
                WriteLine($"\n{_individualResult.Description}");
            }
            else
            {
                WriteLine("\nDESCRIPTION:");
                WriteLine($"\nNOT AVAILABLE");
            }

            if (!string.IsNullOrEmpty(_individualResult.Content))
            {
                WriteLine("\nCONTENT:");
                WriteLine($"\n{_individualResult.Content}");
            }
            else
            {
                WriteLine("\nCONTENT:");
                WriteLine($"\nNOT AVAILABLE");
            }

            if (!string.IsNullOrEmpty(_individualResult.Link))
            {
                WriteLine("\nLINK TO ARTICLE:");
                WriteLine($"\n{_individualResult.Link}");
            }
            else
            {
                WriteLine("\nLINK TO ARTICLE:");
                WriteLine($"\nNOT AVAILABLE");
            }

            Write("\nPress any key to go back to the list...");
            ReadLine();
        }

        // Custom search query menu
        private static void ShowCustomSearchMenu(string? _searchQuery = null)
        {
            ShowMainMenuHeader();
            WriteLine("     Search Query:");
            if (_searchQuery != null)
            {
                WriteLine($"          {_searchQuery}");
            }
            else
            {
                WriteLine("          NO SEARCH ENTERED");
            }

            WriteLine();
            WriteLine("###########################################################\n");
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