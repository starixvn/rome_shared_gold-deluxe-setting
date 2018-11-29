namespace Fanex.GoldDeluxe.CoreSetting.CommandResult
{
    public interface ICommandResult
    {
        dynamic Code
        {
            get;
        }

        dynamic Message
        {
            get;
        }

        bool IsSuccessful
        {
            get;
        }
    }
}
