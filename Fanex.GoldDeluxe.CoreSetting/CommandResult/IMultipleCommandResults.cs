namespace Fanex.GoldDeluxe.CoreSetting.CommandResult
{
    using System.Collections.Generic;

    public interface IMultipleCommandResults
    {
        List<ICommandResults> CommandResultsList { get; set; }

        bool IsSuccessful { get; }
    }
}