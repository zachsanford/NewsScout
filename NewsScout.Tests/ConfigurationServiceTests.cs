using NewsScout.Models;
using NewsScout.Services;

namespace NewsScout.Tests
{
    [TestClass]
    public class ConfigurationServiceTests
    {
        [TestMethod]
        public void LoadSettingsFile()
        {
            // Arrange
            Settings? testSettings;

            // Act
            testSettings = ConfigurationService.LoadSettings();

            // Assert
            Assert.IsNotNull(testSettings);
        }
    }
}