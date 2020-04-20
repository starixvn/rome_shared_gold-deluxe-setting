namespace Fanex.GoldDeluxe.CoreSetting.Configuration
{
    using System.Configuration;
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;

    public class GoldDeluxeSettings : ConfigurationSection
    {
        private const string __GOLD_DELUXE_SETTINGS = "GoldDeluxeSettings";
        private const string __SYSTEM_ID = "SystemId";
        private const string __UN_AUTHORIZED_PATH = "UnAuthorizedPath";
        private const string __AUTHORIZATION_SERVICE_TYPE = "AuthorizationServiceType";
        private const string __LANGUAGE_SESSION_KEY = "LanguageSessionKey";
        private const string __SITE_NAME_SESSION_KEY = "SiteNameSessionKey";
        private const string __SPECIAL_GROUPS_CONFIGURATION_KEY = "SpecialGroupsConfigurationKey";
        private const string __MEMBER_MAX_STAKELEVELS_SELECTION_KEY = "MemberMaxStakeLevels";

        private static GoldDeluxeSettings _settings = ConfigurationManager.GetSection(__GOLD_DELUXE_SETTINGS) as GoldDeluxeSettings;

        public static GoldDeluxeSettings Settings
        {
            get
            {
                return _settings;
            }
        }

        public SystemType System
        {
            get
            {
                return (SystemType)SystemId;
            }
        }

        [ConfigurationProperty(__UN_AUTHORIZED_PATH, IsRequired = false, DefaultValue = "~/Areas/GoldDeluxeSetting/Views/Common/UnAuthorized.cshtml")]
        public string UnAuthorizedPath
        {
            get { return (string)this[__UN_AUTHORIZED_PATH]; }
            set { this[__UN_AUTHORIZED_PATH] = value; }
        }

        [ConfigurationProperty(__AUTHORIZATION_SERVICE_TYPE, IsRequired = false, DefaultValue = "")]
        public string AuthorizationServiceType
        {
            get { return (string)this[__AUTHORIZATION_SERVICE_TYPE]; }
            set { this[__AUTHORIZATION_SERVICE_TYPE] = value; }
        }

        [ConfigurationProperty(__LANGUAGE_SESSION_KEY, IsRequired = false, DefaultValue = "")]
        public string LanguageSessionKey
        {
            get { return (string)this[__LANGUAGE_SESSION_KEY]; }
            set { this[__LANGUAGE_SESSION_KEY] = value; }
        }

        [ConfigurationProperty(__SYSTEM_ID, IsRequired = true)]
        private int SystemId
        {
            get { return (int)this[__SYSTEM_ID]; }
            set { this[__SYSTEM_ID] = value; }
        }

        [ConfigurationProperty(__SITE_NAME_SESSION_KEY, IsRequired = false, DefaultValue = "")]
        public string SiteNameSessionKey
        {
            get { return (string)this[__SITE_NAME_SESSION_KEY]; }
        }

        [ConfigurationProperty(__SPECIAL_GROUPS_CONFIGURATION_KEY, IsRequired = false, DefaultValue = "")]
        public string SpecialGroupsConfigurationKey
        {
            get { return (string)this[__SPECIAL_GROUPS_CONFIGURATION_KEY]; }
        }

        [ConfigurationProperty(__MEMBER_MAX_STAKELEVELS_SELECTION_KEY, IsRequired = false, DefaultValue = "1")]
        public int MemberMaxStakeLevels
        {
            get { return (int)this[__MEMBER_MAX_STAKELEVELS_SELECTION_KEY]; }
        }
    }
}