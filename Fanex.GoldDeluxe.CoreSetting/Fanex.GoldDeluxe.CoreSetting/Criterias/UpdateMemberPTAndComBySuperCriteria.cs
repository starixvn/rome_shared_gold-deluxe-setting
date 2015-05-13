namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    internal class UpdateMemberPTAndComBySuperCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "v255spositiontaking_1701")]
        public decimal S1 { get; set; }

        [SpParam(SqlParamName = "isauto_v255spositiontaking_1701")]
        public bool Is1 { get; set; }

        [SpParam(SqlParamName = "auto_v255spositiontaking_1701")]
        public decimal Us1 { get; set; }

        [SpParam(SqlParamName = "v255UpdatePositiontaking_1701")]
        public bool IsUpdateSuperPositionTaking { get; set; }

        public override bool IsValid()
        {
            return CustId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerUpdMemberGoldDeluxe_SAg";
        }
    }
}
