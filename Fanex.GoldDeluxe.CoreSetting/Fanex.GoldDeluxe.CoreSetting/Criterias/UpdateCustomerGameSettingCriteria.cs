namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    public class UpdateCustomerGameSettingCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        public string StakeLevel { get; set; }

        public override bool IsValid()
        {
            return CustId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerUpdGoldDeluxe_MinMaxBet";
        }
    }
}
