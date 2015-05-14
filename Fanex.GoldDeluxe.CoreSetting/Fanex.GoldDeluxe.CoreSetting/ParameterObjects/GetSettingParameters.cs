namespace Fanex.GoldDeluxe.CoreSetting.ParameterObjects
{
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;

    public class GetSettingParameters
    {
        public int CustId { get; set; }

        public CustomerLevel Level { get; set; }

        public int UpLineId { get; set; }

        public CustomerLevel UpLineLevel { get; set; }
    }
}