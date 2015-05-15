namespace Fanex.GoldDeluxe.CoreSetting.ParameterObjects
{
    using System.Collections.Generic;

    public class UpdatePTAndComMultipleParameters : UpdatePTAndComParameters
    {
        public List<int> CustIds { get; set; }

        public List<string> Usernames { get; set; }
    }
}