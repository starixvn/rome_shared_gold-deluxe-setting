namespace Fanex.GoldDeluxe.CoreSetting.CommandResult
{
    using System.Collections.Generic;
    using System.Linq;

    public class CommandResults : ICommandResults
    {
        public CommandResults()
        {
            Results = new List<ICommandResult>();
        }

        public List<ICommandResult> Results { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public virtual bool IsSuccessful
        {
            get
            {
                return Results.FirstOrDefault(x => !x.IsSuccessful) == null;
            }
        }
    }
}