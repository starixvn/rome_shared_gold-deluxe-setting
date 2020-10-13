namespace Fanex.GoldDeluxe.CoreSetting.ParameterObjects
{
    public class UpdateDisableStatusParameters : CommandParameter
    {
        public bool IsSC { get; set; } = false;

        public int CustId { get; set; }

        public bool Disable { get; set; }
    }
}