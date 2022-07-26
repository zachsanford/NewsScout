#region Manual Test Area

#region MenuService Tests

//char[] choices = { 'a', 'b', 'c' };
//string userInput = "1";

//char returnChar = MenuService.CheckUserSelection(userInput, choices);

WriteLine(MenuService.MenuSelection);
MenuService.MenuSelection = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions, MenuService.MenuType.Main);
string[]? newSettings = null;
bool isLooping = true;
bool isLoopingSubMenu = true;
bool isLoopingEditSetting = true;

while (isLooping)
{
    switch (MenuService.MenuSelection)
    {
        case '0':
            break;

        case '1':
            break;

        case 's':
            isLoopingSubMenu = true;
            MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsMenuOptions, MenuService.SettingsMenuDescriptions, MenuService.MenuType.Settings);

            while (isLoopingSubMenu)
            {                
                switch (MenuService.MenuSelection)
                {
                    case '0':
                        // Edit API
                        isLoopingEditSetting = true;
                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsEditMenuOptions, MenuService.SettingsEditMenuDescriptions, MenuService.MenuType.ApiSettings, newSettings);

                        while (isLoopingEditSetting)
                        {
                            switch (MenuService.MenuSelection)
                            {
                                case '0':
                                    // Enter new API value
                                    Write("\nNew API Key Value >> ");
                                    newSettings = MenuService.ParseSettingsInput(ReadLine(), MenuService.SettingsKeys.ApiKey);
                                    MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsEditMenuOptions, MenuService.SettingsEditMenuDescriptions, MenuService.MenuType.ApiSettings, newSettings);
                                    break;

                                case '1':
                                    // Save Changes
                                    if (newSettings == null)
                                    {
                                        Write("\nNo changes were made. Press any key to continue...");
                                        ReadLine();
                                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsEditMenuOptions, MenuService.SettingsEditMenuDescriptions, MenuService.MenuType.ApiSettings, newSettings);
                                    }
                                    else
                                    {
                                        WriteLine("\nSaving...");
                                        Settings settings = ConfigurationService.LoadSettings();
                                        settings.ApiKey = newSettings.FirstOrDefault();
                                        ConfigurationService.SaveSettings(settings);
                                        Write("COMPLETE. Press any key to continue...");
                                        ReadLine();
                                        newSettings = null;
                                        isLoopingEditSetting = false;
                                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsMenuOptions, MenuService.SettingsMenuDescriptions, MenuService.MenuType.Settings);
                                    }
                                    break;

                                case 'b':
                                    // Discard changes and go back
                                    isLoopingEditSetting = false;
                                    newSettings = null;
                                    MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsMenuOptions, MenuService.SettingsMenuDescriptions, MenuService.MenuType.Settings);
                                    break;

                                default:
                                    break;
                            }
                        }

                        break;

                    case '1':
                        // Edit Countries
                        isLoopingEditSetting = true;
                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsEditMenuOptions, MenuService.SettingsEditMenuDescriptions, MenuService.MenuType.CountrySettings, newSettings);

                        while (isLoopingEditSetting)
                        {
                            switch (MenuService.MenuSelection)
                            {
                                case '0':
                                    // Enter new Country value
                                    Write("\nNew Country Values (comma separated/up to five) >> ");
                                    newSettings = MenuService.ParseSettingsInput(ReadLine(), MenuService.SettingsKeys.ApiKey);

                                    // More than five
                                    if (newSettings.Length > 5)
                                    {
                                        Write("\nThere are more than five countries! Press any key to continue...");
                                        ReadLine();
                                        break;
                                    }
                                    else
                                    {
                                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsEditMenuOptions, MenuService.SettingsEditMenuDescriptions, MenuService.MenuType.CountrySettings, newSettings);
                                        break;
                                    }

                                case '1':
                                    // Save Changes
                                    if (newSettings == null)
                                    {
                                        Write("\nNo changes were made. Press any key to continue...");
                                        ReadLine();
                                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsEditMenuOptions, MenuService.SettingsEditMenuDescriptions, MenuService.MenuType.CountrySettings, newSettings);
                                    }
                                    else
                                    {
                                        // Need array error checking here (wrong country)
                                        WriteLine("\nSaving...");
                                        Settings settings = ConfigurationService.LoadSettings();
                                        settings.Country = ConfigurationService.ConvertToTwoLetter(newSettings, MenuService.SettingsKeys.Country);
                                        ConfigurationService.SaveSettings(settings);
                                        Write("COMPLETE. Press any key to continue...");
                                        ReadLine();
                                        newSettings = null;
                                        isLoopingEditSetting = false;
                                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsMenuOptions, MenuService.SettingsMenuDescriptions, MenuService.MenuType.Settings);
                                    }
                                    break;

                                case 'b':
                                    // Discard changes and go back
                                    isLoopingEditSetting = false;
                                    newSettings = null;
                                    MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsMenuOptions, MenuService.SettingsMenuDescriptions, MenuService.MenuType.Settings);
                                    break;

                                default:
                                    break;
                            }
                        }

                        break;

                    case '2':
                        // Edit Languages
                        isLoopingEditSetting = true;
                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsEditMenuOptions, MenuService.SettingsEditMenuDescriptions, MenuService.MenuType.LanguageSettings, newSettings);

                        while (isLoopingEditSetting)
                        {
                            switch (MenuService.MenuSelection)
                            {
                                case '0':
                                    // Enter new Language value
                                    Write("\nNew Language Values (comma separated/up to five) >> ");
                                    newSettings = MenuService.ParseSettingsInput(ReadLine(), MenuService.SettingsKeys.ApiKey);

                                    // More than five
                                    if (newSettings.Length > 5)
                                    {
                                        Write("\nThere are more than five languages! Press any key to continue...");
                                        ReadLine();
                                        break;
                                    }
                                    else
                                    {
                                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsEditMenuOptions, MenuService.SettingsEditMenuDescriptions, MenuService.MenuType.LanguageSettings, newSettings);
                                        break;
                                    }

                                case '1':
                                    // Save Changes
                                    if (newSettings == null)
                                    {
                                        Write("\nNo changes were made. Press any key to continue...");
                                        ReadLine();
                                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsEditMenuOptions, MenuService.SettingsEditMenuDescriptions, MenuService.MenuType.LanguageSettings, newSettings);
                                    }
                                    else
                                    {
                                        // Need array error checking here (wrong language)
                                        WriteLine("\nSaving...");
                                        Settings settings = ConfigurationService.LoadSettings();
                                        settings.Language = ConfigurationService.ConvertToTwoLetter(newSettings, MenuService.SettingsKeys.Language);
                                        ConfigurationService.SaveSettings(settings);
                                        Write("COMPLETE. Press any key to continue...");
                                        ReadLine();
                                        newSettings = null;
                                        isLoopingEditSetting = false;
                                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsMenuOptions, MenuService.SettingsMenuDescriptions, MenuService.MenuType.Settings);
                                    }
                                    break;

                                case 'b':
                                    // Discard changes and go back
                                    isLoopingEditSetting = false;
                                    newSettings = null;
                                    MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsMenuOptions, MenuService.SettingsMenuDescriptions, MenuService.MenuType.Settings);
                                    break;

                                default:
                                    break;
                            }
                        }

                        break;

                    case 'b':
                        // Back to Main Menu
                        isLoopingSubMenu = false;
                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions, MenuService.MenuType.Main);
                        break;

                    default:
                        break;
                }
            }

            break;

        case 'q':
            isLooping = false;
            MenuService.UserQuitTheProgram();
            break;

        default:
            break;
    }
}

#endregion


#endregion