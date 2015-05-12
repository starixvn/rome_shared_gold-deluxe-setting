namespace Fanex.GoldDeluxe.CoreSetting.Services
{
    using Fanex.GoldDeluxe.CoreSetting.DTOs;
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using Fanex.NAP.Framework.Data;

    public interface ISettingService
    {
        SettingDTO GetSuperSetting(int superId);

        SettingDTO GetMasterSetting(int masterId, int superId);

        SettingDTO GetAgentSetting(int agentId, int masterId);

        SettingDTO GetMemberSetting(int memberId, int agentId);

        SettingDTO GetMemberSettingEditBySuper(int memberId);

        SettingDTO GetMemberSettingEditByMaster(int memberId);

        ICommandResults UpdateSuperPTAndComSetting();

        ICommandResults UpdateMasterPTAndComSetting();

        ICommandResults UpdateAgentPTAndComSetting();

        ICommandResults UpdateMemberPTAndComSetting();

        ICommandResults UpdateMemberPTAndComSettingBySuper();

        ICommandResults UpdateMemberPTAndComSettingByMaster();

        ICommandResult UpdateDisableStatus();

        ICommandResult UpdateGameSetting();
    }
}
