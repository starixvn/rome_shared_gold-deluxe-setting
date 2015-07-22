namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    internal class UpdateWinLimitCriteria : CommandCriteria
    {
        private int _goldDeluxeSportType = 255;
        private int _goldDeluxeBetType = 1701;

        public int CustId { get; set; }

        public float MaxWinLimit { get; set; }

        public bool IsAutoReset { get; set; }

        public int SportType
        {
            get
            {
                return _goldDeluxeSportType;
            }
        }

        public int BetType
        {
            get
            {
                return _goldDeluxeBetType;
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
