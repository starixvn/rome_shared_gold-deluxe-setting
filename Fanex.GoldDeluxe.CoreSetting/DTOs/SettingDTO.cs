namespace Fanex.GoldDeluxe.CoreSetting.DTOs
{
    using Fanex.GoldDeluxe.CoreSetting.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SettingDTO
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string Fax { get; set; }

        public string Site { get; set; }

        public bool IsPT3Decimal => GoldDeluxeSettings.PT3DecimalSites().Any(site => site.Equals(this.Site, StringComparison.CurrentCultureIgnoreCase));

        public bool DisableGoldDeluxe { get; set; }

        public bool DisableUpline { get; set; }

        public CommissionDTO Commission { get; set; }

        public List<GameTypeDTO> GameSetting { get; set; }

        public PositionTakingDTO PositionTaking { get; set; }

        public WinLimitDTO WinLimit { get; set; }
    }
}