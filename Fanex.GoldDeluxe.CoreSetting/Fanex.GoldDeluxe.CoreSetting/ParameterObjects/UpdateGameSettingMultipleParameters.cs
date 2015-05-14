namespace Fanex.GoldDeluxe.CoreSetting.ParameterObjects
{
    using System.Collections.Generic;

    public class UpdateGameSettingMultipleParameters : UpdateGameSettingParameters
    {
        public List<int> CustIds { get; set; }

        public List<string> Usernames { get; set; }
    }
}