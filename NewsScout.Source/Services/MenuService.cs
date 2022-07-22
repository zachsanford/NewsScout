namespace NewsScout.Services
{
    public static class MenuService
    {

        #region Properties

        public static int MenuSelection { get; set; }
        private static char[] MainMenu { get; set; } =
        {
            '0',
            '1',
            's', // Settings
            'q'  // Quit
        };

        #endregion

        #region Methods

        // Main menu
        private static void ShowMainMenu()
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
        // public

        #endregion

    }
}
