namespace NewsScout.Services
{
    public static class OptionsService
    {

        #region Properties

        public static IReadOnlyDictionary<string, string> Country { get; private set; } = new Dictionary<string, string>()
        {
            { "argentina", "ar" },
            { "australia", "au" },
            { "austria", "at" },
            { "belgium", "be" },
            { "brazil", "br" },
            { "bulgaria", "bg" },
            { "canada", "ca" },
            { "china", "cn" },
            { "colombia", "co" },
            { "cuba", "cu" },
            { "czech republic", "cz" },
            { "egypt", "eg" },
            { "france", "fr" },
            { "germany", "de" },
            { "greece", "gr" },
            { "hong kong", "hk" },
            { "hungary", "hu" },
            { "india", "in" },
            { "indonesia", "id" },
            { "iraq", "ie" },
            { "israel", "il" },
            { "italy", "it" },
            { "japan", "jp" },
            { "kazakhstan", "kz" },
            { "lativa", "lv" },
            { "lebanon", "lb" },
            { "lithuania", "lt" },
            { "malaysia", "my" },
            { "mexico", "mx" },
            { "morocco", "ma" },
            { "netherland", "nl" },
            { "new zealand", "nz" },
            { "nigeria", "ng" },
            { "north Korea", "kp" },
            { "norway", "no" },
            { "pakistan", "pk" },
            { "peru", "pe" },
            { "philippines", "ph" },
            { "poland", "pl" },
            { "portugal", "pt" },
            { "romania", "ro" },
            { "russia", "ru" },
            { "saudi arabia", "sa" },
            { "serbia", "rs" },
            { "singapore", "sg" },
            { "slovakia", "si" },
            { "south africa", "za" },
            { "south korea", "kr" },
            { "spain", "es" },
            { "sweden", "se" },
            { "switzerland", "ch" },
            { "taiwan", "tw" },
            { "thailand", "th" },
            { "turkey", "tr" },
            { "ukraine", "ua" },
            { "united arab emirates", "ae" },
            { "united kingdom", "gb" },
            { "united states of america", "us" },
            { "venezuela", "ve" }
        };

        // Enum for the News Categories
        public enum Category
        {
            business,
            entertainment,
            environment,
            food,
            health,
            politics,
            science,
            sports,
            technology,
            top,
            world
        }

        // Language Code Dictionary
        public static IReadOnlyDictionary<string, string> Language { get; private set; } = new Dictionary<string, string>()
        {
            { "arabic", "ar" },
            { "bosnian", "bs" },
            { "bulgarian", "bg" },
            { "central kurdish", "ckb" },
            { "chinese", "zh" },
            { "croation", "hr" },
            { "czech", "cs" },
            { "dutch", "nl" },
            { "english", "en" },
            { "french", "fr" },
            { "german", "de" },
            { "greek",  "el" },
            { "hebrew", "he" },
            { "hindi", "hi" },
            { "hungarian", "hu" },
            { "indonesian", "in" },
            { "italian", "it" },
            { "japanese", "jp" },
            { "korean", "ko" },
            { "latvian", "lv" },
            { "lithuanian", "lt" },
            { "malay", "ms" },
            { "norwegian", "no" },
            { "polish", "pl" },
            { "portuguese", "pt" },
            { "romanian", "ro" },
            { "russian", "ru" },
            { "serbian", "sr" },
            { "slovak", "sk" },
            { "slovenian", "sl" },
            { "spanish", "es" },
            { "swedish", "sv" },
            { "thai", "th" },
            { "turkish", "tr" },
            { "ukrainian", "uk" }
        };      

        #endregion

    }
}
