namespace Fanex.GoldDeluxe.CoreSetting.Repositories
{
    using Fanex.GoldDeluxe.CoreSetting.DTOs;
    using Fanex.NAP.Framework.Data;

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