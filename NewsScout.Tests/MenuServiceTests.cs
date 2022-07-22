using NewsScout.Services;

namespace NewsScout.Tests
{
    [TestClass]
    public class MenuServiceTests
    {
        [DataTestMethod]
        [DataRow("a", new char[] { 'a', 'b', 'c' })]
        [DataRow("b", new char[] { 'a', 'b', 'c' })]
        [DataRow("c", new char[] { 'a', 'b', 'c' })]
        public void TestCheckUserSelection_Correct(string _userInput, char[] _choicesToChooseFrom)
        {
            // Arrange & Assert
            char testOutput = MenuService.CheckUserSelection(_userInput, _choicesToChooseFrom);

            // Assert
            Assert.AreEqual(Convert.ToChar(_userInput), testOutput);
        }
    }
}
