namespace Fanex.GoldDeluxe.CoreSetting.ViewModels
{
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;

    public class EditSettingViewModel
    {
        public int CustId { get; set; }

        public int UpLineId { get; set; }

        public int ActorId { get; set; }

        public int SubAccId { get; set; }

        public string Language { get; set; }

        public FormType FormType { get; set; }

        public CustomerLevel UpLineLevel { get; set; }

        public CustomerLevel Level { get; set; }

        public SystemType System { get; set; }

        public SettingDTO Setting { get; set; }

        public bool IsUpdatePTAllMembers { get; set; }

        public float PTOnMember { get; set; }
    }
}
