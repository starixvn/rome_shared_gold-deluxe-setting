namespace Fanex.GoldDeluxe.CoreSetting.Criterias
{
    using Fanex.NAP.Framework.Data;

    internal class UpdateMasterPTAndComCriteria : CommandCriteria
    {
        public int CustId { get; set; }

        [SpParam(SqlParamName = "srecommend")]
        public int UpLineId { get; set; }

        [SpParam(SqlParamName = "v255spositiontaking_1701")]
        public float? S3 { get; set; }

        [SpParam(SqlParamName = "v255mpositiontaking_1701")]
        public float? M3 { get; set; }

        [SpParam(SqlParamName = "isauto_v255spositiontaking_1701")]
        public bool Is3 { get; set; }

        [SpParam(SqlParamName = "auto_v255spositiontaking_1701")]
        public float? Us3 { get; set; }

        [SpParam(SqlParamName = "v255mpositiontaking_1701_min")]
        public float? N3 { get; set; }

        [SpParam(SqlParamName = "v255discount_1701")]
        public float? Commission { get; set; }

        [SpParam(SqlParamName = "updateallmembers")]
        public bool IsUpdatePTAllMembers { get; set; }

        [SpParam(SqlParamName = "newspositiontaking")]
        public float? PTOnMember { get; set; }

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
