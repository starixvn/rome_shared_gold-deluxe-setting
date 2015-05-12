namespace Fanex.GoldDeluxe.CoreSetting.ViewModels
{
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;

    public class EditSettingViewModel
    {
        public CustomerLevel UplineLevel { get; set; }

        public CustomerLevel Level { get; set; }

        public SystemType System { get; set; }

        public SettingDTO Setting { get; set; }
    }
}
