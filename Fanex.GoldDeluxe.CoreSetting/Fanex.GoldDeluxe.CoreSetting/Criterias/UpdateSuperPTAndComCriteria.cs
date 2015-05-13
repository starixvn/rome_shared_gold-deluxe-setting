namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    internal class UpdateSuperPTAndComCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "v255spositiontaking_1701")]
        public decimal S4 { get; set; }

        [SpParam(SqlParamName = "v255spositiontaking_1701_min")]
        public decimal N4 { get; set; }

        [SpParam(SqlParamName = "v255discount_1701")]
        public decimal Commision { get; set; }

        public override bool IsValid()
        {
            return CustId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerUpdSuperGoldDeluxe_All";
        }
    }
}
