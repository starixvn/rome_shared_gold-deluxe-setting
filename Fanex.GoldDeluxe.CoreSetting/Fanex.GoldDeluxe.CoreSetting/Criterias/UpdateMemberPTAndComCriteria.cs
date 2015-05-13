namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    internal class UpdateMemberPTAndComCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "recommend")]
        public int AgentId { get; set; }

        [SpParam(SqlParamName = "v255apositiontaking_1701")]
        public decimal A1 { get; set; }

        [SpParam(SqlParamName = "v255playerdiscount_1701")]
        public decimal Commission { get; set; }

        public override bool IsValid()
        {
            return CustId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerUpdMemberGoldDeluxe_All";
        }
    }
}
