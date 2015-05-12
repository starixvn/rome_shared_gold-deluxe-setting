namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    public class UpdateMemberPTAndComByMasterCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "v255mpositiontaking_1701")]
        public decimal M1 { get; set; }

        [SpParam(SqlParamName = "auto_v255mpositiontaking_mem_1701")]
        public decimal Um1 { get; set; }

        [SpParam(SqlParamName = "isauto_v255mpositiontaking_mem_1701")]
        public bool Im1 { get; set; }

        [SpParam(SqlParamName = "isauto_v255mpositiontaking_1701")]
        public bool Im2 { get; set; }

        [SpParam(SqlParamName = "v255UpdatePositiontaking_1701")]
        public bool IsUpdateMasterPositionTaking { get; set; }

        public override bool IsValid()
        {
            return CustId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerUpdMemberGoldDeluxe_MAg";
        }
    }
}
