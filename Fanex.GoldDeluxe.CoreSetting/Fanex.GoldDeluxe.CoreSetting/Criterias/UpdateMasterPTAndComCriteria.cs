namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    public class UpdateMasterPTAndComCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "srecommend")]
        public int SuperId { get; set; }

        [SpParam(SqlParamName = "v255spositiontaking_1701")]
        public decimal S3 { get; set; }

        [SpParam(SqlParamName = "v255mpositiontaking_1701")]
        public decimal M3 { get; set; }

        [SpParam(SqlParamName = "isauto_v255spositiontaking_1701")]
        public bool Is3 { get; set; }

        [SpParam(SqlParamName = "auto_v255spositiontaking_1701")]
        public decimal Us3 { get; set; }

        [SpParam(SqlParamName = "v255mpositiontaking_1701_min")]
        public decimal N3 { get; set; }

        [SpParam(SqlParamName = "v255discount_1701")]
        public decimal Commission { get; set; }

        public bool UpdateAllMembers { get; set; }

        [SpParam(SqlParamName = "newspositiontaking")]
        public decimal NewSuperPositionTaking { get; set; }

        public override bool IsValid()
        {
            return CustId > 0;
        }

        public override string GetSettingKey()
        {
            return "Acc_CustomerUpdMasterGoldDeluxe_All";
        }
    }
}
