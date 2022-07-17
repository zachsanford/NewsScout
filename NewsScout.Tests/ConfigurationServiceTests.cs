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

        [TestMethod]
        public void SaveSettingsFile()
        {
            // Arrange            
            Settings testSettings1 = new Settings()
            {
                ApiKey = "N3wK3y",
                Country = new string[]
                {
                    "us"
                },
                Language = new string[]
                {
                    "fr",
                    "de"
                }
            };
            Settings? testSettings2;

            // Act
            ConfigurationService.SaveSettings(testSettings1);
            testSettings2 = ConfigurationService.LoadSettings();

            // Assert
            Assert.AreEqual(testSettings2.ApiKey, testSettings1.ApiKey);
            Assert.AreEqual(testSettings2.Country[0], testSettings1.Country[0]);
            Assert.AreEqual(testSettings2.Language[0], testSettings1.Language[0]);
        }
    }
}