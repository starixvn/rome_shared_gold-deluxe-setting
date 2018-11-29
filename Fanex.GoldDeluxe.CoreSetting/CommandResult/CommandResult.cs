namespace Fanex.GoldDeluxe.CoreSetting.CommandResult
{
    public class CommandResult : CommandResultBase
    {
        public override bool IsSuccessful
        {
            get
            {
                string errCode = this.Code.ToString();

                return string.IsNullOrWhiteSpace(errCode) || errCode == "0";
            }
        }
    }
}