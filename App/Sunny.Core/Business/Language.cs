using System;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.JsonLocalisation;
using Sunny.Core.Domain.Enums;

namespace Sunny.Core.Business
{
    /// <summary>
    /// Language.
    /// This class should be used for everything regarding Language.
    /// A lot more methods are in this class then needed. This is done because of MedNix. 
    /// The localizedLanguageCode should always be in ISO format as shown: 'nl-NL'.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// This method replaces underscores with dashes. 
        /// After that it will set the local language with MvvmCross 
        /// <see>
        ///     <cref>SetLocalLanguage(ELocalizedLanguageCode languageCode)</cref>
        /// </see>
        /// </summary>
        /// <param name="languageCode">     The language code. </param>
        /// <param name="defaultLanguage">  (optional) the default language. </param>
        public static void SetLocalLanguage(string languageCode, ELocalizedLanguageCode defaultLanguage = ELocalizedLanguageCode.enUS)
        {
            languageCode = languageCode.Replace("_", "").Replace("-", "");
            var language = CheckLanguageSupported(languageCode, defaultLanguage);
            SetLocalLanguage(language);
        }

        /// <summary>
        /// Sets local language with MvvmCross. 
        /// This method will try to load all the resources for a given language
        /// </summary>
        /// <param name="languageCode"> The language code. </param>
        public static void SetLocalLanguage(ELocalizedLanguageCode languageCode)
        {
            var language = String.Format("{0}-{1}", languageCode.ToString("G").Substring(0, 2), languageCode.ToString("G").Substring(2, 2));
            Mvx.Resolve<IMvxTextProviderBuilder>().LoadResources(language);
        }

        /// <summary>
        /// Checks if the language is supported.
        /// </summary>
        /// <param name="languageCode">     The language code. </param>
        /// <param name="defaultLanguage">  (optional) the default language. </param>
        /// <returns>
        /// The default language or the requested language
        /// </returns>
        private static ELocalizedLanguageCode CheckLanguageSupported(string languageCode, ELocalizedLanguageCode defaultLanguage = ELocalizedLanguageCode.enUS)
        {
            try
            {
                return (ELocalizedLanguageCode)Enum.Parse(typeof(ELocalizedLanguageCode), languageCode, true);
            }
            catch (Exception)
            {
                return defaultLanguage;
            }
        }
    }
}
