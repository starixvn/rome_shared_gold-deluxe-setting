namespace Fanex.GoldDeluxe.CoreSetting.ParameterObjects
{
    public class UpdateDisableStatusParameters : CommandParameter
    {
        public int CustId { get; set; }

        public bool Disable { get; set; }

        public bool EnableDownlines { get; set; }
    }
}
