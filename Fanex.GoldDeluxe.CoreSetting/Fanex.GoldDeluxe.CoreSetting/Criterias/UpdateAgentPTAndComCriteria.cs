namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    internal class UpdateAgentPTAndComCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "mrecommend")]
        public int MasterId { get; set; }

        [SpParam(SqlParamName = "v255mpositiontaking_1701")]
        public decimal M2 { get; set; }

        [SpParam(SqlParamName = "auto_v255mpositiontaking_1701")]
        public decimal Um2 { get; set; }

        [SpParam(SqlParamName = "isauto_v255mpositiontaking_1701")]
        public bool Im2 { get; set; }

        [SpParam(SqlParamName = "v255apositiontaking_1701")]
        public decimal A2 { get; set; }

        [SpParam(SqlParamName = "min_v255apositiontaking_1701")]
        public decimal N2 { get; set; }

        [SpParam(SqlParamName = "v255discount_1701")]
        public decimal Commission { get; set; }

        public bool UpdateAllMembers { get; set; }

        [SpParam(SqlParamName = "newmpositiontaking")]
        public decimal NewMasterPositionTaking { get; set; }

        public override bool IsValid()
        {
            return CustId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerUpdAgentGoldDeluxe_All";
        }
    }
}
