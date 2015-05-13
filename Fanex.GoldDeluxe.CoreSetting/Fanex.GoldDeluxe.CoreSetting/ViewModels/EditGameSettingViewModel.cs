namespace Fanex.GoldDeluxe.CoreSetting.ViewModels
{
    using System.Collections.Generic;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;

    public class EditGameSettingViewModel
    {
        public int CustId { get; set; }

        public int ActorId { get; set; }

        public int SubAccId { get; set; }

        public string Language { get; set; }

        public List<GameTypeDTO> GameSetting { get; set; }
    }
}
