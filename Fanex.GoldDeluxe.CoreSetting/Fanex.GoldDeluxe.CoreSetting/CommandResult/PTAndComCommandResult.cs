namespace Fanex.GoldDeluxe.CoreSetting.CommandResult
{
    using Fanex.Common;

    public class PTAndComCommandResult : CommandResult
    {
        public PTAndComCommandResult()
        {
        }

        public PTAndComCommandResult(CommandResult result)
        {
            Code = result.Code;
            Message = result.Message;
        }

        public override bool IsSuccessful
        {
            get
            {
                return Converter.ToInt(Code) <= 0;
            }
        }
    }
}