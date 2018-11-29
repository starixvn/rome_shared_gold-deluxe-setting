namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Data;
    using Data.Repository;

    internal class GetMasterSettingCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "srecommend")]
        public int UpLineId { get; set; }

        public override bool IsValid()
        {
            return CustId > 0 && UpLineId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerSelEditMasterGoldDeluxe";
        }
    }
}