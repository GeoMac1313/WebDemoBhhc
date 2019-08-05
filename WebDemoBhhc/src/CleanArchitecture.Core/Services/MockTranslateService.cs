using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Services
{
    public class MockTranslateService : ITranslate
    {
        public string GetTranslation(string input, int languageType)
        {
            string translatedText = "There was an error processing this text";

            switch (languageType)
            {
                case (int)LanguageOption.English:
                    translatedText = input;
                    break;

                case (int)LanguageOption.Spanish:
                    translatedText = "No pude encontrar un servicio de traducción gratuito.";
                    break;

                case (int)LanguageOption.German: 
                    translatedText = "Ich konnte keinen kostenlosen Übersetzungsdienst finden.";
                    break;

            }

            return translatedText;
        }
    }
}
