namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    public class GetAgentSettingCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "mrecommend")]
        public int MasterId { get; set; }

        public override bool IsValid()
        {
            return CustId > 0 && MasterId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerSelEditAgentGoldDeluxe";
        }
    }
}
