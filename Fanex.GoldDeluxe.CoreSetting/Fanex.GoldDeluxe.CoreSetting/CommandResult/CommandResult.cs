namespace Fanex.GoldDeluxe.CoreSetting.CommandResult
{
    using Fanex.NAP.Framework.Data;

    public class CommandResult : CommandResultBase
    {
        public override bool IsSuccessful
        {
            get { return string.IsNullOrWhiteSpace(this.Code.ToString()); }
        }
    }
}
