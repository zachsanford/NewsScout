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
                        isLoopingEditSetting = true;
                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.APIKeyMenuOptions, MenuService.APIKeyMenuDescriptions, MenuService.MenuType.ApiSettings, newSettings);

                        while (isLoopingEditSetting)
                        {
                            switch (MenuService.MenuSelection)
                            {
                                case '0':
                                    // Enter new API value
                                    Write("\nNew API Key Value >> ");
                                    newSettings = MenuService.ParseSettingsInput(ReadLine(), MenuService.SettingsKeys.ApiKey);
                                    MenuService.MenuSelection = MenuService.ShowMenu(MenuService.APIKeyMenuOptions, MenuService.APIKeyMenuDescriptions, MenuService.MenuType.ApiSettings, newSettings);
                                    break;

                                case '1':
                                    // Save Changes
                                    if (newSettings == null)
                                    {
                                        Write("\nNo changes were made. Press any key to continue...");
                                        ReadLine();
                                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.APIKeyMenuOptions, MenuService.APIKeyMenuDescriptions, MenuService.MenuType.ApiSettings, newSettings);
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
                        break;

                    case '2':
                        break;

                    case 'b':
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