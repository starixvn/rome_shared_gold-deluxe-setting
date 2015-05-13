namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    internal class UpdateDisableStatusCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        public bool Disable { get; set; }

        public bool EnableDownlines { get; set; }

        public override bool IsValid()
        {
            return CustId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerUpdDisableGoldDeluxe";
        }
    }
}
