namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.GoldDeluxe.CoreSetting.Configuration;

    internal class UpdateGameSettingCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        public string StakeLevel { get; set; }

        public int SystemID
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
            return "Acc_CustomerUpdGoldDeluxe_MinMaxBet";
        }
    }
}