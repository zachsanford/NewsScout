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
                char testOutput = MenuService.ShowMenu(options, descriptions);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsTrue(ex.Message != null);
            }
        }
    }
}
