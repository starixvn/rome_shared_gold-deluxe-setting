namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Data;
    using Data.Repository;

    internal class GetMemberSettingCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "recommend")]
        public int UpLineId { get; set; }

        public override bool IsValid()
        {
            return CustId > 0 && UpLineId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerSelEditMemberGoldDeluxe";
        }
    }
}