namespace Fanex.GoldDeluxe.CoreSetting.ParameterObjects
{
    public class UpdateWinLimitParameters : CommandParameter
    {
        public int CustId { get; set; }

        public float MaxWinLimit { get; set; }

        public bool IsAutoReset { get; set; }

        public int SportType { get; set; }

        public int BetType { get; set; }
    }
}
