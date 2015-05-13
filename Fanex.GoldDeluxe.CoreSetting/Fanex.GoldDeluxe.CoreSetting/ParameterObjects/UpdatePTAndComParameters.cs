namespace Fanex.GoldDeluxe.CoreSetting.ParameterObjects
{
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;

    public class UpdatePTAndComParameters : CommandParameter
    {
        public int CustId { get; set; }

        public CustomerLevel Level { get; set; }

        public int UpLineId { get; set; }

        public CustomerLevel UpLineLevel { get; set; }

        public PositionTakingDTO PositionTaking { get; set; }

        public CommissionDTO Commission { get; set; }

        public bool IsUpdatePTAllMembers { get; set; }

        public float PTOnMember { get; set; }
    }
}
