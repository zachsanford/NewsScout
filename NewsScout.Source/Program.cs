#region Manual Test Area

#region MenuService Tests

//char[] choices = { 'a', 'b', 'c' };
//string userInput = "1";

//char returnChar = MenuService.CheckUserSelection(userInput, choices);

WriteLine(MenuService.MenuSelection);
MenuService.MenuSelection = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions, MenuService.MenuType.Main);
bool isLooping = true;
bool isLoopingSubMenu = true;

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
                string[]? newSettings;
                
                switch (MenuService.MenuSelection)
                {
                    case '0':
                        MenuService.MenuSelection = MenuService.ShowMenu(MenuService.APIKeyMenuOptions, MenuService.APIKeyMenuDescriptions, MenuService.MenuType.ApiSettings);
                        if (MenuService.MenuSelection == '0')
                        {
                            Write("\nNew API Key Value >> ");
                            newSettings = MenuService.ParseSettingsInput(ReadLine());
                            MenuService.MenuSelection = MenuService.ShowMenu(MenuService.APIKeyMenuOptions, MenuService.APIKeyMenuDescriptions, MenuService.MenuType.ApiSettings, newSettings);
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