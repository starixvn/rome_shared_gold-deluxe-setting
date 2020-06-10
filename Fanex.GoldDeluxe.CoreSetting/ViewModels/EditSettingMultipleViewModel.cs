namespace Fanex.GoldDeluxe.CoreSetting.ViewModels
{
    public class EditSettingMultipleViewModel : EditSettingViewModel
    {
        public bool IsSC { get; set; } = true;

        public string CustIds { get; set; }

        public string Usernames { get; set; }
    }
}