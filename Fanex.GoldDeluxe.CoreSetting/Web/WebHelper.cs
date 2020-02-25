namespace Fanex.GoldDeluxe.CoreSetting.Web
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using Configuration;
    using Enumerations;

    public static class WebHelper
    {
        private static IDictionary<string, bool> _specialGroups = null;

        public static bool IsCustomerNotBelongToSpecialSites()
            => !IsCustomerBelongToSpecialSites();

        public static bool IsCustomerBelongToSpecialSites()
        {
            var settings = GoldDeluxeSettings.Settings;

            return settings.System != SystemType.Accounting
                && IsCustomerBelongToSpecialSites(settings);
        }

        private static bool IsCustomerBelongToSpecialSites(GoldDeluxeSettings settings)
        {
            var specialGroups = GetSpecialGroups(settings);

            if (specialGroups.Count == 0)
            {
                return false;
            }

            var siteName = GetSiteName(settings);

            if (string.IsNullOrWhiteSpace(siteName))
            {
                return false;
            }

            return specialGroups.ContainsKey(siteName.ToUpperInvariant());
        }

        private static string GetSiteName(GoldDeluxeSettings settings)
        {
            var session = HttpContext.Current.Session;
            var sessionKey = settings.System == SystemType.Agency
                ? session.SessionID + "_"
                : string.Empty;

            return (string)session[sessionKey + settings.SiteNameSessionKey];
        }

        private static IDictionary<string, bool> GetSpecialGroups(GoldDeluxeSettings settings)
        {
            if (_specialGroups == null)
            {
                var specialGroupsValue = ConfigurationManager.AppSettings[settings.SpecialGroupsConfigurationKey];

                _specialGroups = string.IsNullOrWhiteSpace(specialGroupsValue)
                    ? new Dictionary<string, bool>()
                    : specialGroupsValue
                        .Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToDictionary(kvp => kvp.Trim().ToUpperInvariant(), kvp => true);
            }

            return _specialGroups;
        }
    }
}
