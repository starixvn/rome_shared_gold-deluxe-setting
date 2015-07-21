namespace Fanex.GoldDeluxe.CoreSetting.DTOs
{
    using System.Collections.Generic;

    public class SettingDTO
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string Fax { get; set; }

        public bool DisableGoldDeluxe { get; set; }

        public bool DisableUpline { get; set; }

        public bool DisableDownlines { get; set; }

        public bool HasDownline { get; set; }

        public CommissionDTO Commission { get; set; }

        public List<GameTypeDTO> GameSetting { get; set; }

        public PositionTakingDTO PositionTaking { get; set; }

        public WinLimitDTO WinLimit { get; set; }
    }
}