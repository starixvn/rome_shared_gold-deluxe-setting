using Fanex.GoldDeluxe.CoreSetting.Configuration;

namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    internal class UpdateDisableStatusCriteria : CommandCriteria
    {
        public bool IsSC { get; set; } = false;

        public int CustId { get; set; }

        public bool Disable { get; set; }

        public int SystemId
        {
            get
            {
                return (int)GoldDeluxeSettings.Settings.System;
            }
        }

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