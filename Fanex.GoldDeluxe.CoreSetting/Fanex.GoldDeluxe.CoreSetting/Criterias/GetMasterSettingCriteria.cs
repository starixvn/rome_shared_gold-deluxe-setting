namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    internal class GetMasterSettingCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "srecommend")]
        public int SuperId { get; set; }

        public override bool IsValid()
        {
            return CustId > 0 && SuperId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerSelEditMasterGoldDeluxe";
        }
    }
}
