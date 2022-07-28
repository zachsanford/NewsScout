using NewsScout.Models;
using NewsScout.Services;

namespace NewsScout.Tests
{
    [TestClass]
    public class ApiServiceTests
    {
        [TestMethod]
        public async Task TestGetNews_Correct()
        {
            // Arrange & Act
            ApiResponse testResponse = await ApiService.GetNews();

            // Assert
            Assert.IsNotNull(testResponse);
        }

        [TestMethod]
        public async Task TestGetNewsWithSettings_Correct()
        {
            // Arrange & Act
            ApiResponse testResponse = await ApiService.GetNewsWithSettings();

            // Assert
            Assert.IsNotNull(testResponse);
        }

        [DataTestMethod]
        [DataRow("  This is a search ")]
        public void TestConvertSearchForURL_Correct(string _searchQuery)
        {
            // Arrange
            string expectedOutput = "This%20is%20a%20search";

            // Act
            string testOutput = ApiService.ConvertSearchForURL(_searchQuery);

            // Assert
            Assert.AreEqual(expectedOutput, testOutput);
        }
    }
}