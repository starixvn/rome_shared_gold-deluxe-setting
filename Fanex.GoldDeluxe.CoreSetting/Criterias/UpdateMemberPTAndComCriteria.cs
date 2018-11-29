namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Data;

    internal class UpdateMemberPTAndComCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "recommend")]
        public int UpLineId { get; set; }

        [SpParam(SqlParamName = "v255apositiontaking_1701")]
        public float? A1 { get; set; }

        [SpParam(SqlParamName = "v255playerdiscount_1701")]
        public float? Commission { get; set; }

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