namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Data.Repository;

    internal class GetSuperSettingCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        public override string GetSettingKey()
        {
            return "Acc_CustomerSelEditSuperGoldDeluxe";
        }

        public override bool IsValid()
        {
            return CustId > 0;
        }
    }
}