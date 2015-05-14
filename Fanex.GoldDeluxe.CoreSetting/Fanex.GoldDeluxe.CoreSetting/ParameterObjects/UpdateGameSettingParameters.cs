namespace Fanex.GoldDeluxe.CoreSetting.ParameterObjects
{
    using System.Collections.Generic;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;

    public class UpdateGameSettingParameters : CommandParameter
    {
        public int CustId { get; set; }

        public List<GameTypeDTO> GameSetting { get; set; }

        public string ToXmlCheckedGameSetting()
        {
            var xml = "<ROOT>";

            foreach (var item in GameSetting)
            {
                xml += string.Format("<Row ID=\"{0}\" Stake=\"{1}\"/>", item.Id, item.CheckedStakeLevelId);
            }

            xml += "</ROOT>";

            return xml;
        }
    }
}
