namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Data;

    internal class UpdateSuperPTAndComCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "v255spositiontaking_1701")]
        public float? S4 { get; set; }

        [SpParam(SqlParamName = "v255spositiontaking_1701_min")]
        public float? N4 { get; set; }

        [SpParam(SqlParamName = "v255discount_1701")]
        public float? Commission { get; set; }

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