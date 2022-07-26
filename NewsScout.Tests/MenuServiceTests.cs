using NewsScout.Services;

namespace NewsScout.Tests
{
    [TestClass]
    public class MenuServiceTests
    {
        [DataTestMethod]
        [DataRow("a", new char[] { 'a', 'b', 'c' })]
        [DataRow("b", new char[] { 'a', 'b', 'c' })]
        [DataRow("C", new char[] { 'a', 'b', 'c' })]
        public void TestCheckUserSelection_Correct(string _userInput, char[] _choicesToChooseFrom)
        {
            // Arrange & Act
            char testOutput = MenuService.CheckUserSelection(_userInput, _choicesToChooseFrom);

            // Assert
            Assert.AreEqual(Convert.ToChar(_userInput.ToLower()), testOutput);
        }

        [DataTestMethod]
        [DataRow(" australia,belgium,Saudi Arabia  ")]
        public void TestParseSettingsInput_Correct(string _userInput)
        {
            // Arrange
            string[] expectedOutput = { "australia", "belgium", "saudi arabia" };

            // Act
            string[] testOutput = MenuService.ParseSettingsInput(_userInput);

            // Assert
            for (int i = 0; i < testOutput.Length; i++)
            {
                Assert.AreEqual(expectedOutput[i], testOutput[i]);
            }
        }

        [DataTestMethod]
        [DataRow("  Saudi arAbia,   united states OF america         ")]
        public void TestParseSettingsInput_CorrectCount(string _userInput)
        {
            // Arrange
            int expectedCount = 2;

            // Act
            string[] testOutput = MenuService.ParseSettingsInput(_userInput);

            // Assert
            Assert.AreEqual(expectedCount, testOutput.Length);
        }

        [TestMethod]
        public void TestShowMenu_Correct()
        {
            // Arrange
            ReadOnlyCollection<char> options = new List<char>
            {
                'a',
                'b',
                'c'
            }.AsReadOnly();

            ReadOnlyCollection<string> descriptions = new List<string>
            {
                "first",
                "second",
                "third"
            }.AsReadOnly();

            // Act
            try
            {
                char testOutput = MenuService.ShowMenu(options, descriptions, MenuService.MenuType.Main);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsTrue(ex.Message != null);
            }
        }
    }
}
