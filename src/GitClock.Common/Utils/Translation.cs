using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace GitClock.Common.Utils
{
    public static class Translation
    {
        public static string GetTranslatedMessage(string resourceItem, params string[] values)
        {
            var resource = Translations.Resources.Messages.ResourceManager;

            // Obter a cultura atual do contexto HTTP se disponível
            var currentCulture = CultureInfo.CurrentCulture;

            return string.Format(resource.GetString(resourceItem, currentCulture) ?? resourceItem, values);
        }

        public static string GetTranslatedMessage(string resourceItem, CultureInfo culture, params string[] values)
        {
            var resource = Translations.Resources.Messages.ResourceManager;
            return string.Format(resource.GetString(resourceItem, culture) ?? resourceItem, values);
        }
    }
}
