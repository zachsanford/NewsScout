namespace NewsScout.Services
{
    public static class MenuService
    {

        #region Properties

        public static int MenuSelection { get; set; }

        #endregion

        #region Methods

        // Main menu
        public static void ShowMainMenu()
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

        
        // Generic method to get a user's selection. Provides error checking.
        //public static int

        #endregion

    }
}
