namespace Fanex.GoldDeluxe.CoreSetting.ParameterObjects
{
    public class UpdateSettingFromExistingMemberParameters : CommandParameter
    {
        public int CustId { get; set; }

        public int FromCustId { get; set; }

        public int UpLineId { get; set; }
    }
}
