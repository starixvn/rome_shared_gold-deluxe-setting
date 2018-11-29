namespace Fanex.GoldDeluxe.CoreSetting.Repositories
{
    using CommandResult;
    using Data.Repository;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;

    public interface ISettingRepository
    {
        SettingDTO GetSupperSetting(ICriteria criteria);

        SettingDTO GetMasterSetting(ICriteria criteria);

        SettingDTO GetAgentSetting(ICriteria criteria);

        SettingDTO GetMemberSetting(ICriteria criteria);

        SettingDTO GetMemberSettingEditBySuper(ICriteria criteria);

        SettingDTO GetMemberSettingEditByMaster(ICriteria criteria);

        ICommandResult SaveChange(ICriteria criteria);
    }
}