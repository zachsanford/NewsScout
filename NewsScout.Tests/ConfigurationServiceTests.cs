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

        [DataTestMethod]
        [DataRow(new string[] { "united states of america", "canada", "japan" }, MenuService.SettingsKeys.Country)]
        public void TestConvertToTwoLetter_CorrectCountry(string[] _input, Enum _type)
        {
            // Arrange
            string[] expectedOutput = { "us", "ca", "jp" };

            // Act
            string[] testOutput = ConfigurationService.ConvertToTwoLetter(_input, _type);

            // Assert
            Assert.AreEqual(expectedOutput[0], testOutput[0]);
            Assert.AreEqual(expectedOutput[1], testOutput[1]);
            Assert.AreEqual(expectedOutput[2], testOutput[2]);
        }

        [DataTestMethod]
        [DataRow(new string[] { "english", "french", "german" }, MenuService.SettingsKeys.Language)]
        public void TestConvertToTwoLetter_CorrectLanguage(string[] _input, Enum _type)
        {
            // Arrange
            string[] expectedOutput = { "en", "fr", "de" };

            // Act
            string[] testOutput = ConfigurationService.ConvertToTwoLetter(_input, _type);

            // Assert
            Assert.AreEqual(expectedOutput[0], testOutput[0]);
            Assert.AreEqual(expectedOutput[1], testOutput[1]);
            Assert.AreEqual(expectedOutput[2], testOutput[2]);
        }
    }
}