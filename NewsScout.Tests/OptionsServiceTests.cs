using NewsScout.Services;

namespace NewsScout.Tests
{
    [TestClass]
    public class OptionsServiceTests
    {
        [TestMethod]
        public void TestCountryCodes()
        {
            // Arrange and Act
            string countryCode1 = OptionsService.Country["canada"];    // ca
            string countryCode2 = OptionsService.Country["india"];     // in
            string countryCode3 = OptionsService.Country["thailand"];  // th

            // Assert
            Assert.AreEqual(countryCode1, OptionsService.Country["canada"]);
            Assert.AreEqual(countryCode2, OptionsService.Country["india"]);
            Assert.AreEqual(countryCode3, OptionsService.Country["thailand"]);
        }

        [TestMethod]
        public void TestCategories()
        {
            // Arrange and Act
            OptionsService.Category category1 = OptionsService.Category.sports;
            string category2 = OptionsService.Category.environment.ToString();

            // Assert
            Assert.AreEqual((int)category1, (int)OptionsService.Category.sports);
            Assert.AreEqual(category2, "environment");
        }

        [TestMethod]
        public void TestLanguageCodes()
        {
            // Arrange and Act
            string languageCode1 = OptionsService.Language["chinese"];           // zh
            string languageCode2 = OptionsService.Language["hindi"];             // hi
            string languageCode3 = OptionsService.Language["LaTvIAn".ToLower()]; // lv

            // Assert
            Assert.AreEqual(languageCode1, "zh");
            Assert.AreEqual(languageCode2, OptionsService.Language["hindi"]);
            Assert.AreEqual(languageCode3, OptionsService.Language["latvian"]);
        }
    }
}
