namespace Fanex.GoldDeluxe.CoreSetting.Services
{
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;
    using Fanex.NAP.Framework.Data;

    public interface ISettingService
    {
        SettingDTO GetCustomerSetting(GetCustomerSettingParameters parameter);

        ICommandResults UpdateSuperPTAndComSetting(UpdateSuperPTAndComParameters parameter);

        ICommandResults UpdateMasterPTAndComSetting(UpdateMasterPTAndComParameters parameter);

        ICommandResults UpdateAgentPTAndComSetting(UpdateAgentPTAndComParameters parameter);

        ICommandResults UpdateMemberPTAndComSetting(UpdateMemberPTAndComParameters parameter);

        ICommandResults UpdateMemberPTAndComSettingBySuper(UpdateMemberPTAndComBySuperParameters parameter);

        ICommandResults UpdateMemberPTAndComSettingByMaster(UpdateMemberPTAndComByMasterParameters parameter);

        ICommandResult UpdateDisableStatus(UpdateDisableStatusParameters parameter);

        ICommandResult UpdateGameSetting(UpdateGameSettingParameters parameter);
    }
}
