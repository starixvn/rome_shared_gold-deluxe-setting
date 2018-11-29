namespace Fanex.GoldDeluxe.CoreSetting.CommandResult
{
    using System;

    public class CommandResultBase : ICommandResult
    {
        public CommandResultBase()
            : this(string.Empty, string.Empty)
        {
        }

        public CommandResultBase(dynamic code, dynamic message)
        {
            Code = code;
            Message = message;
        }

        public dynamic Code { get; set; }

        public dynamic Message { get; set; }

        public virtual bool IsSuccessful
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
