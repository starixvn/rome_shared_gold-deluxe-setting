namespace Fanex.GoldDeluxe.CoreSetting.Services
{
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;
    using Fanex.NAP.Framework.Data;

    public interface ISettingService
    {
        SettingDTO GetSuperSetting(int superId);

        SettingDTO GetMasterSetting(int masterId, int superId);

        SettingDTO GetAgentSetting(int agentId, int masterId);

        SettingDTO GetMemberSetting(int memberId, int agentId);

        SettingDTO GetMemberSettingEditBySuper(int memberId);

        SettingDTO GetMemberSettingEditByMaster(int memberId);

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
