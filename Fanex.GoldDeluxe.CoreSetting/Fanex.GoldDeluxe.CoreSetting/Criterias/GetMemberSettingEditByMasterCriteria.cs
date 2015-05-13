namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    internal class GetMemberSettingEditByMasterCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        public override bool IsValid()
        {
            return CustId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerSelMEditCustomerGoldDeluxe";
        }
    }
}
