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
    }
}
