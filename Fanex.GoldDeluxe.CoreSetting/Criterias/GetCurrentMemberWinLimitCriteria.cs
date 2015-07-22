namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    internal class GetCurrentMemberWinLimitCriteria : CriteriaBase
    {
        private int _goldDeluxeSportType = 255;
        private int _goldDeluxeBetType = 1701;

        public int CustId { get; set; }

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
            return "Acc_CustomerWinLimitSel";
        }
    }
}
