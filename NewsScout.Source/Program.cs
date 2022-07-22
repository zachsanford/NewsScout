#region Manual Test Area

#region MenuService Tests

//char[] choices = { 'a', 'b', 'c' };
//string userInput = "1";

//char returnChar = MenuService.CheckUserSelection(userInput, choices);

char result = MenuService.ShowMenu(MenuService.MainMenuOptions, MenuService.MainMenuDescriptions);
WriteLine(result);

#endregion


#endregion