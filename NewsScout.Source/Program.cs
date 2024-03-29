﻿#region Program Variables

ApiResponse? response = new ApiResponse();
string[]? newSettings = null;
string? searchQuery = null;
bool isLooping = true;
bool isLoopingSubMenu = true;
bool isLoopingSubMenu2 = true;
bool isLoopingEditSetting = true;

#endregion

#region Main

MenuService.MenuSelection = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions, MenuService.MenuType.Main);

while (isLooping)
{
    switch (MenuService.MenuSelection)
    {
        case '0':
            // Get results with current settings
            isLooping = true;
            isLoopingSubMenu = true;
            
            if (response.TotalResults == null || response.TotalResults  == 0)
            {
                Write("\nGathering Articles...");
                response = await ApiService.GetNewsWithSettingsAndSearch();
            }

            if (response.TotalResults != null && response.TotalResults != 0)
            {
                while (isLoopingSubMenu)
                {
                    MenuService.MenuSelection = MenuService.ListArticles(response);
                    if (MenuService.ArticleListPossibleOptions.Contains(MenuService.MenuSelection))
                    {
                        if (MenuService.MenuSelection != 'b')
                        {
                            MenuService.ShowArticle(response.Results[Convert.ToInt16(MenuService.MenuSelection.ToString())]);
                        }
                        else
                        {
                            isLoopingSubMenu = false;
                            MenuService.MenuSelection = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions, MenuService.MenuType.Main);
                            response = new ApiResponse();
                        }
                    }
                    else
                    {
                        Write($"{MenuService.MenuSelection} is not a correct choice! Please try again >> ");
                        MenuService.MenuSelection = MenuService.ListArticles(response);
                    }
                }
            }
            else if (response.Results != null)
            {
                if (response.Results.Length == 0)
                {
                    Write("\n\nNO RESULTS. Press any key to continue...");
                    ReadLine();
                    MenuService.MenuSelection = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions, MenuService.MenuType.Main);
                    break;
                }                
            }
            else
            {
                MenuService.MenuSelection = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions, MenuService.MenuType.Main);
                break;
            }

            break;

        case '1':
            // Get results with search query
            isLooping = true;
            isLoopingSubMenu = true;
            MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SearchQueryMenuOptions, MenuService.SearchQueryMenuDescriptions, MenuService.MenuType.CustomSearch, null, searchQuery);

            while (isLoopingSubMenu)
            {
                switch (MenuService.MenuSelection)
                {
                    case '0':
                        // Create/Edit Query
                        Write("\nEnter your search query >> ");
                        searchQuery = ReadLine();
                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SearchQueryMenuOptions, MenuService.SearchQueryMenuDescriptions, MenuService.MenuType.CustomSearch, null, searchQuery);
                        break;

                    case '1':
                        // Run Query
                        isLoopingSubMenu2 = true;

                        if (response.TotalResults == null || response.TotalResults == 0)
                        {
                            Write("\nGathering Articles...");
                            response = await ApiService.GetNewsWithSettingsAndSearch(searchQuery);
                        }

                        if (response.TotalResults != null && response.TotalResults != 0)
                        {
                            while (isLoopingSubMenu2)
                            {
                                MenuService.MenuSelection = MenuService.ListArticles(response);
                                if (MenuService.ArticleListPossibleOptions.Contains(MenuService.MenuSelection))
                                {
                                    if (MenuService.MenuSelection != 'b')
                                    {
                                        MenuService.ShowArticle(response.Results[Convert.ToInt16(MenuService.MenuSelection.ToString())]);
                                    }
                                    else
                                    {
                                        isLoopingSubMenu2 = false;
                                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SearchQueryMenuOptions, MenuService.SearchQueryMenuDescriptions, MenuService.MenuType.CustomSearch, null, searchQuery);
                                        response = new ApiResponse();
                                    }
                                }
                                else
                                {
                                    Write($"{MenuService.MenuSelection} is not a correct choice! Please try again >> ");
                                    MenuService.MenuSelection = MenuService.ListArticles(response);
                                }
                            }
                        }
                        else if (response.Results != null)
                        {
                            if (response.Results.Length == 0)
                            {
                                Write("\n\nNO RESULTS. Press any key to continue...");
                                ReadLine();
                                isLoopingSubMenu = false;
                                MenuService.MenuSelection = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions, MenuService.MenuType.Main);
                                break;
                            }
                        }
                        else
                        {
                            isLoopingSubMenu = false;
                            MenuService.MenuSelection = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions, MenuService.MenuType.Main);
                            break;
                        }

                        break;

                    case 'b':
                        // Go back
                        isLoopingSubMenu = false;
                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions, MenuService.MenuType.Main);
                        break;

                    default:
                        break;
                }
            }

            break;

        case 's':
            // Settings
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
                                        Write("\nCOMPLETE. Press any key to continue...");
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
                                    newSettings = MenuService.ParseSettingsInput(ReadLine(), MenuService.SettingsKeys.Country);

                                    // More than five
                                    if (newSettings.Length > 5)
                                    {
                                        Write("\nThere are more than five countries! Press any key to continue...");
                                        ReadLine();
                                        break;
                                    }
                                    else if (!ConfigurationService.CheckAgainstDictionary(newSettings, MenuService.SettingsKeys.Country))
                                    {
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
                                        WriteLine("\nSaving...");
                                        Settings settings = ConfigurationService.LoadSettings();
                                        settings.Country = ConfigurationService.ConvertToTwoLetter(newSettings, MenuService.SettingsKeys.Country);
                                        ConfigurationService.SaveSettings(settings);
                                        Write("\nCOMPLETE. Press any key to continue...");
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
                                    newSettings = MenuService.ParseSettingsInput(ReadLine(), MenuService.SettingsKeys.Language);

                                    // More than five
                                    if (newSettings.Length > 5)
                                    {
                                        Write("\nThere are more than five languages! Press any key to continue...");
                                        ReadLine();
                                        break;
                                    }
                                    else if (!ConfigurationService.CheckAgainstDictionary(newSettings, MenuService.SettingsKeys.Language))
                                    {
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
                                        WriteLine("\nSaving...");
                                        Settings settings = ConfigurationService.LoadSettings();
                                        settings.Language = ConfigurationService.ConvertToTwoLetter(newSettings, MenuService.SettingsKeys.Language);
                                        ConfigurationService.SaveSettings(settings);
                                        Write("\nCOMPLETE. Press any key to continue...");
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