namespace Fanex.GoldDeluxe.CoreSetting.Services
{
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;

    public interface ISettingService
    {
        SettingDTO GetSetting(GetSettingParameters parameter);

        ICommandResults UpdatePTAndCom(UpdatePTAndComParameters parameter);

        ICommandResults UpdateStatus(UpdateDisableStatusParameters parameter);

        ICommandResults UpdateGameSetting(UpdateGameSettingParameters parameter);

        IMultipleCommandResults UpdateGameSettingMultiple(UpdateGameSettingMultipleParameters parameter);

        IMultipleCommandResults UpdatePTAndComMultiple(UpdatePTAndComMultipleParameters parameter);
    }
}