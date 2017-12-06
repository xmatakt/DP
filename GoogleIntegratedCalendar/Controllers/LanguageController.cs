using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace EZKO.Controllers
{
    /// <summary>
    /// Controller to allow language localization for EZKO application
    /// </summary>
    public static class LanguageController
    {
        //Rewource manager used to work with language resource files
        private static ResourceManager resourcesManager = new ResourceManager("EZKO.Resources.Language", typeof(MainForm).Assembly);
        //CultureInfo for application based on selected culture string from App.config
        private static CultureInfo currentCultureInfo = CultureInfo.CreateSpecificCulture(GlobalSettings.LanguagePrefix);

        /// <summary>
        /// Get language localized text with specific key
        /// </summary>
        /// <param name="key">Key of the resource string</param>
        /// <returns>Value with provided key from language resource files</returns>
        public static string GetText(string key)
        {
            return resourcesManager.GetString(key, currentCultureInfo);      
        }

        /// <summary>
        /// Get language localized text with specific key
        /// </summary>
        /// <param name="key">Key of the resource string</param>
        /// <returns>Value with provided key from language resource files ended eith "*"</returns>
        public static string GetRequiredText(string key)
        {
            return resourcesManager.GetString(key, currentCultureInfo) + "*";
        }

        /// <summary>
        /// Get language localized text with specific key
        /// </summary>
        /// <param name="key">Key of the resource string</param>
        /// <returns>Value with provided key from language resource files ended eith ":"</returns>
        public static string GetColonText(string key)
        {
            return resourcesManager.GetString(key, currentCultureInfo) + ":";
        }

        /// <summary>
        /// Get language localized text with specific key
        /// </summary>
        /// <param name="key">Key of the resource string</param>
        /// <returns>Value with provided key from language resource files ended eith "*:"</returns>
        public static string GetRequiredColonText(string key)
        {
            return resourcesManager.GetString(key, currentCultureInfo) + "*:";
        }
    }
}
