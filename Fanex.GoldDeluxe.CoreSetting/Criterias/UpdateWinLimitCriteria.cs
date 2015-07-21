namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    internal class UpdateWinLimitCriteria : CommandCriteria
    {
        private int GoldDeluxeSportType = 255;

        private int GoldDeluxeBetType = 1701;

        public int CustId { get; set; }

        public float MaxWinLimit { get; set; }

        public bool IsAutoReset { get; set; }

        public int SportType
        {
            get
            {
                return GoldDeluxeSportType;
            }
        }

        public int BetType
        {
            get
            {
                return GoldDeluxeBetType;
            }
        }

        public override bool IsValid()
        {
            return CustId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerWinlimitUpd";
        }
    }
}
