namespace Fanex.GoldDeluxe.CoreSetting.Repositories
{
    using Fanex.GoldDeluxe.CoreSetting.Criterias;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;
    using Fanex.NAP.Framework.Data;

    public interface ISettingRepository
    {
        SettingDTO GetSupperSetting(GetSuperSettingCriteria criteria);

        SettingDTO GetMasterSetting(GetMasterSettingCriteria criteria);

        SettingDTO GetAgentSetting(GetAgentSettingCriteria criteria);

        SettingDTO GetMemberSetting(GetMemberSettingCriteria criteria);

        SettingDTO GetMemberSettingEditBySuper(GetMemberSettingEditBySuperCriteria criteria);

        SettingDTO GetMemberSettingEditByMaster(GetMemberSettingEditByMasterCriteria criteria);

        ICommandResult SaveChange(ICriteria criteria);
    }
}
