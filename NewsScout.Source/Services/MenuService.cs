namespace NewsScout.Services
{
    public static class MenuService
    {

        #region Properties

        public static int MenuSelection { get; set; }
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

        #endregion

        #region Methods

        // Main menu
        private static void ShowMainMenuHeader()
        {
            // Clear the console
            Clear();

            // Build Menu
            StringBuilder _stringBuilder = new StringBuilder();
            _stringBuilder.AppendLine();
            _stringBuilder.AppendLine("           _/      _/ _/_/_/_/ _/        _/  _/_/");
            _stringBuilder.AppendLine("          _/_/    _/ _/        _/       _/ _/   _/");
            _stringBuilder.AppendLine("         _/  _/  _/ _/_/_/     _/  _/  _/    _/");
            _stringBuilder.AppendLine("        _/    _/_/ _/          _/_/ _/_/ _/    _/");
            _stringBuilder.AppendLine("       _/      _/ _/_/_/_/     _/    _/   _/_/");
            _stringBuilder.AppendLine();
            _stringBuilder.AppendLine("      _/_/     _/_/_/   _/_/_/   _/   _/ _/_/_/_/");
            _stringBuilder.AppendLine("    _/   _/  _/       _/     _/ _/   _/    _/");
            _stringBuilder.AppendLine("      _/    _/       _/     _/ _/   _/    _/");
            _stringBuilder.AppendLine("  _/    _/ _/       _/     _/ _/   _/    _/");
            _stringBuilder.AppendLine("   _/_/     _/_/_/   _/_/_/    _/_/     _/");
            _stringBuilder.AppendLine();
            _stringBuilder.AppendLine("###############################################");
            _stringBuilder.AppendLine();

            // Output
            Write(_stringBuilder.ToString());
        }
        
        // Generic method for error checking the users input
        public static char CheckUserSelection(string _userInput, char[] _choicesToChooseFrom)
        {
            char _userChar;

            while (true)
            {
                // Try and convert to a char
                if (char.TryParse(_userInput, out _userChar))
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
        public static char ShowMenu(ReadOnlyCollection<char> _menuOptions, ReadOnlyCollection<string> _menuDescriptions)
        {
            ShowMainMenuHeader();

            foreach (string _menuItemDescription in _menuDescriptions)
            {
                WriteLine(_menuItemDescription);
            }

            Write("\nPlease enter your selection >> ");
            return CheckUserSelection(ReadLine(), _menuOptions.ToArray());
        }

        #endregion

    }
}
