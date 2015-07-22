namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    internal class GetCurrentMemberWinLimitCriteria : CriteriaBase
    {
        private int GoldDeluxeSportType = 255;

        private int GoldDeluxeBetType = 1701;

        public int CustId { get; set; }

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
            return "Acc_CustomerWinLimitSel";
        }
    }
}
