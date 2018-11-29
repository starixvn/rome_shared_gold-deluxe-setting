namespace Fanex.GoldDeluxe.CoreSetting.CommandResult
{
    using System.Collections.Generic;
    using System.Linq;

    public class MultipleCommandResults : IMultipleCommandResults
    {
        public MultipleCommandResults()
        {
            CommandResultsList = new List<ICommandResults>();
        }

        public List<ICommandResults> CommandResultsList { get; set; }

        public bool IsSuccessful
        {
            get
            {
                return CommandResultsList.FirstOrDefault(x => !x.IsSuccessful) == null;
            }
        }
    }
}