namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Data;

    internal class UpdateAgentPTAndComCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "mrecommend")]
        public int UpLineId { get; set; }

        [SpParam(SqlParamName = "v255mpositiontaking_1701")]
        public float? M2 { get; set; }

        [SpParam(SqlParamName = "auto_v255mpositiontaking_1701")]
        public float? Um2 { get; set; }

        [SpParam(SqlParamName = "isauto_v255mpositiontaking_1701")]
        public bool Im2 { get; set; }

        [SpParam(SqlParamName = "v255apositiontaking_1701")]
        public float? A2 { get; set; }

        [SpParam(SqlParamName = "min_v255apositiontaking_1701")]
        public float? N2 { get; set; }

        [SpParam(SqlParamName = "v255discount_1701")]
        public float? Commission { get; set; }

        [SpParam(SqlParamName = "updateallmembers")]
        public bool IsUpdatePTAllMembers { get; set; }

        [SpParam(SqlParamName = "newmpositiontaking")]
        public float? PTOnMember { get; set; }

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