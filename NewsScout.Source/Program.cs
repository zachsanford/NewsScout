﻿#region Manual Test Area

#region MenuService Tests

//char[] choices = { 'a', 'b', 'c' };
//string userInput = "1";

//char returnChar = MenuService.CheckUserSelection(userInput, choices);

WriteLine(MenuService.MenuSelection);
MenuService.MenuSelection = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions);
bool isLooping = true;

while (isLooping)
{
    switch (MenuService.MenuSelection)
    {
        case '0':
            break;

        case '1':
            break;

        case 's':
            MenuService.MenuSelection = MenuService.ShowMenu(MenuService.SettingsMenuOptions, MenuService.SettingsMenuDescriptions, true);

            switch (MenuService.MenuSelection)
            {
                case '0':
                    break;

                case '1':
                    break;

                case '2':
                    break;

                case 'b':
                    MenuService.MenuSelection = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions);
                    break;

                default:
                    break;
            }

            break;

        case 'q':
            MenuService.UserQuitTheProgram();
            isLooping = false;
            break;

        default:
            break;
    }
}

#endregion


#endregion