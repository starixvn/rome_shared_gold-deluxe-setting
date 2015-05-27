namespace Fanex.GoldDeluxe.CoreSetting.ParameterObjects
{
    public class UpdatePTAndComFromExistingMemberParameters : CommandParameter
    {
        public int CustId { get; set; }

        public int FromCustId { get; set; }

        public int UpLineId { get; set; }
    }
}
